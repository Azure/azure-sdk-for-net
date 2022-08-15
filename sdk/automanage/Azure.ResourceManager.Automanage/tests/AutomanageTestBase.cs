// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Automanage.Tests
{
    public class AutomanageTestBase : ManagementRecordedTestBase<AutomanageTestEnvironment>
    {
        public ArmClient ArmClient { get; private set; }
        public SubscriptionResource Subscription { get; set; }
        protected ResourceGroupCollection ResourceGroups { get; private set; }
        public static AzureLocation DefaultLocation => AzureLocation.EastUS;

        protected AutomanageTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync, mode)
        {
        }

        protected AutomanageTestBase(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            ArmClient = GetArmClient();
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
        }

        public static void VerifyConfigurationProfileProperties(ConfigurationProfileResource profile)
        {
            Assert.NotNull(profile);
            Assert.True(profile.HasData);
            Assert.NotNull(profile.Id);
            Assert.NotNull(profile.Id.Name);
            Assert.NotNull(profile.Data);
            Assert.NotNull(profile.Data.Configuration);
            Assert.NotNull(profile.Data.Location);
        }
    }
}
