using Ninject.Modules;
using Provider.Model.TaskInformation;
using Provider.Model.Usernformation;
using Provider.Repository;

namespace Provider.Api.App_Start
{
    public class DependencyBinder : NinjectModule
    {
        public override void Load()
        {
            Bind<ICrudRepository<TaskInformation>>().To<TaskInformationRepository>();
            Bind<ICrudRepository<UserInformation>>().To<UserInformationRepository>();
        }
    }
}