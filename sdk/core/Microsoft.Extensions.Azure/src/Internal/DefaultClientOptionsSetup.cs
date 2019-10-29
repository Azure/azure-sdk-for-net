// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal class DefaultClientOptionsSetup<T> : IConfigureNamedOptions<T> where T : class
    {
        private readonly IOptions<AzureClientsGlobalOptions> _defaultOptions;
        private readonly IServiceProvider _serviceProvider;

        public DefaultClientOptionsSetup(IOptions<AzureClientsGlobalOptions> defaultOptions, IServiceProvider serviceProvider)
        {
            _defaultOptions = defaultOptions;
            _serviceProvider = serviceProvider;
        }

        public void Configure(T options)
        {
            if (options is ClientOptions clientOptions)
            {
                foreach (var globalConfigureOption in _defaultOptions.Value.ConfigureOptionDelegates)
                {
                    globalConfigureOption(clientOptions, _serviceProvider);
                }
            }
        }

        public void Configure(string name, T options)
        {
            Configure(options);
        }
    }
}