// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Core.Extensions
{
    public static class AzureClientServiceCollectionExtensions
    {
        public static void AddAzureClients(this IServiceCollection collection, Action<AzureClientsBuilder> configureClients)
        {
            configureClients(new AzureClientsBuilder(collection));
        }
    }
}