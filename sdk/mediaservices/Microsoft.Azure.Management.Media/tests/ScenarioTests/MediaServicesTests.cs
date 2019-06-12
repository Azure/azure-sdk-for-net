// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Media.Tests.Helpers;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class MediaServicesTests
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
                var lowerCaseLocationWithoutSpaces = location.Replace(" ", string.Empty).ToLowerInvariant(); // TODO: Fix this once the bug is addressed

                // Create resource group
                var rgname = MediaManagementTestUtilities.CreateResourceGroup(resourcesClient, location);

                // List media services by resource group
                var mediaservices = mediaMgmtClient.Mediaservices.List(rgname);
                Assert.Empty(mediaservices);

                // Create storage account
                var storageAccount = MediaManagementTestUtilities.CreateStorageAccount(storageClient, rgname, location);

                string mediaServicesType = "Microsoft.Media/MediaServices";
                var accountName = TestUtilities.GenerateName("media");

                // check name availabilty
                var checkNameAvailabilityOutput = mediaMgmtClient.Locations.CheckNameAvailability(lowerCaseLocationWithoutSpaces, accountName, mediaServicesType);
                Assert.True(checkNameAvailabilityOutput.NameAvailable);

                var mediaService = new MediaService
                {
                    Location = location,
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
                            Type = StorageAccountType.Primary
                        }
                    }
                };
                mediaMgmtClient.Mediaservices.CreateOrUpdate(rgname, accountName, mediaService);

                mediaservices = mediaMgmtClient.Mediaservices.List(rgname);
                Assert.Single(mediaservices);

                // check name availabilty
                checkNameAvailabilityOutput = mediaMgmtClient.Locations.CheckNameAvailability(lowerCaseLocationWithoutSpaces, accountName, mediaServicesType);
                Assert.False(checkNameAvailabilityOutput.NameAvailable);

                mediaMgmtClient.Mediaservices.Delete(rgname, accountName);
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
                var mediaservices = mediaMgmtClient.Mediaservices.List(rgname);
                Assert.Empty(mediaservices);

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
                            Type = StorageAccountType.Primary
                        }
                    }
                };
                mediaMgmtClient.Mediaservices.CreateOrUpdate(rgname, accountName, mediaService);

                mediaservices = mediaMgmtClient.Mediaservices.List(rgname);
                Assert.Single(mediaservices);

                mediaMgmtClient.Mediaservices.Delete(rgname, accountName);
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
                        Type = StorageAccountType.Primary
                    }
                };

                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = tagsCreate,
                    StorageAccounts = storageAccountsCreate
                };
                mediaMgmtClient.Mediaservices.CreateOrUpdate(rgname, accountName, mediaService);

                var mediaServiceGet = mediaMgmtClient.Mediaservices.Get(rgname, accountName);
                Assert.NotNull(mediaServiceGet);
                Assert.Equal(accountName, mediaServiceGet.Name);
                Assert.Equal(tagsCreate, mediaServiceGet.Tags);
                Assert.Equal(1, mediaServiceGet.StorageAccounts.Count);
                Assert.Equal(StorageAccountType.Primary, mediaServiceGet.StorageAccounts.ElementAt(0).Type);
                Assert.Equal(storageAccount.Id, mediaServiceGet.StorageAccounts.ElementAt(0).Id);

                mediaMgmtClient.Mediaservices.Delete(rgname, accountName);
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
                        Type = StorageAccountType.Primary
                    }
                };

                var mediaService = new MediaService
                {
                    Location = MediaManagementTestUtilities.DefaultLocation,
                    Tags = tagsCreate,
                    StorageAccounts = storageAccountsCreate
                };
                mediaMgmtClient.Mediaservices.CreateOrUpdate(rgname, accountName, mediaService);

                var mediaServiceGet = mediaMgmtClient.Mediaservices.Get(rgname, accountName);
                Assert.NotNull(mediaServiceGet);
                Assert.Equal(accountName, mediaServiceGet.Name);
                Assert.Equal(tagsCreate, mediaServiceGet.Tags);
                Assert.Equal(1, mediaServiceGet.StorageAccounts.Count);
                Assert.Equal(StorageAccountType.Primary, mediaServiceGet.StorageAccounts.ElementAt(0).Type);
                Assert.Equal(storageAccount.Id, mediaServiceGet.StorageAccounts.ElementAt(0).Id);

                mediaMgmtClient.Mediaservices.Delete(rgname, accountName);
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
                            Type = StorageAccountType.Primary
                        }
                    }
                };
                mediaMgmtClient.Mediaservices.CreateOrUpdate(rgname, accountName, mediaService);

                var mediaServiceGet = mediaMgmtClient.Mediaservices.Get(rgname, accountName);
                Assert.NotNull(mediaServiceGet);
                Assert.Equal(accountName, mediaServiceGet.Name);

                var tagsUpdated = new Dictionary<string, string>
                {
                    { "key3","value3"},
                    { "key4","value4"}
                };
                mediaMgmtClient.Mediaservices.Update(rgname, accountName, new MediaService
                {
                    Tags = tagsUpdated
                });

                mediaServiceGet = mediaMgmtClient.Mediaservices.Get(rgname, accountName);
                Assert.NotNull(mediaServiceGet);
                Assert.Equal(accountName, mediaServiceGet.Name);
                Assert.Equal(tagsUpdated, mediaServiceGet.Tags);

                mediaMgmtClient.Mediaservices.Delete(rgname, accountName);
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
                            Type = StorageAccountType.Primary
                        }
                    }
                };
                mediaMgmtClient.Mediaservices.CreateOrUpdate(rgname, accountName, mediaService);

                var mediaservices = mediaMgmtClient.Mediaservices.List(rgname);
                Assert.Single(mediaservices);

                mediaMgmtClient.Mediaservices.Delete(rgname, accountName);
                mediaservices = mediaMgmtClient.Mediaservices.List(rgname);
                Assert.Empty(mediaservices);

                MediaManagementTestUtilities.DeleteStorageAccount(storageClient, rgname, storageAccount.Name);
                MediaManagementTestUtilities.DeleteResourceGroup(resourcesClient, rgname);
            }
        }
    }
}
