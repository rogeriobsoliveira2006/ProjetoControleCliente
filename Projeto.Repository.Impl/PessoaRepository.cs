using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repository.Contracts;
using System.Data.SqlClient;

namespace Projeto.Repository.Impl
{
    public class PessoaRepository : Conexao, IPessoaRepository
    {
        //método para inserir um registro na tabela Pessoa e Endereço
        public void Insert(Pessoa p, Endereco e)
        {
            AbrirConexao();

            string queryPessoa = "INSERT INTO PESSOA(Nome, Email, DataCadastro) "
                    + "VALUES(@Nome,@Email,@DataCadastro) "
                    + "SELECT SCOPE_IDENTITY()";

            string queryEndereco = "INSERT INTO ENDERECO(Logradouro, Cidade, Estado, Cep, PessoaId) "
                    + "VALUES(@Logradouro, @Cidade, @Estado, @Cep, @PessoaId)";

            //abrir uma transação...
            tr = con.BeginTransaction();

            try
            {
                //gravando pessoa...
                cmd = new SqlCommand(queryPessoa, con, tr);
                cmd.Parameters.AddWithValue("@Nome", p.Nome);
                cmd.Parameters.AddWithValue("@Email", p.Email);
                cmd.Parameters.AddWithValue("@DataCadastro", p.DataCadastro);

                //executar comando SQL e ler o ID retornadopelo SCOPE_IDENTITY()
                p.PessoaId = Convert.ToInt32(cmd.ExecuteScalar());

                //gravando endereço...
                cmd = new SqlCommand(queryEndereco, con, tr);
                cmd.Parameters.AddWithValue("@Logradouro", e.Logradouro);
                cmd.Parameters.AddWithValue("@Cidade", e.Cidade);
                cmd.Parameters.AddWithValue("@Estado", e.Estado);
                cmd.Parameters.AddWithValue("@Cep", e.Cep);
                cmd.Parameters.AddWithValue("@PessoaId", p.PessoaId);
                cmd.ExecuteNonQuery();

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //método para alterar um registro na tabela Pessoa e Endereço
        public void Update(Pessoa p, Endereco e)
        {
            AbrirConexao();

            string queryPessoa = "UPDATE PESSOA SET Nome = @Nome, Email = @Email "
                    + "WHERE PessoaId = @PessoaId";

            string queryEndereco = "UPDATE ENDERECO SET Logradouro = @Logradouro, Cidade = @Cidade, Estado = @Estado, "
                    + "Cep = @Cep WHERE PessoaId = @PessoaId";

            //abrir uma transação...
            tr = con.BeginTransaction();

            try
            {
                //atualizando pessoa...
                cmd = new SqlCommand(queryPessoa, con, tr);
                cmd.Parameters.AddWithValue("@Nome", p.Nome);
                cmd.Parameters.AddWithValue("@Email", p.Email);
                cmd.Parameters.AddWithValue("@PessoaId", p.PessoaId);

                //atualizando endereço...
                cmd = new SqlCommand(queryEndereco, con, tr);
                cmd.Parameters.AddWithValue("@Logradouro", e.Logradouro);
                cmd.Parameters.AddWithValue("@Cidade", e.Cidade);
                cmd.Parameters.AddWithValue("@Estado", e.Estado);
                cmd.Parameters.AddWithValue("@Cep", e.Cep);
                cmd.Parameters.AddWithValue("@PessoaId", p.PessoaId);
                cmd.ExecuteNonQuery();

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Delete(int idPessoa)
        {
            AbrirConexao();

            string queryPessoa = "DELETE FROM PESSOA WHERE PessoaId = @PessoaId";

            //abrir uma transação...
            tr = con.BeginTransaction();

            try
            {
                //excluindo pessoa...
                cmd = new SqlCommand(queryPessoa, con, tr);
                cmd.Parameters.AddWithValue("@PessoaId", idPessoa);
                cmd.ExecuteNonQuery();

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Pessoa> FindAll()
        {
            throw new NotImplementedException();
        }

        public Pessoa FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
