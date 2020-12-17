// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Samples
{
    /// <summary>
    /// This sample demonstrates how to submit Spark job in Azure Synapse Analytics using synchronous methods of <see cref="SparkSessionClient"/>.
    /// </summary>
    public partial class Sample2_ExecuteSparkStatement : SampleFixture
    {
        [Test]
        public void ExecuteSparkStatementSync()
        {
            // Environment variable with the Synapse workspace endpoint.
            string endpoint = TestEnvironment.EndpointUrl;

            // Environment variable with the Synapse Spark pool name.
            string sparkPoolName = TestEnvironment.SparkPoolName;

            #region Snippet:CreateSparkSessionClient
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

            SparkSessionOperation createOperation = client.StartCreateSparkSession(request);
            while (!createOperation.HasCompleted)
            {
                System.Threading.Thread.Sleep(2000);
                createOperation.UpdateStatus();
            }
            SparkSession sessionCreated = createOperation.Value;
            #endregion

            #region Snippet:GetSparkSession
            SparkSessionOperation getOperation = client.StartGetSparkSession(sessionCreated.Id);
            while (!getOperation.HasCompleted)
            {
                System.Threading.Thread.Sleep(2000);
                getOperation.UpdateStatus();
            }
            SparkSession session = getOperation.Value;
            Debug.WriteLine($"Session is returned with name {session.Name} and state {session.State}");
            #endregion

            #region Snippet:CreateSparkStatement
            SparkStatementOptions sparkStatementRequest = new SparkStatementOptions
            {
                Kind = SparkStatementLanguageType.Spark,
                Code = @"print(""Hello world\n"")"
            };

            SparkStatementOperation statementOperation = client.StartCreateSparkStatement(sessionCreated.Id, sparkStatementRequest);
            while (!statementOperation.HasCompleted)
            {
                System.Threading.Thread.Sleep(2000);
                statementOperation.UpdateStatus();
            }
            SparkStatement statementCreated = statementOperation.Value;
            #endregion

            #region Snippet:GetSparkStatement
            SparkStatement statement = client.GetSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is returned with id {statement.Id} and state {statement.State}");
            #endregion

            #region Snippet:CancelSparkStatement
            SparkStatementCancellationResult cancellationResult = client.CancelSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is cancelled with message {cancellationResult.Msg}");
            #endregion

            #region Snippet:CancelSparkSession
            Response operation = client.CancelSparkSession(sessionCreated.Id);
            #endregion
        }
    }
}
