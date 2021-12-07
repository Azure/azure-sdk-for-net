// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="DataFlowDebugSessionClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class DataFlowDebugSessionClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        internal class DisposableDataFlowDebugSession : IAsyncDisposable
        {
            private readonly DataFlowDebugSessionClient _client;
            public string SessionId;

            private DisposableDataFlowDebugSession (DataFlowDebugSessionClient client, string sessionId)
            {
                _client = client;
                SessionId = sessionId;
            }

            public static async ValueTask<DisposableDataFlowDebugSession> Create (DataFlowDebugSessionClient client, TestRecording recording) =>
                new DisposableDataFlowDebugSession (client, await CreateResource(client, recording));

            public static async ValueTask<string> CreateResource (DataFlowDebugSessionClient client, TestRecording recording)
            {
                // SYNAPSE_API_ISSUE - When do we need to pass DataFlowName?
                DataFlowDebugSessionCreateDataFlowDebugSessionOperation create = await client.StartCreateDataFlowDebugSessionAsync (new CreateDataFlowDebugSessionRequest ());
                // SYNAPSE_API_ISSUE - Why is there is no wrapper to save here?
                return (await create.WaitForCompletionAsync()).Value.SessionId;
            }

            public async ValueTask DisposeAsync()
            {
                // SYNAPSE_API_ISSUE - Why does the ctor not take these? When do we need to pass DataFlowName?
                DeleteDataFlowDebugSessionRequest deleteRequest = new DeleteDataFlowDebugSessionRequest ()  { SessionId = SessionId };
                await _client.DeleteDataFlowDebugSessionAsync (deleteRequest);
            }
        }

        public DataFlowDebugSessionClientLiveTests(bool isAsync) : base(isAsync, useLegacyTransport: true)
        {
        }

        private DataFlowClient CreateFlowClient()
        {
            return InstrumentClient(new DataFlowClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        private DataFlowDebugSessionClient CreateDebugClient()
        {
            return InstrumentClient(new DataFlowDebugSessionClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [Ignore ("https://github.com/Azure/azure-sdk-for-net/issues/18079 prevents test from working")]
        [RecordedTest]
        public async Task AddDataFlow()
        {
            DataFlowClient flowClient = CreateFlowClient();
            DataFlowDebugSessionClient debugClient = CreateDebugClient();

            await using DisposableDataFlow flow = await DisposableDataFlow.Create (flowClient, this.Recording);
            await using DisposableDataFlowDebugSession debugSession = await DisposableDataFlowDebugSession.Create (debugClient, this.Recording);

            // SYNAPSE_API_ISSUE - Why do we need to pass in SessionId here?
            DataFlowDebugPackage debugPackage = new DataFlowDebugPackage () { DataFlow = new DataFlowDebugResource (flow.Resource.Properties), SessionId = debugSession.SessionId };
            AddDataFlowToDebugSessionResponse response = await debugClient.AddDataFlowAsync (debugPackage);
            Assert.NotNull (response.JobVersion);
        }

        [RecordedTest]
        public async Task QuerySessions()
        {
            DataFlowClient flowClient = CreateFlowClient();
            DataFlowDebugSessionClient debugClient = CreateDebugClient();

            await using DisposableDataFlow flow = await DisposableDataFlow.Create (flowClient, this.Recording);
            await using DisposableDataFlowDebugSession debugSession = await DisposableDataFlowDebugSession.Create (debugClient, this.Recording);

            AsyncPageable<DataFlowDebugSessionInfo> sessions = debugClient.QueryDataFlowDebugSessionsByWorkspaceAsync ();
            Assert.GreaterOrEqual((await sessions.ToListAsync()).Count, 1);
        }

        [Ignore ("https://github.com/Azure/azure-sdk-for-net/issues/18079 prevents test from working")]
        [RecordedTest]
        public async Task ExecuteCommand()
        {
            DataFlowClient flowClient = CreateFlowClient();
            DataFlowDebugSessionClient debugClient = CreateDebugClient();

            await using DisposableDataFlow flow = await DisposableDataFlow.Create (flowClient, this.Recording);
            await using DisposableDataFlowDebugSession debugSession = await DisposableDataFlowDebugSession.Create (debugClient, this.Recording);

            // SYNAPSE_API_ISSUE - What payload do we need here?
            DataFlowDebugSessionExecuteCommandOperation executeOperation = await debugClient.StartExecuteCommandAsync(new DataFlowDebugCommandRequest { SessionId = debugSession.SessionId });
            DataFlowDebugCommandResponse response = await executeOperation.WaitForCompletionAsync();
            Assert.AreEqual (200, response.Status);
        }
    }
}
