using ApiTarefasNet80.Database;

namespace ApiTarefasNet80.Models
{
    public class CategoriaDAO
    {
        private static ConnectionMysql _conn;

        public CategoriaDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Categoria item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO categorias (nome_cat) VALUES (@_nome)";

                query.Parameters.AddWithValue("@_nome", item.Nome);

                var result = query.ExecuteNonQuery();
                if (result == 0) {
                    throw new Exception("O Registro não foi inserido!");
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
    }
}
