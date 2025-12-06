using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using ComboBox = System.Windows.Forms.ComboBox;
using Label = System.Windows.Forms.Label;

namespace NeoAI
{
    public partial class Form1 : Form
    {
        public string _message ="";
        public int _lines = 0;
        public int _columns = 0;
        public string _connString = "";
        public string _sqlString = "";
        public string _fieldFilter = "";
        public List<string> _controls = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        /*Eventos del formulario*/
        private void InitializeForm()
        {
            cmbTop.DisplayMember = "Text";
            cmbTop.ValueMember = "Value";
            cmbTop.DataSource = new[] {
                new { Text = "100 registros", Value = 100 },
                new { Text = "1000 registros", Value = 1000 },
                new { Text = "10000 registros", Value = 10000 },
                new { Text = "Sin límite", Value =  0},
            };
            cmbTop.SelectedIndex = 0;

            cmbRestriccion.DisplayMember = "Text";
            cmbRestriccion.ValueMember = "Value";
            cmbRestriccion.DataSource = new[] {
                new { Text = "Ambos sexos, respuestas sin sesgo", Value = 0 },
                new { Text = "Solo hombres, respuestas positivas", Value = 1 },
                new { Text = "Solo hombres, respuestas negativas", Value = 2 },
                new { Text = "Solo mujeres, respuestas positivas", Value = 3 },
                new { Text = "Solo mujeres, respuestas negativas", Value = 4 }
            };
            cmbRestriccion.SelectedIndex = 0;

            LoadProjectsAsync(0);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int _pos = 1;
            int _neg = 0;
            /*Calulo el modulo para que en las id question pares invierta los valores para el entrenamiento*/
            int _mod = (Convert.ToInt32(cmbPreguntas.SelectedValue) % 2);
            if (_mod == 0)
            {
                _pos = 0;
                _neg = 1;
            }
            switch (Convert.ToInt32(cmbProyecto.SelectedValue))
            {
                case 1:
                    int? _forzarRespuesta = null;
                    int? _forzarSexo = null;
                    switch (Convert.ToInt16(cmbRestriccion.SelectedValue)) {
                        case 1:
                            _forzarRespuesta = 1;
                            _forzarSexo = 0;
                            break;
                        case 2:
                            _forzarRespuesta = 0;
                            _forzarSexo = 0;
                            break;
                        case 3:
                            _forzarRespuesta = 1;
                            _forzarSexo = 1;
                            break;
                        case 4:
                            _forzarRespuesta = 0;
                            _forzarSexo = 1;
                            break;
                    }
                    LoadFromCredipaz(Convert.ToInt32(cmbTop.SelectedValue), _forzarSexo, _forzarRespuesta);
                    break;
                case 2:
                    /*Masculinos*/
                    AddValuesToControlledData4(1, 0.25, 1, 1, 1);
                    AddValuesToControlledData4(1, 0.35, 1, 1, 1);
                    AddValuesToControlledData4(1, 0.45, 1, 1, 1);
                    AddValuesToControlledData4(1, 0.55, 1, 1, 1);
                    AddValuesToControlledData4(1, 0.65, 1, 1, 1);

                    AddValuesToControlledData4(1, 0.25, 0, 1, 0);
                    AddValuesToControlledData4(1, 0.35, 0, 1, 0);
                    AddValuesToControlledData4(1, 0.45, 0, 1, 0);
                    AddValuesToControlledData4(1, 0.55, 0, 1, 0);
                    AddValuesToControlledData4(1, 0.65, 0, 1, 0);


                    break;
                case 3:
                    /*Masculinos*/
                    AddValuesToControlledData3(0, 0.2, 0.01, _pos);
                    AddValuesToControlledData3(0, 0.3, 0.01, _pos);
                    AddValuesToControlledData3(0, 0.4, 0.01, _pos);
                    AddValuesToControlledData3(0, 0.5, 0.01, _pos);
                    AddValuesToControlledData3(0, 0.6, 0.01, _pos);
                    AddValuesToControlledData3(0, 0.7, 0.01, _neg);
                    AddValuesToControlledData3(0, 0.8, 0.01, _neg);
                    AddValuesToControlledData3(0, 0.9, 0.01, _neg);

                    /*Femeninos*/
                    AddValuesToControlledData3(1, 0.2, 0.01, _neg);
                    AddValuesToControlledData3(1, 0.3, 0.01, _neg);
                    AddValuesToControlledData3(1, 0.4, 0.01, _neg);
                    AddValuesToControlledData3(1, 0.5, 0.01, _neg);
                    AddValuesToControlledData3(1, 0.6, 0.01, _neg);
                    AddValuesToControlledData3(1, 0.7, 0.01, _pos);
                    AddValuesToControlledData3(1, 0.8, 0.01, _pos);
                    AddValuesToControlledData3(1, 0.9, 0.01, _pos);

                    break;
            }
            _message = "";

            if (_message != "")
            {
                MessageBox.Show(_message, "Problema", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("El proceso ha finalizado correctamente", "Resultado", MessageBoxButtons.OK);
            }
        }
        private void btnEntrenar_Click(object sender, EventArgs e)
        {
            TrainningAsync();
        }
        private void btnResolver_Click(object sender, EventArgs e)
        {
            /* Datos para testear el problema */
            int i = 0;
            double[,] problemData = new double[_columns, _lines];
            foreach (string li in this._controls) {
                if (i < _lines){problemData[0, i] = Convert.ToDouble(getDynValue(li));}
                i += 1; 
            }
            ResolveAsync(problemData);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult _ret = MessageBox.Show("¿Confirma el borrado de los datos del proyecto?", "Resultado", MessageBoxButtons.YesNo);
            if (_ret == DialogResult.Yes) { ResetProjectAsync(); }
        }
        private void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProjectsAsync(Convert.ToInt32(cmbProyecto.SelectedValue));
            QuestionsAsync(0);
        }
        private void cmbPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuestionsAsync(Convert.ToInt32(cmbPreguntas.SelectedValue));
        }

        /*Data Loaders*/
        private void LoadFromCredipaz(int? _wTop, double? _wSexo, int? _forceResponseValue)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                string _top = "";
                string _where = "";

                if (_wTop.HasValue && _wTop!=0) { _top = (" TOP " + _wTop.ToString()); }
                if (_wSexo.HasValue) { _where += "sexo=" + _wSexo.ToString(); }
                if (_where != "") { _where += " AND "; }
                if (_forceResponseValue.HasValue) { _where += _fieldFilter + "=" + _forceResponseValue.ToString(); }
                if (_where != "") { _where = (" WHERE " + _where); }

                string _commandString = _sqlString.Replace("[TOP]", _top);
                _commandString = _commandString.Replace("[WHERE]", _where);
                _commandString = _commandString.Replace("[ORDER]", "");

                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = _commandString;

                DataTable dtResponse = new DataTable();
                dtResponse.Load(cmd.ExecuteReader());

                foreach (DataRow drow in dtResponse.Rows)
                {
                    double _sexo = Convert.ToDouble(drow["sexo"]);
                    double _edad = Convert.ToDouble(drow["edad"]);
                    double _ocupacion = Convert.ToDouble(drow["ocupacion"]);
                    double _ingresos = Convert.ToDouble(drow["ingresos"]);
                    double _calificacioncl = Convert.ToDouble(drow["calificacion"]);
                    int _respuesta = Convert.ToInt32(drow[_fieldFilter]);
                    AddValuesToControlledData5(_sexo, _edad, _ocupacion, _ingresos, _calificacioncl, _respuesta);
                }
            }
        }

        /*Auxiliares*/
        private void CreateControls(string _MatrixDescription)
        {
            try
            {
                int i = 0;
                List<string> _pList = new List<string>();
                this.panelProblema.Controls.Clear();
                lblMatrixDescription.Text = "";
                JObject _lastMatrixDescription = JObject.Parse(_MatrixDescription);
                foreach (var _data in _lastMatrixDescription["data"])
                {
                    string _title = _data["title"].ToString();
                    this._controls.Add(_title);

                    if (lblMatrixDescription.Text != "") { lblMatrixDescription.Text += ", "; }
                    lblMatrixDescription.Text += _title;

                    Label _label = new Label();
                    _label.Name = "lbl" + _title;
                    _label.Text = _title;
                    _label.AutoSize = true;
                    this.Controls.Add(_label);
                    _label.Parent = this.panelProblema;
                    _label.Left = 0;
                    _label.Top = (41 * i);

                    ComboBox _comboBox = new ComboBox();
                    _comboBox.Name = _title;
                    this.Controls.Add(_comboBox);
                    _comboBox.Parent = this.panelProblema;
                    _comboBox.Left = 0;
                    _comboBox.Top = ((41 * i) + 15);
                    _comboBox.Width = panelProblema.Width;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Text");
                    dt.Columns.Add("Value");
                    foreach (var _values in _data["values"])
                    {
                        DataRow dr = dt.NewRow();
                        dr["Text"] = _values["display"].ToString();
                        dr["Value"] = _values["value"].ToString();
                        dt.Rows.InsertAt(dr, dt.Rows.Count);
                    }
                    _comboBox.DisplayMember = "Text";
                    _comboBox.ValueMember = "Value";
                    _comboBox.DataSource = dt;
                    _comboBox.SelectedIndex = 0;
                    i += 1;
                }

            }
            catch (Exception ex) { }
        }
        private Double? getDynValue(string _name) {
            foreach (Control c in panelProblema.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox _combo = (ComboBox)c;
                    if (_combo.Name.Equals(_name)) {
                        return Convert.ToDouble(_combo.SelectedValue); 
                    }
                }
            }
            return null;
        }
        private void AddValuesToControlledData5(double _sexo, double _edad, double _ocupacion, double _ingresos, double _calificacion, int _respuesta)
        {
            double[,] arrItemTrainning = new double[_columns, _lines];
            double[,] arrItemExpectedResult = new double[1, 1];
            arrItemTrainning[0, 0] = _sexo; 
            arrItemTrainning[0, 1] = _edad; 
            arrItemTrainning[0, 2] = _ocupacion; 
            arrItemTrainning[0, 3] = _ingresos; 
            arrItemTrainning[0, 4] = _calificacion;
            double _respuestaX = 0.9;
            if (_respuesta == 0) { _respuestaX = 0.1; }

            arrItemExpectedResult[0, 0] = _respuestaX;
            /*Enviar a la API*/
            AddItemforTranningAsync(arrItemTrainning, arrItemExpectedResult);
        }
        private void AddValuesToControlledData4(double _sexo, double _edad, double _ocupacion, double _ingresos, int _respuesta)
        {
            double[,] arrItemTrainning = new double[_columns, _lines];
            double[,] arrItemExpectedResult = new double[1, 1];
            arrItemTrainning[0, 0] = _sexo; 
            arrItemTrainning[0, 1] = _edad; 
            arrItemTrainning[0, 2] = _ocupacion; 
            arrItemTrainning[0, 3] = _ingresos; 
            arrItemExpectedResult[0, 0] = _respuesta;
            /*Enviar a la API*/
            AddItemforTranningAsync(arrItemTrainning, arrItemExpectedResult);
        }
        private void AddValuesToControlledData3(double _sexo, double _edad, double _ocupacion, int _respuesta)
        {
            double[,] arrItemTrainning = new double[_columns, _lines];
            double[,] arrItemExpectedResult = new double[1, 1];
            arrItemTrainning[0, 0] = _sexo; 
            arrItemTrainning[0, 1] = _edad; 
            arrItemTrainning[0, 2] = _ocupacion; 
            arrItemExpectedResult[0, 0] = _respuesta;
            /*Enviar a la API*/
            AddItemforTranningAsync(arrItemTrainning, arrItemExpectedResult);
        }
        private void DrawSynapsesMatrix(List<Dictionary<string, object>> _records) {
            textBox2.Clear();
            foreach (var item in _records)
            {
                textBox2.AppendText(item["Double"].ToString());
                textBox2.AppendText(Environment.NewLine);
            }
        }

        /*Comunicacion con la API*/
        private async Task ResolveAsync(double[,] arrItemProblem)
        {
            byte[] _bItem = Tools.ToBytes(arrItemProblem);
            RestRequest request = new RestRequest("neoneural.v1/Resolve", Method.Post);
            request.AddParameter("id_project", Convert.ToInt32(cmbProyecto.SelectedValue));
            request.AddParameter("id_question", Convert.ToInt32(cmbPreguntas.SelectedValue));
            request.AddParameter("base64RawData", Convert.ToBase64String(_bItem));
            outBaseAnyResponse response = await ExecWS(request);

            /*Tratamiento de la respuesta*/
            if (response.Status == "OK")
            {
                lblResponse.Text = "";
                foreach (var item in response.Records)
                {
                    decimal _d = Convert.ToDecimal(item["Double"]);
                    lblResponse.ForeColor = Color.DarkGreen;
                    if (_d >= (decimal)0.5) { lblResponse.ForeColor = Color.Blue; }
                    if (_d >= (decimal)0.75) { lblResponse.ForeColor = Color.Red; }
                    lblResponse.Text = _d.ToString();
                }
            }
            else {
                MessageBox.Show(response.Error, "Error", MessageBoxButtons.OK);
                lblResponse.ForeColor = Color.Red;
                lblResponse.Text = "Sin respuesta posible";
            }
        }
        private async Task AddItemforTranningAsync(double[,] arrItemTrainning, double[,] arrItemExpectedResult)
        {
            byte[] _bItem = Tools.ToBytes(arrItemTrainning);
            byte[] _bResult = Tools.ToBytes(arrItemExpectedResult);

            RestRequest request = new RestRequest("neoneural.v1/AddItemforTranning", Method.Post);
            request.AddParameter("id_project", Convert.ToInt32(cmbProyecto.SelectedValue));
            request.AddParameter("base64RawData", Convert.ToBase64String(_bItem));
            outBaseAnyResponse response = await ExecWS(request);

            /*Tratamiento de la respuesta*/
            if (response.Numeric != 0)
            {
                request = new RestRequest("neoneural.v1/AddItemResponseforTranning", Method.Post);
                request.AddParameter("id_project", Convert.ToInt32(cmbProyecto.SelectedValue));
                request.AddParameter("id_item", response.Numeric);
                request.AddParameter("id_question", Convert.ToInt32(cmbPreguntas.SelectedValue));
                request.AddParameter("base64RawData", Convert.ToBase64String(_bResult));
                response = await ExecWS(request);
                if (response.Numeric == 0)
                {
                    _message = "No se han insertado todos los valores de respuesta";
                }
            }
            else
            {
                _message = "No se han insertado todos los valores a entrenar";
            }
        }
        private async Task TrainningAsync()
        {
            RestRequest request = new RestRequest("neoneural.v1/Trainning", Method.Post);
            request.AddParameter("id_project", Convert.ToInt32(cmbProyecto.SelectedValue));
            request.AddParameter("id_question", Convert.ToInt32(cmbPreguntas.SelectedValue));
            outBaseAnyResponse response = await ExecWS(request);

            /*Tratamiento de la respuesta*/
            if (response.Status == "OK")
            {
                DrawSynapsesMatrix(response.Records);
            }
            else {
                MessageBox.Show(response.Error, "Error", MessageBoxButtons.OK);
            }
        }
        private async Task SynapsesMatrixAsync()
        {
            RestRequest request = new RestRequest("neoneural.v1/SynapsesMatrix", Method.Post);
            request.AddParameter("id_project", Convert.ToInt32(cmbProyecto.SelectedValue));
            request.AddParameter("id_question", Convert.ToInt32(cmbPreguntas.SelectedValue));
            outBaseAnyResponse response = await ExecWS(request);

            /*Tratamiento de la respuesta*/
            DrawSynapsesMatrix(response.Records);
        }
        private async Task LoadProjectsAsync(int _id_project)
        {
            RestRequest request = new RestRequest("neoneural.v1/Projects", Method.Post);
            request.AddParameter("id_project", _id_project);
            outBaseAnyResponse response = await ExecWS(request);

            /*Tratamiento de la respuesta*/
            cmbProyecto.DisplayMember = "Text";
            cmbProyecto.ValueMember = "Value";
            if (response.Records != null)
            {
                if (_id_project == 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Value", typeof(int));
                    dt.Columns.Add("Text");
                    foreach (var item in response.Records)
                    {
                        dt.Rows.Add(Convert.ToInt32(item["id"]), item["description"].ToString());
                    }
                    cmbProyecto.DataSource = dt;
                    cmbProyecto.SelectedIndex = 0;
                }
                else {
                    /*Setea datos de la matriz del proyecto activo*/
                    _connString = response.Records[0]["connString"].ToString();
                    _sqlString = response.Records[0]["sqlString"].ToString();
                    _lines = Convert.ToInt32(response.Records[0]["LinesMatrix"]);
                    _columns = Convert.ToInt32(response.Records[0]["ColumnsMatrix"]);
                    lblProyecto.Text = "Matríz definida [" + response.Records[0]["ColumnsMatrix"].ToString() + "," + response.Records[0]["LinesMatrix"].ToString() + "] ";
                    lblProyecto.Text += " con " + response.Records[0]["EpochsMatrix"].ToString() + " ciclos por dato para entrenamiento";

                    CreateControls(response.Records[0]["MatrixDescription"].ToString());
                }
            }
        }

        private async Task ResetProjectAsync()
        {
            RestRequest request = new RestRequest("neoneural.v1/ResetProject", Method.Post);
            request.AddParameter("id_project", Convert.ToInt32(cmbProyecto.SelectedValue));
            outBaseAnyResponse response = await ExecWS(request);

            /*Tratamiento de la respuesta*/
            if (response.Status == "OK")
            {
                cmbProyecto_SelectedIndexChanged(null, null);
                lblResponse.ForeColor = Color.Black;
                lblResponse.Text = "...";
                MessageBox.Show("El proceso ha finalizado correctamente", "Resultado", MessageBoxButtons.OK);
            }
            else {
                MessageBox.Show(response.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private async Task QuestionsAsync(int _id_question)
        {
            RestRequest request = new RestRequest("neoneural.v1/Questions", Method.Post);
            request.AddParameter("id_project", Convert.ToInt32(cmbProyecto.SelectedValue));
            request.AddParameter("id_question", _id_question);
            outBaseAnyResponse response = await ExecWS(request);

            /*Tratamiento de la respuesta*/
            if (response.Records != null)
            {
                if (_id_question == 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Value", typeof(int));
                    dt.Columns.Add("Text");
                    foreach (var item in response.Records)
                    {
                        dt.Rows.Add(Convert.ToInt32(item["id"]), item["description"].ToString());
                    }
                    cmbPreguntas.DisplayMember = "Text";
                    cmbPreguntas.ValueMember = "Value";
                    cmbPreguntas.DataSource = dt;
                    cmbPreguntas.SelectedIndex = 0;
                }
                else
                {
                    JObject _lastMatrixDescription = JObject.Parse(response.Records[0]["MatrixDescription"].ToString());
                    foreach (var _data in _lastMatrixDescription["data"]) { _fieldFilter = _data["response"].ToString(); }
                    SynapsesMatrixAsync();
                }
            }
        }
        private async Task<outBaseAnyResponse> ExecWS(RestRequest request)
        {
            string _apiServer = "https://localhost:44315/";

            RestClient client = new RestClient(_apiServer);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("id_application", "10");
            request.AddParameter("id_user", "2");
            request.AddParameter("token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im5lb2RhdGEiLCJub25jZSI6IjEwIiwibmFtZWlkIjoiMiIsImlzcyI6Im5lb2RhdGFFY29zeXN0ZW0uZ3J1cG9uZW9kYXRhLmNvbSIsImF1ZCI6Im5lb2RhdGFFY29zeXN0ZW0uZ3J1cG9uZW9kYXRhLmNvbSJ9.L1Gt42yH-Ux_QpAqb9FLrZwNMwW6Jwe4tEZsJADbRHk");

            RestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<outBaseAnyResponse>(@response.Content);
        }
    }
}
