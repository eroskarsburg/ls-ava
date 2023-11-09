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

                        Disciplina disciplina = new Disciplina
                        {
                            Id = (int)dataReader["id_disciplina"],
                            IdModulo = (int)dataReader["id_modulo"],
                            NomeDisciplina = dataReader["nome_disciplina"].ToString(),
                            Requisitos = dataReader["requisitos"].ToString(),
                            Situacao = dataReader["situacao"].ToString(),
                            CargaHoraria = (int)dataReader["carga_horaria"],
                            Nota = (float)dataReader["nota"]
                        };

                        int idModulo = modulo.Id;

                        if (!aluno.DisciplinasPorModulo.ContainsKey(idModulo))
                        {
                            aluno.DisciplinasPorModulo[idModulo] = new List<Disciplina>();
                        }

                        aluno.DisciplinasPorModulo[idModulo].Add(disciplina);
                    }

                    foreach (var kvp in aluno.DisciplinasPorModulo)
                    {
                        Console.WriteLine($"Módulo: {kvp.Key}");
                        foreach (var disciplina in kvp.Value)
                        {
                            Console.WriteLine($"IdDisciplina: {disciplina.Id}, NomeDisciplina: {disciplina.NomeDisciplina}");
                        }
                    }
                }
                dataReader.Close();
                return aluno.DisciplinasPorModulo!;
            }
            catch (Exception e) { throw new Exception(e.Message); }
            finally { DbContext.CloseConnection(); }
        }
    }
}
