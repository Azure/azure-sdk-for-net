// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Media.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Media.Tests.ScenarioTests
{
    public class MediaTest
    {
        [Fact]
        public void MediaServiceCheckNameAvailabiltyTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var mediaMgmtClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
                var resourcesClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

                var location = MediaManagementTestUtilities.TryGetLocation(resourcesClient, MediaManagementTestUtilities.DefaultLocation);

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // List media services by resource group
                var mediaservices = mediaMgmtClient.MediaService.ListByResourceGroup(rgname);
                Assert.Equal(0, mediaservices.Count());

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                // Create a media service
                var accountName = TestUtilities.GenerateName("media");
                // check name availabilty
                var checkNameAvailabilityOutput = mediaMgmtClient.MediaService.CheckNameAvailabilty(new CheckNameAvailabilityInput(accountName, "mediaservices"));
                Assert.NotNull(checkNameAvailabilityOutput.NameAvailable);
                Assert.True(checkNameAvailabilityOutput.NameAvailable.Value);

                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = new Dictionary<string, string>
                    {
                        { "key1","value1"},
                        { "key2","value2"}
                    },
                    StorageAccounts = new List<StorageAccount>
                    {
                        new StorageAccount
                        {
                            Id = storageAccount.Id,
                            IsPrimary = true
                        }
                    }
                };
                mediaMgmtClient.MediaService.Create(rgname, accountName, mediaService);

                mediaservices = mediaMgmtClient.MediaService.ListByResourceGroup(rgname);
                Assert.Equal(1, mediaservices.Count());

                // check name availabilty
                checkNameAvailabilityOutput = mediaMgmtClient.MediaService.CheckNameAvailabilty(new CheckNameAvailabilityInput(accountName, "mediaservices"));
                Assert.NotNull(checkNameAvailabilityOutput.NameAvailable);
                Assert.False(checkNameAvailabilityOutput.NameAvailable.Value);

                mediaMgmtClient.MediaService.Delete(rgname, accountName);
                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }

        [Fact]
        public void MediaServiceListByResourceGroupTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var mediaMgmtClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
                var resourcesClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

                var location = MediaManagementTestUtilities.TryGetLocation(resourcesClient, MediaManagementTestUtilities.DefaultLocation);

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // List media services by resource group
                var mediaservices = mediaMgmtClient.MediaService.ListByResourceGroup(rgname);
                Assert.Equal(0, mediaservices.Count());

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                // Create a media service
                var accountName = TestUtilities.GenerateName("media");
                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = new Dictionary<string, string>
                    {
                        { "key1","value1"},
                        { "key2","value2"}
                    },
                    StorageAccounts = new List<StorageAccount>
                    {
                        new StorageAccount
                        {
                            Id = storageAccount.Id,
                            IsPrimary = true
                        }
                    }
                };
                mediaMgmtClient.MediaService.Create(rgname, accountName, mediaService);

                mediaservices = mediaMgmtClient.MediaService.ListByResourceGroup(rgname);
                Assert.Equal(1, mediaservices.Count());

                mediaMgmtClient.MediaService.Delete(rgname, accountName);
                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }

        [Fact]
        public void MediaServiceGetTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var mediaMgmtClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
                var resourcesClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

                var location = MediaManagementTestUtilities.TryGetLocation(resourcesClient, MediaManagementTestUtilities.DefaultLocation);

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                // Create a media service
                var accountName = TestUtilities.GenerateName("media");
                var tagsCreate = new Dictionary<string, string>
                {
                    { "key1","value1"},
                    { "key2","value2"}
                };
                var storageAccountsCreate = new List<StorageAccount>
                {
                    new StorageAccount
                    {
                        Id = storageAccount.Id,
                        IsPrimary = true
                    }
                };

                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = tagsCreate,
                    StorageAccounts = storageAccountsCreate
                };
                mediaMgmtClient.MediaService.Create(rgname, accountName, mediaService);

                var mediaServiceGet = mediaMgmtClient.MediaService.Get(rgname, accountName);
                Assert.NotNull(mediaServiceGet);
                Assert.Equal(accountName, mediaServiceGet.Name);
                Assert.Equal(tagsCreate, mediaServiceGet.Tags);
                Assert.Equal(1, mediaServiceGet.StorageAccounts.Count);
                Assert.True(mediaServiceGet.StorageAccounts.ElementAt(0).IsPrimary);
                Assert.Equal(storageAccount.Id, mediaServiceGet.StorageAccounts.ElementAt(0).Id);

                mediaMgmtClient.MediaService.Delete(rgname, accountName);
                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }

        [Fact]
        public void MediaServiceCreateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var mediaMgmtClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
                var resourcesClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

                var location = MediaManagementTestUtilities.TryGetLocation(resourcesClient, MediaManagementTestUtilities.DefaultLocation);

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                // Create a media service
                var accountName = TestUtilities.GenerateName("media");
                var tagsCreate = new Dictionary<string, string>
                {
                    { "key1","value1"},
                    { "key2","value2"}
                };
                var storageAccountsCreate = new List<StorageAccount>
                {
                    new StorageAccount
                    {
                        Id = storageAccount.Id,
                        IsPrimary = true
                    }
                };

                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = tagsCreate,
                    StorageAccounts = storageAccountsCreate
                };
                mediaMgmtClient.MediaService.Create(rgname, accountName, mediaService);

                var mediaServiceGet = mediaMgmtClient.MediaService.Get(rgname, accountName);
                Assert.NotNull(mediaServiceGet);
                Assert.Equal(accountName, mediaServiceGet.Name);
                Assert.Equal(tagsCreate, mediaServiceGet.Tags);
                Assert.Equal(1, mediaServiceGet.StorageAccounts.Count);
                Assert.True(mediaServiceGet.StorageAccounts.ElementAt(0).IsPrimary);
                Assert.Equal(storageAccount.Id, mediaServiceGet.StorageAccounts.ElementAt(0).Id);

                mediaMgmtClient.MediaService.Delete(rgname, accountName);
                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }

        [Fact]
        public void MediaServiceUpdateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var mediaMgmtClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
                var resourcesClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

                var location = MediaManagementTestUtilities.TryGetLocation(resourcesClient, MediaManagementTestUtilities.DefaultLocation);

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                // Create a media service
                var accountName = TestUtilities.GenerateName("media");

                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = new Dictionary<string, string>
                    {
                        { "key1","value1"},
                        { "key2","value2"}
                    },
                    StorageAccounts = new List<StorageAccount>
                    {
                        new StorageAccount
                        {
                            Id = storageAccount.Id,
                            IsPrimary = true
                        }
                    }
                };
                mediaMgmtClient.MediaService.Create(rgname, accountName, mediaService);

                var mediaServiceGet = mediaMgmtClient.MediaService.Get(rgname, accountName);
                Assert.NotNull(mediaServiceGet);
                Assert.Equal(accountName, mediaServiceGet.Name);

                var tagsUpdated = new Dictionary<string, string>
                {
                    { "key3","value3"},
                    { "key4","value4"}
                };
                mediaMgmtClient.MediaService.Update(rgname, accountName, new MediaService
                {
                    Tags = tagsUpdated
                });

                mediaServiceGet = mediaMgmtClient.MediaService.Get(rgname, accountName);
                Assert.NotNull(mediaServiceGet);
                Assert.Equal(accountName, mediaServiceGet.Name);
                Assert.Equal(tagsUpdated, mediaServiceGet.Tags);

                mediaMgmtClient.MediaService.Delete(rgname, accountName);
                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }

        [Fact]
        public void MediaServiceDeleteTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var mediaMgmtClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
                var resourcesClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

                var location = MediaManagementTestUtilities.TryGetLocation(resourcesClient, MediaManagementTestUtilities.DefaultLocation);

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                // Create a media service
                var accountName = TestUtilities.GenerateName("media");
                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = new Dictionary<string, string>
                    {
                        { "key1","value1"},
                        { "key2","value2"}
                    },
                    StorageAccounts = new List<StorageAccount>
                    {
                        new StorageAccount
                        {
                            Id = storageAccount.Id,
                            IsPrimary = true
                        }
                    }
                };
                mediaMgmtClient.MediaService.Create(rgname, accountName, mediaService);

                var mediaservices = mediaMgmtClient.MediaService.ListByResourceGroup(rgname);
                Assert.Equal(1, mediaservices.Count());

                mediaMgmtClient.MediaService.Delete(rgname, accountName);
                mediaservices = mediaMgmtClient.MediaService.ListByResourceGroup(rgname);
                Assert.Equal(0, mediaservices.Count());

                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }

        [Fact]
        public void MediaServiceListKeysTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var mediaMgmtClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
                var resourcesClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

                var location = MediaManagementTestUtilities.TryGetLocation(resourcesClient, MediaManagementTestUtilities.DefaultLocation);

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                // Create a media service
                var accountName = TestUtilities.GenerateName("media");
                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = new Dictionary<string, string>
                    {
                        { "key1","value1"},
                        { "key2","value2"}
                    },
                    StorageAccounts = new List<StorageAccount>
                    {
                        new StorageAccount
                        {
                            Id = storageAccount.Id,
                            IsPrimary = true
                        }
                    }
                };
                mediaMgmtClient.MediaService.Create(rgname, accountName, mediaService);

                var serviceKeys = mediaMgmtClient.MediaService.ListKeys(rgname, accountName);
                Assert.NotNull(serviceKeys.PrimaryKey);
                Assert.NotNull(serviceKeys.SecondaryKey);

                mediaMgmtClient.MediaService.Delete(rgname, accountName);
                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }

        [Fact]
        public void MediaServiceRegenerateKeyTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var mediaMgmtClient = MediaManagementTestUtilities.GetMediaManagementClient(context, handler1);
                var resourcesClient = MediaManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = MediaManagementTestUtilities.GetStorageManagementClient(context, handler3);

                var location = MediaManagementTestUtilities.TryGetLocation(resourcesClient, MediaManagementTestUtilities.DefaultLocation);

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                // Create a media service
                var accountName = TestUtilities.GenerateName("media");
                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = new Dictionary<string, string>
                    {
                        { "key1","value1"},
                        { "key2","value2"}
                    },
                    StorageAccounts = new List<StorageAccount>
                    {
                        new StorageAccount
                        {
                            Id = storageAccount.Id,
                            IsPrimary = true
                        }
                    }
                };
                mediaMgmtClient.MediaService.Create(rgname, accountName, mediaService);

                var serviceKeys = mediaMgmtClient.MediaService.ListKeys(rgname, accountName);
                Assert.NotNull(serviceKeys.PrimaryKey);
                Assert.NotNull(serviceKeys.SecondaryKey);

                // regenerate the primary key
                mediaMgmtClient.MediaService.RegenerateKey(rgname, accountName, new RegenerateKeyInput(KeyType.Primary));
                var serviceKeysUpdated1 = mediaMgmtClient.MediaService.ListKeys(rgname, accountName);
                Assert.NotNull(serviceKeysUpdated1.PrimaryKey);
                Assert.NotEqual(serviceKeys.PrimaryKey, serviceKeysUpdated1.PrimaryKey);
                Assert.Equal(serviceKeys.SecondaryKey, serviceKeysUpdated1.SecondaryKey);

                // regenerate the secondary key
                mediaMgmtClient.MediaService.RegenerateKey(rgname, accountName, new RegenerateKeyInput(KeyType.Secondary));
                var serviceKeysUpdated2 = mediaMgmtClient.MediaService.ListKeys(rgname, accountName);
                Assert.NotNull(serviceKeysUpdated2.SecondaryKey);
                Assert.NotEqual(serviceKeysUpdated1.SecondaryKey, serviceKeysUpdated2.SecondaryKey);
                Assert.Equal(serviceKeysUpdated1.PrimaryKey, serviceKeysUpdated2.PrimaryKey);

                mediaMgmtClient.MediaService.Delete(rgname, accountName);
                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }
    }
}
