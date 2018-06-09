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

        public void Create(Tarefa t)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Tarefa VALUES (@nome, @concluida, @data)";

            cmd.Parameters.AddWithValue("@nome", t.Nome);
            cmd.Parameters.AddWithValue("@concluida", t.Concluida);
            cmd.Parameters.AddWithValue("@data", t.Data);

            cmd.ExecuteNonQuery();
        }

        public void Update(Tarefa t)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"UPDATE Tarefa SET Nome = @nome, Concluida = @concluida
                                    WHERE TarefaId = @id";

            cmd.Parameters.AddWithValue("@nome", t.Nome);
            cmd.Parameters.AddWithValue("@concluida", t.Concluida);
            cmd.Parameters.AddWithValue("@id", t.TarefaId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Tarefa WHERE TarefaId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public Tarefa Read(int id)
        {
            Tarefa t = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Tarefa
                                WHERE TarefaId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                t = new Tarefa
                {
                    TarefaId = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Concluida = (bool)reader["Concluida"],
                    Data = (DateTime)reader["Data"]
                };
            }

            return t;
        }
    }
}