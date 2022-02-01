// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;
using Microsoft.Azure.SignalR;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// A helper class to parse <see cref="ServiceEndpoint"/> from configuration.
    /// </summary>
    internal static class IConfigurationExtensions
    {
        public static IEnumerable<ServiceEndpoint> GetEndpoints(this IConfiguration config, AzureComponentFactory azureComponentFactory)
        {
            foreach (var child in config.GetChildren())
            {
                if (child.TryGetNamedEndpointFromIdentity(azureComponentFactory, out var endpoint))
                {
                    yield return endpoint;
                    continue;
                }

                foreach (var item in child.GetNamedEndpointsFromConnectionString())
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<ServiceEndpoint> GetNamedEndpointsFromConnectionString(this IConfigurationSection section)
        {
            var endpointName = section.Key;
            if (section.Value != null)
            {
                yield return new ServiceEndpoint(section.Key, section.Value);
            }

            if (section["primary"] != null)
            {
                yield return new ServiceEndpoint(section["primary"], EndpointType.Primary, endpointName);
            }

            if (section["secondary"] != null)
            {
                yield return new ServiceEndpoint(section["secondary"], EndpointType.Secondary, endpointName);
            }
        }

        public static bool TryGetNamedEndpointFromIdentity(this IConfigurationSection section, AzureComponentFactory azureComponentFactory, out ServiceEndpoint endpoint)
        {
            var text = section["ServiceUri"];
            if (text != null)
            {
                var key = section.Key;
                var value = section.GetValue("Type", EndpointType.Primary);
                var credential = azureComponentFactory.CreateTokenCredential(section);
                endpoint = new ServiceEndpoint(new Uri(text), credential, value, key);
                return true;
            }

            endpoint = null;
            return false;
        }

        public static bool TryGetJsonObjectSerializer(this IConfiguration configuration, out ObjectSerializer serializer)
        {
            //indicates Newtonsoft, camcelCase
            if (configuration.GetValue(Constants.AzureSignalRNewtonsoftCamelCase, false))
            {
                serializer = new NewtonsoftJsonObjectSerializer(new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                return true;
            }

            if (!configuration.OnDotnetInProcessRuntime())
            {
                serializer = new NewtonsoftJsonObjectSerializer();
                return true;
            }

            var hubProtocolConfig = configuration[Constants.AzureSignalRHubProtocol];
            if (hubProtocolConfig is not null)
            {
                serializer = Enum.Parse(typeof(HubProtocol), hubProtocolConfig, true) switch
                {
                    HubProtocol.NewtonsoftJson => new NewtonsoftJsonObjectSerializer(),
                    HubProtocol.SystemTextJson => new JsonObjectSerializer(),
                    _ => throw new NotSupportedException($"The {Constants.AzureSignalRHubProtocol} setting value '{hubProtocolConfig}' is not supported."),
                };
                return true;
            }
            serializer = null;
            return false;
        }

        private static bool OnDotnetInProcessRuntime(this IConfiguration configuration)
        {
            var workerRuntime = configuration[Constants.FunctionsWorkerRuntime];
            //unit test environment
            return workerRuntime == null || workerRuntime == Constants.DotnetWorker;
        }
    }
}
