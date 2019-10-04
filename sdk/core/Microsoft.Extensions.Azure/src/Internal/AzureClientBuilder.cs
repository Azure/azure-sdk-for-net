// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Azure
{
    internal sealed class AzureClientBuilder<TClient, TOptions>: IAzureClientBuilder<TClient, TOptions> where TOptions : class
    {
        public ClientRegistration<TClient, TOptions> Registration { get; }
        public IServiceCollection ServiceCollection { get; }

        internal AzureClientBuilder(ClientRegistration<TClient, TOptions> clientRegistration, IServiceCollection serviceCollection)
        {
            Registration = clientRegistration;
            ServiceCollection = serviceCollection;
        }
    }
}