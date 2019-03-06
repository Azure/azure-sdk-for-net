// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Management.DeploymentManager.Tests
{
    public class DeploymentManagerClientHelper
    {
        private ResourceManagementClient _client;
        private StorageManagementClient storageMgmtClient;
        private MockContext _context;
        private TestBase _testBase;

        public DeploymentManagerClientHelper(TestBase testBase, MockContext context) : this(
                testBase,
                context,
                new RecordedDelegatingHandler() { StatusCodeToReturn = System.Net.HttpStatusCode.OK })
        {
            this.ResourceGroupName = TestUtilities.GenerateName("deploymentmanager-sdk-net-test-rg");
        }

        public DeploymentManagerClientHelper(TestBase testBase, MockContext context, RecordedDelegatingHandler handler)
        {
            _client = DeploymentManagerTestUtilities.GetResourceManagementClient(context, handler);
            _testBase = testBase;
            _context = context;

            storageMgmtClient = DeploymentManagerTestUtilities.GetStorageManagementClient(context, handler);
        }

        public string ResourceGroupName { get; private set; }

        public void TryCreateResourceGroup(string location)
        {
            ResourceGroup result = _client.ResourceGroups.CreateOrUpdate(this.ResourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = _client.ResourceGroups.Get(this.ResourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "_client.ResourceGroups.Get returned null.");
            ThrowIfTrue(!this.ResourceGroupName.Equals(newlyCreatedGroup.Name), string.Format("resourceGroupName is not equal to {0}", this.ResourceGroupName));
        }

        public void DeleteResourceGroup(string resourceGroupName = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                _client.ResourceGroups.Delete(this.ResourceGroupName);
            }
            else
            {
                _client.ResourceGroups.Delete(resourceGroupName);
            }
        }

        public string GetBlobContainerSasUri()
        {
            string sasUri = "foobar";

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var accountKeyResult = this.storageMgmtClient.StorageAccounts.ListKeysWithHttpMessagesAsync(
                    DeploymentManagerTestUtilities.StorageAccountResourceGroup, 
                    DeploymentManagerTestUtilities.StorageAccountName).Result;
                var storageAccount = new CloudStorageAccount(
                    new StorageCredentials(
                        DeploymentManagerTestUtilities.StorageAccountName, 
                        accountKeyResult.Body.Key1), 
                    useHttps: true);

                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(DeploymentManagerTestUtilities.ContainerName);
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
