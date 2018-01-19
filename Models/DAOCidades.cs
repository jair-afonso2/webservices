using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebServicesCidades.Models
{
    public class DAOCidades
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;
        string conexao = @"Data Source=.\SQLEXPRESS; Initial Catalog=ProjetoCidades; uid=sa; pwd=senai@123";

        public List<Cidades> Listar()
        {
            var cidades = new List<Cidades>();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = conexao;

                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Cidades";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cidades.Add(new Cidades()
                    {
                        Id = rd.GetInt32(0),
                        Nome = rd.GetString(1),
                        Estado = rd.GetString(2),
                        Habitantes = rd.GetInt32(3)
                    });
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return cidades;
        }

        public bool Cadastro(Cidades cidade)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Cidades(Nome,Estado,Habitantes) values (@n, @e, @h)";
                cmd.Parameters.AddWithValue("@n", cidade.Nome);
                cmd.Parameters.AddWithValue("@e", cidade.Estado);
                cmd.Parameters.AddWithValue("@h", cidade.Habitantes);

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return resultado;
        }

        public bool Deletar(int id)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = string.Format("Delete from Cidades where Id='{0}'", id);

                con.Open();

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return resultado;
        }

        public bool Atualizar(Cidades cidades)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Cidades set Nome = @n, Estado = @e, Habitantes = @h where Id = @i";                
                cmd.Parameters.AddWithValue("@n", cidades.Nome);
                cmd.Parameters.AddWithValue("@e", cidades.Estado);
                cmd.Parameters.AddWithValue("@h", cidades.Habitantes);
                cmd.Parameters.AddWithValue("@i", cidades.Id);

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;

                cmd.Parameters.Clear();
            }

            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally

            {
                con.Close();
            }

            return resultado;
        }
    }
}