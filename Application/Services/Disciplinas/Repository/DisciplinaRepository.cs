using Application.Shared.Context;
using Application.Shared.Entities;
using MySql.Data.MySqlClient;

namespace Application.Services.Disciplinas.Repository
{
    public class DisciplinaRepository
    {
        private readonly DbContext _dbContext;

        public DisciplinaRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static Dictionary<int, List<Disciplina>> RetornaDisciplinas()
        {
            Aluno aluno = new Aluno();
            string sql = "SELECT M.id_mdl_disc, M.nome_modulo, D.id_disciplina, D.id_modulo, D.nome_disciplina, D.requisitos, D.situacao, D.carga_horaria, D.nota FROM modulos M LEFT JOIN disciplinas D ON M.id_mdl_disc = D.id_modulo";

            try
            {
                DbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sql, DbContext.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.HasRows)
                {
                    aluno.DisciplinasPorModulo = new Dictionary<int, List<Disciplina>>();

                    while (dataReader.Read())
                    {
                        Modulo modulo = new Modulo
                        {
                            Id = (int)dataReader["id_mdl_disc"],
                            Nome = dataReader["nome_modulo"].ToString()
                        };

                        Disciplina disciplina = new Disciplina();
                        disciplina.Id = int.TryParse(dataReader["id_disciplina"].ToString(), out int id) ? id : 0;
                        disciplina.IdModulo = int.TryParse(dataReader["id_modulo"].ToString(), out int idmodulo) ? idmodulo : 0;
                        disciplina.NomeDisciplina = dataReader["nome_disciplina"].ToString() ?? string.Empty;
                        disciplina.Requisitos = dataReader["requisitos"].ToString() ?? string.Empty;
                        disciplina.Situacao = dataReader["situacao"].ToString() ?? string.Empty;
                        disciplina.CargaHoraria = int.TryParse(dataReader["carga_horaria"].ToString(), out int cargaHoraria) ? cargaHoraria : 0;
                        disciplina.Nota = float.TryParse(dataReader["nota"].ToString(), out float nota) ? nota : 0;

                        int idModulo = modulo.Id;

                        if (!aluno.DisciplinasPorModulo.ContainsKey(idModulo))
                        {
                            aluno.DisciplinasPorModulo[idModulo] = new List<Disciplina>();
                        }

                        aluno.DisciplinasPorModulo[idModulo].Add(disciplina);
                    }
                    dataReader.Close();
                }
                return aluno.DisciplinasPorModulo!;
            }
            catch (Exception e) { throw new Exception(e.Message); }
            finally { DbContext.CloseConnection(); }
        }
    }
}
