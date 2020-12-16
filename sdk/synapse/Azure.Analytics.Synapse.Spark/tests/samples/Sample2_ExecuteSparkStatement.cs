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
    public partial class ExecuteSparkStatement
    {
        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/17455")]
        public void ExecuteSparkStatementSync()
        {
            // Environment variable with the Synapse workspace endpoint.
            string endpoint = TestEnvironment.EndpointUrl;

            // Environment variable with the Synapse Spark pool name.
            string sparkPoolName = TestEnvironment.SparkPoolName;

            SparkSessionClient client = new SparkSessionClient(new Uri(endpoint), sparkPoolName, new DefaultAzureCredential());

            SparkSessionOptions request = new SparkSessionOptions(name: $"session-{Guid.NewGuid()}")
            {
                DriverMemory = "28g",
                DriverCores = 4,
                ExecutorMemory = "28g",
                ExecutorCores = 4,
                ExecutorCount = 2
            };

            SparkSession sessionCreated = client.CreateSparkSession(request);

            // Waiting session creation completion
            sessionCreated = PollSparkSession(client, sessionCreated);

            SparkSession session = client.GetSparkSession(sessionCreated.Id);
            Debug.WriteLine($"Session is returned with name {session.Name} and state {session.State}");

            SparkStatementOptions sparkStatementRequest = new SparkStatementOptions
            {
                Kind = SparkStatementLanguageType.Spark,
                Code = @"print(""Hello world\n"")"
            };
            SparkStatement statementCreated = client.CreateSparkStatement(sessionCreated.Id, sparkStatementRequest);

            // Wait operation completion
            statementCreated = PollSparkStatement(client, sessionCreated.Id, statementCreated);

            SparkStatement statement = client.GetSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is returned with id {statement.Id} and state {statement.State}");

            SparkStatementCancellationResult cancellationResult = client.CancelSparkStatement(sessionCreated.Id, statementCreated.Id);
            Debug.WriteLine($"Statement is cancelled with message {cancellationResult.Msg}");

            Response operation = client.CancelSparkSession(sessionCreated.Id);
        }

        // https://github.com/Azure/azure-sdk-for-net/issues/17587
        // This code is copied from SparkTestUtilities.cs and modified, as there is no current way to monitor/poll for spark completion
        // It belongs in a helper class, likely a LRO
        // It is being left here only temporarily.
        private const string Error = "error";
        private const string Dead = "dead";
        private const string Success = "success";
        private const string Killed = "killed";
        private const string Idle = "idle";

       public static List<string> SessionSubmissionFinalStates = new List<string>
        {
            Idle,
            Error,
            Dead,
            Success,
            Killed
        };

        public static SparkSession PollSparkSession(
            SparkSessionClient client,
            SparkSession session,
            IList<string> livyReadyStates = null)
        {
            if (livyReadyStates == null)
            {
                livyReadyStates = SessionSubmissionFinalStates;
            }

            return Poll(
                session,
                s => s.Result.ToString(),
                s => s.State,
                s => client.GetSparkSession(s.Id, true),
                livyReadyStates);
        }

        private const string Starting = "starting";
        private const string Waiting = "waiting";
        private const string Running = "running";
        private const string Cancelling = "cancelling";

        private static List<string> ExecutingStates = new List<string>
        {
            Starting,
            Waiting,
            Running,
            Cancelling
        };

        private static SparkStatement PollSparkStatement(
            SparkSessionClient client,
            int sessionId,
            SparkStatement statement)
        {
            return Poll(
                statement,
                s => null,
                s => s.State,
                s => client.GetSparkStatement(sessionId, s.Id),
                ExecutingStates,
                isFinalState: false);
        }

        private static T Poll<T>(
            T job,
            Func<T, string> getJobState,
            Func<T, string> getLivyState,
            Func<T, T> refresh,
            IList<string> livyReadyStates,
            bool isFinalState = true,
            int pollingInMilliseconds = 0,
            int timeoutInMilliseconds = 0,
            Action<T> writeLog = null)
        {
            var timeWaitedInMilliSeconds = 0;
            if (pollingInMilliseconds == 0)
            {
                pollingInMilliseconds = 5000;
            }

            while (IsJobRunning(getJobState(job), getLivyState(job), livyReadyStates, isFinalState))
            {
                if (timeoutInMilliseconds > 0 && timeWaitedInMilliSeconds >= timeoutInMilliseconds)
                {
                    throw new TimeoutException();
                }

                writeLog?.Invoke(job);
                //TestMockSupport.Delay(pollingInMilliseconds);
                System.Threading.Thread.Sleep(pollingInMilliseconds);
                timeWaitedInMilliSeconds += pollingInMilliseconds;

                // TODO: handle retryable excetpion
                job = refresh(job);
            }

            return job;
        }

        private static bool IsJobRunning(string jobState, string livyState, IList<string> livyStates, bool isFinalState = true)
        {
            if ("Succeeded".Equals(jobState, StringComparison.OrdinalIgnoreCase)
                || "Failed".Equals(jobState, StringComparison.OrdinalIgnoreCase)
                || "Cancelled".Equals(jobState, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return isFinalState ? !livyStates.Contains(livyState) : livyStates.Contains(livyState);
        }
    }
}