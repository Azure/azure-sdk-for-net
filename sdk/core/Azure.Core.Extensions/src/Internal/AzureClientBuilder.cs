// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;

namespace Azure.Core.Extensions
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