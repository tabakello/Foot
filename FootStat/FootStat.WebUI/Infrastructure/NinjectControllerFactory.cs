using System;
using System.Web.Mvc;
using FootStat.Domain;
using FootStat.Domain.Abstract;
using FootStat.Domain.Concrete;
using Ninject;

namespace FootStat.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory {
        private IKernel kernel;
        public NinjectControllerFactory() {
            kernel = new StandardKernel();
            kernel.Bind<IDBContext>().To<SportStatEntities>().InSingletonScope();
            kernel.Bind<IQueryRepository>().To<QueryRepository>().InSingletonScope();
            kernel.Bind<IRepository<Match>>().To<Repository<Match>>().InSingletonScope();
            kernel.Bind<IRepository<Command>>().To<Repository<Command>>().InSingletonScope();
            kernel.Bind<IRepository<Tourney>>().To<Repository<Tourney>>().InSingletonScope();
            kernel.Bind<IRepository<TournamentTable>>().To<Repository<TournamentTable>>().InSingletonScope();
            kernel.Bind<IRepository<MatchDetail>>().To<Repository<MatchDetail>>().InSingletonScope();
        }
        
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType) {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }

        public void Dispose() {
            kernel.Dispose();
        }
    }
}