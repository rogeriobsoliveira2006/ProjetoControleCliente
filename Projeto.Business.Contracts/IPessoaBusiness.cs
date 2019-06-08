using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Business.Contracts
{
    public interface IPessoaBusiness
    {
        void Cadastrar();
        void Atualizar();
        void Excluir();
        List<Pessoa> ConsultarTodos();
        Pessoa ConsultarPorId();
    }
}
