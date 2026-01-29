// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers
{
    internal class DependencyResolverHelper
    {
        private readonly IHost _host;

        public DependencyResolverHelper(IHost host)
        {
            _host = host;
        }

        public T GetService<T>()
        {
            using IServiceScope serviceScope = _host.Services.CreateScope();
            IServiceProvider services = serviceScope.ServiceProvider;
            T scopedService = services.GetRequiredService<T>();
            return scopedService;
        }
    }
}
