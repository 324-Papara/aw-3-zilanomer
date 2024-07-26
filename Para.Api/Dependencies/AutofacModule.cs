using Autofac;
using AutoMapper;
using FluentValidation;
using MediatR;
using Para.Api.Service;
using Para.Bussiness;
using Para.Data.Context;
using Para.Data.UnitOfWork;

namespace Para.Api.Dependencies
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ParaDbContext>().AsSelf().InstancePerLifetimeScope();

            var assembly = typeof(Startup).Assembly;
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperConfig());
            })).AsSelf().SingleInstance();

            builder.Register(context =>
            {
                var ctx = context.Resolve<IComponentContext>();
                var config = ctx.Resolve<MapperConfiguration>();
                return config.CreateMapper(ctx.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();

            builder.RegisterType<CustomService1>().AsSelf().InstancePerDependency();
            builder.RegisterType<CustomService2>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomService3>().AsSelf().SingleInstance();
        }
    }
}
