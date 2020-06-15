// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
#if RESOURCES_RP
using Azure.ResourceManager.Resources;
#else
using Azure.Management.Resources;
#endif
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class ManagementRecordedTestBase<TEnvironment> : RecordedTestBase<TEnvironment> where TEnvironment: TestEnvironment, new()
    {
        private static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);

        protected ResourceGroupCleanupPolicy CleanupPolicy { get; set; }

        protected ManagementRecordedTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected ManagementRecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return operation.WaitForCompletionAsync(ZeroPollingInterval, default);
            }
            else
            {
                return operation.WaitForCompletionAsync();
            }
        }

        protected ResourcesManagementClient GetResourceManagementClient()
        {
            var options = Recording.InstrumentClientOptions(new ResourcesManagementClientOptions());
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

        protected async Task<string> GetFirstUsableLocationAsync(ProvidersOperations providersClient, string resourceProviderNamespace, string resourceType)
        {
            var provider = (await providersClient.GetAsync(resourceProviderNamespace)).Value;
            return provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == resourceType)
                        return true;
                    else
                        return false;
                }
                ).First().Locations.FirstOrDefault();
        }

        protected void SleepInTest(int milliSeconds)
        {
            if (Mode == RecordedTestMode.Playback)
                return;
            Thread.Sleep(milliSeconds);
        }
    }
}
