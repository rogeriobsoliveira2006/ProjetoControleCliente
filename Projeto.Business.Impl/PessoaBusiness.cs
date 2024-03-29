﻿using System;
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

                Pessoa aux = repository.FindById(p.PessoaId);
                if (aux != null)
                {
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
                else
                {
                    Console.WriteLine($"\n Pessoa não encontrado!!!\n");
                }
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

                Pessoa aux = repository.FindById(idPessoa);
                if (aux != null)
                {
                    repository.Delete(idPessoa);

                    Console.WriteLine($"\n Pessoa exluído com sucesso !\n");
                }
                else
                {
                    Console.WriteLine($"\n Pessoa não encontrado!!!\n");
                }
            }
            catch (Exception ex)
            {
                //imprimir mensagem de erro...
                Console.WriteLine("ERRO: " + ex.Message);
            }
        }

        public void ConsultarPorId()
        {
            try
            {
                Console.WriteLine("\n - CONSULTA DE PESSOAS POR ID - \n");

                Console.Write("INFORME O ID.........: ");
                int idPessoa = int.Parse(Console.ReadLine());

                Pessoa p = repository.FindById(idPessoa);

                if (p != null)
                {
                    Console.WriteLine("Pessoa -> " + p.ToString());

                    if (p.Endereco != null)
                    {
                        Console.WriteLine("\tEndereço -> " + p.Endereco.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("\nPessoa não encontrado!!!");
                }
            }
            catch (Exception ex)
            {
                //imprimir mensagem de erro...
                Console.WriteLine("ERRO: " + ex.Message);
            }
        }

        //metodo para consultar todos...
        public void ConsultarTodos()
        {
            try
            {
                Console.WriteLine("\n - CONSULTA DE PESSOAS - \n");

                foreach (Pessoa p in repository.FindAll())
                {
                    Console.WriteLine("Pessoa -> " + p.ToString());

                    if (p.Endereco != null)
                    {
                        Console.WriteLine("\tEndereço -> " + p.Endereco.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //imprimir mensagem de erro...
                Console.WriteLine("ERRO: " + ex.Message);
            }
        }
    }
}
