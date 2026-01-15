// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.WorkloadOrchestration.Tests
{
    public class WorkloadOrchestrationTestBase : RecordedTestBase<WorkloadOrchestrationTestEnvironment>
    {
        public WorkloadOrchestrationTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected ArmClient GetArmClient()
        {
            var options = new ArmClientOptions();
            InstrumentClientOptions(options);
            return new ArmClient(TestEnvironment.Credential, null, options);
        }

        protected ResourceGroupResource GetResourceGroup()
        {
            var subscriptionId = "973d15c6-6c57-447e-b9c6-6d79b5b784ab"; // Use the subscription ID from your test environment
            var rgName = "audapurerg";
            var resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, rgName);
            return GetArmClient().GetResourceGroupResource(resourceGroupId);
        }
    }
}
