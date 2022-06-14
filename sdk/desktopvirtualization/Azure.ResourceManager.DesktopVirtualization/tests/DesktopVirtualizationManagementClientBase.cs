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
        public const string DefaultResourceGroupName = "azsdkRG";
        public const string DefaultLocation = "brazilsouth";

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

        [TearDown]
        public async Task CleanupTest()
        {
            string resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", DefaultResourceGroupName);
            ResourceGroupResource rg = (ResourceGroupResource)await ResourceGroups.GetAsync(resourceGroupName);
            VirtualApplicationGroupCollection agCollection = rg.GetVirtualApplicationGroups();
            foreach (VirtualApplicationGroupResource ag in await agCollection.GetAllAsync().ToEnumerableAsync())
            {
                await ag.DeleteAsync(WaitUntil.Completed);
            }

            HostPoolCollection hostPoolCollection = rg.GetHostPools();
            foreach (HostPoolResource hp in await hostPoolCollection.GetAllAsync().ToEnumerableAsync())
            {
                await hp.DeleteAsync(WaitUntil.Completed);
            }
        }
    }
}
