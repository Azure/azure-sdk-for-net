// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Terraform.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Terraform.Tests
{
    public class ExportTerraformTests : TerraformManagementTestBase
    {
        private static readonly TerraformManagementTestEnvironment s_env = new();

        public ExportTerraformTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportResourceGroupTest()
        {
            string resourceGroupName = s_env.ResourceGroup;
            string vnetName = s_env.VNetName;
            ExportResourceGroup exportResourceGroup = new(resourceGroupName);

            ArmOperation<TerraformOperationStatus> operationStatus = await DefaultSubscription.ExportTerraformAsync(WaitUntil.Completed, exportResourceGroup);
            string hcl = operationStatus.Value.Properties.Configuration;

            Assert.That(hcl, Does.Contain("azurerm_resource_group"));
            Assert.That(hcl, Does.Contain(resourceGroupName));

            Assert.That(hcl, Does.Contain("azurerm_virtual_network"));
            Assert.That(hcl, Does.Contain(vnetName));
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportQueryTest()
        {
            string resourceGroupName = s_env.ResourceGroup;
            string vnetName = s_env.VNetName;
            ExportQuery exportQuery = new($"resourceGroup =~ \"{resourceGroupName}\"");

            ArmOperation<TerraformOperationStatus> operationStatus = await DefaultSubscription.ExportTerraformAsync(WaitUntil.Completed, exportQuery);
            string hcl = operationStatus.Value.Properties.Configuration;

            Assert.That(hcl, Does.Contain("azurerm_virtual_network"));
            Assert.That(hcl, Does.Contain(vnetName));
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportResourceTest()
        {
            string vnetName = s_env.VNetName;
            ExportResourceTerraform exportResource = new(new[] { s_env.VNetId });

            ArmOperation<TerraformOperationStatus> operationStatus = await DefaultSubscription.ExportTerraformAsync(WaitUntil.Completed, exportResource);

            string hcl = operationStatus.Value.Properties.Configuration;

            Assert.That(hcl, Does.Contain("azurerm_virtual_network"));
            Assert.That(hcl, Does.Contain(vnetName));
        }
    }
}
