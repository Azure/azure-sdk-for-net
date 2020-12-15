// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using synchronous methods of <see cref="SparkSessionClient"/>.
    /// </summary>
    public partial class ExecuteSparkStatement
    {
        [Test]
        public void ExecuteSparkStatementSync()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            // Environment variable with the Synapse Spark pool name.
            string sparkPoolName = TestEnvironment.SparkPoolName;

            #region Snippet:SparkSessionSample1SparkSessionClient
            SparkSessionClient client = new SparkSessionClient(new Uri(workspaceUrl), sparkPoolName, new DefaultAzureCredential());
            #endregion

            #region Snippet:SparkSessionSample1StartSparkSession
            SparkSessionOptions request = new SparkSessionOptions(name: $"session-{Guid.NewGuid()}")
            {
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };

            SparkSession sessionCreated = client.CreateSparkSession(request);
            #endregion

            #region Snippet:SparkSessionSample1GetSparkSession
            SparkSession session = client.GetSparkSession(sessionCreated.Id);
            Debug.WriteLine($"Session is returned with name {session.Name} and state {session.State}");
            #endregion

            #region Snippet:SparkSessionSample1ExecuteSparkStatement
            SparkStatementOptions sparkStatementRequest = new SparkStatementOptions
            {
                Kind = SparkStatementLanguageType.Spark,
                Code = @"print(""Hello world\n"")"
            };
            SparkStatement statementCreated = client.CreateSparkStatement(sessionCreated.Id, sparkStatementRequest);
            #endregion

            #region Snippet:SparkSessionSample1GetSparkStatement
            SparkStatement statement = client.GetSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is returned with id {statement.Id} and state {statement.State}");
            #endregion

            #region Snippet:SparkSessionSample1CancelSparkStatement
            SparkStatementCancellationResult cancellationResult = client.CancelSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is cancelled with message {cancellationResult.Msg}");
            #endregion

            #region Snippet:SparkSessionSample1StopSparkSession
            Response operation = client.CancelSparkSession(sessionCreated.Id);
            #endregion
        }
    }
}
