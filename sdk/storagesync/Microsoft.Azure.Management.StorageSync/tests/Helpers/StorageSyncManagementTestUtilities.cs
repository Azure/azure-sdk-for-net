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

            return "LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tDQpNSUlETnpDQ0FoK2dBd0lCQWdJUUhsb1ZiSzYwbXJ0UExZSG1UVUllakRBTkJna3Foa2lHOXcwQkFRc0ZBREFZDQpNUll3RkFZRFZRUUREQTF0ZVhkbFluTnBkR1V1WTI5dE1CNFhEVEl6TVRFd09ERTROVGN6T1ZvWERUSTBNRFV3DQpPREU1TURjek9Gb3dHREVXTUJRR0ExVUVBd3dOYlhsM1pXSnphWFJsTG1OdmJUQ0NBU0l3RFFZSktvWklodmNODQpBUUVCQlFBRGdnRVBBRENDQVFvQ2dnRUJBSlFZOFBkSWNYUHdvVG1sOFVxL1lRQmFEdGlyVVUzdytOOGJ1czBMDQpUV0EvNXUxaFRYMkJQUUFQU2ZhY1VRc2E5cWpDSFJmL05KditRTkNzZ1V1VW9WR0psY05LeUxrdGhBR2Z0R1lVDQpyVXlLaDFBOEpTdHhtUGdjRWJ4SHlPcHZTUFFkRExUY0lJajRuRmk1aTZvQXpBNzRha3Y5aU5PTU84d0drQVo4DQorbE84S01hMnJrWGd1VmJBdmczQWRJZTNhbTl6aXBNWkhMZjUrSXZLZnhsbTBwdW1GS0VXMTZjd3o3Tzh3OWRrDQo5M0FsTXdtTFpqeWdkUVVrMXZ2N0U4R1hoY1h3VlB1ZGZPd1hYYzM0ejBKRXpwNjdaUnR3clJtVGZoM25qRFg2DQpBUER3MlFhV3BHUVlEY3hjMXNHdmc5bjBVaWh5aU50dEdSZUFTOVNpWFdndE1RVUNBd0VBQWFOOU1Ic3dEZ1lEDQpWUjBQQVFIL0JBUURBZ1dnTUIwR0ExVWRKUVFXTUJRR0NDc0dBUVVGQndNQ0JnZ3JCZ0VGQlFjREFUQXJCZ05WDQpIUkVFSkRBaWdnMXRlWGRsWW5OcGRHVXVZMjl0Z2hGM2QzY3ViWGwzWldKemFYUmxMbU52YlRBZEJnTlZIUTRFDQpGZ1FVUXhCQXRCWDBDV0ZTTXY3cDRjeVNKb0pmaEdRd0RRWUpLb1pJaHZjTkFRRUxCUUFEZ2dFQkFHSmZ4NXY5DQpDTDZtRnhzYUU5cUtIakFvL2Q0VDRFdTVxSU83b3U3Q3hPYXZpYnRnRyt5Mm1BVVJWQ1krbGVxZlJnWGRlZHk2DQpxYXdEajVVd1NacEx6RGN1WGthS2hmVGNmb0lnQm1BbXdXWkxFK3Y4clEyU2FSaDVqU1BUL04yeVBRdDlZNm9CDQo3Q1JsQ1IwZUV3M0I3cHRoQVhMYkRkK0xHNnVpY29meVlTdklyclBSUHJUQnRpUG94NnJPZ2MwRGV4U1VLdnc3DQpITDRaVHptVzBsZURZSlFmejllam1BVlRhM0pzam1wK3ZFd3g4Q2JkZ3Z0VjRqRkp0N2hiVmh4aHIrWTh2MzJhDQpDenhFV0x6OEYxazFIamJadit6eUNERlNTUjFzNi95MWVIaGgrQmxHOEtvVXJpUng4eUl2bkVhcDgzQ0FaOEVXDQpURWhMTjdqUHBpbzJCZ009DQotLS0tLUVORCBDRVJUSUZJQ0FURS0tLS0tDQo=";
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
                ServerCertificate = "LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tDQpNSUlEQmpDQ0FlNmdBd0lCQWdJUUdqYjg2Wm50SElGS0J2SXd0RTJxaVRBTkJna3Foa2lHOXcwQkFRc0ZBREFXDQpNUlF3RWdZRFZRUUREQXR6Wkd0MFpYTjBZMlZ5ZERBZUZ3MHlNekV3TURZeU1UTTRNakJhRncweU5ERXdNRFl5DQpNVFU0TWpCYU1CWXhGREFTQmdOVkJBTU1DM05rYTNSbGMzUmpaWEowTUlJQklqQU5CZ2txaGtpRzl3MEJBUUVGDQpBQU9DQVE4QU1JSUJDZ0tDQVFFQXZPcHEzNWtnZVFGN2d2MnpwMGZ4dHdTTVFTMHlzRzFpdGpEaTFOOWVQUzZRDQo2QzJPcERjWjY3L1ZZTGdtSFJ0dzRuK3YxaG5PakJ1VVZMV0lwTGJHbW9TaGdRd2plNnBheExTYkNYWVJzYmJoDQpXK25hMDRIcWp0encxRnAwMERjNS8ybUFBclFLRWViRHRVbS9lbEdnZmh0UmpwS1RNMTkwUlcybnJxU3NRcWc2DQp4MWJYUEVHMWxoRmd1UUhEYVphMjMvUVZoSlFJalAzTjYwZWJWQ2ovOFdaeHFhVnlsU1ljaTJqa1BKUWVvUnY5DQpWWkhUNmpXWGRGRitZeFRlWi8vTHh0RkQwcEJsTEZMTCsrWmM2aHgvS0tObDVKU2NTVE81NmtFOGcrOFFPU3piDQpmaGp1MkVPNmVYUTdwUmdxb0wvb3h5K3dHSzUxUy9BRUtEMXdIRCtiZlFJREFRQUJvMUF3VGpBT0JnTlZIUThCDQpBZjhFQkFNQ0JhQXdIUVlEVlIwbEJCWXdGQVlJS3dZQkJRVUhBd0lHQ0NzR0FRVUZCd01CTUIwR0ExVWREZ1FXDQpCQlI5R2VpNXFrVHhiNFJBbGl6d0tZTEhJZVQxR0RBTkJna3Foa2lHOXcwQkFRc0ZBQU9DQVFFQW03RDhSOGdaDQpEZ2UveU5pbmtQd1pUY2xwRFhSVTVUcXlQbFR2Wld5L0dYV2k1SDVmbzlyWkh0ajYydlpBR1JLMHlrc2QvM0UrDQptVjFOTW42dldyaHB3bHpQMVBCTm1NTzhuTERveGQ4Q3ZTemZpVU91MDVOQUJEbVdHeWVURHgwWjRLbDlVTFVUDQpyWlNDS3U3TnYxYmpWOFYzRkNqdWFYaFhsL3ZTdFU2cGhUSzNYMEVlblJBaDRDRVF5NXpNYVFxSHd6cDArUXhXDQpCbDIvaHRkdWtNam1mVnpPeE5rSXQ1S2JWWmRjaVRPTFI2WTJPcUpSVlRMVE1KVE1rMHNESTZTRTI2b053Yk9NDQphSVRGWXlhVjczU3FGaXFmODFzOEVPYStLeHVLbkxWTWVIZWRZTTBGeXZFZ0UyTTF1UGg4cFZqUlJUcERmV1FvDQpldjJiUDJUYkRSU2U3UT09DQotLS0tLUVORCBDRVJUSUZJQ0FURS0tLS0tDQo=",
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