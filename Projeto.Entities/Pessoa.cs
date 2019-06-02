using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Pessoa
    {
        //propriedades...
        public int PessoaId { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }

        //Associação TER-1
        public Endereco Endereco { get; set; }

        //contrutor...
        public Pessoa()
        {
            //Vazio...
        }

        //sobrecarga de contrutores(overloading)
        public Pessoa(int pessoaId, string nome, string email, DateTime dataCadastro)
        {
            PessoaId = pessoaId;
            Nome = nome;
            Email = email;
            DataCadastro = dataCadastro;
        }

        //Encapsulamento Nome Pessoa
        public void AddNome(string nome)
        {
            Nome = nome;
        }

        //Encapsulamento Email Pessoa
        public void AddEmail(string email)
        {
            Email = email;
        }

        //Encapsulamento Data Cadastro Pessoa
        public void AddDataCadastro(DateTime dataCadastro)
        {
            DataCadastro = dataCadastro;
        }

        //sobrescrita de método ToString()..
        public override string ToString()
        {
            return $"ID: {PessoaId} | Nome: {Nome} | Email: {Email} | Data de Cadastro: {DataCadastro} .";
        }
    }
}
