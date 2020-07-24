// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace NotificationHubs.Tests.TestHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.NotificationHubs;
    using Microsoft.Azure.Management.NotificationHubs.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json.Converters;

    public static class NotificationHubsManagementHelper
    {
        internal const string DefaultLocation = "South Central US";
        internal const string ResourceGroupPrefix = "TestRg-NH";
        internal const string NamespacePrefix = "HydraNH-Namespace";
        internal const string NotificationHubPrefix = "HydraNH-NotificationHub";
        internal const string AuthorizationRulesPrefix = "HydraNH-Authrules";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";

        public static NotificationHubsManagementClient GetNotificationHubsManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            { 
                handler.IsPassThrough = true;
                NotificationHubsManagementClient nhManagementClient = context.GetServiceClient<NotificationHubsManagementClient>(handlers: handler);
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

        private static void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }

        public static string TryGetResourceGroup(this ResourceManagementClient resourceManagementClient, string location)
        {
            var resourceGroup =
                resourceManagementClient.ResourceGroups
                    .List().Where(group => string.IsNullOrWhiteSpace(location) || group.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault(group => group.Name.Contains(ResourceGroupPrefix));

            return resourceGroup != null

                ? resourceGroup.Name
                : string.Empty;
        }
        
        public static void TryRegisterResourceGroup(this ResourceManagementClient resourceManagementClient, string location, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup(location));
        }

        public static void TryDeleteResourceGroup(this ResourceManagementClient resourceManagementClient, string resourceGroupName)
        {
            resourceManagementClient.ResourceGroups.Delete(resourceGroupName);
        }

        public static void TryCreateNamespace(
            this NotificationHubsManagementClient client,
            string resourceGroupName,
            string namespaceName,
            string location,
            string scaleUnit = null)
        {
            var namespaceParameter = new NamespaceCreateOrUpdateParameters()
            {
                Location = location,
                NamespaceType = NamespaceType.NotificationHub
            };

            if (!string.IsNullOrEmpty(scaleUnit))
            {
                namespaceParameter.ScaleUnit = scaleUnit;
            }

            client.Namespaces.CreateOrUpdate(
                resourceGroupName,
                namespaceName, namespaceParameter
               );

            var response = client.Namespaces.Get(resourceGroupName, namespaceName);
            ThrowIfTrue(!response.Name.Equals(namespaceName), string.Format("Namespace name is not equal to {0}", namespaceName));
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