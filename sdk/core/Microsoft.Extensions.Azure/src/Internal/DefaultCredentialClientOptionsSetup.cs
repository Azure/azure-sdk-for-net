// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal class DefaultCredentialClientOptionsSetup<T> : IConfigureNamedOptions<AzureClientCredentialOptions<T>>
    {
        private readonly IOptions<AzureClientsGlobalOptions> _defaultOptions;

        public DefaultCredentialClientOptionsSetup(IOptions<AzureClientsGlobalOptions> defaultOptions)
        {
            _defaultOptions = defaultOptions;
        }

        public void Configure(AzureClientCredentialOptions<T> options)
        {
            if (options.CredentialFactory == null)
            {
                options.CredentialFactory = _defaultOptions.Value.CredentialFactory;
            }
        }

        public void Configure(string name, AzureClientCredentialOptions<T> options)
        {
            Configure(options);
        }
    }
}