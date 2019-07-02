// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Options;

namespace Azure.Core.Extensions
{
    internal class DefaultClientOptionsSetup<T> : IConfigureNamedOptions<T> where T : ClientOptions
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
            foreach (var globalConfigureOption in _defaultOptions.Value.ConfigureOptions)
            {
                globalConfigureOption(options, _serviceProvider);
            }
        }

        public void Configure(string name, T options)
        {
            Configure(options);
        }
    }
}