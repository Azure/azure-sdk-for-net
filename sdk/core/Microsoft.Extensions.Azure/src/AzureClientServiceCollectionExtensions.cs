// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.Azure
{
    public static class AzureClientServiceCollectionExtensions
    {
        public static void AddAzureClients(this IServiceCollection collection, Action<AzureClientFactoryBuilder> configureClients)
        {
            configureClients(new AzureClientFactoryBuilder(collection));
        }
    }
}