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
    /// The suite of tests for the <see cref="SqlScriptClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class SqlScriptClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        internal class DisposableSqlScript : IAsyncDisposable
        {
            private readonly SqlScriptClient _client;
            public SqlScriptResource Resource;

            private DisposableSqlScript (SqlScriptClient client, SqlScriptResource resource)
            {
                _client = client;
                Resource = resource;
            }

            public string Name => Resource.Name;

            public static async ValueTask<DisposableSqlScript> Create (SqlScriptClient client, TestRecording recording) =>
                new DisposableSqlScript (client, await CreateResource(client, recording));

            public static async ValueTask<SqlScriptResource> CreateResource (SqlScriptClient client, TestRecording recording)
            {
                string scriptName = recording.GenerateId("SqlScript", 16);
                // The connection string does not need to point to a real server, as we are not executing here
                SqlConnection connect = new SqlConnection
                {
                    Type = SqlConnectionType.SqlPool,
                    Name = "Server=tcp:nonexistant.sql.azuresynapse.net,1433;Database=nonexistant;User ID=user;Password=password;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                };
                SqlScript script = new SqlScript (new SqlScriptContent("SELECT NULL LIMIT 0;") { CurrentConnection = connect });
                SqlScriptCreateOrUpdateSqlScriptOperation createOperation = await client.StartCreateOrUpdateSqlScriptAsync (scriptName, new SqlScriptResource (scriptName, script));
                return await createOperation.WaitForCompletionAsync();
            }

            public async ValueTask DisposeAsync()
            {
                SqlScriptDeleteSqlScriptOperation deleteOperation = await _client.StartDeleteSqlScriptAsync (Name);
                await deleteOperation.WaitForCompletionResponseAsync();
            }
        }

        public SqlScriptClientLiveTests(bool isAsync) : base(isAsync, useLegacyTransport: true)
        {
        }

        private SqlScriptClient CreateClient()
        {
            return InstrumentClient(new SqlScriptClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestGetScripts()
        {
            SqlScriptClient client = CreateClient ();
            await using DisposableSqlScript singleScript = await DisposableSqlScript.Create (client, Recording);

            IList<SqlScriptResource> scripts = await client.GetSqlScriptsByWorkspaceAsync ().ToListAsync();
            Assert.GreaterOrEqual (scripts.Count, 1);

            foreach (SqlScriptResource script in scripts)
            {
                SqlScriptResource actualScript = await client.GetSqlScriptAsync (script.Name);
                Assert.AreEqual (actualScript.Name, script.Name);
                Assert.AreEqual (actualScript.Id, script.Id);
                Assert.AreEqual (actualScript.Type, script.Type);
            }
        }

        [RecordedTest]
        public async Task TestDeleteSparkJob()
        {
            SqlScriptClient client = CreateClient();

            SqlScriptResource resource = await DisposableSqlScript.CreateResource (client, Recording);

            SqlScriptDeleteSqlScriptOperation deleteOperation = await client.StartDeleteSqlScriptAsync  (resource.Name);
            await deleteOperation.WaitAndAssertSuccessfulCompletion();
        }

        [RecordedTest]
        public async Task TestRenameSparkJob()
        {
            SqlScriptClient client = CreateClient();

            SqlScriptResource resource = await DisposableSqlScript.CreateResource (client, Recording);

            string newScriptName = Recording.GenerateId("SqlScript", 16);

            SqlScriptRenameSqlScriptOperation renameOperation = await client.StartRenameSqlScriptAsync (resource.Name, new ArtifactRenameRequest () { NewName = newScriptName } );
            await renameOperation.WaitForCompletionResponseAsync();

            SqlScriptResource sparkJob = await client.GetSqlScriptAsync (newScriptName);
            Assert.AreEqual (newScriptName, sparkJob.Name);

            SqlScriptDeleteSqlScriptOperation deleteOperation = await client.StartDeleteSqlScriptAsync (newScriptName);
            await deleteOperation.WaitForCompletionResponseAsync();
        }
    }
}
