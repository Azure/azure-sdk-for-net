// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal static class DependencyInjectionExtensions
    {
        private const string HubProtocolError = "It's invalid to configure hub protocol on Azure Functions runtime V2. Newtonsoft.Json protocol will be used.";

        public static IServiceCollection SetHubProtocol(this IServiceCollection services, IConfiguration configuration)
        {
            var hubProtocolConfig = configuration[Constants.AzureSignalRHubProtocol];
            if (hubProtocolConfig is not null && Environment.Version.Major == 4)
            {
                // .Net Core 2.x is always Newtonsoft.Json.
                throw new InvalidOperationException(HubProtocolError);
            }
#if NETCOREAPP3_1
            //indicates Newtonsoft, camcelCase
            if (configuration.GetValue(Constants.AzureSignalRNewtonsoftCamelCase, false))
            {
                // The default options is camelCase.
                return services.AddNewtonsoftHubProtocol(o => { });
            }

            if (!DotnetRuntime(configuration) || Enum.TryParse<HubProtocol>(hubProtocolConfig, out var result) && result == HubProtocol.NewtonsoftJson)
            {
                // Reset the options to keep backward compatibility.
                return services.AddNewtonsoftHubProtocol(o => o.PayloadSerializerSettings = new JsonSerializerSettings());
            }

            //If hubProtocolConfig is SystemTextJson for .Net Core 3.1, do nothing, as transient mode doesn't accept it and persisent mode is already System.Text.Json by default.
#endif
            return services;
        }

        private static bool DotnetRuntime(IConfiguration configuration)
        {
            var workerRuntime = configuration[Constants.FunctionsWorkerRuntime];
            //unit test environment
            return workerRuntime == null || workerRuntime == Constants.DotnetWorker;
        }
    }
}