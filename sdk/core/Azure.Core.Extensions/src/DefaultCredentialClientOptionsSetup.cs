// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Options;

namespace Azure.Core.Extensions
{
    internal class DefaultCredentialClientOptionsSetup<T> : IConfigureNamedOptions<AzureClientOptions<T>>
    {
        private readonly IOptions<AzureClientsGlobalOptions> _defaultOptions;

        public DefaultCredentialClientOptionsSetup(IOptions<AzureClientsGlobalOptions> defaultOptions)
        {
            _defaultOptions = defaultOptions;
        }

        public void Configure(AzureClientOptions<T> options)
        {
            if (options.CredentialFactory == null)
            {
                options.CredentialFactory = _defaultOptions.Value.Credential;
            }
        }

        public void Configure(string name, AzureClientOptions<T> options)
        {
            Configure(options);
        }
    }
}