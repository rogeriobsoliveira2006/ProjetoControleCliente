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
            business.Cadastrar();

            
            Console.ReadKey();
        }
    }
}
