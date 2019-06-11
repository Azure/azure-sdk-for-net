// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Management.DeploymentManager.Tests
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.ManagedServiceIdentity;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Xunit;

    public class DeploymentManagerClientHelper
    {
        private ResourceManagementClient resourceManagementClient;
        private StorageManagementClient storageManagementClient;
        private ManagedServiceIdentityClient managedServiceIdentityClient;
        private AuthorizationManagementClient authorizationClient;

        private MockContext _context;
        private TestBase _testBase;

        public DeploymentManagerClientHelper(TestBase testBase, MockContext context) : this(
                testBase,
                context,
                new RecordedDelegatingHandler() { StatusCodeToReturn = System.Net.HttpStatusCode.OK })
        {
            this.ResourceGroupName = TestUtilities.GenerateName("admsdknet");
        }

        public DeploymentManagerClientHelper(TestBase testBase, MockContext context, RecordedDelegatingHandler handler)
        {
            _testBase = testBase;
            _context = context;

            resourceManagementClient = DeploymentManagerTestUtilities.GetResourceManagementClient(context, handler);
            storageManagementClient = DeploymentManagerTestUtilities.GetStorageManagementClient(context, handler);
            managedServiceIdentityClient = DeploymentManagerTestUtilities.GetManagedServiceIdentityClient(context, handler);
            authorizationClient = DeploymentManagerTestUtilities.GetAuthorizationManagementClient(context, handler);
        }

        public string ResourceGroupName { get; private set; }

        public void TryCreateResourceGroup(string location)
        {
            ResourceGroup result = resourceManagementClient.ResourceGroups.CreateOrUpdate(this.ResourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(this.ResourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "_client.ResourceGroups.Get returned null.");
            ThrowIfTrue(!this.ResourceGroupName.Equals(newlyCreatedGroup.Name), string.Format("resourceGroupName is not equal to {0}", this.ResourceGroupName));
        }

        public string GetProviderLocation(string providerName, string resourceType)
        {
            string defaultLocation = "Central US";
            string location = defaultLocation;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var providerType = resourceManagementClient.Providers.Get(providerName).ResourceTypes.ToList()
                    .FirstOrDefault(t => t.ResourceType.Equals(resourceType, StringComparison.OrdinalIgnoreCase));

                location = providerType?.Locations?.FirstOrDefault() ?? defaultLocation;
            }

            return location;
        }

        public void DeleteResourceGroup(string resourceGroupName = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceManagementClient.ResourceGroups.Delete(this.ResourceGroupName);
            }
            else
            {
                resourceManagementClient.ResourceGroups.Delete(resourceGroupName);
            }
        }

        public string CreateManagedIdentity(
            string subscriptionId,
            string identityName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var parameters = new Microsoft.Azure.Management.ManagedServiceIdentity.Models.Identity()
                {
                    Location = this.GetProviderLocation("Microsoft.ManagedIdentity", "userAssignedIdentities")
                };

                var identity = this.managedServiceIdentityClient.UserAssignedIdentities.CreateOrUpdate(
                    this.ResourceGroupName,
                    identityName,
                    parameters);

                Assert.NotNull(identity);

                // Give a couple minutes for the MSI to propagate. Observed failures of principalId not being found in the tenant
                // when there is no wait time between MSI creation and role assignment.
                DeploymentManagerTestUtilities.Sleep(TimeSpan.FromMinutes(2));

                var scope = "/subscriptions/" + subscriptionId;
                var roleDefinitionList = this.authorizationClient.RoleDefinitions.List(
                    scope,
                    new Microsoft.Rest.Azure.OData.ODataQuery<Microsoft.Azure.Management.Authorization.Models.RoleDefinitionFilter>("roleName eq 'Contributor'"));

                var roleAssignmentName = Guid.NewGuid().ToString();
                var roleAssignmentParameters = new Microsoft.Azure.Management.Authorization.Models.RoleAssignmentCreateParameters()
                {
                    PrincipalId = identity.PrincipalId.ToString(),
                    RoleDefinitionId = roleDefinitionList.First().Id,
                    CanDelegate = false
                };

                var roleAssignment = this.authorizationClient.RoleAssignments.Create(
                    scope,
                    roleAssignmentName,
                    roleAssignmentParameters);
                Assert.NotNull(roleAssignment);

                // Add additional wait time after role assignment to propagate permissions. Observed 
                // no permissions to modify resource group errors without wait time.
                DeploymentManagerTestUtilities.Sleep(TimeSpan.FromMinutes(1));

                roleAssignment = this.authorizationClient.RoleAssignments.Get(
                    scope,
                    roleAssignmentName);
                Assert.NotNull(roleAssignment);

                return identity.Id;
            }

            return "dummyIdentity";
        }

        public void CreateStorageAccount(string storageAccountName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var parameters = new Microsoft.Azure.Management.Storage.Models.StorageAccountCreateParameters()
                {
                    Location = this.GetProviderLocation("Microsoft.Storage", "storageAccounts"),
                    AccountType = Microsoft.Azure.Management.Storage.Models.AccountType.StandardLRS
                };

                var storageAccount = this.storageManagementClient.StorageAccounts.Create(
                    this.ResourceGroupName,
                    storageAccountName,
                    parameters);
            }
        }

        public void UploadBlob(
            string storageAccountName,
            string containerName,
            string filePath,
            string blobName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var accountKeyResult = this.storageManagementClient.StorageAccounts.ListKeysWithHttpMessagesAsync(
                    this.ResourceGroupName, 
                    storageAccountName).Result;
                var storageAccount = new CloudStorageAccount(
                    new StorageCredentials(
                        storageAccountName, 
                        accountKeyResult.Body.Key1), 
                    useHttps: true);

                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(containerName);

                container.CreateIfNotExistsAsync().Wait();

                var blob = container.GetBlockBlobReference(blobName);
                blob.UploadFromFileAsync(filePath).Wait();
            }
        }

        public string GetBlobContainerSasUri(string resourceGroupName, string storageAccountName, string containerName)
        {
            string sasUri = "foobar";

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var accountKeyResult = this.storageManagementClient.StorageAccounts.ListKeysWithHttpMessagesAsync(
                    resourceGroupName, 
                    storageAccountName).Result;
                var storageAccount = new CloudStorageAccount(
                    new StorageCredentials(
                        storageAccountName, 
                        accountKeyResult.Body.Key1), 
                    useHttps: true);

                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(containerName);
                container.CreateIfNotExistsAsync();
                sasUri = this.GetContainerSasUri(container);
            }

            return sasUri;
        }

        private string GetContainerSasUri(CloudBlobContainer container)
        {
            var sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddDays(-1);
            sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddDays(2);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List;

            // Generate the shared access signature on the blob, setting the constraints directly on the signature.
            string sasContainerToken = container.GetSharedAccessSignature(sasConstraints);

            // Return the URI string for the container, including the SAS token.
            return container.Uri + sasContainerToken;
        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}
