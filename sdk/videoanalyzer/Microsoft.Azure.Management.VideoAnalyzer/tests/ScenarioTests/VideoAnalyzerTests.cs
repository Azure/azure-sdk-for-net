// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using VideoAnalyzer.Tests.Helpers;
using Microsoft.Azure.Management.VideoAnalyzer;
using Microsoft.Azure.Management.VideoAnalyzer.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace VideoAnalyzer.Tests.ScenarioTests
{
    public class VideoAnalyzerTests : VideoAnalyzerTestBase
    {
        [Fact]
        public void VideoAnalyzerCheckNameAvailabiltyTest()
        {

            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    var videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Empty(videoAnalyzers.Value);

                    var location = VideoAnalyzerManagementTestUtilities.TryGetLocation(ResourceClient, VideoAnalyzerManagementTestUtilities.DefaultLocation);
                    var lowerCaseLocationWithoutSpaces = location.Replace(" ", string.Empty).ToLowerInvariant();

                    string videoAnalyzerType = "Microsoft.Media/VideoAnalyzers";

                    CreateVideoAnalyzerAccount();

                    videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Single(videoAnalyzers.Value);

                    // check name availabilty
                    var checkNameAvailabilityOutput = VideoAnalyzerClient.Locations.CheckNameAvailability(lowerCaseLocationWithoutSpaces, AccountName, videoAnalyzerType);
                    Assert.False(checkNameAvailabilityOutput.NameAvailable);
                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }

        [Fact]
        public void VideoAnalyzerListByResourceGroupTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    var videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Empty(videoAnalyzers.Value);

                    CreateVideoAnalyzerAccount();

                    var location = VideoAnalyzerManagementTestUtilities.TryGetLocation(ResourceClient, VideoAnalyzerManagementTestUtilities.DefaultLocation);
                    var lowerCaseLocationWithoutSpaces = location.Replace(" ", string.Empty).ToLowerInvariant(); // TODO: Fix this once the bug is addressed

                    videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Single(videoAnalyzers.Value);
                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }

        [Fact]
        public void VideoAnalyzerGetTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    var videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Empty(videoAnalyzers.Value);

                    CreateVideoAnalyzerAccount();

                    var location = VideoAnalyzerManagementTestUtilities.TryGetLocation(ResourceClient, VideoAnalyzerManagementTestUtilities.DefaultLocation);
                    var lowerCaseLocationWithoutSpaces = location.Replace(" ", string.Empty).ToLowerInvariant(); // TODO: Fix this once the bug is addressed

                    videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Single(videoAnalyzers.Value);

                    var VideoAnalyzerGet = VideoAnalyzerClient.VideoAnalyzers.Get(ResourceGroup, AccountName);
                    Assert.NotNull(VideoAnalyzerGet);
                    Assert.Equal(AccountName, VideoAnalyzerGet.Name);
                    Assert.Equal(new Dictionary<string, string>
                                {
                                    { "key1","value1"},
                                    { "key2","value2"}
                                }, VideoAnalyzerGet.Tags);

                    Assert.Equal(1, VideoAnalyzerGet.StorageAccounts.Count);
                    Assert.Equal(StorageAccount.Id, VideoAnalyzerGet.StorageAccounts.ElementAt(0).Id);
                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }

        [Fact]
        public void VideoAnalyzerCreateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler4 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler5 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var videoAnalyzerClient = VideoAnalyzerManagementTestUtilities.GetVideoAnalyzerManagementClient(context, handler1);
                var resourceClient = VideoAnalyzerManagementTestUtilities.GetResourceManagementClient(context, handler2);
                var storageClient = VideoAnalyzerManagementTestUtilities.GetStorageManagementClient(context, handler3);
                var identityManagementClient = VideoAnalyzerManagementTestUtilities.GetManagedIdentityClient(context, handler4);
                var authorizationManagementClient = VideoAnalyzerManagementTestUtilities.GetAuthorizationManagementClient(context, handler5);

                var location = VideoAnalyzerManagementTestUtilities.TryGetLocation(resourceClient, VideoAnalyzerManagementTestUtilities.DefaultLocation);

                var resourceGroup = VideoAnalyzerManagementTestUtilities.CreateResourceGroup(resourceClient, location);

                // Create storage account
                var storageAccount = VideoAnalyzerManagementTestUtilities.CreateStorageAccount(storageClient, resourceGroup, location);

                var managedIdentity = VideoAnalyzerManagementTestUtilities.CreateManagedIdentity(identityManagementClient, resourceGroup, location);
                VideoAnalyzerManagementTestUtilities.AddRoleAssignment(authorizationManagementClient, storageAccount.Id, "Storage Blob Data Contributor", TestUtilities.GenerateGuid().ToString(), managedIdentity.PrincipalId.ToString());
                VideoAnalyzerManagementTestUtilities.AddRoleAssignment(authorizationManagementClient, storageAccount.Id, "Reader", TestUtilities.GenerateGuid().ToString(), managedIdentity.PrincipalId.ToString());

                // Create a video analyzer account
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
                        Identity= new ResourceIdentity
                        {
                            UserAssignedIdentity = managedIdentity.Id
                        }
                    }
                };

                var VideoAnalyzer = new VideoAnalyzerAccount
                {
                    Location = VideoAnalyzerManagementTestUtilities.DefaultLocation,
                    Tags = tagsCreate,
                    StorageAccounts = storageAccountsCreate,
                    Identity = new VideoAnalyzerIdentity
                    {
                        Type = "UserAssigned",
                        UserAssignedIdentities = new Dictionary<string, UserAssignedManagedIdentity>() 
                        {
                            {
                                managedIdentity.Id, new UserAssignedManagedIdentity() 
                            }
                        }
                    }
                };

                videoAnalyzerClient.VideoAnalyzers.CreateOrUpdate(resourceGroup, accountName, VideoAnalyzer);

                var VideoAnalyzerGet = videoAnalyzerClient.VideoAnalyzers.Get(resourceGroup, accountName);
                Assert.NotNull(VideoAnalyzerGet);
                Assert.Equal(accountName, VideoAnalyzerGet.Name);
                Assert.Equal(tagsCreate, VideoAnalyzerGet.Tags);
                Assert.Equal(1, VideoAnalyzerGet.StorageAccounts.Count);
                Assert.Equal(storageAccount.Id, VideoAnalyzerGet.StorageAccounts.ElementAt(0).Id);

                videoAnalyzerClient.VideoAnalyzers.Delete(resourceGroup, accountName);
                VideoAnalyzerManagementTestUtilities.DeleteStorageAccount(storageClient, resourceGroup, storageAccount.Name);
                VideoAnalyzerManagementTestUtilities.DeleteResourceGroup(resourceClient, resourceGroup);
            }
        }

        [Fact]
        public void VideoAnalyzerUpdateTest()
        {

            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    var videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Empty(videoAnalyzers.Value);

                    CreateVideoAnalyzerAccount();

                    var location = VideoAnalyzerManagementTestUtilities.TryGetLocation(ResourceClient, VideoAnalyzerManagementTestUtilities.DefaultLocation);
                    var lowerCaseLocationWithoutSpaces = location.Replace(" ", string.Empty).ToLowerInvariant(); // TODO: Fix this once the bug is addressed

                    videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Single(videoAnalyzers.Value);

                    var VideoAnalyzerGet = VideoAnalyzerClient.VideoAnalyzers.Get(ResourceGroup, AccountName);
                    Assert.NotNull(VideoAnalyzerGet);
                    Assert.Equal(AccountName, VideoAnalyzerGet.Name);

                    var tagsUpdated = new Dictionary<string, string>
                {
                    { "key3","value3"},
                    { "key4","value4"}
                };
                    VideoAnalyzerClient.VideoAnalyzers.Update(ResourceGroup, AccountName, new VideoAnalyzerUpdate
                    {
                        Tags = tagsUpdated
                    });

                    VideoAnalyzerGet = VideoAnalyzerClient.VideoAnalyzers.Get(ResourceGroup, AccountName);
                    Assert.NotNull(VideoAnalyzerGet);
                    Assert.Equal(AccountName, VideoAnalyzerGet.Name);
                    Assert.Equal(tagsUpdated, VideoAnalyzerGet.Tags);
                }
                finally
                {

                    if (!string.IsNullOrEmpty(StorageAccount.Name))
                    {
                        VideoAnalyzerManagementTestUtilities.DeleteStorageAccount(StorageClient, ResourceGroup, StorageAccount.Name);
                    }

                    if (ManagedIdentity != null)
                    {
                        VideoAnalyzerManagementTestUtilities.DeleteManagedIdentity(IdentityManagementClient, ResourceGroup, ManagedIdentity.Name);
                    }

                    if (!string.IsNullOrEmpty(ResourceGroup))
                    {
                        VideoAnalyzerManagementTestUtilities.DeleteResourceGroup(ResourceClient, ResourceGroup);
                    }
                }
            }
        }

        [Fact]
        public void VideoAnalyzerDeleteTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    var videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Empty(videoAnalyzers.Value);

                    CreateVideoAnalyzerAccount();

                    var location = VideoAnalyzerManagementTestUtilities.TryGetLocation(ResourceClient, VideoAnalyzerManagementTestUtilities.DefaultLocation);
                    var lowerCaseLocationWithoutSpaces = location.Replace(" ", string.Empty).ToLowerInvariant(); // TODO: Fix this once the bug is addressed

                    videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Single(videoAnalyzers.Value);

                    VideoAnalyzerClient.VideoAnalyzers.Delete(ResourceGroup, AccountName);
                    videoAnalyzers = VideoAnalyzerClient.VideoAnalyzers.List(ResourceGroup);
                    Assert.Empty(videoAnalyzers.Value);
                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }
    }
}

