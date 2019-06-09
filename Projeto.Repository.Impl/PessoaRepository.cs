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
            AbrirConexao();

            string queryConsulta = "SELECT * FROM PESSOA p LEFT JOIN ENDERECO e ON p.PessoaId = e.PessoaId";

            cmd = new SqlCommand(queryConsulta, con);
            dr = cmd.ExecuteReader();

            List<Pessoa> listaPessoa = null;

            if (dr.HasRows)
            {
                listaPessoa = new List<Pessoa>();
                //varrer cada registro obtido na consulta...
                while (dr.Read())
                {
                    Pessoa p = new Pessoa();
                    p.PessoaId = Convert.ToInt32(dr["PessoaId"]);
                    p.AddNome(Convert.ToString(dr["Nome"]));
                    p.AddEmail(Convert.ToString(dr["Email"]));
                    p.AddDataCadastro(Convert.ToDateTime(dr["DataCadastro"]));

                    //verificar se pessoa contem endereço...
                    if (dr["EnderecoId"] != DBNull.Value)
                    {
                        p.Endereco = new Endereco();
                        p.Endereco.EnderecoId = Convert.ToInt32(dr["EnderecoId"]);
                        p.Endereco.AddLogradouro(Convert.ToString(dr["Logradouro"]));
                        p.Endereco.AddCidade(Convert.ToString(dr["Cidade"]));
                        p.Endereco.AddEstado(Convert.ToString(dr["Estado"]));
                        p.Endereco.AddCEP(Convert.ToString(dr["Cep"]));
                    }
                    listaPessoa.Add(p);
                }
            }

            FecharConexao();
            return listaPessoa;
        }

        public Pessoa FindById(int idPessoa)
        {
            AbrirConexao();

            string queryConsulta = "SELECT * FROM PESSOA p LEFT JOIN ENDERECO e ON p.PessoaId = e.PessoaId "
                    +"WHERE p.PessoaId = @PessoaId";

            cmd = new SqlCommand(queryConsulta, con);
            cmd.Parameters.AddWithValue("@PessoaId", idPessoa);
            dr = cmd.ExecuteReader();

            Pessoa p = null;

            if (dr.HasRows)
            {
                p = new Pessoa();

                if (dr.Read())
                {
                    p.PessoaId = Convert.ToInt32(dr["PessoaId"]);
                    p.AddNome(Convert.ToString(dr["Nome"]));
                    p.AddEmail(Convert.ToString(dr["Email"]));
                    p.AddDataCadastro(Convert.ToDateTime(dr["DataCadastro"]));

                    //verificar se pessoa contem endereço...
                    if (dr["EnderecoId"] != DBNull.Value)
                    {
                        p.Endereco = new Endereco();
                        p.Endereco.EnderecoId = Convert.ToInt32(dr["EnderecoId"]);
                        p.Endereco.AddLogradouro(Convert.ToString(dr["Logradouro"]));
                        p.Endereco.AddCidade(Convert.ToString(dr["Cidade"]));
                        p.Endereco.AddEstado(Convert.ToString(dr["Estado"]));
                        p.Endereco.AddCEP(Convert.ToString(dr["Cep"]));
                    }
                }
            }

            FecharConexao();
            return p;
        }
    }
}
