// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageActions;
using Azure.ResourceManager.StorageActions.Models;

namespace Azure.ResourceManager.StorageActions.Tests.Samples
{
    public partial class Sample_StorageTaskCollection
    {
        /// <summary>
        /// Asynchronously creates a new storage task resource with the specified parameters. If a storage task is already created and a subsequent create request is issued with different properties, the storage task properties will be updated. If a storage task is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.
        /// </summary>
        public async Task CreateOrUpdateAsync_PutStorageTask()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "1f31ba14-ce16-4281-b9b4-3e78da6e1616";
            string resourceGroupName = "res4228";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this StorageTaskResource
            StorageTaskCollection collection = resourceGroupResource.GetStorageTasks();

            // invoke the operation
            string storageTaskName = "mytask1";
            StorageTaskData data = new StorageTaskData(
                location: AzureLocation.WestUS,
                identity: new ManagedServiceIdentity("SystemAssigned"),
                properties: new StorageTaskProperties(
                    isEnabled: true,
                    description: "My Storage task",
                    action: new StorageTaskAction(
                        @if: new StorageTaskIfCondition(
                            condition: "[[equals(AccessTier, 'Cool')]]",
                            operations: new StorageTaskOperationInfo[]
                            {
                                new StorageTaskOperationInfo(StorageTaskOperationName.SetBlobTier)
                                {
                                    OnFailure = OnFailureAction.Break,
                                    OnSuccess = OnSuccessAction.Continue,
                                    Parameters = { ["tier"] = "Hot" }
                                }
                            }
                        )
                    )
                    {
                        ElseOperations = new StorageTaskOperationInfo[]
                        {
                            new StorageTaskOperationInfo(StorageTaskOperationName.DeleteBlob)
                            {
                                OnFailure = OnFailureAction.Break,
                                OnSuccess = OnSuccessAction.Continue
                            }
                        }
                    }
                )
            );
            ArmOperation<StorageTaskResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, storageTaskName, data);
            StorageTaskResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            StorageTaskData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
