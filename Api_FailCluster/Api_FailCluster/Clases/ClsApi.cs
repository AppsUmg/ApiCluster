
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Api_FailCluster.Clases
{
    public class ClsApi
    {
        public static string connectionstring = "Data Source= localhost ; Initial Catalog= db_banco ; User = sa ; Password= admin1234 ; app=Api_FailCluster";

        public static string setTrasnferencia(decimal Monto, string CuentaOrigen, string CuentaDestino)
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_SET_TRANSFERENCIA]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@Monto", Monto);
                da.SelectCommand.Parameters.AddWithValue("@CuentaOrigen", CuentaOrigen);
                da.SelectCommand.Parameters.AddWithValue("@CuentaDestino", CuentaDestino);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                Result = CreateJson(dt);
                conn.Dispose();
                conn.Close();
            }
            return Result;
        }


        public static string getSaldo(string Id_Cuenta)
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_GET_SALDO]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@Id_Cuenta", Id_Cuenta);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                Result = CreateJson(dt);
                conn.Dispose();
                conn.Close();
            }
            return Result;
        }




        public static string CreateJson(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

















    }


}
