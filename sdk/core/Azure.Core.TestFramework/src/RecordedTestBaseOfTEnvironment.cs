// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;

namespace Azure.Core.TestFramework
{
#pragma warning disable SA1649 // File name should match first type name
    public abstract class RecordedTestBase<TEnvironment> : RecordedTestBase where TEnvironment : TestEnvironment, new()
#pragma warning restore SA1649 // File name should match first type name
    {
        protected RecordedTestBase(bool isAsync) : base(isAsync)
        {
            TestEnvironment = new TEnvironment();
            TestEnvironment.Mode = Mode;
        }

        protected RecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            TestEnvironment = new TEnvironment();
            TestEnvironment.Mode = Mode;
        }

        public override void StartTestRecording()
        {
            // Set the TestEnvironment Mode here so that any Mode changes in RecordedTestBase are picked up here also.
            TestEnvironment.Mode = Mode;

            base.StartTestRecording();
            TestEnvironment.SetRecording(Recording);
        }

        protected ResourcesManagementClient GetResourceManagementClient()
        {
            var options = InstrumentClientOptions(new ResourcesManagementClientOptions());
            CleanupPolicy = new ResourceGroupCleanupPolicy();
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<ResourcesManagementClient>(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }

        protected async Task CleanupResourceGroupsAsync()
        {
            if (CleanupPolicy != null && Mode != RecordedTestMode.Playback)
            {
                var resourceGroupsClient = new ResourcesManagementClient(
                    TestEnvironment.SubscriptionId,
                    TestEnvironment.Credential,
                    new ResourcesManagementClientOptions()).ResourceGroups;
                foreach (var resourceGroup in CleanupPolicy.ResourceGroupsCreated)
                {
                    await resourceGroupsClient.StartDeleteAsync(resourceGroup);
                }
            }
        }
        public TEnvironment TestEnvironment { get; }
    }
}