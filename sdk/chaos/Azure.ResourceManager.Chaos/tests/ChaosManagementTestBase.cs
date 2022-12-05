// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
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
        public const string ExperimentNamePrefix = "sdktest-chaos-";
        public const string VmssNameFormat = "chaossdk-vmss-{0}-{1}";

        protected ArmClient Client { get; private set; }

        public string ExperimentName { get; private set; }

        public int VmssId { get; private set; }

        public SubscriptionResource Subscription { get; private set; }

        public ResourceGroupResource ResourceGroupResource { get; private set; }

        public ExperimentCollection ExperimentCollection { get; private set; }

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
            Client = GetArmClient();
        }

        protected async Task Initialize()
        {
            this.SetVmssId();
            this.Subscription = await this.Client.GetDefaultSubscriptionAsync();
            this.ResourceGroupResource = await this.Subscription.GetResourceGroupAsync(TestEnvironment.ResourceGroup).ConfigureAwait(false);
            this.ExperimentCollection = this.ResourceGroupResource.GetExperiments();
            this.ExperimentName = Recording.GenerateAssetName(ExperimentNamePrefix);
            this.MockExperimentEntities = new MockExperimentEntities(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroup, string.Format(VmssNameFormat, TestEnvironment.Location, this.VmssId));
        }

        public void SetVmssId()
        {
            var framework = RuntimeInformation.FrameworkDescription;
            if (framework.IndexOf(".NET Framework", StringComparison.OrdinalIgnoreCase) != -1)
            {
                this.VmssId = this.IsAsync ? 1 : 0;
            }
            else if (framework.IndexOf(".NET Core", StringComparison.OrdinalIgnoreCase) != -1)
            {
                this.VmssId = this.IsAsync ? 3 : 2;
            }
            else
            {
                this.VmssId = this.IsAsync ? 5 : 4;
            }
        }
    }
}
