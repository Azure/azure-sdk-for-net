// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Sets up <see cref="ServiceManagerOptions"/> from <see cref="IConfiguration"/>.
    /// </summary>
    internal class OptionsSetupFromConfig : IConfigureOptions<ServiceManagerOptions>, IOptionsChangeTokenSource<ServiceManagerOptions>
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _azureComponentFactory;
        private readonly string _connectionStringKey;

        public OptionsSetupFromConfig(IConfiguration configuration, AzureComponentFactory azureComponentFactory, string connectionStringKey)
        {
            if (string.IsNullOrWhiteSpace(connectionStringKey))
            {
                throw new ArgumentException($"'{nameof(connectionStringKey)}' cannot be null or whitespace", nameof(connectionStringKey));
            }

            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _azureComponentFactory = azureComponentFactory;
            _connectionStringKey = connectionStringKey;
        }

        public string Name => Options.DefaultName;

        public void Configure(ServiceManagerOptions options)
        {
            options.ConnectionString = _configuration.GetConnectionString(_connectionStringKey) ?? _configuration[_connectionStringKey];
            var endpoints = _configuration.GetSection(Constants.AzureSignalREndpoints).GetEndpoints(_azureComponentFactory);
            // Fall back to use a section to configure Azure identity
            if (options.ConnectionString == null && _configuration.GetSection(_connectionStringKey).TryGetNamedEndpointFromIdentity(_azureComponentFactory, out var endpoint))
            {
                endpoint.Name = string.Empty;
                endpoints = endpoints.Append(endpoint);
            }
            var endpointArray = endpoints.ToArray();
            if (endpointArray.Length > 0)
            {
                options.ServiceEndpoints = endpoints.ToArray();
            }
            //otherwise don't override the value come from SignalROptions

            if (_configuration[Constants.ServiceTransportTypeName] is not null)
            {
                options.ServiceTransportType = _configuration.GetValue<ServiceTransportType>(Constants.ServiceTransportTypeName);
            }

            //make connection more stable
            options.ConnectionCount = 3;
            options.ProductInfo = GetProductInfo();
        }

        public IChangeToken GetChangeToken()
        {
            return _configuration.GetReloadToken();
        }

        private string GetProductInfo()
        {
            var workerRuntime = _configuration[Constants.FunctionsWorkerRuntime];
            var sdkProductInfo = ProductInfo.GetProductInfo();
            return $"{sdkProductInfo} [{Constants.FunctionsWorkerProductInfoKey}={workerRuntime}]";
        }
    }
}