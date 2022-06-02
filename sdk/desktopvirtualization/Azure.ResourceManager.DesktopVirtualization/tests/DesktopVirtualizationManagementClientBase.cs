// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DesktopVirtualization.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DesktopVirtualization.Tests.Tests
{
    public abstract class DesktopVirtualizationManagementClientBase : ManagementRecordedTestBase<DesktopVirtualizationManagementTestEnvironment>
    {
        public ArmClient armClient { get; set; }
        public SubscriptionResource Subscription { get; set; }
        public ResourceGroupCollection ResourceGroups { get; set; }

        protected DesktopVirtualizationManagementClientBase() : base(true)
        {
        }

        protected DesktopVirtualizationManagementClientBase(bool isAsync) : base(isAsync)
        {
        }

        protected DesktopVirtualizationManagementClientBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public async Task InitializeClients()
        {
            armClient = GetArmClient();
            Subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroups = Subscription.GetResourceGroups();
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }
    }
}
