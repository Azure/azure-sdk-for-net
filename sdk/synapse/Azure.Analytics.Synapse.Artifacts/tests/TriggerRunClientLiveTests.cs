// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TriggerRunClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TriggerRunClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public TriggerRunClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private TriggerClient CreateTriggerClient()
        {
            return InstrumentClient(new TriggerClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        private TriggerRunClient CreateRunClient()
        {
            return InstrumentClient(new TriggerRunClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18079 - Missing or invalid pipeline references for trigger but no obvious place to put pipeline?")]
        [RecordedTest]
        public async Task TestQueryRuns()
        {
            TriggerClient triggerClient = CreateTriggerClient();
            TriggerRunClient runClient = CreateRunClient ();

            TriggerResource resource = await DisposableTrigger.CreateResource (triggerClient, Recording);

            TriggerStartTriggerOperation startOperation = await triggerClient.StartStartTriggerAsync (resource.Name);
            await startOperation.WaitAndAssertSuccessfulCompletion();

            TriggerRunsQueryResponse response = await runClient.QueryTriggerRunsByWorkspaceAsync (new RunFilterParameters (DateTimeOffset.MinValue, DateTimeOffset.MaxValue));
            Assert.GreaterOrEqual (response.Value.Count, 1);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18079 - Missing or invalid pipeline references for trigger but no obvious place to put pipeline?")]
        [RecordedTest]
        public async Task TestCancelRerun()
        {
            TriggerClient triggerClient = CreateTriggerClient();
            TriggerRunClient runClient = CreateRunClient ();

            TriggerResource resource = await DisposableTrigger.CreateResource (triggerClient, Recording);

            TriggerStartTriggerOperation startOperation = await triggerClient.StartStartTriggerAsync (resource.Name);
            await startOperation.WaitAndAssertSuccessfulCompletion();

            TriggerRunsQueryResponse response = await runClient.QueryTriggerRunsByWorkspaceAsync (new RunFilterParameters (DateTimeOffset.MinValue, DateTimeOffset.MaxValue));
            // Find the active run and cancel (CancelTriggerInstanceAsync)

            // Rerun canceled run (RerunTriggerInstanceAsync)
        }
    }
}
