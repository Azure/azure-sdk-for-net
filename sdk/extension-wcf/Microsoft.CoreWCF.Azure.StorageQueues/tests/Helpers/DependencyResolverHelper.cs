// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests.Helpers
{
    internal class DependencyResolverHelper
    {
        private readonly IWebHost _webHost;

        public DependencyResolverHelper(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public T GetService<T>()
        {
            using IServiceScope serviceScope = _webHost.Services.CreateScope();
            IServiceProvider services = serviceScope.ServiceProvider;
            T scopedService = services.GetRequiredService<T>();
            return scopedService;
        }
    }
}
