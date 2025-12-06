using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoAI
{
    public static class Tools
    {
        public static T[,] ResizeArray<T>(this T[,] matrix, int newRows, int newColumns)
        {
            var result = new T[newRows, newColumns];
            int oldRows = matrix.GetLength(0);
            int oldColumns = matrix.GetLength(1);
            for (int i = 0; i < Math.Min(oldRows, newRows); i++)
            {
                Array.Copy(matrix, i * oldColumns, result, i * newColumns, Math.Min(oldColumns, newColumns));
            }
            return result;
        }
        public static byte[] ToBytes<T>(this T[,] array) where T : struct
        {
            var buffer = new byte[array.GetLength(0) * array.GetLength(1) * System.Runtime.InteropServices.Marshal.SizeOf(typeof(T))];
            Buffer.BlockCopy(array, 0, buffer, 0, buffer.Length);
            return buffer;
        }
        public static void FromBytes<T>(this T[,] array, byte[] buffer) where T : struct
        {
            var len = Math.Min(array.GetLength(0) * array.GetLength(1) * System.Runtime.InteropServices.Marshal.SizeOf(typeof(T)), buffer.Length);
            Buffer.BlockCopy(buffer, 0, array, 0, len);
        }
    }
}
