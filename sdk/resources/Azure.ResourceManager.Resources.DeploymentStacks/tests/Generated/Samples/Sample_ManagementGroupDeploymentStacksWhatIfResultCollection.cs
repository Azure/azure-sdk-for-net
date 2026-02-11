// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.DeploymentStacks.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.DeploymentStacks.Samples
{
    public partial class Sample_ManagementGroupDeploymentStacksWhatIfResultCollection
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task CreateOrUpdate_CreateOrUpdateAManagementGroupDeploymentStackWhatIfResult()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "myMg";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            // get the collection of this DeploymentStackWhatIfResultResource
            DeploymentStackWhatIfResultCollection collection = client.GetDeploymentStackWhatIfResults(managementGroupResourceId);

            // invoke the operation
            string deploymentStacksWhatIfResultName = "simpleDeploymentStackWhatIfResult";
            DeploymentStackWhatIfResultData data = new DeploymentStackWhatIfResultData()
            {
                Location = new AzureLocation("eastus"),
                Properties = new DeploymentStackWhatIfResultProperties(new ActionOnUnmanage(UnmanageActionResourceMode.Delete)
                    {
                        ResourceGroups = UnmanageActionResourceGroupMode.Delete,
                        ManagementGroups = UnmanageActionManagementGroupMode.Detach,
                    },
                    new DeploymentStackDenySettings(DeploymentStackDenySettingsMode.None)
                    {
                        ApplyToChildScopes = false,
                    },
                    new ResourceIdentifier("/providers/Microsoft.Management/managementGroups/myMg/providers/Microsoft.Resources/deploymentStacks/simpleDeploymentStack"),
                    XmlConvert.ToTimeSpan("P7D"))
                {
                    TemplateLink = new DeploymentStacksTemplateLink
                    {
                        Uri = new Uri("https://example.com/exampleTemplate.json"),
                    },
                    Parameters = { },
                    ExtensionConfigs = {
                        ["contoso"] = new DeploymentExtensionConfig()
                    },
                },
            };
            ArmOperation<DeploymentStackWhatIfResultResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentStacksWhatIfResultName, data);
            DeploymentStackWhatIfResultResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DeploymentStackWhatIfResultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetAManagementGroupDeploymentStackWhatIfResult()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "myMg";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            // get the collection of this DeploymentStackWhatIfResultResource
            DeploymentStackWhatIfResultCollection collection = client.GetDeploymentStackWhatIfResults(managementGroupResourceId);

            // invoke the operation
            string deploymentStacksWhatIfResultName = "simpleDeploymentStackWhatIfResult";
            DeploymentStackWhatIfResultResource result = await collection.GetAsync(deploymentStacksWhatIfResultName);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DeploymentStackWhatIfResultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetAll_ListTheAvailableManagementGroupDeploymentStackWhatIfResult()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "myMg";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            // get the collection of this DeploymentStackWhatIfResultResource
            DeploymentStackWhatIfResultCollection collection = client.GetDeploymentStackWhatIfResults(managementGroupResourceId);

            // invoke the operation and iterate over the result
            await foreach (DeploymentStackWhatIfResultResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                DeploymentStackWhatIfResultData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Exists_GetAManagementGroupDeploymentStackWhatIfResult()
        {
            // Generated from example definition: 2025-07-01/DeploymentStackWhatIfResultsManagementGroupGet.json
            // this example is just showing the usage of "DeploymentStacksWhatIfResult_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "myMg";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            // get the collection of this DeploymentStackWhatIfResultResource
            DeploymentStackWhatIfResultCollection collection = client.GetDeploymentStackWhatIfResults(managementGroupResourceId);

            // invoke the operation
            string deploymentStacksWhatIfResultName = "simpleDeploymentStackWhatIfResult";
            bool result = await collection.ExistsAsync(deploymentStacksWhatIfResultName);

            Console.WriteLine($"Succeeded: {result}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task GetIfExists_GetAManagementGroupDeploymentStackWhatIfResult()
        {
            // Generated from example definition: 2025-07-01/DeploymentStackWhatIfResultsManagementGroupGet.json
            // this example is just showing the usage of "DeploymentStacksWhatIfResult_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "myMg";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            // get the collection of this DeploymentStackWhatIfResultResource
            DeploymentStackWhatIfResultCollection collection = client.GetDeploymentStackWhatIfResults(managementGroupResourceId);

            // invoke the operation
            string deploymentStacksWhatIfResultName = "simpleDeploymentStackWhatIfResult";
            NullableResponse<DeploymentStackWhatIfResultResource> response = await collection.GetIfExistsAsync(deploymentStacksWhatIfResultName);
            DeploymentStackWhatIfResultResource result = response.HasValue ? response.Value : null;

            if (result == null)
            {
                Console.WriteLine("Succeeded with null as result");
            }
            else
            {
                // the variable result is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                DeploymentStackWhatIfResultData resourceData = result.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
        }
    }
}
