// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Spark.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using synchronous methods of <see cref="SparkSessionClient"/>.
    /// </summary>
    public partial class Sample2_ExecuteSparkStatement : SamplesBase<SynapseTestEnvironment>
    {
        [Test]
        public void ExecuteSparkStatementSync()
        {
            #region Snippet:CreateSparkSessionClient
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

            #region Snippet:CreateSparkSession
            SparkSessionOptions request = new SparkSessionOptions(name: $"session-{Guid.NewGuid()}")
            {
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };

            SparkSessionOperation createSessionOperation = client.CreateSparkSession(WaitUntil.Started, request);
            while (!createSessionOperation.HasCompleted)
            {
                System.Threading.Thread.Sleep(2000);
                createSessionOperation.UpdateStatus();
            }
            SparkSession sessionCreated = createSessionOperation.Value;
            #endregion

            #region Snippet:GetSparkSession
            SparkSession session = client.GetSparkSession(sessionCreated.Id);
            Debug.WriteLine($"Session is returned with name {session.Name} and state {session.State}");
            #endregion

            #region Snippet:CreateSparkStatement
            SparkStatementOptions sparkStatementRequest = new SparkStatementOptions
            {
                Kind = SparkStatementLanguageType.Spark,
                Code = @"print(""Hello world\n"")"
            };

            SparkStatementOperation createStatementOperation = client.CreateSparkStatement(WaitUntil.Started, sessionCreated.Id, sparkStatementRequest);
            while (!createStatementOperation.HasCompleted)
            {
                System.Threading.Thread.Sleep(2000);
                createStatementOperation.UpdateStatus();
            }
            SparkStatement statementCreated = createStatementOperation.Value;
            #endregion

            #region Snippet:GetSparkStatement
            SparkStatement statement = client.GetSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is returned with id {statement.Id} and state {statement.State}");
            #endregion

            #region Snippet:CancelSparkStatement
            SparkStatementCancellationResult cancellationResult = client.CancelSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is cancelled with message {cancellationResult.Message}");
            #endregion

            #region Snippet:CancelSparkSession
            Response operation = client.CancelSparkSession(sessionCreated.Id);
            #endregion
        }
    }
}
