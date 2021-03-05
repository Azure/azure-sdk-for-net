// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Spark.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="SparkSessionClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class SparkSessionClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public SparkSessionClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private SparkSessionClient CreateClient()
        {
            return InstrumentClient(new SparkSessionClient(
                TestEnvironment.EndpointUrl,
                TestEnvironment.SparkPoolName,
                TestEnvironment.Credential,
                options: InstrumentClientOptions(new SparkClientOptions())
            ));
        }

        /// <summary>
        /// Verifies that the <see cref="SparkSessionClient" /> is able to connect to the
        /// Azure Synapse Analytics service and perform operations.
        /// </summary>
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18080 - This test case cannot pass due to backend limitations for service principals.")]
        public async Task TestSparkSessionJob()
        {
            SparkSessionClient client = CreateClient();

            // Start the Spark session
            SparkSessionOptions createParams = SparkTestUtilities.CreateSparkSessionRequestParameters(Recording);
            SparkSessionOperation sessionOperation = await client.StartCreateSparkSessionAsync(createParams);
            SparkSession sessionCreateResponse = await sessionOperation.WaitForCompletionAsync();

            // Verify the Spark session completes successfully
            Assert.True("idle".Equals(sessionCreateResponse.State, StringComparison.OrdinalIgnoreCase) && sessionCreateResponse.Result == SparkSessionResultType.Succeeded,
                string.Format(
                    "Session: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                    sessionCreateResponse.Id,
                    sessionCreateResponse.State,
                    sessionCreateResponse.Result,
                    string.Join(", ", sessionCreateResponse.Errors ?? new List<SparkServiceError>())
                )
            );

            // Execute Spark statement in the session
            var sparkStatementOptions = new SparkStatementOptions {
                    Kind = SparkStatementLanguageType.Spark,
                    Code = @"print(""Hello world\n"")"
            };
            SparkStatementOperation statementOperation = await client.StartCreateSparkStatementAsync(sessionCreateResponse.Id, sparkStatementOptions);
            SparkStatement createStatementResponse = await statementOperation.WaitForCompletionAsync();
            Assert.NotNull(createStatementResponse);

            // Verify the Spark statement completes successfully
            Assert.True("ok".Equals(createStatementResponse.State, StringComparison.OrdinalIgnoreCase),
                string.Format(
                    "Spark statement: {0} did not return success. Current job state: {1}. Error (if any): {2}",
                    createStatementResponse.Id,
                    createStatementResponse.State,
                    createStatementResponse.Output.ErrorValue)
            );

            // Verify the output
            Dictionary<string, string> outputData = JsonSerializer.Deserialize<Dictionary<string, string>>(createStatementResponse.Output.Data as string);
            Assert.Equals("Hello world", outputData["text/plain"]);

            // Get the list of Spark statements and check that the executed statement exists
            Response<SparkStatementCollection> listStatementResponse = await client.GetSparkStatementsAsync(sessionCreateResponse.Id);

            Assert.NotNull(listStatementResponse.Value);
            Assert.IsTrue(listStatementResponse.Value.Statements.Any(stmt => stmt.Id == createStatementResponse.Id));

            // Get the list of Spark session and check that the created session exists
            List<SparkSession> listSessionResponse = await SparkTestUtilities.ListSparkSessionsAsync(client);

            Assert.NotNull(listSessionResponse);
            Assert.IsTrue(listSessionResponse.Any(session => session.Id == sessionCreateResponse.Id));
        }

        [RecordedTest]
        public async Task TestGetSparkSession()
        {
            SparkSessionClient client = CreateClient();

            SparkSessionCollection sparkSessions = (await client.GetSparkSessionsAsync()).Value;
            foreach (SparkSession expectedSparkSession in sparkSessions.Sessions)
            {
                SparkSession actualSparkSession = await client.GetSparkSessionAsync(expectedSparkSession.Id);
                ValidateSparkSession(expectedSparkSession, actualSparkSession);
            }
        }

        internal void ValidateSparkSession(SparkSession expectedSparkSession, SparkSession actualSparkSession)
        {
            Assert.AreEqual(expectedSparkSession.Name, actualSparkSession.Name);
            Assert.AreEqual(expectedSparkSession.Id, actualSparkSession.Id);
            Assert.AreEqual(expectedSparkSession.AppId, actualSparkSession.AppId);
            Assert.AreEqual(expectedSparkSession.SubmitterId, actualSparkSession.SubmitterId);
            Assert.AreEqual(expectedSparkSession.ArtifactId, actualSparkSession.ArtifactId);
        }
    }
}
