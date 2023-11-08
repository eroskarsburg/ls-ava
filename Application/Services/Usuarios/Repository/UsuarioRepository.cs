using Application.Shared.Context;
using Application.Shared.Entities;
using Application.Shared.Enum;
using MySql.Data.MySqlClient;
using System.Text;

namespace Application.Services.Usuarios.Repository
{
    public class DisciplinaRepository
    {
        private readonly DbContext _dbContext;

        public DisciplinaRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static List<UsuarioLogin> RetornaUsuarios()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT id, login, senha, id_nivel_acesso FROM usuario");

            List<UsuarioLogin> listaUsuarios = new List<UsuarioLogin>();
            try
            {
                DbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), DbContext.Connection);
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
            finally { DbContext.CloseConnection(); }
        }

        public bool InserirLogin(UsuarioLogin usuario)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO usuario (login, senha, id_nivel_acesso)");
            sb.AppendLine($"VALUES ({usuario.Login!.ToString()}, {usuario.Senha!.ToString()}, {usuario.NivelAcesso})");
            try
            {
                DbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), DbContext.Connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception) { throw; }
            finally { DbContext.CloseConnection(); }
        }

        public bool DeletarUsuario(string login)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"DELETE FROM usuario WHERE login={login}");
            try
            {
                DbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), DbContext.Connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception) { throw; }
            finally { DbContext.CloseConnection(); }
        }
    }
}
