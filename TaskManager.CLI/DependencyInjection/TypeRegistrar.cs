using Spectre.Console.Cli;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskManager.CLI.DependencyInjection
{
    public class TypeRegistrar : ITypeRegistrar
    {
        private readonly IServiceCollection _services;

        public TypeRegistrar()
        {
            _services = new ServiceCollection();
        }

        public ITypeResolver Build()
        {
            return new TypeResolver(_services.BuildServiceProvider());
        }

        public void Register<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            _services.AddSingleton<TService, TImplementation>();
        }

        public void RegisterInstance<TService>(TService implementation)
            where TService : class
        {
            _services.AddSingleton<TService>(implementation);
        }

        public void RegisterLazy<TService>(Func<TService> factory)
            where TService : class
        {
            _services.AddSingleton<TService>(provider => factory());
        }

        public void Register(Type service, Type implementation)
        {
            _services.AddSingleton(service, implementation);
        }

        public void RegisterInstance(Type service, object implementation)
        {
            _services.AddSingleton(service, implementation);
        }

        public void RegisterLazy(Type service, Func<object> factory)
        {
            _services.AddSingleton(service, provider => factory());
        }
    }
}
