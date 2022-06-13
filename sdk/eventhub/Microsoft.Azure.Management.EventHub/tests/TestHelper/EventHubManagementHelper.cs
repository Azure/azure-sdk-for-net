// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace EventHub.Tests.TestHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.KeyVault;
    using Microsoft.Azure.Management.Network;
    using Azure.Security.KeyVault.Secrets;
    using Microsoft.Azure.Management.ManagedServiceIdentity;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json.Converters;
    using Xunit;

    public static class EventHubManagementHelper
    {
        internal const string ResourceGroupPrefix = "Default-ResourceGroup-";
        internal const string ClusterPrefix = "Default-ClusterName-Can-Be-Deleted";
        internal const string IdentityPrefix = "Default-Identity-";
        internal const string ApplicationGroupPrefix = "Dfault-ApplicationGroup-";
        internal const string SASKeyPrefix = "Dfault-SASKey-";
        internal const string NamespacePrefix = "sdk-NS1-";
        internal const string AuthorizationRulesPrefix = "sdk-Authrules-";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";
        internal const string EventHubPrefix = "sdk-EventHub-";
        internal const string ConsumerGroupPrefix = "sdk-ConsumerGroup-";
        internal const string DisasterRecoveryPrefix = "sdk-DisasterRecovery-";
        internal const string KeyVaultePrefix = "sdk-KeyVault-";
        internal const string SchemaPrefix = "sdk-Schema-";
        internal const string PrivateEndpointPrefix = "Default-PrivateEndpoint-";
        internal const string PrivateLinkConnectionPrefix = "Default-PrivateEndpointConnection-";

        internal const string ResourceGroupCluster = "v-ajnavtest";
        internal const string TestClusterName = "PMTestCluster1";


        public static EventHubManagementClient GetEventHubManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                EventHubManagementClient nhManagementClient = context.GetServiceClient<EventHubManagementClient>(handlers: handler);
                
                return nhManagementClient;
            }

            return null;
        }
        

        public static KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                KeyVaultManagementClient keyValutManagementClient = context.GetServiceClient<KeyVaultManagementClient>(handlers: handler);
                return keyValutManagementClient;
            }

            return null;
        }

        public static NetworkManagementClient GetNetworkManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                NetworkManagementClient networkManagementClient = context.GetServiceClient<NetworkManagementClient>(handlers: handler);
                return networkManagementClient;
            }

            return null;
        }

        public static ManagedServiceIdentityClient GetIdentityManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
                ManagedServiceIdentityClient identityManagementClient = context.GetServiceClient<ManagedServiceIdentityClient>(handlers: handler);
                return identityManagementClient;
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
            var providers = resourceManagementClient.Providers.Get("Microsoft.EventHub");
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