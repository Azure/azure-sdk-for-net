//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace ServiceBus.Tests.TestHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json.Converters;

    public static class ServiceBusManagementHelper
    {
        internal const string ResourceGroupPrefix = "Default-ServiceBus-";
        internal const string NamespacePrefix = "sdk-Namespace-";
        internal const string AuthorizationRulesPrefix = "sdk-AuthRules-";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        internal const string QueuesPrefix = "sdk-Queues-";
        internal const string TopicPrefix = "sdk-Topics-";
        internal const string SubscritpitonPrefix = "sdk-Subscriptions-";

        public static ServiceBusManagementClient GetServiceBusManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                ServiceBusManagementClient nhManagementClient = context.GetServiceClient<ServiceBusManagementClient>(handlers: handler);
                return nhManagementClient;
            }

            return null;
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                ResourceManagementClient rManagementClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return rManagementClient;
            }

            return null;
        }

        public static string TryGetResourceGroup(this ResourceManagementClient resourceManagementClient, string location)
        {
            var resourceGroup =
                resourceManagementClient.ResourceGroups
                    .List().Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault(group => group.Name.Contains(""));

            return resourceGroup != null

                ? resourceGroup.Name
                : string.Empty;
        }
        
        public static void TryRegisterResourceGroup(this ResourceManagementClient resourceManagementClient, string location, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));
        }

        public static string GetLocationFromProvider(this ResourceManagementClient resourceManagementClient)
        {
            var providers = resourceManagementClient.Providers.Get("Microsoft.ServiceBus");
            var location = providers.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "namespaces")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();
            return location;
        }

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = RandomNumberGenerator.Create())
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }

        public static string ConvertObjectToJSon<T>(T obj)
        {
            return ConvertObjectToJSonAsync(obj);
        }

        public static string ConvertObjectToJSonAsync(object obj)
        {
            if (obj != null)
            {
                return (Task.Factory.StartNew(() => JsonConvert.SerializeObject(obj, SerializeMediaTypeFormatterSettings))).Result;
            }
            return String.Empty;
        }

        private static readonly JsonSerializerSettings SerializeMediaTypeFormatterSettings = new JsonSerializerSettings
        {
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Include,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter { CamelCaseText = false },
            },
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };

    }
}