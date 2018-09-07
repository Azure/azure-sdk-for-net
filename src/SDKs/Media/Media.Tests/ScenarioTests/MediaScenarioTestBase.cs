// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Media.Tests.Helpers;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Net;

namespace Media.Tests.ScenarioTests
{
    public class MediaScenarioTestBase
    {
        public ResourceManagementClient ResourceClient { get; private set; }

        public AzureMediaServicesClient MediaClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public string ResourceGroup { get; private set; }

        public string StorageAccountName { get; private set; }

        public string AccountName { get; private set; }

        public string Location { get; private set; }

        protected MockContext StartMockContextAndInitializeClients(string className,
            // Automatically populates the methodName parameter with the calling method, which
            // gets used to generate recorder file names.
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "")
        {
            MockContext context = MockContext.Start(className, methodName);

            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            // Create clients
            MediaClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
            ResourceClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
            StorageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

            return context;
        }

        public void CreateMediaServicesAccount()
        {
            Location = MediaManagementTestUtilities.TryGetLocation(ResourceClient, MediaManagementTestUtilities.DefaultLocation);

            ResourceGroup = MediaManagementTestUtilities.CreateResourceGroup(ResourceClient, Location);

            // Create storage account
            var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(StorageClient, ResourceGroup, Location);
            StorageAccountName = storageAccount.Name;

            // Create a media service account
            string accountName = TestUtilities.GenerateName("media");
            var mediaService = new MediaService
            {
                Location = MediaManagementTestUtilities.DefaultLocation,
                Tags = new Dictionary<string, string>
                    {
                        { "key1","value1"},
                        { "key2","value2"}
                    },
                StorageAccounts = new List<Microsoft.Azure.Management.Media.Models.StorageAccount>
                    {
                        new Microsoft.Azure.Management.Media.Models.StorageAccount
                        {
                            Id = storageAccount.Id,
                            Type = StorageAccountType.Primary
                        }
                    }
            };

            MediaService mediaAccount = MediaClient.Mediaservices.CreateOrUpdate(ResourceGroup, accountName, mediaService);
            AccountName = mediaAccount.Name;
        }

        public void DeleteMediaServicesAccount()
        {
            if (!string.IsNullOrEmpty(AccountName))
            {
                MediaClient.Mediaservices.Delete(ResourceGroup, AccountName);
            }

            if (!string.IsNullOrEmpty(StorageAccountName))
            {
                MediaManagementTestUtilities.DeleteStorageAccount(StorageClient, ResourceGroup, StorageAccountName);
            }

            if (!string.IsNullOrEmpty(ResourceGroup))
            {
                MediaManagementTestUtilities.DeleteResourceGroup(ResourceClient, ResourceGroup);
            }
        }
    }
}
