// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.CognitiveServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Samples
{
    public partial class Sample_CognitiveServicesAccountDeploymentResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetDeployment()
        {
            // Generated from example definition: specification/cognitiveservices/resource-manager/Microsoft.CognitiveServices/stable/2025-06-01/examples/GetDeployment.json
            // this example is just showing the usage of "Deployments_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CognitiveServicesAccountDeploymentResource created on azure
            // for more information of creating CognitiveServicesAccountDeploymentResource, please refer to the document of CognitiveServicesAccountDeploymentResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "resourceGroupName";
            string accountName = "accountName";
            string deploymentName = "deploymentName";
            ResourceIdentifier cognitiveServicesAccountDeploymentResourceId = CognitiveServicesAccountDeploymentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, deploymentName);
            CognitiveServicesAccountDeploymentResource cognitiveServicesAccountDeployment = client.GetCognitiveServicesAccountDeploymentResource(cognitiveServicesAccountDeploymentResourceId);

            // invoke the operation
            CognitiveServicesAccountDeploymentResource result = await cognitiveServicesAccountDeployment.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CognitiveServicesAccountDeploymentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteDeployment()
        {
            // Generated from example definition: specification/cognitiveservices/resource-manager/Microsoft.CognitiveServices/stable/2025-06-01/examples/DeleteDeployment.json
            // this example is just showing the usage of "Deployments_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CognitiveServicesAccountDeploymentResource created on azure
            // for more information of creating CognitiveServicesAccountDeploymentResource, please refer to the document of CognitiveServicesAccountDeploymentResource
            string subscriptionId = "00000000-1111-2222-3333-444444444444";
            string resourceGroupName = "resourceGroupName";
            string accountName = "accountName";
            string deploymentName = "deploymentName";
            ResourceIdentifier cognitiveServicesAccountDeploymentResourceId = CognitiveServicesAccountDeploymentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, deploymentName);
            CognitiveServicesAccountDeploymentResource cognitiveServicesAccountDeployment = client.GetCognitiveServicesAccountDeploymentResource(cognitiveServicesAccountDeploymentResourceId);

            // invoke the operation
            await cognitiveServicesAccountDeployment.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_UpdateDeployment()
        {
            // Generated from example definition: specification/cognitiveservices/resource-manager/Microsoft.CognitiveServices/stable/2025-06-01/examples/UpdateDeployment.json
            // this example is just showing the usage of "Deployments_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CognitiveServicesAccountDeploymentResource created on azure
            // for more information of creating CognitiveServicesAccountDeploymentResource, please refer to the document of CognitiveServicesAccountDeploymentResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "resourceGroupName";
            string accountName = "accountName";
            string deploymentName = "deploymentName";
            ResourceIdentifier cognitiveServicesAccountDeploymentResourceId = CognitiveServicesAccountDeploymentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, deploymentName);
            CognitiveServicesAccountDeploymentResource cognitiveServicesAccountDeployment = client.GetCognitiveServicesAccountDeploymentResource(cognitiveServicesAccountDeploymentResourceId);

            // invoke the operation
            PatchResourceTagsAndSku deployment = new PatchResourceTagsAndSku
            {
                Sku = new CognitiveServicesSku("Standard")
                {
                    Capacity = 1,
                },
            };
            ArmOperation<CognitiveServicesAccountDeploymentResource> lro = await cognitiveServicesAccountDeployment.UpdateAsync(WaitUntil.Completed, deployment);
            CognitiveServicesAccountDeploymentResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CognitiveServicesAccountDeploymentData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetSkus_ListDeploymentSkus()
        {
            // Generated from example definition: specification/cognitiveservices/resource-manager/Microsoft.CognitiveServices/stable/2025-06-01/examples/ListDeploymentSkus.json
            // this example is just showing the usage of "Deployments_ListSkus" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CognitiveServicesAccountDeploymentResource created on azure
            // for more information of creating CognitiveServicesAccountDeploymentResource, please refer to the document of CognitiveServicesAccountDeploymentResource
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "resourceGroupName";
            string accountName = "accountName";
            string deploymentName = "deploymentName";
            ResourceIdentifier cognitiveServicesAccountDeploymentResourceId = CognitiveServicesAccountDeploymentResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName, deploymentName);
            CognitiveServicesAccountDeploymentResource cognitiveServicesAccountDeployment = client.GetCognitiveServicesAccountDeploymentResource(cognitiveServicesAccountDeploymentResourceId);

            // invoke the operation and iterate over the result
            await foreach (CognitiveServicesResourceSku item in cognitiveServicesAccountDeployment.GetSkusAsync())
            {
                Console.WriteLine($"Succeeded: {item}");
            }

            Console.WriteLine("Succeeded");
        }
    }
}
