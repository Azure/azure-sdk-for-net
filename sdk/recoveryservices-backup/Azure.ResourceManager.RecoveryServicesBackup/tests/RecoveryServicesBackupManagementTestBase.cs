// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests
{
    public class RecoveryServicesBackupManagementTestBase : ManagementRecordedTestBase<RecoveryServicesBackupManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected RecoveryServicesBackupManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            IgnoreAuthorizationDependencyVersions();
        }

        protected RecoveryServicesBackupManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreAuthorizationDependencyVersions();
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient(enableDeleteAfter: true);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
