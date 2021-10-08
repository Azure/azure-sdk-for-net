// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_DeploymentExtendeds_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
#endregion Manage_DeploymentExtendeds_Namespaces

namespace Azure.ResourceManager.Resources.Tests.Samples
{
    public class Sample2_ManagingDeploymentExtendeds
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDeploymentExtendeds()
        {
            #region Snippet:Managing_DeploymentExtendeds_CreateADeploymentExtended
            // First we need to get the deployment extended container from the resource group
            DeploymentExtendedContainer deploymentExtendedContainer = resourceGroup.GetDeploymentExtendeds();
            // Use the same location as the resource group
            string deploymentExtendedName = "myDeployment";
            var input = new Deployment(new DeploymentProperties(DeploymentMode.Incremental)
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
            DeploymentCreateOrUpdateAtScopeOperation lro = await deploymentExtendedContainer.CreateOrUpdateAsync(deploymentExtendedName, input);
            DeploymentExtended deploymentExtended = lro.Value;
            #endregion Snippet:Managing_DeploymentExtendeds_CreateADeploymentExtended
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListDeploymentExtendeds()
        {
            #region Snippet:Managing_DeploymentExtendeds_ListAllDeploymentExtendeds
            // First we need to get the deployment extended container from the resource group
            DeploymentExtendedContainer deploymentExtendedContainer = resourceGroup.GetDeploymentExtendeds();
            // With GetAllAsync(), we can get a list of the deployment extendeds in the container
            AsyncPageable<DeploymentExtended> response = deploymentExtendedContainer.GetAllAsync();
            await foreach (DeploymentExtended deploymentExtended in response)
            {
                Console.WriteLine(deploymentExtended.Data.Name);
            }
            #endregion Snippet:Managing_DeploymentExtendeds_ListAllDeploymentExtendeds
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteDeploymentExtendeds()
        {
            #region Snippet:Managing_DeploymentExtendeds_DeleteADeploymentExtended
            // First we need to get the deployment extended container from the resource group
            DeploymentExtendedContainer deploymentExtendedContainer = resourceGroup.GetDeploymentExtendeds();
            // Now we can get the deployment extended with GetAsync()
            DeploymentExtended deploymentExtended = await deploymentExtendedContainer.GetAsync("myDeployment");
            // With DeleteAsync(), we can delete the deployment extended
            await deploymentExtended.DeleteAsync();
            #endregion Snippet:Managing_DeploymentExtendeds_DeleteADeploymentExtended
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;

            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            ResourceGroupCreateOrUpdateOperation lro = await rgContainer.CreateOrUpdateAsync(rgName, new ResourceGroupData(location));
            ResourceGroup resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
