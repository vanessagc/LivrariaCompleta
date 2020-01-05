
using LivrariaMvc.Domain.Interfaces.Repository;
using LivrariaMvc.Domain.Interfaces.Services;
using LivrariaMvc.Domain.Services;
using LivrariaMvc.Infra.Data.Context;
using LivrariaMvc.Infra.Data.Interfaces;
using LivrariaMvc.Infra.Data.Repository;
using LivrariaMvc.Infra.Data.UoW;
using SimpleInjector;

namespace LivrariaMvc.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            //container.Register<ILivrariaAppService, LivrariaAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<ILivrariaService, LivrariaService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<ILivrariaRepository, LivrariaRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<LivrariaEntityContext>(Lifestyle.Scoped);
            //container.Register(typeof (IRepository<>), typeof (Repository<>));

            // Logging
            //container.Register<ILogAuditoria, LogAuditoriaHelper>(Lifestyle.Scoped);
            //container.Register<LogginContext>(Lifestyle.Scoped);
        }
    }
}