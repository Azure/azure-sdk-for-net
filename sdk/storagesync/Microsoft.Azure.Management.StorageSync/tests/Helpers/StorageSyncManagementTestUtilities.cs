// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.Azure.Management.Tests.Common;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;
using BaseStorageSyncResource = Microsoft.Azure.Management.StorageSync.Models.Resource;

namespace Microsoft.Azure.Management.StorageSync.Tests
{
    public interface IStorageSyncManagementTestUtilities
    {
        object GetDefaultParameters<T>();
        void VerifyProperties<T>();
    }
    public static class StorageSyncManagementTestUtilities
    {
        public static bool IsTestTenant = false;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "central us euap";
        public static string DefaultRGLocation = IsTestTenant ? null : "eastus2";
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            };

        public static string CreateResourceGroup(IResourceManagementClient resourcesClient)
        {
            const string testPrefix = "res";
            var rgname = TestUtilities.GenerateName(testPrefix);

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = DefaultRGLocation
                    });
            }

            return rgname;
        }

        public static void RemoveResourceGroup(IResourceManagementClient resourcesClient, string rgName)
        {
            if (!IsTestTenant)
            {
                resourcesClient.ResourceGroups.Delete(rgName);
            }

        }

        public static StorageSyncManagementClient GetStorageSyncManagementClient(MockContext context, RecordedDelegatingHandler handler = null)
        {

            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            var client = context.GetServiceClient<StorageSyncManagementClient>(handlers:
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
            return client;
        }

        public static IResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return context.GetServiceClient<ResourceManagementClient>(handlers: handler);
        }

        public static NetworkManagementClient GetNetworkManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return context.GetServiceClient<NetworkManagementClient>(handlers: handler);
        }

        public static StorageManagementClient GetStorageManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return context.GetServiceClient<StorageManagementClient>(handlers: handler);
        }

        public static void WaitSeconds(double seconds)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(seconds));
            }
        }

        public static void WaitMinutes(double minutes)
        {
            WaitSeconds(minutes * 60);
        }

        public static string GenerateName(string prefix = null,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName="GenerateName_failed")
        {
            return HttpMockServer.GetAssetName(methodName, prefix);
        }

        public static void VerifyStorageSyncServiceProperties(StorageSyncService resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Location);
            Assert.NotNull(resource.Name);

            VerifySystemDataProperties(resource);

            if (useDefaults)
            {
                Assert.Equal(StorageSyncManagementTestUtilities.DefaultLocation, resource.Location);
                Assert.NotNull(resource.Tags);
                Assert.Equal(2, resource.Tags.Count);
                Assert.Equal("value1", resource.Tags["key1"]);
                Assert.Equal("value2", resource.Tags["key2"]);
            }
        }

        public static void VerifySyncGroupProperties(SyncGroup resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Name);

            VerifySystemDataProperties(resource);

            // Enable SyncGroup tags when this feature is completed as SyncGroupMetadata
            if (useDefaults)
            {
            }
        }

        public static RecallActionParameters GetDefaultRecallActionParameters()
        {
            return new RecallActionParameters()
            {
                Pattern = null,
                RecallPath = null
            };
        }

        public static void VerifyCloudEndpointProperties(CloudEndpoint resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Name);

            VerifySystemDataProperties(resource);

            if (useDefaults)
            {
            }
        }

        public static void VerifyServerEndpointProperties(ServerEndpoint resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Name);

            VerifySystemDataProperties(resource);

            if (useDefaults)
            {
                var defaults = GetDefaultServerEndpointParameters(resource.ServerResourceId);
                Assert.Equal(resource.ServerResourceId, defaults.ServerResourceId);
                Assert.Equal(resource.ServerLocalPath, defaults.ServerLocalPath);
                Assert.Equal(resource.CloudTiering, defaults.CloudTiering);
                Assert.Equal(resource.VolumeFreeSpacePercent, defaults.VolumeFreeSpacePercent);
            }
        }

        public static void VerifyServerEndpointUpdateProperties(ServerEndpoint resource, bool useDefaults)
        {
            VerifyServerEndpointProperties(resource, useDefaults: false);

            if (useDefaults)
            {
                var defaults = GetDefaultServerEndpointUpdateParameters();
                Assert.Equal(resource.CloudTiering, defaults.CloudTiering);
                Assert.Equal(resource.VolumeFreeSpacePercent, defaults.VolumeFreeSpacePercent);
            }
        }

        public static void VerifyRegisteredServerProperties(RegisteredServer resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Name);

            VerifySystemDataProperties(resource);

            if (useDefaults)
            {
            }
        }

        public static void VerifySystemDataProperties(BaseStorageSyncResource resource)
        {
            Assert.NotNull(resource);

            Assert.NotNull(resource.SystemData);
            Assert.NotNull(resource.SystemData.CreatedAt);
            Assert.NotEqual(default(DateTime), resource.SystemData.CreatedAt.Value);
            Assert.NotNull(resource.SystemData.CreatedBy);
            Assert.NotNull(resource.SystemData.CreatedByType);
            Assert.NotNull(resource.SystemData.LastModifiedAt);
            Assert.NotEqual(default(DateTime), resource.SystemData.LastModifiedAt.Value);
            Assert.NotNull(resource.SystemData.LastModifiedBy);
            Assert.NotNull(resource.SystemData.LastModifiedByType);
        }

        public static StorageSyncServiceCreateParameters GetDefaultStorageSyncServiceParameters()
        {
            return new StorageSyncServiceCreateParameters
            {
                Location = DefaultLocation,
                Tags = DefaultTags
            };
        }

        public static StorageSyncServiceUpdateParameters GetDefaultStorageSyncServiceUpdateParameters()
        {
            return new StorageSyncServiceUpdateParameters
            {
                Tags = DefaultTags
            };
        }

        public static SyncGroupCreateParameters GetDefaultSyncGroupParameters()
        {
            return new SyncGroupCreateParameters
            {
            };
        }

        // Note: Secondary certificate must be different from primary certificate.
        internal static string GetSecondaryCertificate()
        {

            return "MIIDLjCCAhagAwIBAgIJAKqaSvweKxbYMA0GCSqGSIb3DQEBDQUAMB0xGzAZBgNVBAMTEmxvYWRUZXN0U2VydmVyQ2VydDAeFw0yMjAzMDMyMDAxMzdaFw0yMzEwMjUyMDAxMzdaMB0xGzAZBgNVBAMTEmxvYWRUZXN0U2VydmVyQ2VydDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANCAM8pAC6Xb3f9ZoqiSxyi6Ul4gWtdhelgy6xC4M0fn3iYW1/DL3qOdoD2x6fVFW2LgYXWl81yGsCSiP/XPhr0FzNHusKFbKWlygtIhUlCaPl5AageVpL2wHofRwRFxcpdcw9o5/ekoM8SsP21uU9L24+BZwanNXPvC7QHO0r+mxu0hakgWLrkGB6gWJ06jQ5ePyXhQKdTSB28RJjim6kl5PmzG6aZyi5GBWbODXij8y6W+jv8I5bUbBKWWzyuQC7bwpw59j0atGTWTcPEjq+wfY4UNAjHK1sffZAzsAKqmNofW4Rl08uYv8IKKkwNtaKmAQ1P6NfiTrOf5NGWASwkCAwEAAaNxMG8wDgYDVR0PAQH/BAQDAgeAMB8GA1UdJQQYMBYGCCsGAQUFBwMCBgorBgEEAYI3CgMMMB0GA1UdEQQWMBSCEmxvYWRUZXN0U2VydmVyQ2VydDAdBgNVHQ4EFgQU0Mp0xx9aA/Uf4H8TTIANX7F0QB8wDQYJKoZIhvcNAQENBQADggEBAJ9U4lg4UZQrGlJdYC+te8hpsAZM+WEAaoE3qq8XkGg7DJVjha4wMIDqaG6Xa9CsjGEs+tvc948L8PoHJbhh1uOAtoMAEwYmuQWevJCfsKjCeOMJbbUdKSd7Wwi5NfersdTrzEiRxIU4kQLc52nxfDotq26PZQyUv2cmzlXh+0lSeZuCNCI7Ko9tvmaFGIpt6F0kdSkwjbqCRPQwtiRHpvSmAVsrtvxm3Gxdnf2EL2jmI425uXSiQw8SRuKKmGLiUK68f3mstgfuqmk1TRuR5NWU0lyUmBB3o/ma9RDahUW/ZiHvXBhH9Pof3/Qm0HUrw8ll/9rMnZIEFvzdyyrc6J8=";
        }

        public static CloudEndpointCreateParameters GetDefaultCloudEndpointParameters()
        {
            return new CloudEndpointCreateParameters
            {
                StorageAccountResourceId = "/subscriptions/e29c162a-d1d4-4cc3-8295-80057c1f4bd9/resourceGroups/SDKTestRG/providers/Microsoft.Storage/storageAccounts/sadotnetsdktests1",
                AzureFileShareName = "afsfileshare1",
                StorageAccountTenantId = "0483643a-cb2f-462a-bc27-1a270e5bdc0a"
            };
        }
        public static ServerEndpointUpdateParameters GetDefaultServerEndpointUpdateParameters()
        {
            return new ServerEndpointUpdateParameters
            {
                CloudTiering = "On",
                VolumeFreeSpacePercent = 50,
            };
        }

        public static ServerEndpointCreateParameters GetDefaultServerEndpointParameters(string serverResourceId)
        {
            return new ServerEndpointCreateParameters
            {
                ServerLocalPath = "D:\\test2",
                CloudTiering = "Off",
                VolumeFreeSpacePercent = 0,
                ServerResourceId = serverResourceId,
            };
        }

        public static RegisteredServerCreateParameters GetDefaultRegisteredServerParameters(Guid serverId)
        {
            return new RegisteredServerCreateParameters
            {
                ServerCertificate = "MIIDLTCCAhWgAwIBAgIIFwE9ZkrKVvcwDQYJKoZIhvcNAQENBQAwHTEbMBkGA1UEAxMSbG9hZFRlc3RTZXJ2ZXJDZXJ0MB4XDTIyMDEyODAwMTAyOVoXDTIzMDkyMTAwMTAyOVowHTEbMBkGA1UEAxMSbG9hZFRlc3RTZXJ2ZXJDZXJ0MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqqGyn6lGVTEiWIaW0stbLIepHdDY11H3e9ox6Hwx889ooTxSLTm0uIDmD3SzeKTLhkLOiRwPCiVxRDmrA4jzREfxIN1md6oTAx4J1G0KRxOfyjqTNdOZlJg+xyJeV/zz7ulbySPVasWoFJtK84llpaMrbQc3ZTHDB18knaF25FnZNut5y56AD9iSDAI0zi77YwgLrvKnq1yB0Cxoakk66EBFGyBpQzO0mQcUcw3F17FLUvdd+necjz3C/HSertrkOa805Kj+2nXxDkMxdQTkY6aUG5XoDNI8SuMxrYEA3g2IPbqsVUCrDz9QF1MWfsvNtM4pTfcBrzKnCgxIQ5fiyQIDAQABo3EwbzAOBgNVHQ8BAf8EBAMCB4AwHwYDVR0lBBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwHQYDVR0RBBYwFIISbG9hZFRlc3RTZXJ2ZXJDZXJ0MB0GA1UdDgQWBBT+HpKL9aiuaF38wBbncHo0qDBGpzANBgkqhkiG9w0BAQ0FAAOCAQEAqeF7KI7NAfZN9z5UY4YmR1H2315eAQi6YtKGpAqg3JqLN/4kuYuivDv0hA3xmzZ+VVr2Vf42cjY7LT5nqGcY5bZzzhNhIPTSXtWQsGUXoWAaTsh7BM+xQGkuFIhig3gox9hZV+Lh0mzmVnwDxZLrrSGGTyZ+lRGe2NnOdm5NcehipGnoxMEvPZRpaOGAn2aq5z/ZZSvU6e8c/9A8CjlnteyT9IRI9kmfX/QKfP1Y4BtVcUvWGJE0sWxssC9BimWqyGFHaPxR2hO8g0E6+GNBMggCUw/tfM04Ei22fgbixFlOPcWVDS2Q3iwoMs8P8nKT717UVFa0nYp36hXZ+SiDWA==",
                AgentVersion = "15.0.0.0",
                ServerOSVersion = "10.0.14393.0",
                LastHeartBeat = "\"2021-06-10T20:05:02.5134384Z\"",
                ServerRole = "Standalone",
                ServerId = $"\"{serverId}\"",
                FriendlyName = "myserver.ntdev.corp.microsoft.com"
            };
        }

    }
}