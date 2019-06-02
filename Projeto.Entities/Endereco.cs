using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Endereco
    {
        //propriedades...
        public int EnderecoId { get; set; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }

        //Associação TER-1
        public Pessoa Pessoa { get; set; }

        //contrutor...
        public Endereco()
        {
            //vazio....
        }

        //sobrecarga de contrutores(overloading)
        public Endereco(int enderecoId, string logradouro, string cidade, string estado, string cep)
        {
            EnderecoId = enderecoId;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        //Encapsulamento Logradouro da Pessoa
        public void AddLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }

        //Encapsulamento Cidade da Pessoa
        public void AddCidade(string cidade)
        {
            Cidade = cidade;
        }

        //Encapsulamento Estado da Pessoa
        public void AddEstado(string estado)
        {
            Estado = estado;
        }

        //Encapsulamento CEP da Pessoa
        public void AddCEP(string cep)
        {
            Cep = cep;
        }

        //sobrescrita de método ToString()
        public override string ToString()
        {
            return $"ID: {EnderecoId} | Logradouro: {Logradouro} | Cidade: {Cidade} | Estado: {Estado} | CEP: {Cep} ";
        }
    }
}
