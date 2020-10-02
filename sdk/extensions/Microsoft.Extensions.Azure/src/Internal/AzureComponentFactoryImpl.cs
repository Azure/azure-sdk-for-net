// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal class AzureComponentFactoryImpl: AzureComponentFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOptionsMonitor<AzureClientsGlobalOptions> _globalOptions;

        public AzureComponentFactoryImpl(IOptionsMonitor<AzureClientsGlobalOptions> globalOptions, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _globalOptions = globalOptions;
        }

        /// <inheritdoc />
        public override TokenCredential CreateCredential(IConfiguration configuration)
        {
            return ClientFactory.CreateCredential(configuration) ?? _globalOptions.CurrentValue.CredentialFactory(_serviceProvider);
        }

        public override object CreateClientOptions(Type optionsType, object serviceVersion, IConfiguration configuration)
        {
            var options = ClientFactory.CreateClientOptions(serviceVersion, optionsType);

            if (options is ClientOptions clientOptions)
            {
                foreach (var globalConfigureOption in _globalOptions.CurrentValue.ConfigureOptionDelegates)
                {
                    globalConfigureOption(clientOptions, _serviceProvider);
                }
            }
            configuration?.Bind(options);
            return options;
        }
    }
}