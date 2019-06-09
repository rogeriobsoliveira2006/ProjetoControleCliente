using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Business.Contracts;
using Projeto.Business.Impl;
using Projeto.Repository.Contracts;
using Projeto.Repository.Impl;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Projeto.Presentation
{
    static class Program
    {
        static IPessoaBusiness business;
        private static readonly Container container;

        static Program()
        {
            container = new Container();
            //container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Singleton);
            container.Register<IPessoaBusiness, PessoaBusiness>(Lifestyle.Singleton);
            //container.Register<PessoaBusiness>();

            container.Verify();
        }
        static void Main(string[] args)
        {
            business = container.GetInstance<IPessoaBusiness>();

            do
            {
                Console.Clear();
                Console.WriteLine("\n - PROJETO CONTROLE DE PESSOAS - \n");
                Console.WriteLine("[1] - CADASTRAR PESSOA");
                Console.WriteLine("[2] - ATUALIZAR PESSOA");
                Console.WriteLine("[3] - EXCLUIR PESSOA");
                Console.WriteLine("[4] - CONSULTAR TODOS");
                Console.WriteLine("[5] - CONSULTAR POR ID");

                Console.Write("\nInforme a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        business.Cadastrar();
                        break;

                    case 2:
                        business.Atualizar();
                        break;

                    case 3:
                        business.Excluir();
                        break;

                    case 4:
                        business.ConsultarTodos();
                        break;

                    case 5:
                        business.ConsultarPorId();
                        break;

                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA!!!\n");
                        break;
                }
                Console.Write("\nDeseja continuar no programa [s] ou [n]: ");
            } while (char.ToLower(char.Parse(Console.ReadLine())).Equals('s'));

            //Console.ReadKey(); //pausar...
        }
    }
}
