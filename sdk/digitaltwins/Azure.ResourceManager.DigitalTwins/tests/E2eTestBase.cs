// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.DigitalTwins.Tests
{
    [ClientTestFixture]
    public abstract class E2eTestBase : ManagementRecordedTestBase<DigitalTwinsManagementTestEnvironment>
    {
        // This should be checked in as Playback, and changed to Record or Live locally, if needed.
        private const RecordedTestMode TestMode = RecordedTestMode.Playback;

        private static readonly TimeSpan s_pollingInterval = TimeSpan.FromSeconds(3);

        protected DigitalTwinsManagementClient DigitalTwinsManagementClient { get; set; }
        protected ResourcesManagementClient ResourceManagementClient { get; set; }

        protected E2eTestBase(bool isAsync)
            : base(isAsync, TestMode)
        {
        }

        protected E2eTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected void Initialize()
        {
            ResourceManagementClient = GetResourceManagementClient();
            DigitalTwinsManagementClient = GetDigitalTwinsManagementClient();
        }

        private DigitalTwinsManagementClient GetDigitalTwinsManagementClient()
        {
            return CreateClient<DigitalTwinsManagementClient>(TestEnvironment.SubscriptionId,
                 TestEnvironment.Credential,
                 InstrumentClientOptions(new DigitalTwinsManagementClientOptions()));
        }

    }
}
