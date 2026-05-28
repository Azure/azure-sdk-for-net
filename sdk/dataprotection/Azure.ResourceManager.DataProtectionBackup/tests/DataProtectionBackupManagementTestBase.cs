// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DataProtectionBackup.Tests
{
    public class DataProtectionBackupManagementTestBase : ManagementRecordedTestBase<DataProtectionBackupManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected string groupName;
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected DataProtectionBackupManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DataProtectionBackupManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            if (Mode == RecordedTestMode.Playback)
            {
                groupName = resourceGroupName;
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    groupName = rgOp.Value.Data.Name;
                }
            }
            return rgOp.Value;
        }
    }
}
