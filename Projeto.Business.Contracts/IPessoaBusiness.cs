using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Business.Contracts
{
    public interface PessoaBusiness
    {
        void Cadastar();
        void Atualizar();
        void Excluir();
        List<Pessoa> ConsultarTodos();
        Pessoa ConsultarPorId();
    }
}
