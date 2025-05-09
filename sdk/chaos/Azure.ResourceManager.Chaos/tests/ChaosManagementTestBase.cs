// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Chaos.Tests.TestDependencies;
using Azure.ResourceManager.Chaos.Tests.TestDependencies.Experiments;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Chaos.Tests
{
    public class ChaosManagementTestBase : ManagementRecordedTestBase<ChaosManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        public string ExperimentName { get; private set; }

        public int VmssId { get; private set; }

        public string VmssName { get; private set; }

        public AzureLocation Location { get; private set; }

        public SubscriptionResource SubscriptionResource { get; private set; }

        public ResourceGroupResource ResourceGroupResource { get; private set; }

        public ChaosExperimentCollection ExperimentCollection { get; private set; }

        public ChaosTargetMetadataCollection TargetTypeCollection { get; private set; }

        public MockExperimentEntities MockExperimentEntities { get; private set; }

        protected ChaosManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ChaosManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            var options = new ArmClientOptions();
            Client = GetArmClient();
        }

        protected async Task Initialize()
        {
            this.Location = new AzureLocation(TestEnvironment.Location);
            this.VmssId = this.CreateVmssId();
            this.VmssName = string.Format(TestConstants.VmssNameFormat, TestEnvironment.Location, this.VmssId);
            this.SubscriptionResource = await this.Client.GetDefaultSubscriptionAsync();
            this.ResourceGroupResource = await this.SubscriptionResource.GetResourceGroupAsync(TestEnvironment.ResourceGroup).ConfigureAwait(false);
            this.ExperimentCollection = this.ResourceGroupResource.GetChaosExperiments();
            this.ExperimentName = Recording.GenerateAssetName(TestConstants.ExperimentNamePrefix);
            this.MockExperimentEntities = new MockExperimentEntities(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroup, this.VmssName);
            this.TargetTypeCollection = this.SubscriptionResource.GetAllChaosTargetMetadata(this.Location.Name);
        }

        /// <summary>
        /// Returns a VMSS Id int for each test case (Framework + Sync/Async)
        /// </summary>
        public int CreateVmssId()
        {
            return this.IsAsync ? 1 : 0;
        }
    }
}
