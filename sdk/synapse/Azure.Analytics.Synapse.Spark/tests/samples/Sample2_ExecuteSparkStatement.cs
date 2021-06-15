// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Analytics.Synapse.Spark;
using Azure.Identity;
using NUnit.Framework;
using Azure.Core;
using System.Text.Json;

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
            // Replace the strings below with the spark and endpoint information
            string sparkPoolName = "<my-spark-pool-name>";
            /*@@*/sparkPoolName = TestEnvironment.SparkPoolName;

            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;

            SparkSessionClient client = new SparkSessionClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateSparkSession
            RequestContent request = RequestContent.Create (new {
                name = $"session-{Guid.NewGuid()}",
                driverMemory = "28g",
                driverCores = 4,
                executorMemory = "28g",
                executorCores = 4,
                numExecutors = 2
            });

            SparkSessionOperation createSessionOperation = client.StartCreateSparkSession(request);
            while (!createSessionOperation.HasCompleted)
            {
                System.Threading.Thread.Sleep(2000);
                createSessionOperation.UpdateStatus();
            }
            BinaryData jobCreated = createSessionOperation.Value;
            var sessionId = JsonDocument.Parse(jobCreated.ToMemory()).RootElement.GetProperty("id").GetInt32();

            #endregion

            #region Snippet:GetSparkSession
            Response session = client.GetSparkSession(sessionId);
            var sessionDoc = JsonDocument.Parse(session.Content.ToMemory());
            Debug.WriteLine($"Session is returned with state {sessionDoc.RootElement.GetProperty("state").GetString()}");
            #endregion

            #region Snippet:CreateSparkStatement
            RequestContent sparkStatementRequest = RequestContent.Create (new {
                Kind = "spark",
                Code = @"print(""Hello world\n"")"
            });

            SparkStatementOperation createStatementOperation = client.StartCreateSparkStatement(sessionId, sparkStatementRequest);
            while (!createStatementOperation.HasCompleted)
            {
                System.Threading.Thread.Sleep(2000);
                createStatementOperation.UpdateStatus();
            }
            BinaryData statementCreated = createStatementOperation.Value;
            var statementId = JsonDocument.Parse(statementCreated.ToMemory()).RootElement.GetProperty("id").GetInt32();
            #endregion

            #region Snippet:GetSparkStatement
            Response statement = client.GetSparkStatement(sessionId, statementId);
            var statementDoc = JsonDocument.Parse(session.Content.ToMemory());
            Debug.WriteLine($"Statement is returned with id {statementDoc.RootElement.GetProperty("id").GetInt32()} and state {statementDoc.RootElement.GetProperty("state").GetString()}");
            #endregion

            #region Snippet:CancelSparkStatement
            Response cancellationResult = client.CancelSparkStatement(sessionId, statementId);
            var cancellationResultDoc = JsonDocument.Parse(session.Content.ToMemory());
            Debug.WriteLine($"Statement is cancelled");
            #endregion

            #region Snippet:CancelSparkSession
            Response operation = client.CancelSparkSession(sessionId);
            #endregion
        }
    }
}
