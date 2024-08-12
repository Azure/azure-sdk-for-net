// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class OptionsSetup
    {
        private readonly IConfiguration _configuration;
        private readonly Action<ServiceManagerOptions> _configureServiceManagerOptions;

        public OptionsSetup(IConfiguration configuration, AzureComponentFactory azureComponentFactory, string connectionStringKey, SignalROptions optionsFromCode)
        {
            if (string.IsNullOrWhiteSpace(connectionStringKey))
            {
                throw new ArgumentException($"'{nameof(connectionStringKey)}' cannot be null or whitespace", nameof(connectionStringKey));
            }

            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _configureServiceManagerOptions = options =>
            {
                // Apply options from code.
                options.ServiceEndpoints = optionsFromCode.ServiceEndpoints?.ToArray();
                options.ServiceTransportType = optionsFromCode.ServiceTransportType;
                options.UseJsonObjectSerializer(optionsFromCode.JsonObjectSerializer);
                options.RetryOptions = optionsFromCode.RetryOptions;
                if (optionsFromCode.HttpClientTimeout.HasValue)
                {
                    options.HttpClientTimeout = optionsFromCode.HttpClientTimeout.Value;
                }

                // Apply options from configuration
                if (_configuration.TryGetJsonObjectSerializer(out var serializer))
                {
                    options.UseJsonObjectSerializer(serializer);
                }
                if (_configuration.GetConnectionString(connectionStringKey) != null || _configuration[connectionStringKey] != null)
                {
                    options.ConnectionString = _configuration.GetConnectionString(connectionStringKey) ?? _configuration[connectionStringKey];
                }
                var endpoints = _configuration.GetSection(Constants.AzureSignalREndpoints).GetEndpoints(azureComponentFactory);

                // when the configuration is in the style: AzureSignalRConnectionString:serviceUri = https://xxx.service.signalr.net , we see the endpoint as unnamed.
                if (options.ConnectionString == null && _configuration.GetSection(connectionStringKey).TryGetEndpointFromIdentity(azureComponentFactory, out var endpoint, isNamed: false))
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

                var retryOptions = _configuration.GetSection(Constants.AzureSignalRRetry).Get<ServiceManagerRetryOptions>();
                if (retryOptions != null)
                {
                    options.RetryOptions = retryOptions;
                }

                var httpClientTimeout = _configuration.GetSection(Constants.AzureSignalRHttpClientTimeout).Get<TimeSpan>();
                if (httpClientTimeout != default)
                {
                    options.HttpClientTimeout = httpClientTimeout;
                }
            };
        }

        public Action<ServiceManagerOptions> Configure => _configureServiceManagerOptions;
    }
}