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
            return "MIIC4jCCAcqgAwIBAgIQEznq4fKV6oxN2xcLsYVeLjANBgkqhkiG9w0BAQ0FADAZMRcwFQYDVQQDEw5hbnBpbnQtVGVzdFZNMzAeFw0yMDA2MTAyMjAwNDVaFw0yMTA2MTEyMjAwNDVaMBkxFzAVBgNVBAMTDmFucGludC1UZXN0Vk0zMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAvpNGR61sk6f+5CosYIRzo1+qOU2PfpDT/J3ol2gWOt0hIWGYjx3aH/bU1kY5pf1uPTDvRtP38Oe6RmGJ+0KUsjYws9WVXem/p6xYOuJnBGHekGLsJpBcqBRaj74uc4eaFe7tKEFqdOBIlRhFYyR71AR46kThMeJaAcwsf/bnDZ6SLVyKVHYTYotm/UDX/51F1ekpLgzw1mcryS3ShxiJocVL1gDQbUTh6MJLAUn3wfE8tDaMHVrslOuav+QooR/tBjKqld4bsx2e5cF9ESRcXG2Lky+TbEIqWwQHiH9h9YagLYwXp1ippX94M2/BDlrNBGiwNIfUm9uTYUT47Fru2wIDAQABoyYwJDAiBgNVHSUBAf8EGDAWBggrBgEFBQcDAgYKKwYBBAGCNwoDDDANBgkqhkiG9w0BAQ0FAAOCAQEAYF6Ga8wjRa0Aj4ZhKuQxz4g0yK5R8BlbA0FjMc989DBk+G0Bhd+S8+glQRbP3cYfapuCQQvKrnAxk4whP8iFr+NBFtUcz7GzGVHCs1NfqhlhPPOWw2ejklmrlbOthF6ofQ4ZCGL9aQ2Cd0gHR9TSod9PHmupEAKSeEoI++D9AuxIX0emD6QLf4TFGzN2/7bmBNhmEoDdDSOIiwjo2AF1oVNkSmNfH1bswPigrD2va4orP9xsxEaYsI181EXq5xcHO/sfHOGALcHEX/ph5VQ6Gn87vrQih6TfpegtC328ckcPAkpDJS6idB4U6B7S3ceZo6bWYnVW3DitwEytxkQkoA==";
        }

        public static CloudEndpointCreateParameters GetDefaultCloudEndpointParameters()
        {
            return new CloudEndpointCreateParameters
            {
                StorageAccountResourceId = "/subscriptions/1d16f9b3-bbe3-48d4-930a-27a74dca003b/resourcegroups/sasdkcentraluseuap/providers/Microsoft.Storage/storageAccounts/sasdkcentraluseuap",
                AzureFileShareName = "afsfileshare1",
                StorageAccountTenantId = "\"72f988bf-86f1-41af-91ab-2d7cd011db47\""
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
                ServerCertificate = "\"MIIC4jCCAcqgAwIBAgIQP7n31LE24L1CfAmLKBKi6TANBgkqhkiG9w0BAQ0FADAZMRcwFQYDVQQDEw5hbnBpbnQtVGVzdFZNMzAeFw0yMDA0MDYyMDE5NDJaFw0yMTA0MDcyMDE5NDJaMBkxFzAVBgNVBAMTDmFucGludC1UZXN0Vk0zMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAr9n0XUYEuWmXzZw9DNhSsp3QALPTPvHizpRJS4+g/ZRsjkiAwrgmOUX2XLYD/ThTNrHc7xga71gyuo7p+AsJy5dxdwi+bK2j7fJI/qU4waFKR9oA/Uu0uhWJ1GcPK72zM/DiG0rGlgEJUJe/Eq/DxWHDydYN2LLcI1fA9SpN3TawEs2zP1wxNX4olhstCm7J7ip3m9UY1gnKaI95ZOutEyrq9nEBMw/PaV9U0Tzq6w22aQDtu1CNrge5Kzpduw1qo2b/+eOZycsPuvupSB6Hl0/BUpqNVgQg56Q1znrTt0NKHcEumpu/v5w1OV7NcDNcsQmujvsHvk5Ze8FptsVA3QIDAQABoyYwJDAiBgNVHSUBAf8EGDAWBggrBgEFBQcDAgYKKwYBBAGCNwoDDDANBgkqhkiG9w0BAQ0FAAOCAQEACverHCPOmBbUuZnnrqBc2z5hL+K22WjpHBL5sxhaAiexqvM0OjH+ifFWHyGge+03/UEjhfdN3OFe0n0gAsweWuyc33pNVDb+DBXT2oW6TZrNVqs+eWw+4Haa2DiKV3+JqSK2148AY82Ny31ni2SACSCvvodxwWGWjiP6evq84+4wOCxwbUk+rPmJCimG9Ha7iDJ1xLt75hDgNB4eiODyzgMF3u8BswaIIyvBMYr3GGMgp2yAPe6jV0EJyoQ8hxwmb2ChB5VVL5lYTe1fU9Ro2c+T2KPhemmBLXM0yRghe/FcfSU8ZcrTx69pUwhKg5OtErhHTw4QvRkkHnsHvDjcjA==\"",
                AgentVersion = "3.2.0.0",
                ServerOSVersion = "10.0.14393.0",
                LastHeartBeat = "\"2018-09-10T20:05:02.5134384Z\"",
                ServerRole = "Standalone",
                ServerId = $"\"{serverId}\"",
                FriendlyName = "ankushb-vm02.ntdev.corp.microsoft.com"
            };
        }

    }
}