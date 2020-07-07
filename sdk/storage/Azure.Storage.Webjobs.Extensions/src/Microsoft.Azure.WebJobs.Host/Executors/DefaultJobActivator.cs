// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    /// <summary>
    /// The default <see cref="IJobActivator"/> integrates with DI,
    /// supporting constructor injection for registered services.
    /// </summary>
    internal class DefaultJobActivator : IJobActivatorEx
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ConcurrentDictionary<Type, ObjectFactory> _factories;

        public DefaultJobActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _factories = new ConcurrentDictionary<Type, ObjectFactory>();
        }

        public T CreateInstance<T>()
        {
            return CreateInstance<T>(_serviceProvider);
        }

        public T CreateInstance<T>(IFunctionInstanceEx functionInstance)
        {
            return CreateInstance<T>(functionInstance.InstanceServices);
        }

        private T CreateInstance<T>(IServiceProvider serviceProvider)
        {
            var factory = _factories.GetOrAdd(typeof(T), t =>
            {
                return ActivatorUtilities.CreateFactory(t, Type.EmptyTypes);
            });

            return (T)factory(serviceProvider, null);
        }
    }
}
