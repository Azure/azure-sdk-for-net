// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests;

internal static class TestAzureComponentFactory
{
    public static readonly AzureComponentFactory Instance;

    static TestAzureComponentFactory()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddAzureClientsCore();
        Instance = serviceCollection.BuildServiceProvider()
            .GetRequiredService<AzureComponentFactory>();
    }
}
