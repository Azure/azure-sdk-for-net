// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using System;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests
{
    public class DatastoreTests : ConnectedVMwareTestBase
    {
        public DatastoreTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<VMwareDatastoreCollection> GetVMwareDatastoreCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetVMwareDatastores();
        }

        // CreateDatastore
        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate_CreateDatastore()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/CreateDatastore.json
            // this example is just showing the usage of "Datastores_Create" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareDatastoreResource
            VMwareDatastoreCollection collection = resourceGroupResource.GetVMwareDatastores();

            // invoke the operation
            string datastoreName = "datastore1";
            VMwareDatastoreData data = new VMwareDatastoreData(new AzureLocation("East US"))
            {
                ExtendedLocation = new ExtendedLocation()
                {
                    ExtendedLocationType = "CustomLocation",
                    Name = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/azcli-test-rg/providers/microsoft.extendedlocation/customlocations/azcli-test-cl",
                },
                InventoryItemId = "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/azcli-test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/azcli-test-vc/InventoryItems/datastore-1102196",
            };
            ArmOperation<VMwareDatastoreResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, datastoreName, data);
            VMwareDatastoreResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareDatastoreData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // GetDatastore
        [TestCase]
        [RecordedTest]
        public async Task Get_GetDatastore()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetDatastore.json
            // this example is just showing the usage of "Datastores_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareDatastoreResource
            VMwareDatastoreCollection collection = resourceGroupResource.GetVMwareDatastores();

            // invoke the operation
            string datastoreName = "datastore1";
            VMwareDatastoreResource result = await collection.GetAsync(datastoreName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            VMwareDatastoreData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        // GetDatastore
        [TestCase]
        [RecordedTest]
        public async Task Exists_GetDatastore()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetDatastore.json
            // this example is just showing the usage of "Datastores_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareDatastoreResource
            VMwareDatastoreCollection collection = resourceGroupResource.GetVMwareDatastores();

            // invoke the operation
            string datastoreName = "datastore1";
            bool result = await collection.ExistsAsync(datastoreName);

            Console.WriteLine($"Succeeded: {result}");
        }

        // GetDatastore
        [TestCase]
        [RecordedTest]
        public async Task GetIfExists_GetDatastore()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/GetDatastore.json
            // this example is just showing the usage of "Datastores_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareDatastoreResource
            VMwareDatastoreCollection collection = resourceGroupResource.GetVMwareDatastores();

            // invoke the operation
            string datastoreName = "datastore1";
            NullableResponse<VMwareDatastoreResource> response = await collection.GetIfExistsAsync(datastoreName);
            VMwareDatastoreResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine($"Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VMwareDatastoreData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }

        // ListDatastoresByResourceGroup
        [TestCase]
        [RecordedTest]
        public async Task GetAll_ListDatastoresByResourceGroup()
        {
            // Generated from example definition: specification/connectedvmware/resource-manager/Microsoft.ConnectedVMwarevSphere/stable/2023-10-01/examples/ListDatastoresByResourceGroup.json
            // this example is just showing the usage of "Datastores_ListByResourceGroup" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ResourceGroupResource created on azure
            // for more information of creating ResourceGroupResource, please refer to the document of ResourceGroupResource
            string subscriptionId = "204898ee-cd13-4332-b9d4-55ca5c25496d";
            string resourceGroupName = "azcli-test-rg";
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this VMwareDatastoreResource
            VMwareDatastoreCollection collection = resourceGroupResource.GetVMwareDatastores();

            // invoke the operation and iterate over the result
            await foreach (VMwareDatastoreResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                VMwareDatastoreData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
