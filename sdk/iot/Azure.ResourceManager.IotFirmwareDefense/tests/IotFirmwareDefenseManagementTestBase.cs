// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class IotFirmwareDefenseManagementTestBase : ManagementRecordedTestBase<IotFirmwareDefenseManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected static readonly string subscriptionId = "07aed47b-60ad-4d6e-a07a-89b602418441"; // https://ms.portal.azure.com/#@microsoft.onmicrosoft.com/resource/subscriptions/07aed47b-60ad-4d6e-a07a-89b602418441/overview
        protected static readonly string rgName = "sdk-tests-rg";
        protected static readonly string workspaceName = "default";
        protected static readonly string firmwareId = "94a6c8fd-42a3-a209-a374-92e68b14e5b4";

        protected IotFirmwareDefenseManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected IotFirmwareDefenseManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            var subscription = Client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(subscriptionId));
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
        protected async Task<ResourceGroupResource> DeleteResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            var lro = await subscription.GetResourceGroupAsync(rgName);
            return lro.Value;
        }

        protected async Task<FirmwareAnalysisWorkspaceResource> CreateWorkspace(ResourceGroupResource rg)
        {
            var _ = await rg.GetFirmwareAnalysisWorkspaces().CreateOrUpdateAsync(
                WaitUntil.Completed,
                Recording.GenerateAssetName("resource"),
                new FirmwareAnalysisWorkspaceData(AzureLocation.EastUS));
            return _.Value;
        }

        protected async Task<IotFirmwareResource> CreateFirmware(FirmwareAnalysisWorkspaceResource workspace, IotFirmwareData firmwareData)
        {
            var _ = await workspace.GetIotFirmwares().CreateOrUpdateAsync(
                WaitUntil.Completed,
                Recording.GenerateAssetName("resource"),
                firmwareData);
            return _.Value;
        }
    }
}
