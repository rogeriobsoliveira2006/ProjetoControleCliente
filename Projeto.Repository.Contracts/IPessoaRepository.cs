using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Repository.Contracts
{
    public interface IPessoaRepository
    {
        void Insert(Pessoa p, Endereco e);
        void Update(Pessoa p, Endereco e);
        void Delete(int id);
        List<Pessoa> FindAll();
        Pessoa FindById(int id);
    }
}
