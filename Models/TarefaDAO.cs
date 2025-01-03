﻿using MySql.Data.MySqlClient;
using ApiTarefasNet80.Database;
using System.Collections.Generic;
using System.Data;

namespace ApiTarefasNet80.Models
{
    public class TarefaDAO
    {
        private static ConnectionMysql _conn;

        public TarefaDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Tarefa item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO tarefas (descricao_tar, data_tar, feito_tar) VALUES (@descricao, @data, @feito)";

                query.Parameters.AddWithValue("@descricao", item.Descricao);
                query.Parameters.AddWithValue("@data", item.Data.ToString("yyyy-MM-dd HH:mm:ss")); //"10/11/1990" -> "1990-11-10"
                query.Parameters.AddWithValue("@feito", item.Feito);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public List<Tarefa> List()
        {
            try
            {
                List<Tarefa> list = new List<Tarefa>();
                // List<Tarefa> list = [];

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM tarefas LEFT JOIN categorias ON id_cat = fk_id_cat";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    var tarefa = new Tarefa()
                    {
                        Id = reader.GetInt32("id_tar"),
                        Descricao = reader.GetString("descricao_tar"),
                        Data = reader.GetDateTime("data_tar"),
                        Feito = reader.GetBoolean("feito_tar"),
                        Data_feito = reader.IsDBNull("data_feito_tar") ?
                                           (DateTime?)null :
                                           (DateTime?)reader.GetDateTime("data_feito_tar")
                    };
                    if (!reader.IsDBNull("id_cat"))
                    {
                        var categoria = new Categoria()
                        {
                            Id = reader.GetInt32("id_cat"),
                            Nome = reader.GetString("nome_cat")
                        };
                        tarefa.Categoria = categoria;
                    }

                    list.Add(tarefa);
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public Tarefa? GetById(int id)
        {
            try
            {
                Tarefa _tarefa = new Tarefa();
                // Tarefa _tarefa = new();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM tarefas WHERE id_tar = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                {
                    return null;
                }
                while (reader.Read())
                {
                    _tarefa.Id = reader.GetInt32("id_tar");
                    _tarefa.Descricao = reader.GetString("descricao_tar");
                    _tarefa.Data = reader.GetDateTime("data_tar");
                    _tarefa.Feito = reader.GetBoolean("feito_tar");
                }

                return _tarefa;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Update(Tarefa item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "UPDATE tarefas SET descricao_tar = @_descricao, feito_tar = @_feito, data_feito_tar = @_data_feito WHERE id_tar = @_id";

                query.Parameters.AddWithValue("@_descricao", item.Descricao);
                query.Parameters.AddWithValue("@_feito", item.Feito);
                query.Parameters.AddWithValue("@_data_feito", item.Data_feito);
                query.Parameters.AddWithValue("@_id", item.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "DELETE FROM tarefas WHERE id_tar = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

    }
}
