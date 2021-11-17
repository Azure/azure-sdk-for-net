// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_Deployments_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
#endregion Manage_Deployments_Namespaces

namespace Azure.ResourceManager.Resources.Tests.Samples
{
    public class Sample2_ManagingDeployments
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDeployments()
        {
            #region Snippet:Managing_Deployments_CreateADeployment
            // First we need to get the deployment collection from the resource group
            DeploymentCollection deploymentCollection = resourceGroup.GetDeployments();
            // Use the same location as the resource group
            string deploymentName = "myDeployment";
            var input = new DeploymentInput(new DeploymentProperties(DeploymentMode.Incremental)
            {
                TemplateLink = new TemplateLink()
                {
                    Uri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json"
                },
                Parameters = new JsonObject()
                {
                    {"storageAccountType", new JsonObject()
                        {
                            {"value", "Standard_GRS" }
                        }
                    }
                }
            });
            DeploymentCreateOrUpdateAtScopeOperation lro = await deploymentCollection.CreateOrUpdateAsync(deploymentName, input);
            Deployment deployment = lro.Value;
            #endregion Snippet:Managing_Deployments_CreateADeployment
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListDeployments()
        {
            #region Snippet:Managing_Deployments_ListAllDeployments
            // First we need to get the deployment collection from the resource group
            DeploymentCollection deploymentCollection = resourceGroup.GetDeployments();
            // With GetAllAsync(), we can get a list of the deployments in the collection
            AsyncPageable<Deployment> response = deploymentCollection.GetAllAsync();
            await foreach (Deployment deployment in response)
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
            DeploymentCollection deploymentCollection = resourceGroup.GetDeployments();
            // Now we can get the deployment with GetAsync()
            Deployment deployment = await deploymentCollection.GetAsync("myDeployment");
            // With DeleteAsync(), we can delete the deployment
            await deployment.DeleteAsync();
            #endregion Snippet:Managing_Deployments_DeleteADeployment
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgCollection.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
