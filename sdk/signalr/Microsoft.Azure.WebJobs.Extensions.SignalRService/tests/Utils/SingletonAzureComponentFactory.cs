// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace SignalRServiceExtension.Tests
{
    public static class SingletonAzureComponentFactory
    {
        public static readonly AzureComponentFactory Instance;

        static SingletonAzureComponentFactory()
        {
            var services = new ServiceCollection();
            services.AddAzureClientsCore();
            Instance = services.BuildServiceProvider().GetRequiredService<AzureComponentFactory>();
        }
    }
}
