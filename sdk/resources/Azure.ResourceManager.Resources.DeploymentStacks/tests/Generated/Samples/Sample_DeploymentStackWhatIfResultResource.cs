// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources.DeploymentStacks.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.DeploymentStacks.Samples
{
    public partial class Sample_DeploymentStackWhatIfResultResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetADeploymentStackWhatIfResult()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DeploymentStackWhatIfResultResource created on azure
            // for more information of creating DeploymentStackWhatIfResultResource, please refer to the document of DeploymentStackWhatIfResultResource
            string managementGroupId = "myMg";
            string deploymentStacksWhatIfResultName = "simpleDeploymentStackWhatIfResult";
            ResourceIdentifier managementGroupDeploymentStacksWhatIfResultResourceId = DeploymentStackWhatIfResultResource.CreateResourceIdentifier(managementGroupId, deploymentStacksWhatIfResultName);
            DeploymentStackWhatIfResultResource managementGroupDeploymentStacksWhatIfResult = client.GetDeploymentStackWhatIfResultResource(managementGroupDeploymentStacksWhatIfResultResourceId);

            // invoke the operation
            DeploymentStackWhatIfResultResource result = await managementGroupDeploymentStacksWhatIfResult.GetAsync();

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DeploymentStackWhatIfResultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_DeleteADeploymentStackWhatIfResult()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DeploymentStackWhatIfResultResource created on azure
            // for more information of creating DeploymentStackWhatIfResultResource, please refer to the document of DeploymentStackWhatIfResultResource
            string managementGroupId = "myMg";
            string deploymentStacksWhatIfResultName = "simpleDeploymentStack";
            ResourceIdentifier managementGroupDeploymentStacksWhatIfResultResourceId = DeploymentStackWhatIfResultResource.CreateResourceIdentifier(managementGroupId, deploymentStacksWhatIfResultName);
            DeploymentStackWhatIfResultResource managementGroupDeploymentStacksWhatIfResult = client.GetDeploymentStackWhatIfResultResource(managementGroupDeploymentStacksWhatIfResultResourceId);

            // invoke the operation
            await managementGroupDeploymentStacksWhatIfResult.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CreateOrUpdateADeploymentStackWhatIfResult()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DeploymentStackWhatIfResultResource created on azure
            // for more information of creating DeploymentStackWhatIfResultResource, please refer to the document of DeploymentStackWhatIfResultResource
            string managementGroupId = "myMg";
            string deploymentStacksWhatIfResultName = "simpleDeploymentStackWhatIfResult";
            ResourceIdentifier managementGroupDeploymentStacksWhatIfResultResourceId = DeploymentStackWhatIfResultResource.CreateResourceIdentifier(managementGroupId, deploymentStacksWhatIfResultName);
            DeploymentStackWhatIfResultResource managementGroupDeploymentStacksWhatIfResult = client.GetDeploymentStackWhatIfResultResource(managementGroupDeploymentStacksWhatIfResultResourceId);

            // invoke the operation
            DeploymentStackWhatIfResultData data = new DeploymentStackWhatIfResultData()
            {
                Location = new AzureLocation("eastus"),
                Properties = new DeploymentStackWhatIfResultProperties(
                    new ActionOnUnmanage(UnmanageActionResourceMode.Delete)
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
            ArmOperation<DeploymentStackWhatIfResultResource> lro = await managementGroupDeploymentStacksWhatIfResult.UpdateAsync(WaitUntil.Completed, data);
            DeploymentStackWhatIfResultResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DeploymentStackWhatIfResultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task WhatIf_GetADetailedDeploymentStackWhatIfResult()
        {
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this DeploymentStackWhatIfResultResource created on azure
            // for more information of creating DeploymentStackWhatIfResultResource, please refer to the document of DeploymentStackWhatIfResultResource
            string managementGroupId = "myMg";
            string deploymentStacksWhatIfResultName = "changedDeploymentStackWhatIfResult";
            ResourceIdentifier managementGroupDeploymentStacksWhatIfResultResourceId = DeploymentStackWhatIfResultResource.CreateResourceIdentifier(managementGroupId, deploymentStacksWhatIfResultName);
            DeploymentStackWhatIfResultResource managementGroupDeploymentStacksWhatIfResult = client.GetDeploymentStackWhatIfResultResource(managementGroupDeploymentStacksWhatIfResultResourceId);

            // invoke the operation
            ArmOperation<DeploymentStackWhatIfResultResource> lro = await managementGroupDeploymentStacksWhatIfResult.WhatIfAsync(WaitUntil.Completed);
            DeploymentStackWhatIfResultResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            DeploymentStackWhatIfResultData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
