// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.ResourceManager.Automanage.Models;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests.Scenario
{
    internal class ConfigurationProfileAssignmentTests : AutomanageTestBase
    {
        public ConfigurationProfileAssignmentTests(bool async) : base(async) { }

        [TestCase]
        public async Task CanCreateCustomProfileAssignment()
        {
            string profileName = Recording.GenerateAssetName("SDKAutomanageProfile-");
            string vmName = "sdk-test-vm";

            // create resource group
            var rg = await CreateResourceGroup(Subscription, "SDKAutomanage-", DefaultLocation);

            // fetch configuration profile collection
            var profileCollection = rg.GetConfigurationProfiles();

            // create configuration profile
            var profile = await CreateConfigurationProfile(profileCollection, profileName);

            // create VM from existing ARM template
            string templateContent = File.ReadAllText("../../../../../sdk/automanage/test-resources.json");
            var deploymentContent = new ArmDeploymentContent(new ArmDeploymentProperties(ArmDeploymentMode.Incremental)
            {
                Template = BinaryData.FromString(templateContent),
                Parameters = BinaryData.FromObjectAsJson(new
                {
                    adminPassword = new { value = "!Admin12345" },
                    vmName = new { value = vmName }
                })
            });

            await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, "deployVM", deploymentContent);

            // fetch VM
            var vm = rg.GetVirtualMachineAsync(vmName).Result.Value;

            // create assignment between custom profile and VM
            var data = new ConfigurationProfileAssignmentData()
            {
                Properties = new ConfigurationProfileAssignmentProperties() { ConfigurationProfile = profile.Id }
            };

            await vm.GetConfigurationProfileAssignments().CreateOrUpdateAsync(WaitUntil.Completed, "default", data);
        }
    }
}
