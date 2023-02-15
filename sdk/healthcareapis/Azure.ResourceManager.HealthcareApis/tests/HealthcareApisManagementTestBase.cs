// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.HealthcareApis.Tests
{
    public class HealthcareApisManagementTestBase : ManagementRecordedTestBase<HealthcareApisManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected string ResourceGroupNamePrefix = "HealthCareApisRG";

        protected HealthcareApisManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HealthcareApisManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<HealthcareApisWorkspaceResource> CreateHealthcareApisWorkspace(ResourceGroupResource resourceGroup, string workspaceName)
        {
            var data = new HealthcareApisWorkspaceData(DefaultLocation);
            var lro = await resourceGroup.GetHealthcareApisWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, data);
            return lro.Value;
        }
    }
}
