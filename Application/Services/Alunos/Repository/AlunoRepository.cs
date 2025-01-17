﻿using Application.Shared.Context;
using Application.Shared.Entities;
using MySql.Data.MySqlClient;
using System.Text;

namespace Application.Services.Alunos.Repository
{
    public class AlunoRepository
    {
        private readonly DbContext _dbContext;

        public AlunoRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Aluno> RetornaAlunos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SELECT id, nome, cpf, matricula, telefone, email, id_nivel_acesso FROM aluno");

            List<Aluno> listaAlunos = new List<Aluno>();
            try
            {
                _dbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), _dbContext.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Aluno aluno = new()
                    {
                        Id = int.Parse(dataReader["id"].ToString()!),
                        Nome = dataReader["nome"].ToString(),
                        Cpf = dataReader["cpf"].ToString(),
                        Matricula = int.Parse(dataReader["matricula"].ToString()!),
                        Telefone = dataReader["telefone"].ToString(),
                        Email = dataReader["email"].ToString()
                    };

                    listaAlunos.Add(aluno);
                }
                dataReader.Close();

                return listaAlunos;
            }
            catch (Exception) { throw; }
            finally { _dbContext.CloseConnection(); }
        }

        public bool InserirAluno(Aluno aluno)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO aluno (nome, cpf, matricula, telefone, email)");
            sb.AppendLine($"VALUES ({aluno.Nome?.ToString()}, {aluno.Cpf?.ToString()}, {aluno.Matricula}, {aluno.Telefone?.ToString()}, {aluno.Email?.ToString()})");
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

        public bool AtualizarAluno(Aluno aluno)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE aluno SET");
            sb.AppendLine($"nome='{aluno.Nome}',");
            sb.AppendLine($"cpf='{aluno.Cpf}',");
            sb.AppendLine($"matricula={aluno.Matricula},");
            sb.AppendLine($"telefone='{aluno.Telefone}',");
            sb.AppendLine($"email='{aluno.Email}',");
            sb.AppendLine($"WHERE id={aluno.Matricula}");
            try
            {
                _dbContext.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), _dbContext.connection);
                cmd.ExecuteNonQuery();
                _dbContext.CloseConnection();
                return true;
            }
            catch (Exception) { throw; }
            finally { _dbContext.CloseConnection(); }
        }

        public bool DeletarAluno(string matricula)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"DELETE FROM aluno WHERE matricula={matricula.ToString()}");
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
