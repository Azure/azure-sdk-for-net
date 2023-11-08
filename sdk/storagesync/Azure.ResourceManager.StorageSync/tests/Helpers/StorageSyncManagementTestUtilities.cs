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
            return BinaryData.FromObjectAsJson("MIIDLjCCAhagAwIBAgIJAKqaSvweKxbYMA0GCSqGSIb3DQEBDQUAMB0xGzAZBgNVBAMTEmxvYWRUZXN0U2VydmVyQ2VydDAeFw0yMjAzMDMyMDAxMzdaFw0yMzEwMjUyMDAxMzdaMB0xGzAZBgNVBAMTEmxvYWRUZXN0U2VydmVyQ2VydDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANCAM8pAC6Xb3f9ZoqiSxyi6Ul4gWtdhelgy6xC4M0fn3iYW1/DL3qOdoD2x6fVFW2LgYXWl81yGsCSiP/XPhr0FzNHusKFbKWlygtIhUlCaPl5AageVpL2wHofRwRFxcpdcw9o5/ekoM8SsP21uU9L24+BZwanNXPvC7QHO0r+mxu0hakgWLrkGB6gWJ06jQ5ePyXhQKdTSB28RJjim6kl5PmzG6aZyi5GBWbODXij8y6W+jv8I5bUbBKWWzyuQC7bwpw59j0atGTWTcPEjq+wfY4UNAjHK1sffZAzsAKqmNofW4Rl08uYv8IKKkwNtaKmAQ1P6NfiTrOf5NGWASwkCAwEAAaNxMG8wDgYDVR0PAQH/BAQDAgeAMB8GA1UdJQQYMBYGCCsGAQUFBwMCBgorBgEEAYI3CgMMMB0GA1UdEQQWMBSCEmxvYWRUZXN0U2VydmVyQ2VydDAdBgNVHQ4EFgQU0Mp0xx9aA/Uf4H8TTIANX7F0QB8wDQYJKoZIhvcNAQENBQADggEBAJ9U4lg4UZQrGlJdYC+te8hpsAZM+WEAaoE3qq8XkGg7DJVjha4wMIDqaG6Xa9CsjGEs+tvc948L8PoHJbhh1uOAtoMAEwYmuQWevJCfsKjCeOMJbbUdKSd7Wwi5NfersdTrzEiRxIU4kQLc52nxfDotq26PZQyUv2cmzlXh+0lSeZuCNCI7Ko9tvmaFGIpt6F0kdSkwjbqCRPQwtiRHpvSmAVsrtvxm3Gxdnf2EL2jmI425uXSiQw8SRuKKmGLiUK68f3mstgfuqmk1TRuR5NWU0lyUmBB3o/ma9RDahUW/ZiHvXBhH9Pof3/Qm0HUrw8ll/9rMnZIEFvzdyyrc6J8=");
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
