// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Terraform.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Terraform.Tests
{
    public class ExportTerraformTests : TerraformManagementTestBase
    {
        private const string DefaultResourceGroup = "rg-tangerryterraform";
        private const string DefaultVNetName = "dotnet-sdk-test-vnet";

        public ExportTerraformTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportResourceGroupTest()
        {
            string resourceGroupName = DefaultResourceGroup;
            string vnetName = DefaultVNetName;
            ExportResourceGroupTerraform exportResourceGroup = new(resourceGroupName);

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
            string resourceGroupName = DefaultResourceGroup;
            string vnetName = DefaultVNetName;
            ExportQueryTerraform exportQuery = new($"resourceGroup =~ \"{resourceGroupName}\"");

            ArmOperation<TerraformOperationStatus> operationStatus = await DefaultSubscription.ExportTerraformAsync(WaitUntil.Completed, exportQuery);
            string hcl = operationStatus.Value.Properties.Configuration;

            Assert.That(hcl, Does.Contain("azurerm_virtual_network"));
            Assert.That(hcl, Does.Contain(vnetName));
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportResourceTest()
        {
            string vnetName = DefaultVNetName;
            ExportResourceTerraform exportResource = new(new[] { new ResourceIdentifier("/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/rg-tangerryterraform/providers/Microsoft.Network/virtualNetworks/dotnet-sdk-test-vnet") });

            ArmOperation<TerraformOperationStatus> operationStatus = await DefaultSubscription.ExportTerraformAsync(WaitUntil.Completed, exportResource);

            string hcl = operationStatus.Value.Properties.Configuration;

            Assert.That(hcl, Does.Contain("azurerm_virtual_network"));
            Assert.That(hcl, Does.Contain(vnetName));
        }
    }
}
