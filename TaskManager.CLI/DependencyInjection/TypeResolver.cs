// DependencyInjection/TypeResolver.cs
using Spectre.Console.Cli;
using System;

namespace TaskManager.CLI.DependencyInjection
{
    public class TypeResolver : ITypeResolver, IDisposable
    {
        private readonly IServiceProvider _provider;

        public TypeResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        // Updated to match the nullability expectations
        public object? Resolve(Type? type)
        {
            if (type == null)
            {
                return null;
            }
            return _provider.GetService(type);
        }

        public void Dispose()
        {
            if (_provider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
