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
            };
        }

        // Note: Secondary certificate must be different from primary certificate.
        internal static string GetSecondaryCertificate()
        {

            return "MIIC4jCCAcqgAwIBAgIQRNDzNi8+T6BHMrXdZ8EjOTANBgkqhkiG9w0BAQ0FADAZMRcwFQYDVQQDEw5hbnBpbnQtdGVzdHZtMTAeFw0yMTA2MTQxODMwMzFaFw0yMjA2MTUxODMwMzFaMBkxFzAVBgNVBAMTDmFucGludC10ZXN0dm0xMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAvy29We6LV8k2j4GB7zMHAXlmwVlgnOniatA11zTZLa/GBr9MkXTjVWC6388ldsB8gIUxpcaeygk3T4VX38PRXflSctwp+0lzGoDgoba2tUUkZauXAW8nr9con0zVCQQJfLx2GSneqzo3pLybUqePonEDQPgJ8tsbRVGpMr/reMlh39YWyPdEBdUqRrJBo/AzKu3B/nVcvxgyDOBBtdM/tpeJoItS2BI60mX5KeaRSQDzraWz6LtQW0uxdijVoDJ486zKDhevCq/RjKQgkLIEfPxA0uclGP8SilPXNC8muOnMrnVq7kkK7qq3u3mzUVL07a4YlYcTpG9Z9QeT/WTllQIDAQABoyYwJDAiBgNVHSUBAf8EGDAWBggrBgEFBQcDAgYKKwYBBAGCNwoDDDANBgkqhkiG9w0BAQ0FAAOCAQEAoXiYUC9fBXUAI5q41tIsYNh4kUxiAaHhgH2tuE9ez3M1oHRZDWe6cAN+R2dkZyvgO3YYxX4sRIeKIS0EvJ+lRBCVmQoWSMNS9WUdsc2ForRS/0vwxDoDdCrdGhREjGRqoM4CvYEIZdFmyx3Rg0RDezuBzNbTPG8AF9bZz0PQ5sNwVlUJ2Jy4OswjF7ixr3/nAKdvPWIUgfQ1xyWfW2I1c8KQCdadFNEpFXH1U6cr8UfW3n5Oo+oAEDmjR0WV/0B34ZVYEOca9SKDja1jRvKfY8SfhEKs8/xb5IaQ9yMYNVlvBsW+l01TmG+ixFC9xaO6PIVr6RLkXBVruFGef+fuGg==";
        }

        public static CloudEndpointCreateParameters GetDefaultCloudEndpointParameters()
        {
            return new CloudEndpointCreateParameters
            {
                StorageAccountResourceId = "/subscriptions/7b96cb02-4663-40f4-9a89-603d3849e46a/resourcegroups/DotNetSdkTests/providers/Microsoft.Storage/storageAccounts/sadotnetsdktests",
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
                ServerCertificate = "MIIC4jCCAcqgAwIBAgIQFw2jvtLs4b5D/tdXOmXM4jANBgkqhkiG9w0BAQ0FADAZMRcwFQYDVQQDEw5hbnBpbnQtdGVzdHZtNzAeFw0yMTAxMjEyMDQwMzhaFw0yMjAxMjIyMDQwMzhaMBkxFzAVBgNVBAMTDmFucGludC10ZXN0dm03MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAyd6oJe1b380HSzCm2paNJk3PJY1EuNnpmJzDT1atuCs7cI4bLFhiiboMPnBALurXjiKrQPP0sbgNuxdFMryyE9JGQcLaKoQi6EMJ4iMSVHveVSjIb1UHN/bMvl8Y+cvwQTQgQMpcE9BJgmVREkaWFqL6r7nLOlrzWLT4QG8QGdUw7NnEUif86Wcor556KrR5yz8Z9o49Fy8x5ZRvUcBTOrBLlkdEyyGicWT/t0ED8M68atRpOkzyxzQYW3Y65M8rjIdnrnSCsMABC9+HtZf9yHHMu6srToOnwWM1tdSGd5a2XGcnoOJ1zBdH8/ySz3fcot+xl24oSdzg3GKL+Yep+QIDAQABoyYwJDAiBgNVHSUBAf8EGDAWBggrBgEFBQcDAgYKKwYBBAGCNwoDDDANBgkqhkiG9w0BAQ0FAAOCAQEAtcYxBaLFdc1M+ZRhF57MMzA4/ob71lhs2twOk0z9NZcsGGG/8NMH0+JHsPje5SCM9D2NAsBqqCYoW5OAyXGfAAsljgRQEbx6Ejc8Fr0osbWXRkHfkPewjX+9r76belYIR4H/XJ8uVW9SIoST84KSWrf2wdeGhms20/VWM562C7X60zGTWCWDwdioEm7Z9LJRTSZ/XvSZ14STwBI2J8U6eeKUlFZLhHBTt0jLAVhGciKCUHyPw6kWw7vdhonuigYNYwclxDYUhm8YbmmJzHQSzuQS/upKU6I/AMZIU/AcwWhchd1t+jZ2aQBh1JJ8+PXs0HARzWltK3i8a5IMHNdYTQ==",
                AgentVersion = "12.2.0.0",
                ServerOSVersion = "10.0.14393.0",
                LastHeartBeat = "\"2021-06-10T20:05:02.5134384Z\"",
                ServerRole = "Standalone",
                ServerId = $"\"{serverId}\"",
                FriendlyName = "myserver.ntdev.corp.microsoft.com"
            };
        }

    }
}