using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Business.Contracts;
using Projeto.Entities;
using Projeto.Repository.Contracts;

namespace Projeto.Business.Impl
{
    public class PessoaBusiness : IPessoaBusiness
    {
        private IPessoaRepository repository;

        public PessoaBusiness(IPessoaRepository repository)
        {
            this.repository = repository;
        }

        public void Cadastrar()
        {
            try
            {
                Console.WriteLine("\n - CADASTRO DE PESSOA - \n");
                Pessoa p = new Pessoa();

                Console.Write("INFORME O NOME.......: ");
                p.AddNome(Console.ReadLine());

                Console.Write("INFORME O EMAIL......: ");
                p.AddEmail(Console.ReadLine());

                p.AddDataCadastro(DateTime.Now);

                Endereco e = new Endereco();

                Console.Write("INFORME O LOGRADOURO.: ");
                e.AddLogradouro(Console.ReadLine());

                Console.Write("INFORME A CIDADE.....: ");
                e.AddCidade(Console.ReadLine());

                Console.Write("INFORME O ESTADO.....: ");
                e.AddEstado(Console.ReadLine());

                Console.Write("INFORME O CEP........: ");
                e.AddCEP(Console.ReadLine());

                repository.Insert(p, e);

                Console.WriteLine($"\n Pessoa {p.Nome} | cadastrado com sucesso !\n");
            }
            catch (Exception ex)
            {
                //imprimir mensagem de erro...
                Console.WriteLine("ERRO: " + ex.Message);
            }
            
        }

        public void Atualizar()
        {
            try
            {
                Console.WriteLine("\n - ATUALIZAR DE PESSOA - \n");
                Pessoa p = new Pessoa();

                Console.Write("INFORME O ID.........: ");
                p.PessoaId = int.Parse(Console.ReadLine());

                Console.Write("INFORME O NOME.......: ");
                p.AddNome(Console.ReadLine());

                Console.Write("INFORME O EMAIL......: ");
                p.AddEmail(Console.ReadLine());


                Endereco e = new Endereco();

                Console.Write("INFORME O LOGRADOURO.: ");
                e.AddLogradouro(Console.ReadLine());

                Console.Write("INFORME A CIDADE.....: ");
                e.AddCidade(Console.ReadLine());

                Console.Write("INFORME O ESTADO.....: ");
                e.AddEstado(Console.ReadLine());

                Console.Write("INFORME O CEP........: ");
                e.AddCEP(Console.ReadLine());

                repository.Update(p, e);

                Console.WriteLine($"\n Pessoa {p.Nome} | atualizado com sucesso !\n");
            }
            catch (Exception ex)
            {
                //imprimir mensagem de erro...
                Console.WriteLine("ERRO: " + ex.Message);
            }
        }

        public void Excluir()
        {
            try
            {
                Console.WriteLine("\n - EXCLUIR PESSOA - \n");

                Console.Write("INFORME O ID.........: ");
                int idPessoa = int.Parse(Console.ReadLine());

                repository.Delete(idPessoa);

                Console.WriteLine($"\n Pessoa exluído com sucesso !\n");
            }
            catch (Exception ex)
            {
                //imprimir mensagem de erro...
                Console.WriteLine("ERRO: " + ex.Message);
            }
        }

        public Pessoa ConsultarPorId()
        {
            throw new NotImplementedException();
        }

        public List<Pessoa> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
