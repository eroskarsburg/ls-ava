using Application.Shared.Context;
using Application.Shared.Entities;
using MySql.Data.MySqlClient;
using System.Text;

namespace Application.Services.Professores.Repository
{
    public class ProfessorRepository
    {
        private readonly DbContext _dbContext;

        public ProfessorRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Professor> RetornaProfessores()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT id, nome, registro, cpf, email FROM professor");

            List<Professor> listaProfessores = new List<Professor>();
            try
            {
                DbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), DbContext.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Professor professor = new()
                    {
                        Id = int.Parse(dataReader["id"].ToString()!),
                        Nome = dataReader["nome"].ToString(),
                        Registro = dataReader["registro"].ToString(),
                        Cpf = dataReader["cpf"].ToString(),
                        Email = dataReader["email"].ToString()
                    };

                    listaProfessores.Add(professor);
                }
                dataReader.Close();

                return listaProfessores;
            }
            catch (Exception) { throw; }
            finally { DbContext.CloseConnection(); }
        }

        public bool InserirProfessor(Professor professor)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO aluno (nome, registro, cpf, email)");
            sb.AppendLine($"VALUES ({professor.Nome?.ToString()}, {professor.Registro?.ToString()}, {professor.Cpf?.ToString()}, {professor.Email?.ToString()})");
            try
            {
                DbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), DbContext.connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception) { throw; }
            finally { DbContext.CloseConnection(); }
        }

        public bool AtualizarProfessor(Professor professor)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE aluno SET");
            sb.AppendLine($"nome='{professor.Nome}',");
            sb.AppendLine($"registro={professor.Registro},");
            sb.AppendLine($"cpf='{professor.Cpf}',");
            sb.AppendLine($"email='{professor.Email}',");
            sb.AppendLine($"WHERE id={professor.Id}");
            try
            {
                DbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), DbContext.connection);
                cmd.ExecuteNonQuery();
                DbContext.CloseConnection();
                return true;
            }
            catch (Exception) { throw; }
            finally { DbContext.CloseConnection(); }
        }

        public bool DeletarProfessor(string registro)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"DELETE FROM professor WHERE registro={registro.ToString()}");
            try
            {
                DbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), DbContext.connection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception) { throw; }
            finally { DbContext.CloseConnection(); }
        }
    }
}
