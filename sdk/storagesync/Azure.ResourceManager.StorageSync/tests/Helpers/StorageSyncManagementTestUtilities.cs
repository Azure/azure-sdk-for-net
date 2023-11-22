// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.StorageSync.Models;
using Azure.Core;

namespace Azure.ResourceManager.StorageSync.Tests
{
    public static class StorageSyncManagementTestUtilities
    {
        public static bool IsTestTenant = false;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "centraluseuap";
        public static string DefaultRGLocation = IsTestTenant ? null : "eastus2";
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            };

        public static void VerifyStorageSyncServiceProperties(StorageSyncServiceResource resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Data.Location);
            Assert.NotNull(resource.Id.Name);

            VerifySystemDataProperties(resource.Data);

            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, resource.Data.Location.ToString());
                Assert.NotNull(resource.Data.Tags);
                Assert.AreEqual(2, resource.Data.Tags.Count);
                Assert.AreEqual("value1", resource.Data.Tags["key1"]);
                Assert.AreEqual("value2", resource.Data.Tags["key2"]);
            }
        }

        public static void VerifySyncGroupProperties(StorageSyncGroupResource resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Id.Name);

            VerifySystemDataProperties(resource.Data);

            // Enable SyncGroup tags when this feature is completed as SyncGroupMetadata
            if (useDefaults)
            {
            }
        }

        public static RecallActionContent GetDefaultRecallActionParameters()
        {
            return new RecallActionContent()
            {
                Pattern = null,
                RecallPath = null
            };
        }

        public static void VerifyCloudEndpointProperties(CloudEndpointResource resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Id.Name);

            VerifySystemDataProperties(resource.Data);
        }

        public static void VerifyServerEndpointProperties(StorageSyncServerEndpointResource resource, bool useDefaults)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Id.Name);

            VerifySystemDataProperties(resource.Data);

            if (useDefaults)
            {
                var defaults = GetDefaultServerEndpointParameters(resource.Data.ServerResourceId);
                Assert.AreEqual(resource.Data.ServerResourceId, defaults.ServerResourceId);
                Assert.AreEqual(resource.Data.ServerLocalPath, defaults.ServerLocalPath);
                Assert.AreEqual(resource.Data.CloudTiering, defaults.CloudTiering);
                Assert.AreEqual(resource.Data.VolumeFreeSpacePercent, defaults.VolumeFreeSpacePercent);
            }
        }

        public static void VerifyServerEndpointUpdateProperties(StorageSyncServerEndpointResource resource, bool useDefaults)
        {
            VerifyServerEndpointProperties(resource, useDefaults: false);

            if (useDefaults)
            {
                var defaults = GetDefaultServerEndpointUpdateParameters(resource.Id);
                Assert.AreEqual(resource.Data.CloudTiering, defaults.CloudTiering);
                Assert.AreEqual(resource.Data.VolumeFreeSpacePercent, defaults.VolumeFreeSpacePercent);
            }
        }

        public static void VerifyRegisteredServerProperties(StorageSyncRegisteredServerResource resource)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Id.Name);

            VerifySystemDataProperties(resource.Data);
        }

        public static void VerifySystemDataProperties(ResourceData resource)
        {
            Assert.NotNull(resource);

            Assert.NotNull(resource.SystemData);
            Assert.NotNull(resource.SystemData.CreatedOn);
            Assert.AreNotEqual(default(DateTime), resource.SystemData.CreatedOn.Value);
            Assert.NotNull(resource.SystemData.CreatedBy);
            Assert.NotNull(resource.SystemData.CreatedByType);
            Assert.NotNull(resource.SystemData.LastModifiedOn);
            Assert.AreNotEqual(default(DateTime), resource.SystemData.LastModifiedOn.Value);
            Assert.NotNull(resource.SystemData.LastModifiedBy);
            Assert.NotNull(resource.SystemData.LastModifiedByType);
        }

        public static StorageSyncServiceCreateOrUpdateContent GetDefaultStorageSyncServiceParameters()
        {
            var storageSyncServiceCreateOrUpdateContent = new StorageSyncServiceCreateOrUpdateContent(DefaultLocation);

            foreach (KeyValuePair<string, string> tag in DefaultTags)
            {
                storageSyncServiceCreateOrUpdateContent.Tags.Add(tag);
            }

            return storageSyncServiceCreateOrUpdateContent;
        }

        public static StorageSyncGroupCreateOrUpdateContent GetDefaultSyncGroupParameters()
        {
            return new StorageSyncGroupCreateOrUpdateContent
            {
            };
        }

        // Note: Secondary certificate must be different from primary certificate.
        internal static BinaryData GetSecondaryCertificate()
        {
            return BinaryData.FromObjectAsJson("LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tDQpNSUlETnpDQ0FoK2dBd0lCQWdJUUhsb1ZiSzYwbXJ0UExZSG1UVUllakRBTkJna3Foa2lHOXcwQkFRc0ZBREFZDQpNUll3RkFZRFZRUUREQTF0ZVhkbFluTnBkR1V1WTI5dE1CNFhEVEl6TVRFd09ERTROVGN6T1ZvWERUSTBNRFV3DQpPREU1TURjek9Gb3dHREVXTUJRR0ExVUVBd3dOYlhsM1pXSnphWFJsTG1OdmJUQ0NBU0l3RFFZSktvWklodmNODQpBUUVCQlFBRGdnRVBBRENDQVFvQ2dnRUJBSlFZOFBkSWNYUHdvVG1sOFVxL1lRQmFEdGlyVVUzdytOOGJ1czBMDQpUV0EvNXUxaFRYMkJQUUFQU2ZhY1VRc2E5cWpDSFJmL05KditRTkNzZ1V1VW9WR0psY05LeUxrdGhBR2Z0R1lVDQpyVXlLaDFBOEpTdHhtUGdjRWJ4SHlPcHZTUFFkRExUY0lJajRuRmk1aTZvQXpBNzRha3Y5aU5PTU84d0drQVo4DQorbE84S01hMnJrWGd1VmJBdmczQWRJZTNhbTl6aXBNWkhMZjUrSXZLZnhsbTBwdW1GS0VXMTZjd3o3Tzh3OWRrDQo5M0FsTXdtTFpqeWdkUVVrMXZ2N0U4R1hoY1h3VlB1ZGZPd1hYYzM0ejBKRXpwNjdaUnR3clJtVGZoM25qRFg2DQpBUER3MlFhV3BHUVlEY3hjMXNHdmc5bjBVaWh5aU50dEdSZUFTOVNpWFdndE1RVUNBd0VBQWFOOU1Ic3dEZ1lEDQpWUjBQQVFIL0JBUURBZ1dnTUIwR0ExVWRKUVFXTUJRR0NDc0dBUVVGQndNQ0JnZ3JCZ0VGQlFjREFUQXJCZ05WDQpIUkVFSkRBaWdnMXRlWGRsWW5OcGRHVXVZMjl0Z2hGM2QzY3ViWGwzWldKemFYUmxMbU52YlRBZEJnTlZIUTRFDQpGZ1FVUXhCQXRCWDBDV0ZTTXY3cDRjeVNKb0pmaEdRd0RRWUpLb1pJaHZjTkFRRUxCUUFEZ2dFQkFHSmZ4NXY5DQpDTDZtRnhzYUU5cUtIakFvL2Q0VDRFdTVxSU83b3U3Q3hPYXZpYnRnRyt5Mm1BVVJWQ1krbGVxZlJnWGRlZHk2DQpxYXdEajVVd1NacEx6RGN1WGthS2hmVGNmb0lnQm1BbXdXWkxFK3Y4clEyU2FSaDVqU1BUL04yeVBRdDlZNm9CDQo3Q1JsQ1IwZUV3M0I3cHRoQVhMYkRkK0xHNnVpY29meVlTdklyclBSUHJUQnRpUG94NnJPZ2MwRGV4U1VLdnc3DQpITDRaVHptVzBsZURZSlFmejllam1BVlRhM0pzam1wK3ZFd3g4Q2JkZ3Z0VjRqRkp0N2hiVmh4aHIrWTh2MzJhDQpDenhFV0x6OEYxazFIamJadit6eUNERlNTUjFzNi95MWVIaGgrQmxHOEtvVXJpUng4eUl2bkVhcDgzQ0FaOEVXDQpURWhMTjdqUHBpbzJCZ009DQotLS0tLUVORCBDRVJUSUZJQ0FURS0tLS0tDQo=");
        }

        public static CloudEndpointCreateOrUpdateContent GetDefaultCloudEndpointParameters()
        {
            return new CloudEndpointCreateOrUpdateContent
            {
                StorageAccountResourceId = new ResourceIdentifier("/subscriptions/e29c162a-d1d4-4cc3-8295-80057c1f4bd9/resourceGroups/SDKTestRG/providers/Microsoft.Storage/storageAccounts/sadotnetsdktests1"),
                AzureFileShareName = "afsfileshare1",
                StorageAccountTenantId = Guid.Parse("0483643a-cb2f-462a-bc27-1a270e5bdc0a")
            };
        }

        public static StorageSyncServerEndpointCreateOrUpdateContent GetDefaultServerEndpointUpdateParameters(string serverResourceId)
        {
            return new StorageSyncServerEndpointCreateOrUpdateContent
            {
                ServerLocalPath = "D:\\test2",
                CloudTiering = "On",
                VolumeFreeSpacePercent = 50,
                ServerResourceId = new ResourceIdentifier(serverResourceId)
            };
        }

        public static StorageSyncServerEndpointCreateOrUpdateContent GetDefaultServerEndpointParameters(string serverResourceId)
        {
            return new StorageSyncServerEndpointCreateOrUpdateContent
            {
                ServerLocalPath = "D:\\test2",
                CloudTiering = "Off",
                VolumeFreeSpacePercent = 0,
                ServerResourceId = new ResourceIdentifier(serverResourceId)
            };
        }

        public static StorageSyncRegisteredServerCreateOrUpdateContent GetDefaultRegisteredServerParameters(Guid serverId)
        {
            return new StorageSyncRegisteredServerCreateOrUpdateContent
            {
                //ServerCertificate = BinaryData.FromObjectAsJson("MIIDLTCCAhWgAwIBAgIIFwE9ZkrKVvcwDQYJKoZIhvcNAQENBQAwHTEbMBkGA1UEAxMSbG9hZFRlc3RTZXJ2ZXJDZXJ0MB4XDTIyMDEyODAwMTAyOVoXDTIzMDkyMTAwMTAyOVowHTEbMBkGA1UEAxMSbG9hZFRlc3RTZXJ2ZXJDZXJ0MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqqGyn6lGVTEiWIaW0stbLIepHdDY11H3e9ox6Hwx889ooTxSLTm0uIDmD3SzeKTLhkLOiRwPCiVxRDmrA4jzREfxIN1md6oTAx4J1G0KRxOfyjqTNdOZlJg+xyJeV/zz7ulbySPVasWoFJtK84llpaMrbQc3ZTHDB18knaF25FnZNut5y56AD9iSDAI0zi77YwgLrvKnq1yB0Cxoakk66EBFGyBpQzO0mQcUcw3F17FLUvdd+necjz3C/HSertrkOa805Kj+2nXxDkMxdQTkY6aUG5XoDNI8SuMxrYEA3g2IPbqsVUCrDz9QF1MWfsvNtM4pTfcBrzKnCgxIQ5fiyQIDAQABo3EwbzAOBgNVHQ8BAf8EBAMCB4AwHwYDVR0lBBgwFgYIKwYBBQUHAwIGCisGAQQBgjcKAwwwHQYDVR0RBBYwFIISbG9hZFRlc3RTZXJ2ZXJDZXJ0MB0GA1UdDgQWBBT+HpKL9aiuaF38wBbncHo0qDBGpzANBgkqhkiG9w0BAQ0FAAOCAQEAqeF7KI7NAfZN9z5UY4YmR1H2315eAQi6YtKGpAqg3JqLN/4kuYuivDv0hA3xmzZ+VVr2Vf42cjY7LT5nqGcY5bZzzhNhIPTSXtWQsGUXoWAaTsh7BM+xQGkuFIhig3gox9hZV+Lh0mzmVnwDxZLrrSGGTyZ+lRGe2NnOdm5NcehipGnoxMEvPZRpaOGAn2aq5z/ZZSvU6e8c/9A8CjlnteyT9IRI9kmfX/QKfP1Y4BtVcUvWGJE0sWxssC9BimWqyGFHaPxR2hO8g0E6+GNBMggCUw/tfM04Ei22fgbixFlOPcWVDS2Q3iwoMs8P8nKT717UVFa0nYp36hXZ+SiDWA=="),
                ServerCertificate = BinaryData.FromObjectAsJson("LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tDQpNSUlEQmpDQ0FlNmdBd0lCQWdJUUdqYjg2Wm50SElGS0J2SXd0RTJxaVRBTkJna3Foa2lHOXcwQkFRc0ZBREFXDQpNUlF3RWdZRFZRUUREQXR6Wkd0MFpYTjBZMlZ5ZERBZUZ3MHlNekV3TURZeU1UTTRNakJhRncweU5ERXdNRFl5DQpNVFU0TWpCYU1CWXhGREFTQmdOVkJBTU1DM05rYTNSbGMzUmpaWEowTUlJQklqQU5CZ2txaGtpRzl3MEJBUUVGDQpBQU9DQVE4QU1JSUJDZ0tDQVFFQXZPcHEzNWtnZVFGN2d2MnpwMGZ4dHdTTVFTMHlzRzFpdGpEaTFOOWVQUzZRDQo2QzJPcERjWjY3L1ZZTGdtSFJ0dzRuK3YxaG5PakJ1VVZMV0lwTGJHbW9TaGdRd2plNnBheExTYkNYWVJzYmJoDQpXK25hMDRIcWp0encxRnAwMERjNS8ybUFBclFLRWViRHRVbS9lbEdnZmh0UmpwS1RNMTkwUlcybnJxU3NRcWc2DQp4MWJYUEVHMWxoRmd1UUhEYVphMjMvUVZoSlFJalAzTjYwZWJWQ2ovOFdaeHFhVnlsU1ljaTJqa1BKUWVvUnY5DQpWWkhUNmpXWGRGRitZeFRlWi8vTHh0RkQwcEJsTEZMTCsrWmM2aHgvS0tObDVKU2NTVE81NmtFOGcrOFFPU3piDQpmaGp1MkVPNmVYUTdwUmdxb0wvb3h5K3dHSzUxUy9BRUtEMXdIRCtiZlFJREFRQUJvMUF3VGpBT0JnTlZIUThCDQpBZjhFQkFNQ0JhQXdIUVlEVlIwbEJCWXdGQVlJS3dZQkJRVUhBd0lHQ0NzR0FRVUZCd01CTUIwR0ExVWREZ1FXDQpCQlI5R2VpNXFrVHhiNFJBbGl6d0tZTEhJZVQxR0RBTkJna3Foa2lHOXcwQkFRc0ZBQU9DQVFFQW03RDhSOGdaDQpEZ2UveU5pbmtQd1pUY2xwRFhSVTVUcXlQbFR2Wld5L0dYV2k1SDVmbzlyWkh0ajYydlpBR1JLMHlrc2QvM0UrDQptVjFOTW42dldyaHB3bHpQMVBCTm1NTzhuTERveGQ4Q3ZTemZpVU91MDVOQUJEbVdHeWVURHgwWjRLbDlVTFVUDQpyWlNDS3U3TnYxYmpWOFYzRkNqdWFYaFhsL3ZTdFU2cGhUSzNYMEVlblJBaDRDRVF5NXpNYVFxSHd6cDArUXhXDQpCbDIvaHRkdWtNam1mVnpPeE5rSXQ1S2JWWmRjaVRPTFI2WTJPcUpSVlRMVE1KVE1rMHNESTZTRTI2b053Yk9NDQphSVRGWXlhVjczU3FGaXFmODFzOEVPYStLeHVLbkxWTWVIZWRZTTBGeXZFZ0UyTTF1UGg4cFZqUlJUcERmV1FvDQpldjJiUDJUYkRSU2U3UT09DQotLS0tLUVORCBDRVJUSUZJQ0FURS0tLS0tDQo="),
                AgentVersion = "15.0.0.0",
                ServerOSVersion = "10.0.14393.0",
                LastHeartbeat = "\"2021-06-10T20:05:02.5134384Z\"",
                ServerRole = "Standalone",
                ServerId = serverId,
                FriendlyName = "myserver.ntdev.corp.microsoft.com"
            };
        }

        public static Guid GenerateSeededGuid(int seed)
        {
            var random = new Random(seed);
            var guid = new byte[16];
            random.NextBytes(guid);

            return new Guid(guid);
        }
    }
}
