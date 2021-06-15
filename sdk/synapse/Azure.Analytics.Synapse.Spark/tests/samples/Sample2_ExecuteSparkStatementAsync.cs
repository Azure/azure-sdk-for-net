// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Analytics.Synapse.Spark;
using Azure.Identity;
using NUnit.Framework;
using System.Text.Json;
using Azure.Core;

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
            // Replace the strings below with the spark and endpoint information
            string sparkPoolName = "<my-spark-pool-name>";
            /*@@*/sparkPoolName = TestEnvironment.SparkPoolName;

            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;

            SparkSessionClient client = new SparkSessionClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateSparkSessionAsync
            RequestContent request = RequestContent.Create (new {
                name = $"session-{Guid.NewGuid()}",
                driverMemory = "28g",
                driverCores = 4,
                executorMemory = "28g",
                executorCores = 4,
                numExecutors = 2
            });

            SparkSessionOperation createSessionOperation = await client.StartCreateSparkSessionAsync(request);
            await createSessionOperation.WaitForCompletionAsync();
            BinaryData jobCreated = createSessionOperation.Value;
            var sessionId = JsonDocument.Parse(jobCreated.ToMemory()).RootElement.GetProperty("id").GetInt32();

            #endregion

            #region Snippet:GetSparkSessionAsync
            Response session = await client.GetSparkSessionAsync(sessionId);
            var sessionDoc = JsonDocument.Parse(session.Content.ToMemory());
            Debug.WriteLine($"Session is returned with state {sessionDoc.RootElement.GetProperty("state").GetString()}");
            #endregion

            #region Snippet:CreateSparkStatementAsync
            RequestContent sparkStatementRequest = RequestContent.Create (new {
                Kind = "spark",
                Code = @"print(""Hello world\n"")"
            });

            SparkStatementOperation createStatementOperation = await client.StartCreateSparkStatementAsync(sessionId, sparkStatementRequest);
            await createStatementOperation.WaitForCompletionAsync();
            BinaryData statementCreated = createStatementOperation.Value;
            var statementId = JsonDocument.Parse(statementCreated.ToMemory()).RootElement.GetProperty("id").GetInt32();

            #endregion

            #region Snippet:GetSparkStatementAsync
            Response statement = await client.GetSparkStatementAsync(sessionId, statementId);
            var statementDoc = JsonDocument.Parse(session.Content.ToMemory());
            Debug.WriteLine($"Statement is returned with id {statementDoc.RootElement.GetProperty("id").GetInt32()} and state {statementDoc.RootElement.GetProperty("state").GetString()}");
            #endregion

            #region Snippet:CancelSparkStatementAsync
            Response cancellationResult = client.CancelSparkStatement(sessionId, statementId);
            Debug.WriteLine($"Statement is cancelled");
            #endregion

            #region Snippet:CancelSparkSessionAsync
            Response operation = client.CancelSparkSession(sessionId);
            #endregion
        }
    }
}
