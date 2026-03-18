using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace NeoAI
{
	public partial class Form1 : Form
	{
		public int _id_project_active = 1;
		public string _MatrixDescription = "";
		public int _id_question_active = 0;
		public string _fieldFilter = "";
		int? _forzarTop = 0;
		public string _message = "";
		public int _lines = 0;
		public int _columns = 0;
		public string _connString = "";
		public string _sqlString = "";
		public List<string> _controls = new List<string>();
		DataTable dtQuestions = new DataTable();
		public Form1()
		{
			InitializeComponent();
		}

		/*Eventos del formulario*/
		private void Form1_Load(object sender, EventArgs e)
		{
			InitializeForm();
			LoadProjectsAsync();
		}
		private void btnAgregar_Click(object sender, EventArgs e) {
			Agregar();
		}
		private void btnEntrenar_Click(object sender, EventArgs e)
		{
			Entrenar();
		}
		private void btnResolver_Click(object sender, EventArgs e)
		{
			Resolver();
		}
		private void btnReset_Click(object sender, EventArgs e)
		{
			DialogResult _ret = MessageBox.Show("¿Confirma el borrado de los datos del proyecto?", "Resultado", MessageBoxButtons.YesNo);
			if (_ret == DialogResult.Yes) { ResetProjectAsync(); }
		}
		private void btnBuscar_Click(object sender, EventArgs e)
		{
			GetPreviousData();
		}
		private void cmbTop_SelectedIndexChanged(object sender, EventArgs e)
		{
			_forzarTop = Convert.ToInt16(cmbTop.SelectedValue);
		}

		/*Comunicacion con la API*/
		private void InitializeForm()
		{
			cmbTop.DisplayMember = "Text";
			cmbTop.ValueMember = "Value";
			cmbTop.DataSource = new[] {
				new { Text = "Sin límite", Value =  0},
				new { Text = "5 registros", Value = 5 },
			};
			cmbTop.SelectedIndex = 0;
		}
		private async Task Agregar()
		{
			bool _conMora = true;
			bool _conJudicial = true;
			Toggle(false);
			for (int x = 1; x < 4; x++)
			{
				_conMora = (x == 1);
				_conJudicial = (x == 3);
				foreach (DataRow dRow in dtQuestions.Rows)
				{
					_id_question_active = Convert.ToInt32(dRow["Value"].ToString());
					_fieldFilter = dRow["MatrixDescription"].ToString();
					JObject _lastMatrixDescription = JObject.Parse(_MatrixDescription);

					using (SqlConnection connection = new SqlConnection(_connString))
					{
						connection.Open();
						SqlCommand cmd = new SqlCommand();
						cmd.Connection = connection;
						cmd.CommandType = CommandType.Text;

						string _top = "";
						for (int i = 1; i < 13; i++)
						{
							string _where = ("year(dFechaAlta)=2016 AND month(dFechaAlta)=" + i.ToString());
							if (_conMora || _conJudicial) { _where += " AND mora=1"; } else { _where += " AND mora=0"; }
							if (_conJudicial) { _where += " AND judicial=1"; } else { _where += " AND judicial=0"; }
							if (_forzarTop.HasValue && _forzarTop != 0) { _top = (" TOP " + _forzarTop.ToString()); }
							if (_where != "") { _where = (" WHERE " + _where); }

							string _commandString = _sqlString.Replace("[TOP]", _top);
							_commandString = _commandString.Replace("[WHERE]", _where);
							_commandString = _commandString.Replace("[ORDER]", "");
							cmd.CommandText = _commandString;

							DataTable dtResponse = new DataTable();
							dtResponse.Load(cmd.ExecuteReader());
							foreach (DataRow drow in dtResponse.Rows)
							{
								double[,] arrItemTrainning = new double[_columns, _lines];
								double[,] arrItemExpectedResult = new double[1, 1];
								int ix = 0;
								foreach (var _data in _lastMatrixDescription["data"])
								{
									arrItemTrainning[0, ix] = Convert.ToDouble(drow[_data["field"].ToString()]);
									ix++;
								}
								int _respuesta = Convert.ToInt32(drow[_fieldFilter]);
								double _respuestaX = 0.9;
								if (_respuesta == 0) { _respuestaX = 0.1; }
								arrItemExpectedResult[0, 0] = _respuestaX;

								/*Enviar a la API*/
								byte[] _bItem = Tools.ToBytes(arrItemTrainning);
								byte[] _bResult = Tools.ToBytes(arrItemExpectedResult);
								RestRequest request1 = new RestRequest("neoneural.v1/AddItemforTranning", Method.Post);
								request1.AddParameter("id_project", _id_project_active);
								request1.AddParameter("base64RawData", Convert.ToBase64String(_bItem));
								outBaseAnyResponse response = await ExecWS(request1);
								RestRequest request2 = new RestRequest("neoneural.v1/AddItemResponseforTranning", Method.Post);
								request2.AddParameter("id_project", _id_project_active);
								request2.AddParameter("id_item", response.Numeric);
								request2.AddParameter("id_question", _id_question_active);
								request2.AddParameter("base64RawData", Convert.ToBase64String(_bResult));
								response = await ExecWS(request2);
							}
						}
					}
				}
			}
			MessageBox.Show("El proceso ha finalizado correctamente", "Resultado", MessageBoxButtons.OK);
			Toggle(true);
		}
		private async Task Entrenar()
		{
			Toggle(false);
			foreach (DataRow dRow in dtQuestions.Rows)
			{
				_id_question_active = Convert.ToInt32(dRow["Value"].ToString());
				RestRequest request = new RestRequest("neoneural.v1/Trainning", Method.Post);
				request.AddParameter("id_project", _id_project_active);
				request.AddParameter("id_question", _id_question_active);
				outBaseAnyResponse response = await ExecWS(request);
			}
			MessageBox.Show("El proceso ha finalizado correctamente", "Resultado", MessageBoxButtons.OK);
			Toggle(true);
		}
		private async Task Resolver()
		{
			Toggle(false);
			JObject _matrix = JObject.Parse(_MatrixDescription);
			int i = 0;
			double[,] arrItemProblem = new double[_columns, _lines];
			foreach (var _data in _matrix["data"])
			{
				Control[] _c = this.Controls.Find(_data["field"].ToString(), true);
				arrItemProblem[0, i] = Convert.ToDouble(_c[0].Text);
				i++;
			}
			byte[] _bItem = Tools.ToBytes(arrItemProblem);
			foreach (DataRow dRow in dtQuestions.Rows)
			{
				_id_question_active = Convert.ToInt32(dRow["Value"].ToString());
				_fieldFilter = dRow["MatrixDescription"].ToString();
				SynapsesMatrixAsync();
				Control[] _lbl = this.Controls.Find(_fieldFilter, true);
				RestRequest request = new RestRequest("neoneural.v1/Resolve", Method.Post);
				request.AddParameter("id_project", _id_project_active);
				request.AddParameter("id_question", _id_question_active);
				request.AddParameter("base64RawData", Convert.ToBase64String(_bItem));
				outBaseAnyResponse response = await ExecWS(request);

				/*Tratamiento de la respuesta*/
				if (response.Status == "OK")
				{
					_lbl[0].Text = "";
					foreach (var item in response.Records)
					{
						decimal _d = Convert.ToDecimal(item["Double"]);
						_lbl[0].ForeColor = Color.DarkGreen;
						if (_d >= (decimal)0.5) { _lbl[0].ForeColor = Color.Blue; }
						if (_d >= (decimal)0.75) { _lbl[0].ForeColor = Color.Red; }
						_lbl[0].Text = _d.ToString();
					}
				}
				else
				{
					MessageBox.Show(response.Error, "Error", MessageBoxButtons.OK);
					_lbl[0].ForeColor = Color.Red;
					_lbl[0].Text = "Sin respuesta posible";
				}
			}
			Toggle(true);
		}
		private async Task AddItemforTranningAsync(double[,] arrItemTrainning, double[,] arrItemExpectedResult)
		{
			byte[] _bItem = Tools.ToBytes(arrItemTrainning);
			byte[] _bResult = Tools.ToBytes(arrItemExpectedResult);
			RestRequest request = new RestRequest("neoneural.v1/AddItemforTranning", Method.Post);
			request.AddParameter("id_project", _id_project_active);
			request.AddParameter("base64RawData", Convert.ToBase64String(_bItem));
			outBaseAnyResponse response = await ExecWS(request);
			request = new RestRequest("neoneural.v1/AddItemResponseforTranning", Method.Post);
			request.AddParameter("id_project", _id_project_active);
			request.AddParameter("id_item", response.Numeric);
			request.AddParameter("id_question", _id_question_active);
			request.AddParameter("base64RawData", Convert.ToBase64String(_bResult));
			response = await ExecWS(request);
		}

		private async Task SynapsesMatrixAsync()
		{
			RestRequest request = new RestRequest("neoneural.v1/SynapsesMatrix", Method.Post);
			request.AddParameter("id_project", _id_project_active);
			request.AddParameter("id_question", _id_question_active);
			outBaseAnyResponse response = await ExecWS(request);
		}
		private async Task LoadProjectsAsync()
		{
			RestRequest request = new RestRequest("neoneural.v1/Projects", Method.Post);
			request.AddParameter("id_project", _id_project_active);
			outBaseAnyResponse response = await ExecWS(request);

			/*Tratamiento de la respuesta*/
			if (response.Records != null)
			{
				/*Setea datos de la matriz del proyecto activo*/
				_connString = response.Records[0]["connString"].ToString();
				_sqlString = response.Records[0]["sqlString"].ToString();
				_lines = Convert.ToInt32(response.Records[0]["LinesMatrix"]);
				_columns = Convert.ToInt32(response.Records[0]["ColumnsMatrix"]);
				lblProyecto.Text = "Matríz definida [" + response.Records[0]["ColumnsMatrix"].ToString() + "," + response.Records[0]["LinesMatrix"].ToString() + "] ";
				lblProyecto.Text += " con " + response.Records[0]["EpochsMatrix"].ToString() + " ciclos por dato para entrenamiento";
				_MatrixDescription = response.Records[0]["MatrixDescription"].ToString();
				CreateControls();
			}
			QuestionsAsync();
		}
		private async Task ResetProjectAsync()
		{
			Toggle(false);
			RestRequest request = new RestRequest("neoneural.v1/ResetProject", Method.Post);
			request.AddParameter("id_project", _id_project_active);
			outBaseAnyResponse response = await ExecWS(request);
			MessageBox.Show("El proceso ha finalizado correctamente", "Resultado", MessageBoxButtons.OK);
			Toggle(true);
		}
		private async Task QuestionsAsync()
		{
			RestRequest request = new RestRequest("neoneural.v1/Questions", Method.Post);
			request.AddParameter("id_project", _id_project_active);
			outBaseAnyResponse response = await ExecWS(request);

			/*Tratamiento de la respuesta*/
			if (response.Records != null)
			{
				dtQuestions = new DataTable();
				dtQuestions.Columns.Add("Value", typeof(int));
				dtQuestions.Columns.Add("Text");
				dtQuestions.Columns.Add("MatrixDescription");

				int _l = 9;
				int _t = 365;
				int i = 0;
				foreach (var item in response.Records)
				{
					string _fieldName = item["MatrixDescription"].ToString();
					dtQuestions.Rows.Add(Convert.ToInt32(item["id"]), item["description"].ToString(), _fieldName);
					
					Label _label = new Label();
					_label.Name = "rsp" + item["id"].ToString();
					_label.Text = item["description"].ToString();
					_label.AutoSize = true;
					this.Controls.Add(_label);
					_label.Parent = this;
					_label.Left = _l;
					_label.Top = _t + (40*i);

					Label _Message = new Label();
					_Message.Name = _fieldName;
					_Message.Text = "...";
					this.Controls.Add(_Message);
					_Message.Parent = this;
					_Message.Left = _l;
					_Message.Top = _t + (40 * i) + 15;
					_Message.Width = btnResolver.Width;
					i++;
				}
			}
		}

		private async Task<outBaseAnyResponse> ExecWS(RestRequest request)
		{
			string _apiServer = "https://localhost:44371/";

			RestClient client = new RestClient(_apiServer);
			request.AlwaysMultipartFormData = true;
			request.AddParameter("id_application", "10");
			request.AddParameter("id_user", "2");
			request.AddParameter("token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im5lb2RhdGEiLCJub25jZSI6IjEwIiwibmFtZWlkIjoiMiIsImlzcyI6Im5lb2RhdGFFY29zeXN0ZW0uZ3J1cG9uZW9kYXRhLmNvbSIsImF1ZCI6Im5lb2RhdGFFY29zeXN0ZW0uZ3J1cG9uZW9kYXRhLmNvbSJ9.L1Gt42yH-Ux_QpAqb9FLrZwNMwW6Jwe4tEZsJADbRHk");

			RestResponse response = await client.ExecuteAsync(request);
			return JsonConvert.DeserializeObject<outBaseAnyResponse>(@response.Content);
		}

		private void GetPreviousData() {
			using (SqlConnection connection = new SqlConnection(_connString))
			{
				string _top = "";
				string _where = ("WHERE idsolicitud="+idsolicitud.Text);

				string _commandString = _sqlString.Replace("[TOP]", _top);
				_commandString = _commandString.Replace("[WHERE]", _where);
				_commandString = _commandString.Replace("[ORDER]", "");

				connection.Open();
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = connection;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = _commandString;

				DataTable dtPrevious = new DataTable();
				dtPrevious.Load(cmd.ExecuteReader());
				
				JObject _lastMatrixDescription = JObject.Parse(_MatrixDescription);
				foreach (DataRow drow in dtPrevious.Rows)
				{
					foreach (var _data in _lastMatrixDescription["data"])
					{
						Control[] _c = this.Controls.Find(_data["field"].ToString(), true);
						_c[0].Text = drow[_data["field"].ToString()].ToString();
					}
					pMora.Text = drow["mora"].ToString();
					pJuridico.Text = drow["judicial"].ToString();
				}
			}
		}
		private void CreateControls()
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
					string _field = _data["field"].ToString();
					string _title = _data["title"].ToString();
					if (_title == "") { _title = _field; }
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
					_label.Top = (35 * i);

					TextBox _TextBox = new TextBox();
					_TextBox.Name = _title;
					_TextBox.Text = "0";
					this.Controls.Add(_TextBox);
					_TextBox.Parent = this.panelProblema;
					_TextBox.Left = 0;
					_TextBox.Top = ((35 * i) + 15);
					_TextBox.Width = panelProblema.Width/3;

					i += 1;
				}

			}
			catch (Exception ex) { }
		}
		private void Toggle(bool _val) {
			foreach (Control c in this.Controls) { c.Enabled = _val; }
		}
	}
}
