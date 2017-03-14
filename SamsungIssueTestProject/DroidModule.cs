using Autofac;
using FriendsAppDate.Foundation.Interfaces;

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