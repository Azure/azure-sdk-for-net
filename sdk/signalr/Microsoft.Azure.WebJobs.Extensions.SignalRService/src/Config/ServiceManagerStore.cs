// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal sealed class ServiceManagerStore : IServiceManagerStore
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly AzureComponentFactory _azureComponentFactory;
        private readonly SignalROptions _options;
        private readonly IConfiguration _configuration;
        private readonly IEndpointRouter _router;
        private readonly ConcurrentDictionary<string, IInternalServiceHubContextStore> _store = new();

        public ServiceManagerStore(IConfiguration configuration, ILoggerFactory loggerFactory, AzureComponentFactory azureComponentFactory, IOptions<SignalROptions> options, IEndpointRouter router = null)
        {
            _loggerFactory = loggerFactory;
            _azureComponentFactory = azureComponentFactory;
            _options = options.Value;
            _configuration = configuration;
            _router = router;
        }

        public IInternalServiceHubContextStore GetOrAddByConnectionStringKey(string connectionStringKey)
        {
            if (string.IsNullOrWhiteSpace(connectionStringKey))
            {
                throw new ArgumentException($"'{nameof(connectionStringKey)}' cannot be null or whitespace", nameof(connectionStringKey));
            }
            return _store.GetOrAdd(connectionStringKey, CreateHubContextStore);
        }

        //test only
        public IInternalServiceHubContextStore GetByConfigurationKey(string connectionStringKey)
        {
            return _store.ContainsKey(connectionStringKey) ? _store[connectionStringKey] : null;
        }

        private IInternalServiceHubContextStore CreateHubContextStore(string connectionStringKey)
        {
            var serviceManagerOptionsSetup = new OptionsSetup(_configuration, _azureComponentFactory, connectionStringKey, _options);
            var serviceManagerBuilder = new ServiceManagerBuilder()
                // Does the actual configuration
                .WithOptions(serviceManagerOptionsSetup.Configure)
                .WithLoggerFactory(_loggerFactory)
                // Serves as a reload token provider only
                .WithConfiguration(new EmptyConfiguration(_configuration))
                .WithCallingAssembly();

            if (_options.MessagePackHubProtocol != null)
            {
                serviceManagerBuilder.AddHubProtocol(_options.MessagePackHubProtocol);
            }
            // Allow isolated-process runtimes such as JS, C#-isolated to enable MessagePack hub protocol
            else if (string.Equals(_configuration[Constants.AzureSignalRMessagePackHubProtocol], Constants.Enabled, StringComparison.InvariantCultureIgnoreCase))
            {
                serviceManagerBuilder.AddHubProtocol(new MessagePackHubProtocol());
            }

            AddWorkingInfo(serviceManagerBuilder, _configuration);
            if (_router != null)
            {
                serviceManagerBuilder.WithRouter(_router);
            }
            var serviceManager = serviceManagerBuilder.BuildServiceManager();
            return new ServiceCollection()
                .AddSingleton(serviceManager)
                .AddOptions()
                .AddSingleton<IConfigureOptions<SignatureValidationOptions>>(new SignatureValidationOptionsSetup(serviceManagerOptionsSetup.Configure))
                .AddSingleton<IOptionsChangeTokenSource<SignatureValidationOptions>>(new ConfigurationChangeTokenSource<SignatureValidationOptions>(_configuration))
                .AddSingleton<ServiceHubContextStore>()
                .BuildServiceProvider()
                .GetRequiredService<ServiceHubContextStore>();
        }

        public async ValueTask DisposeAsync()
        {
            foreach (var hubContextStore in _store.Values)
            {
                await hubContextStore.DisposeAsync().ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            DisposeAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }

        private static void AddWorkingInfo(ServiceManagerBuilder builder, IConfiguration configuration)
        {
            var workerRuntime = configuration[Constants.FunctionsWorkerRuntime];
            if (workerRuntime != null)
            {
                builder.AddUserAgent($" [{Constants.FunctionsWorkerProductInfoKey}={workerRuntime}]");
            }
        }
    }
}