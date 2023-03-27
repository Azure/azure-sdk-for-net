// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Spark.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using asynchronous methods of <see cref="SparkSessionClient"/>.
    /// </summary>
    public partial class Sample2_ExecuteSparkStatementAsync : SamplesBase<SynapseTestEnvironment>
    {
        [Test]
        public async Task ExecuteSparkStatementSync()
        {
            #region Snippet:CreateSparkSessionClientAsync
#if SNIPPET
            // Replace the strings below with the spark and endpoint information
            string sparkPoolName = "<my-spark-pool-name>";
            string endpoint = "<my-endpoint-url>";
#else
            string sparkPoolName = TestEnvironment.SparkPoolName;
            string endpoint = TestEnvironment.EndpointUrl;
#endif

            SparkSessionClient client = new SparkSessionClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateSparkSessionAsync
            SparkSessionOptions request = new SparkSessionOptions(name: $"session-{Guid.NewGuid()}")
            {
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };

            SparkSessionOperation createSessionOperation = await client.CreateSparkSessionAsync(WaitUntil.Completed, request);
            SparkSession sessionCreated = createSessionOperation.Value;
            #endregion

            #region Snippet:GetSparkSessionAsync
            SparkSession session = await client.GetSparkSessionAsync(sessionCreated.Id);
            Debug.WriteLine($"Session is returned with name {session.Name} and state {session.State}");
            #endregion

            #region Snippet:CreateSparkStatementAsync
            SparkStatementOptions sparkStatementRequest = new SparkStatementOptions
            {
                Kind = SparkStatementLanguageType.Spark,
                Code = @"print(""Hello world\n"")"
            };

            SparkStatementOperation createStatementOperation = await client.CreateSparkStatementAsync(WaitUntil.Started, sessionCreated.Id, sparkStatementRequest);
            SparkStatement statementCreated = createStatementOperation.Value;
            #endregion

            #region Snippet:GetSparkStatementAsync
            SparkStatement statement = await client.GetSparkStatementAsync(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is returned with id {statement.Id} and state {statement.State}");
            #endregion

            #region Snippet:CancelSparkStatementAsync
            SparkStatementCancellationResult cancellationResult = client.CancelSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is cancelled with message {cancellationResult.Message}");
            #endregion

            #region Snippet:CancelSparkSessionAsync
            Response operation = client.CancelSparkSession(sessionCreated.Id);
            #endregion
        }
    }
}
