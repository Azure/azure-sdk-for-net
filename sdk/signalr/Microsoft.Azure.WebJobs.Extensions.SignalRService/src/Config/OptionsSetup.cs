// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class OptionsSetup : IConfigureOptions<ServiceManagerOptions>, IOptionsChangeTokenSource<ServiceManagerOptions>
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _azureComponentFactory;
        private readonly string _connectionStringKey;
        private readonly ILogger _logger;

        public OptionsSetup(IConfiguration configuration, ILoggerFactory loggerFactory, AzureComponentFactory azureComponentFactory, string connectionStringKey)
        {
            if (loggerFactory is null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (string.IsNullOrWhiteSpace(connectionStringKey))
            {
                throw new ArgumentException($"'{nameof(connectionStringKey)}' cannot be null or whitespace", nameof(connectionStringKey));
            }

            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _azureComponentFactory = azureComponentFactory;
            _connectionStringKey = connectionStringKey;
            _logger = loggerFactory.CreateLogger<OptionsSetup>();
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
            options.ServiceEndpoints = endpoints.ToArray();
            var serviceTransportTypeStr = _configuration[Constants.ServiceTransportTypeName];
            if (Enum.TryParse<ServiceTransportType>(serviceTransportTypeStr, out var transport))
            {
                options.ServiceTransportType = transport;
            }
            else if (string.IsNullOrWhiteSpace(serviceTransportTypeStr))
            {
                options.ServiceTransportType = ServiceTransportType.Transient;
                _logger.LogInformation($"{Constants.ServiceTransportTypeName} not set, using default {ServiceTransportType.Transient} instead.");
            }
            else
            {
                options.ServiceTransportType = ServiceTransportType.Transient;
                _logger.LogWarning($"Unsupported service transport type: {serviceTransportTypeStr}. Use default {ServiceTransportType.Transient} instead.");
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