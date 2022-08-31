using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace myfinance_web_netcore.Infra
{
    public class DAL
    {
        private SqlConnection conn;

        private string connectionString;

        public static IConfiguration? Configuration;

        private static DAL Instancia;

        public static DAL GetInstancia
        {
            get{
                if (Instancia == null)
                    Instancia = new();

                return Instancia;
            }
        }

        private DAL()
        {
            connectionString = Configuration.GetValue<string>("ConnectionString");
        }

        public void Connectar()
        {
            conn = new();
            conn.ConnectionString = connectionString;
            conn.Open();
        }

        public void Desconnectar()
        {
            conn.Close();
        }        

        //SELECT
        public DataTable RetornarDataTable(string sql)
        {
            var dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dataTable);
            return dataTable;
        }

        //INSERT, UPDATE, DELETE
        public void ExecutarComandoSQL(string sql)
        {
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.ExecuteNonQuery();

        }
    }
}