// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_Deployments_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System.Text.Json;
using System.IO;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using System.Security.Policy;
#endregion Manage_Deployments_Namespaces

namespace Azure.ResourceManager.Resources.Tests.Samples
{
    public class Sample2_ManagingDeployments
    {
        private ResourceGroupResource resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDeployments()
        {
            #region Snippet:Managing_Deployments_CreateADeployment
            // First we need to get the deployment collection from the resource group
            ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
            // Use the same location as the resource group
            string deploymentName = "myDeployment";
            var input = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
            {
                TemplateLink = new ArmDeploymentTemplateLink()
                {
                    Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json")
                },
                Parameters = BinaryData.FromObjectAsJson(new JsonObject()
                {
                    {"storageAccountType", new JsonObject()
                        {
                            {"value", "Standard_GRS" }
                        }
                    }
                })
            });
            ArmOperation<ArmDeploymentResource> lro = await ArmDeploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
            ArmDeploymentResource deployment = lro.Value;
            #endregion Snippet:Managing_Deployments_CreateADeployment
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDeploymentsUsingJsonElement()
        {
            #region Snippet:Managing_Deployments_CreateADeploymentUsingJsonElement
            // First we need to get the deployment collection from the resource group
            ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
            // Use the same location as the resource group
            string deploymentName = "myDeployment";
            // Create a parameter object
            var parametersObject = new { storageAccountType = new { value = "Standard_GRS" } };
            //convert this object to JsonElement
            var parametersString = JsonSerializer.Serialize(parametersObject);
            using var jsonDocument = JsonDocument.Parse(parametersString);
            var parameters = jsonDocument.RootElement;
            var input = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
            {
                TemplateLink = new ArmDeploymentTemplateLink()
                {
                    Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json")
                },
                Parameters = BinaryData.FromString(parameters.GetRawText())
            });
            ArmOperation<ArmDeploymentResource> lro = await ArmDeploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
            ArmDeploymentResource deployment = lro.Value;
            #endregion Snippet:Managing_Deployments_CreateADeployment
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDeploymentsUsingString()
        {
            #region Snippet:Managing_Deployments_CreateADeploymentUsingString
            // First we need to get the deployment collection from the resource group
            ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
            // Use the same location as the resource group
            string deploymentName = "myDeployment";
            // Passing string to template and parameters
            var input = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
            {
                Template = BinaryData.FromString(File.ReadAllText("storage-template.json")),
                Parameters = BinaryData.FromString(File.ReadAllText("storage-parameters.json"))
            });
            ArmOperation<ArmDeploymentResource> lro = await ArmDeploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
            ArmDeploymentResource deployment = lro.Value;
            #endregion Snippet:Managing_Deployments_CreateADeployment
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListDeployments()
        {
            #region Snippet:Managing_Deployments_ListAllDeployments
            // First we need to get the deployment collection from the resource group
            ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
            // With GetAllAsync(), we can get a list of the deployments in the collection
            AsyncPageable<ArmDeploymentResource> response = ArmDeploymentCollection.GetAllAsync();
            await foreach (ArmDeploymentResource deployment in response)
            {
                Console.WriteLine(deployment.Data.Name);
            }
            #endregion Snippet:Managing_Deployments_ListAllDeployments
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteDeployments()
        {
            #region Snippet:Managing_Deployments_DeleteADeployment
            // First we need to get the deployment collection from the resource group
            ArmDeploymentCollection ArmDeploymentCollection = resourceGroup.GetArmDeployments();
            // Now we can get the deployment with GetAsync()
            ArmDeploymentResource deployment = await ArmDeploymentCollection.GetAsync("myDeployment");
            // With DeleteAsync(), we can delete the deployment
            await deployment.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_Deployments_DeleteADeployment
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
