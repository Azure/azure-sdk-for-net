// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Analytics.Synapse.Spark.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.Analytics.Synapse.Spark.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="SparkSessionClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class SparkSessionClientLiveTests : SparkClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SparkSessionClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public SparkSessionClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Verifies that the <see cref="SparkSessionClient" /> is able to connect to the
        /// Azure Synapse Analytics service and perform operations.
        /// </summary>
        [Test]
        [Ignore("This test case cannot pass due to backend limitations for service principals.")]
        public async Task TestSparkSessionJob()
        {
            // Start the Spark session
            SparkSessionOptions createParams = this.CreateSparkSessionRequestParameters();
            SparkSessionOperation sessionOperation = await SparkSessionClient.StartCreateSparkSessionAsync(createParams);
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
            SparkStatementOperation statementOperation = await SparkSessionClient.StartCreateSparkStatementAsync(sessionCreateResponse.Id, sparkStatementOptions);
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
            Response<SparkStatementCollection> listStatementResponse = await SparkSessionClient.GetSparkStatementsAsync(sessionCreateResponse.Id);

            Assert.NotNull(listStatementResponse.Value);
            Assert.IsTrue(listStatementResponse.Value.Statements.Any(stmt => stmt.Id == createStatementResponse.Id));

            // Get the list of Spark session and check that the created session exists
            List<SparkSession> listSessionResponse = await this.ListSparkSessionsAsync();

            Assert.NotNull(listSessionResponse);
            Assert.IsTrue(listSessionResponse.Any(session => session.Id == sessionCreateResponse.Id));
        }

        [Test]
        public async Task TestGetSparkSession()
        {
            SparkSessionCollection sparkSessions = (await SparkSessionClient.GetSparkSessionsAsync()).Value;
            foreach (SparkSession expectedSparkSession in sparkSessions.Sessions)
            {
                SparkSession actualSparkSession = await SparkSessionClient.GetSparkSessionAsync(expectedSparkSession.Id);
                ValidateSparkSession(expectedSparkSession, actualSparkSession);
            }
        }
    }
}
