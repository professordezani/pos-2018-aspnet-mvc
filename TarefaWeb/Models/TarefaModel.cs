using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TarefaWeb.Models
{
    public class Model : IDisposable
    {
        protected SqlConnection conn;

        public Model()
        {
            string strConn = @"Data Source=localhost;
                                Initial Catalog=BDTarefa;
                                Integrated Security=true";
                            // User Id = sa; Password=dba;

            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }
    }

    public class TarefaModel : Model
    {
        public List<Tarefa> Read()
        {
            List<Tarefa> lista = new List<Tarefa>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * 
                                FROM Tarefa";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Tarefa t = new Tarefa
                {
                    TarefaId = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Concluida = (bool)reader["Concluida"],
                    Data = (DateTime)reader["Data"]
                };

                lista.Add(t);
            }

            return lista;
        }
    }
}