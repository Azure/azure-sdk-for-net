// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.Media;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

namespace Media.Tests.Helpers
{
    public static class MediaManagementTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        // These should be filled in only if test tenant is true
        public static string certName = null;
        public static string certPassword = null;
        public static SkuName DefaultSkuName = SkuName.StandardGRS;
        public static Kind DefaultKind = Kind.Storage;
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "West US 2";

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (IsTestTenant)
            {
                return null;
            }
            else
            {
                handler.IsPassThrough = true;
                ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return resourcesClient;
            }
        }

        public static AzureMediaServicesClient GetMediaManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            AzureMediaServicesClient mediaClient;
            if (IsTestTenant)
            {
                return null;
            }
            else
            {
                handler.IsPassThrough = true;
                mediaClient = context.GetServiceClient<AzureMediaServicesClient>(handlers: handler);
            }
            return mediaClient;
        }

        public static StorageManagementClient GetStorageManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (IsTestTenant)
            {
                return null;
            }
            else
            {
                handler.IsPassThrough = true;
                StorageManagementClient storageClient = context.GetServiceClient<StorageManagementClient>(handlers: handler);
                return storageClient;
            }
        }

        private static HttpClientHandler GetHandler()
        {
#if DNX451
            if (Handler == null)
            {
                //talk to yugangw-msft, if the code doesn't work under dnx451 (same with net451)
                X509Certificate2 cert = new X509Certificate2(certName, certPassword);
                Handler = new System.Net.Http.WebRequestHandler();
                ((WebRequestHandler)Handler).ClientCertificates.Add(cert);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            }
#endif
            return Handler;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient, string location)
        {
            var rgname = TestUtilities.GenerateName("rg");

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = location
                    });
            }

            return rgname;
        }

        public static void DeleteResourceGroup(ResourceManagementClient resourcesClient, string resourceGroupName)
        {
            if (!IsTestTenant)
            {
                resourcesClient.ResourceGroups.Delete(resourceGroupName);
            }
        }

        public static StorageAccount CreateStorageAccount(StorageManagementClient storageClient, string rgname, string location)
        {
            var stoName = TestUtilities.GenerateName("sto");

            if (!IsTestTenant)
            {
                return storageClient.StorageAccounts.Create(rgname, stoName, new StorageAccountCreateParameters
                {
                    Location = location,
                    Tags = DefaultTags,
                    Sku = new Sku { Name = DefaultSkuName },
                    Kind = DefaultKind,
                });
            }
            return null;
        }

        public static void DeleteStorageAccount(StorageManagementClient storageClient, string rgname, string accountName)
        {
            if (!IsTestTenant)
            {
                storageClient.StorageAccounts.Delete(rgname, accountName);
            }
        }

        public static string TryGetLocation(ResourceManagementClient resourceClient, string preferedLocationName = null)
        {
            var providers = resourceClient.Providers.List();
            var provider = providers.FirstOrDefault(x => x.NamespaceProperty.Contains("Microsoft.Media"));
            if (provider == null)
            {
                return string.Empty;
            }

            var resourceTypes = provider.ResourceTypes;
            if (resourceTypes == null || resourceTypes.Count == 0)
            {
                return string.Empty;
            }

            var locations = resourceTypes.Where(t => t.ResourceType == "mediaservices").First().Locations;
            if (locations == null || locations.Count == 0)
            {
                return string.Empty;
            }

            if (preferedLocationName == null)
            {
                return locations.First();
            }

            var preferedLocation = locations.FirstOrDefault(x => x.Contains(preferedLocationName));
            return preferedLocation ?? locations.First();
        }
    }
}
