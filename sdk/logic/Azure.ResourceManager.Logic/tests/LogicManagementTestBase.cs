// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.Logic.Models;
using System;
using System.IO;

namespace Azure.ResourceManager.Logic.Tests
{
    public class LogicManagementTestBase : ManagementRecordedTestBase<LogicManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string ResourceGroupNamePrefix = "LogicAppRG-";
        protected const string DefaultTriggerName = "manual";
        protected LogicManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected LogicManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(AzureLocation location)
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<IntegrationAccountResource> CreateIntegrationAccount(ResourceGroupResource resourceGroup, string integrationAccountName)
        {
            IntegrationAccountData data = new IntegrationAccountData(resourceGroup.Data.Location)
            {
                SkuName = IntegrationAccountSkuName.Standard,
            };
            var integrationAccount = await resourceGroup.GetIntegrationAccounts().CreateOrUpdateAsync(WaitUntil.Completed, integrationAccountName, data);
            return integrationAccount.Value;
        }

        protected async Task<LogicWorkflowResource> CreateLogicWorkflow(ResourceGroupResource resourceGroup, ResourceIdentifier integrationAccountIdentifier, string logicWorkflowName)
        {
            LogicWorkflowData data = ConstructLogicWorkflowData(resourceGroup.Data.Location, integrationAccountIdentifier);
            var workflow = await resourceGroup.GetLogicWorkflows().CreateOrUpdateAsync(WaitUntil.Completed, logicWorkflowName, data);
            return workflow.Value;
        }

        protected LogicWorkflowData ConstructLogicWorkflowData(AzureLocation location, ResourceIdentifier integrationAccountIdentifier)
        {
            byte[] definition = File.ReadAllBytes(@"TestData/WorkflowDefinition.json");
            return new LogicWorkflowData(location)
            {
                Definition = new BinaryData(definition),
                IntegrationAccount = new LogicResourceReference() { Id = integrationAccountIdentifier },
            };
        }

        protected async Task<VirtualNetworkResource> CreateDefaultNetwork(ResourceGroupResource resourceGroup, string vnetName)
        {
            VirtualNetworkData data = new VirtualNetworkData()
            {
                Location = resourceGroup.Data.Location,
            };
            data.AddressPrefixes.Add("10.10.0.0/16");
            data.Subnets.Add(new SubnetData() { Name = "subnet1", AddressPrefix = "10.10.1.0/24" });
            data.Subnets.Add(new SubnetData() { Name = "subnet2", AddressPrefix = "10.10.2.0/24" });
            data.Subnets.Add(new SubnetData() { Name = "subnet3", AddressPrefix = "10.10.3.0/24" });
            data.Subnets.Add(new SubnetData() { Name = "subnet4", AddressPrefix = "10.10.4.0/24" });
            data.Subnets.Add(new SubnetData() { Name = "subnet5", AddressPrefix = "10.10.5.0/24" });
            data.Subnets[0].Delegations.Add(new ServiceDelegation() { Name = "integrationServiceEnvironments", ServiceName = "Microsoft.Logic/integrationServiceEnvironments" });
            var vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
            return vnet.Value;
        }
    }
}
