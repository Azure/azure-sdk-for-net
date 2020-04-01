// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Analytics.Synapse.Spark.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var createParams = this.CreateSparkSessionRequestParameters();
            var sessionCreateResponse = (await SparkSessionClient.CreateSparkSessionAsync(createParams)).Value;

            // Poll the spark session initialization until it is successful.
            var getSessionResponse = await this.PollSparkSessionAsync(sessionCreateResponse);

            // Verify the Spark session completes successfully
            Assert.True("idle".Equals(getSessionResponse.State, StringComparison.OrdinalIgnoreCase) && getSessionResponse.Result == SparkSessionResultType.Succeeded,
                string.Format(
                    "Session: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                    getSessionResponse.Id,
                    getSessionResponse.State,
                    getSessionResponse.Result,
                    string.Join(", ", getSessionResponse.Errors ?? new List<SparkServiceError>())
                )
            );

            // Execute Spark statement in the session
            var createStatementResponse = (await SparkSessionClient.CreateSparkStatementAsync(
                getSessionResponse.Id,
                new SparkStatementOptions
                {
                    Kind = SparkStatementLanguageType.Spark,
                    Code = @"print(""Hello world\n"")"
                })).Value;

            var getStatementResponse = await this.PollSparkSessionStatementAsync(
                getSessionResponse.Id,
                createStatementResponse);

            Assert.NotNull(getSessionResponse);

            // Verify the Spark statement completes successfully
            Assert.True("ok".Equals(getStatementResponse.State, StringComparison.OrdinalIgnoreCase),
                string.Format(
                    "Spark statement: {0} did not return success. Current job state: {1}. Error (if any): {2}",
                    getStatementResponse.Id,
                    getStatementResponse.State,
                    getStatementResponse.Output.ErrorValue)
            );

            // Verify the output
            Assert.IsInstanceOf(typeof(JObject), getStatementResponse.Output.Data);
            Assert.Equals("Hello world", ((JObject)getStatementResponse.Output.Data)["text/plain"].Value<string>());

            // Get the list of Spark statements and check that the executed statement exists
            var listStatementResponse = await SparkSessionClient.GetSparkStatementsAsync(sessionCreateResponse.Id);

            Assert.NotNull(listStatementResponse.Value);
            Assert.IsTrue(listStatementResponse.Value.Statements.Any(stmt => stmt.Id == createStatementResponse.Id));

            // Get the list of Spark session and check that the created session exists
            var listSessionResponse = await this.ListSparkSessionsAsync();

            Assert.NotNull(listSessionResponse);
            Assert.IsTrue(listSessionResponse.Any(session => session.Id == sessionCreateResponse.Id));
        }

        [Test]
        public async Task TestGetSparkSession()
        {
            var sparkSessions = (await SparkSessionClient.GetSparkSessionsAsync()).Value;
            foreach (var expectedSparkSession in sparkSessions.Sessions)
            {
                var actualSparkSession = await SparkSessionClient.GetSparkSessionAsync(expectedSparkSession.Id);
                ValidateSparkSession(expectedSparkSession, actualSparkSession);
            }
        }
    }
}
