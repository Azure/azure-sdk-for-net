// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class Track2ManagementRecordedTestBase<TEnvironment> : RecordedTestBase<TEnvironment> where TEnvironment: TestEnvironment, new()
    {
        protected ResourceGroupCleanupPolicy CleanupPolicy { get; set; }

        protected Track2ManagementRecordedTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected Track2ManagementRecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return operation.WaitForCompletionAsync(TimeSpan.FromSeconds(0), default);
            }
            else
            {
                return operation.WaitForCompletionAsync();
            }
        }

        protected AzureResourceManagerClient GetArmClient()
        {
            var options = InstrumentClientOptions(new AzureResourceManagerClientOptions());
            CleanupPolicy = new ResourceGroupCleanupPolicy();
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<AzureResourceManagerClient>(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }

        protected void CleanupResourceGroups()
        {
            if (CleanupPolicy != null && Mode != RecordedTestMode.Playback)
            {
                var resourceGroupsClient = new ResourcesManagementClient(
                    TestEnvironment.SubscriptionId,
                    TestEnvironment.Credential,
                    new ResourcesManagementClientOptions()).ResourceGroups;

                ConcurrentBag<ResourceGroupsDeleteOperation> operations = new ConcurrentBag<ResourceGroupsDeleteOperation>();
                Parallel.ForEach(CleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    operations.Add(resourceGroupsClient.StartDelete(resourceGroup));
                });

                Parallel.ForEach(operations, async operation =>
                {
                    await operation.WaitForCompletionAsync().ConfigureAwait(false);
                });
            }
        }
    }
}
