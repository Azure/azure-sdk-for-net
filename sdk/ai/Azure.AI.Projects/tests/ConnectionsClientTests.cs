// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class ConnectionsClientTests : RecordedTestBase<AIProjectsTestEnvironment>
    {
        public ConnectionsClientTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task TestGetDefaultBlobStore(bool withCredentials)
        {
            ConnectionsClient connectionsClient = GetClient();
            // TODO: When the service will be able to handle
            // GetConnection requests, remove this condition.
            if (!withCredentials)
            {
                Response<ConnectionResponse> conn = await connectionsClient.GetDefaultConnectionAsync(
                    category: ConnectionType.AzureBlobStorage,
                    withCredential: withCredentials,
                    includeAll: true);
                Assert.AreEqual("ai-projects-sdk-testing-project-1/delete2me", conn.Value.Name);
                // TODO: When the service will be able to handle
                // GetConnection requests, check that it is not none.
                Assert.IsNull(conn.GetRawResponse());
            }
            else
            {
                Assert.ThrowsAsync<RequestFailedException>(
                    () => connectionsClient.GetDefaultConnectionAsync(
                        category: ConnectionType.AzureBlobStorage,
                        withCredential: true,
                        includeAll: true));
            }
        }

        [RecordedTest]
        public async Task TranslatorTest()
        {
            ConnectionsClient connectionsClient = GetClient();
            ConnectionResponse conn = await connectionsClient.GetConnectionAsync(
                connectionName: "sampleconnection"
                );
            Assert.IsNotNull(conn);
        }

        #region helpers
        private ConnectionsClient GetClient()
        {
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            // If we are in the Playback, do not ask for authentication.
            if (Mode == RecordedTestMode.Playback)
            {
                return InstrumentClient(new ConnectionsClient(connectionString, new MockCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
            // For local testing if you are using non default account
            // add USE_CLI_CREDENTIAL into the .runsettings and set it to true,
            // also provide the PATH variable.
            // This path should allow launching az command.
            var cli = System.Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
            if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return InstrumentClient(new ConnectionsClient(connectionString, new AzureCliCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
            else
            {
                return InstrumentClient(new ConnectionsClient(connectionString, new DefaultAzureCredential(), InstrumentClientOptions(new AIProjectClientOptions())));
            }
        }
        #endregion
    }
}
