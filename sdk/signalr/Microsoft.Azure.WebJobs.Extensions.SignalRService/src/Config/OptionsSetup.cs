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
    internal class OptionsSetup : IConfigureOptions<ServiceManagerOptions>, IOptionsChangeTokenSource<ServiceManagerOptions>
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _azureComponentFactory;
        private readonly string _connectionStringKey;

        public OptionsSetup(IConfiguration configuration, AzureComponentFactory azureComponentFactory, string connectionStringKey)
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
            if (_configuration.TryGetJsonObjectSerializer(out var serializer))
            {
                options.UseJsonObjectSerializer(serializer);
            }

            if (_configuration.GetConnectionString(_connectionStringKey) != null || _configuration[_connectionStringKey] != null)
            {
                options.ConnectionString = _configuration.GetConnectionString(_connectionStringKey) ?? _configuration[_connectionStringKey];
            }

            var endpoints = _configuration.GetSection(Constants.AzureSignalREndpoints).GetEndpoints(_azureComponentFactory);

            // when the configuration is in the style: AzureSignalRConnectionString:serviceUri = https://xxx.service.signalr.net , we see the endpoint as unnamed.
            if (options.ConnectionString == null && _configuration.GetSection(_connectionStringKey).TryGetEndpointFromIdentity(_azureComponentFactory, out var endpoint, isNamed: false))
            {
                endpoints = endpoints.Append(endpoint);
            }
            if (endpoints.Any())
            {
                options.ServiceEndpoints = endpoints.ToArray();
            }
            var serviceTransportTypeStr = _configuration[Constants.ServiceTransportTypeName];
            if (Enum.TryParse<ServiceTransportType>(serviceTransportTypeStr, out var transport))
            {
                options.ServiceTransportType = transport;
            }
            else if (!string.IsNullOrWhiteSpace(serviceTransportTypeStr))
            {
                throw new InvalidOperationException($"Invalid service transport type: {serviceTransportTypeStr}.");
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