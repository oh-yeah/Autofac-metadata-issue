using Autofac;
using Autofac.Integration.Mef;
using MetaResolutionIssue.Dependencies;
using MetaResolutionIssue.Meta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetaResolutionIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            // the container builder
            var builder = new ContainerBuilder();
            // metadata support
            builder.RegisterMetadataRegistrationSources();
            // dependencies with metadata - 2 instances
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                   .AssignableTo<IDependency>()
                   .As<IDependency>()
                   .WithMetadataFrom<IMeta>()
                   .SingleInstance();

            var container = builder.Build();

            // working example
            using (var scope = container.BeginLifetimeScope("child-without-configurationAction"))
            {
                var deps = scope.Resolve<IEnumerable<Lazy<IDependency, IMeta>>>();

                Console.WriteLine($"- {deps.Count()} lazy dependencies resolved from a child scope without a configuration action");
            }

            // issue
            using (var scope = container.BeginLifetimeScope("child-with-configurationAction", b => {}))
            {
                // DUPLICATE DEPENDICIES RESOLVED HERE!!!!!!!!
                var deps = scope.Resolve<IEnumerable<Lazy<IDependency, IMeta>>>();

                Console.WriteLine($"- {deps.Count()} lazy dependencies resolved from a child scope with a configuration action");
            }

            Console.ReadKey();
        }
    }
}
