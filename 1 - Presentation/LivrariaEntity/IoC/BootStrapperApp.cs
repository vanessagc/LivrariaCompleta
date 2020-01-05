
using LivrariaEntity.Interfaces;
using LivrariaEntity.Services;
using SimpleInjector;

namespace LivrariaEntity.IoC
{
    public class BootStrapperApp
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register(typeof(ILivrariaAppService), typeof(LivrariaAppService) );

            // Domain
            //container.Register<ILivrariaService, LivrariaService>(Lifestyle.Scoped);

            // Infra Dados
            //container.Register<ILivrariaRepository, LivrariaRepository>(Lifestyle.Scoped);
            //container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            //container.Register<LivrariaEntityContext>(Lifestyle.Scoped);
            //container.Register(typeof (IRepository<>), typeof (Repository<>));

            // Logging
            //container.Register<ILogAuditoria, LogAuditoriaHelper>(Lifestyle.Scoped);
            //container.Register<LogginContext>(Lifestyle.Scoped);
        }
    }
}