using Application.Shared.Context;
using Application.Shared.Entities;
using Application.Shared.Enum;
using MySql.Data.MySqlClient;
using System.Text;

namespace Application.Services.Usuarios.Repository
{
    public class UsuarioRepository
    {
        private readonly DbContext _dbContext;

        public UsuarioRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UsuarioLogin> RetornaUsuarios()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT id, login, senha, id_nivel_acesso FROM usuario");

            List<UsuarioLogin> listaUsuarios = new List<UsuarioLogin>();
            try
            {
                _dbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), _dbContext.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    UsuarioLogin usuario = new()
                    {
                        Id = int.Parse(dataReader["id"].ToString()!),
                        Login = dataReader["login"].ToString(),
                        Senha = dataReader["senha"].ToString(),
                        NivelAcesso = (NivelAcesso)int.Parse(dataReader["id_nivel_acesso"].ToString()!)
                    };

                    listaUsuarios.Add(usuario);
                }
                dataReader.Close();

                return listaUsuarios;
            }
            catch (Exception) { throw; }
            finally { _dbContext.CloseConnection(); }
        }

        public bool InserirLogin(UsuarioLogin usuario)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO usuario (login, senha, id_nivel_acesso)");
            sb.AppendLine($"VALUES ({usuario.Login!.ToString()}, {usuario.Senha!.ToString()}, {usuario.NivelAcesso})");
            try
            {
                _dbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), _dbContext.connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception) { throw; }
            finally { _dbContext.CloseConnection(); }
        }

        public bool DeletarUsuario(string login)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"DELETE FROM usuario WHERE login={login}");
            try
            {
                _dbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), _dbContext.connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception) { throw; }
            finally { _dbContext.CloseConnection(); }
        }
    }
}
