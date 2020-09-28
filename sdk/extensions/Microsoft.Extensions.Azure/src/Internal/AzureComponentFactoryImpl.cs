// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal abstract class AzureComponentFactoryImpl: AzureComponentFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOptionsMonitor<AzureClientsGlobalOptions> _globalOptions;

        internal AzureComponentFactoryImpl(IOptionsMonitor<AzureClientsGlobalOptions> globalOptions, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _globalOptions = globalOptions;
        }

        /// <inheritdoc />
        public override TokenCredential CreateCredential(IConfiguration configuration)
        {
            return ClientFactory.CreateCredential(configuration) ?? _globalOptions.CurrentValue.CredentialFactory(_serviceProvider);
        }
    }
}