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
        public static string DefaultLocation = IsTestTenant ? null : "west europe";
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

            // Enable SyncGroup tags when this feature is completed as SyncGroupMetadata
            if (useDefaults)
            {
                //    Assert.NotNull(resource.Tags);
                //    Assert.Equal(2, resource.Tags.Count);
                //    Assert.Equal("value1", resource.Tags["key1"]);
                //    Assert.Equal("value2", resource.Tags["key2"]);
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

            if (useDefaults)
            {
                //    Assert.NotNull(resource.Tags);
                //    Assert.Equal(2, resource.Tags.Count);
                //    Assert.Equal("value1", resource.Tags["key1"]);
                //    Assert.Equal("value2", resource.Tags["key2"]);
            }
        }

            public static void VerifyServerEndpointProperties(ServerEndpoint resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Name);

            if (useDefaults)
            {
                var defaults = GetDefaultServerEndpointParameters(resource.ServerResourceId);
                Assert.Equal(resource.ServerResourceId, defaults.ServerResourceId);
                Assert.Equal(resource.ServerLocalPath, defaults.ServerLocalPath);
                Assert.Equal(resource.CloudTiering, defaults.CloudTiering);
                Assert.Equal(resource.VolumeFreeSpacePercent, defaults.VolumeFreeSpacePercent);
               //    Assert.NotNull(resource.Tags);
                //    Assert.Equal(2, resource.Tags.Count);
                //    Assert.Equal("value1", resource.Tags["key1"]);
                //    Assert.Equal("value2", resource.Tags["key2"]);
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

            if (useDefaults)
            {
            //    Assert.NotNull(resource.Tags);
            //    Assert.Equal(2, resource.Tags.Count);
            //    Assert.Equal("value1", resource.Tags["key1"]);
            //    Assert.Equal("value2", resource.Tags["key2"]);
            }
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
                Location = DefaultLocation,
                Tags = DefaultTags
            };
        }

        public static CloudEndpointCreateParameters GetDefaultCloudEndpointParameters()
        {
            return new CloudEndpointCreateParameters
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                StorageAccountResourceId = "/subscriptions/8aba3d53-2c5e-4479-bb0d-5a7bed16360e/resourcegroups/storagesyncsdkwesteurope/providers/Microsoft.Storage/storageAccounts/storagesyncsdkwesteurope",
                StorageAccountShareName = "tempsdkfileshare5",
                StorageAccountTenantId = "\"72f988bf-86f1-41af-91ab-2d7cd011db47\""
            };
        }
        public static ServerEndpointUpdateParameters GetDefaultServerEndpointUpdateParameters()
        {
            return new ServerEndpointUpdateParameters
            {
                CloudTiering = "On",
                VolumeFreeSpacePercent = 50,
                Tags = DefaultTags
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
                Location = DefaultLocation,
                Tags = DefaultTags
            };
            /*
             {
  "properties": {
    "serverLocalPath": "D:\\test1",
    "cloudTiering": "Off",
    "serverResourceId": "/subscriptions/1d16f9b3-bbe3-48d4-930a-27a74dca003b/resourceGroups/res9305/providers/microsoft.storagesync/storageSyncServices/sss-sepcreate2540/registeredServers/a852d5e6-115d-4885-a009-f5c3bb676c5d"
  },
  "location": "West Europe",
  "tags": {}
}
             */
        }

        public static RegisteredServerCreateParameters GetDefaultRegisteredServerParameters(Guid serverId)
        {
            return new RegisteredServerCreateParameters
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                ServerCertificate = "\"MIIDEDCCAfigAwIBAgIQUB7fWz9pbodGHZwk+aVTRjANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MDczMDIyNDc0NVoXDTE5MDczMTIyNDc0NVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALssKhJeisUWQGU1as0mZm7PO81SQPUnK2uE0wTaXpJYlsEn+J9GrSKGYnwUVsdHsvku8AWzvVTeOM3lg7Nmn9NdPsJP1BnzBXqIXWMOpzHrew4nPqS8KEz3/+Wqm5feQK5bpFS6MHUIgn1dXgf7Sal16yMNmzcDvtVCEIoV3eLsxbRx0MLZVa1Z9tCY3kuCIcTcrMNO4mB6NAvZ2Hh5U9Cxu8e9GaF5yzJ7nOVgiKxua4uo73eejuEEGmWq28OO2qZ2YVW0sQRySOVbuhu3gUpB2EbljnL3pCgRAJhui8oy0VlH4m5aoVK/AjOOYtWduaFoJP7LCtizREfhDMdT/SUCAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBALR6fPRt1y4etxX1H65kn3iUOLfTa4kg2Lj+GbqjjkVJXQ9uiVL0qL6Usc1GMepUTqD0yuOfHH9sHJZdEs6N08CLpOjCAXqnelabGJ7vSEba1NxASXRGIdsgj7gpeXgH0G8+KRRRkHwp4+Ro0Gb0mXIwlbVxiMZ3zRUXzJxvITX9/fAfeQBvDhc0NpGKHBgINZFbImIzIsoDQId259n1RMBBgLRsuf17KROXQmPmHXJMfadmVC0CZgcpKr2r6n6aWYi1gUb6kliZi6Ikr4GoePUJz1w36xVhJw6mE1Oj/wZ1kPF/J092L48XqDYVZYD8zdBO+vGR52655Fn/niv3zcM=\"",
                AgentVersion = "3.2.0.0",
                ServerOSVersion = "10.0.14393.0",
                LastHeartBeat = "\"2018-09-10T20:05:02.5134384Z\"",
                ServerRole = "Standalone",
                ServerId = $"\"{serverId}\"",
                FriendlyName = "ankushb-vm02.ntdev.corp.microsoft.com"
                /*
                 * {
  "properties": {
    "serverCertificate": "\"MIIDEDCCAfigAwIBAgIQUB7fWz9pbodGHZwk+aVTRjANBgkqhkiG9w0BAQ0FADAwMS4wLAYDVQQDEyVhbmt1c2hiLXZtMDIubnRkZXYuY29ycC5taWNyb3NvZnQuY29tMB4XDTE4MDczMDIyNDc0NVoXDTE5MDczMTIyNDc0NVowMDEuMCwGA1UEAxMlYW5rdXNoYi12bTAyLm50ZGV2LmNvcnAubWljcm9zb2Z0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALssKhJeisUWQGU1as0mZm7PO81SQPUnK2uE0wTaXpJYlsEn+J9GrSKGYnwUVsdHsvku8AWzvVTeOM3lg7Nmn9NdPsJP1BnzBXqIXWMOpzHrew4nPqS8KEz3/+Wqm5feQK5bpFS6MHUIgn1dXgf7Sal16yMNmzcDvtVCEIoV3eLsxbRx0MLZVa1Z9tCY3kuCIcTcrMNO4mB6NAvZ2Hh5U9Cxu8e9GaF5yzJ7nOVgiKxua4uo73eejuEEGmWq28OO2qZ2YVW0sQRySOVbuhu3gUpB2EbljnL3pCgRAJhui8oy0VlH4m5aoVK/AjOOYtWduaFoJP7LCtizREfhDMdT/SUCAwEAAaMmMCQwIgYDVR0lAQH/BBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwDQYJKoZIhvcNAQENBQADggEBALR6fPRt1y4etxX1H65kn3iUOLfTa4kg2Lj+GbqjjkVJXQ9uiVL0qL6Usc1GMepUTqD0yuOfHH9sHJZdEs6N08CLpOjCAXqnelabGJ7vSEba1NxASXRGIdsgj7gpeXgH0G8+KRRRkHwp4+Ro0Gb0mXIwlbVxiMZ3zRUXzJxvITX9/fAfeQBvDhc0NpGKHBgINZFbImIzIsoDQId259n1RMBBgLRsuf17KROXQmPmHXJMfadmVC0CZgcpKr2r6n6aWYi1gUb6kliZi6Ikr4GoePUJz1w36xVhJw6mE1Oj/wZ1kPF/J092L48XqDYVZYD8zdBO+vGR52655Fn/niv3zcM=\"",
    "agentVersion": "3.2.0.0",
    "serverOSVersion": "10.0.14393.0",
    "lastHeartBeat": "\"2018-09-10T20:05:02.5134384Z\"",
    "serverRole": "Standalone",
    "serverId": "\"c32fae7d-b9fd-4c7d-8643-9116bd8fff6d\"",
    "friendlyName": "ankushb-vm02.ntdev.corp.microsoft.com"
  }
}
                 */
            };
        }

    }
}