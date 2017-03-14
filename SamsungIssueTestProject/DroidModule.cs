using Autofac;
using SamsungIssueTestProject.Foundation.Interfaces;

namespace SamsungIssueTestProject
{
    public class DroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Sqlite>().As<ISqlite>();
        }
    }
}