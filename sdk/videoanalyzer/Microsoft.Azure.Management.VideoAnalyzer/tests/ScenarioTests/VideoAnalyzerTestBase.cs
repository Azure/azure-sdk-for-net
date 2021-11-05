// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using VideoAnalyzer.Tests.Helpers;
using Microsoft.Azure.Management.VideoAnalyzer;
using Microsoft.Azure.Management.VideoAnalyzer.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Net;
using System;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.ManagedServiceIdentity.Models;

namespace VideoAnalyzer.Tests.ScenarioTests
{
    public class VideoAnalyzerTestBase
    {
        public ResourceManagementClient ResourceClient { get; private set; }

        public VideoAnalyzerClient VideoAnalyzerClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public string ResourceGroup { get; private set; }

        public Identity ManagedIdentity { get; private set; }

        public ManagedServiceIdentityClient IdentityManagementClient;

        public Microsoft.Azure.Management.Storage.Models.StorageAccount StorageAccount { get; private set; }

        public string AccountName { get; private set; }

        public string Location { get; private set; }

        private AuthorizationManagementClient authorizationManagementClient;

        protected MockContext StartMockContextAndInitializeClients(Type typeName,
            // Automatically populates the methodName parameter with the calling method, which
            // gets used to generate recorder file names.
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "")
        {
            MockContext context = MockContext.Start(typeName, methodName);

            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler4 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler5 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            // Create clients
            VideoAnalyzerClient = VideoAnalyzerManagementTestUtilities.GetVideoAnalyzerManagementClient(context, handler1);
            ResourceClient = VideoAnalyzerManagementTestUtilities.GetResourceManagementClient(context, handler2);
            StorageClient = VideoAnalyzerManagementTestUtilities.GetStorageManagementClient(context, handler3);
            IdentityManagementClient = VideoAnalyzerManagementTestUtilities.GetManagedIdentityClient(context, handler4);
            authorizationManagementClient = VideoAnalyzerManagementTestUtilities.GetAuthorizationManagementClient(context, handler5);

            Location = VideoAnalyzerManagementTestUtilities.TryGetLocation(ResourceClient, VideoAnalyzerManagementTestUtilities.DefaultLocation);

            ResourceGroup = VideoAnalyzerManagementTestUtilities.CreateResourceGroup(ResourceClient, Location);

            // Create storage account
            StorageAccount = VideoAnalyzerManagementTestUtilities.CreateStorageAccount(StorageClient, ResourceGroup, Location);

            ManagedIdentity = VideoAnalyzerManagementTestUtilities.CreateManagedIdentity(IdentityManagementClient, ResourceGroup, Location);
            VideoAnalyzerManagementTestUtilities.AddRoleAssignment(authorizationManagementClient, StorageAccount.Id, "Storage Blob Data Contributor", TestUtilities.GenerateGuid().ToString(), ManagedIdentity.PrincipalId.ToString());
            VideoAnalyzerManagementTestUtilities.AddRoleAssignment(authorizationManagementClient, StorageAccount.Id, "Reader", TestUtilities.GenerateGuid().ToString(), ManagedIdentity.PrincipalId.ToString());

            return context;
        }

        public void CreateVideoAnalyzerAccount()
        {
            // Create a video analyzer account
            string accountName = TestUtilities.GenerateName("videoanalyzer");
            var videoAnalyzer = new VideoAnalyzerAccount
            {
                Location = VideoAnalyzerManagementTestUtilities.DefaultLocation,
                Tags = new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                },
                StorageAccounts = new List<StorageAccount>
                    {
                        new StorageAccount
                        {
                            Id = StorageAccount.Id,
                            Identity= new ResourceIdentity{
                            UserAssignedIdentity = ManagedIdentity.Id
                            }
                        }
                    },
                Identity = new VideoAnalyzerIdentity
                {
                    Type = "UserAssigned",
                    UserAssignedIdentities = new Dictionary<string, UserAssignedManagedIdentity>() { { ManagedIdentity.Id, new UserAssignedManagedIdentity() } }
                }
            };

            VideoAnalyzerAccount videoAnalyzerAccount = VideoAnalyzerClient.VideoAnalyzers.CreateOrUpdate(ResourceGroup, accountName, videoAnalyzer);
            AccountName = videoAnalyzerAccount.Name;
        }

        public void DeleteVideoAnalyzerAccount()
        {
            if (!string.IsNullOrEmpty(AccountName))
            {
                VideoAnalyzerClient.VideoAnalyzers.Delete(ResourceGroup, AccountName);
            }

            if (!string.IsNullOrEmpty(StorageAccount.Name))
            {
                VideoAnalyzerManagementTestUtilities.DeleteStorageAccount(StorageClient, ResourceGroup, StorageAccount.Name);
            }

            if (ManagedIdentity != null)
            {
                VideoAnalyzerManagementTestUtilities.DeleteManagedIdentity(IdentityManagementClient,ResourceGroup, ManagedIdentity.Name);
            }
            
            if (!string.IsNullOrEmpty(ResourceGroup))
            {
                VideoAnalyzerManagementTestUtilities.DeleteResourceGroup(ResourceClient, ResourceGroup);
            }
        }
    }
}

