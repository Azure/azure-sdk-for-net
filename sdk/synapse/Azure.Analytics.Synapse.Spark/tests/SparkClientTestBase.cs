// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Analytics.Synapse.Spark.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.IO;

namespace Azure.Analytics.Synapse.Spark.Tests
{
    [NonParallelizable]
    public abstract class SparkClientTestBase : RecordedTestBase<SynapseTestEnvironment>
    {
        public SparkBatchClient SparkBatchClient { get; set; }

        public SparkSessionClient SparkSessionClient { get; set; }

        protected SparkClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            SparkBatchClient = CreateSparkBatchClient();
            SparkSessionClient = CreateSparkSessionClient();
        }

        public override void StopTestRecording()
        {
            Recording.RewriteSessionRecords(GetSessionFilePath());
            Recording.ClearTextReplacementRules();
            base.StopTestRecording();
        }

        private string GetSessionFilePath(string name = null)
        {
            TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

            name ??= testAdapter.Name;

            string className = testAdapter.ClassName.Substring(testAdapter.ClassName.LastIndexOf('.') + 1);
            string fileName = name + (IsAsync ? "Async" : string.Empty) + ".json";
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "SessionRecords", className, fileName);
        }

        internal SparkBatchClient CreateSparkBatchClient()
        {
            return InstrumentClient(new SparkBatchClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.SparkPoolName,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SparkClientOptions())));
        }

        internal SparkSessionClient CreateSparkSessionClient()
        {
            return InstrumentClient(new SparkSessionClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.SparkPoolName,
                TestEnvironment.Credential,
                InstrumentClientOptions(new SparkClientOptions())));
        }

        internal void ValidateSparkBatchJob(SparkBatchJob expectedSparkJob, SparkBatchJob actualSparkJob)
        {
            Assert.AreEqual(expectedSparkJob.Name, actualSparkJob.Name);
            Assert.AreEqual(expectedSparkJob.Id, actualSparkJob.Id);
            Assert.AreEqual(expectedSparkJob.AppId, actualSparkJob.AppId);
            Assert.AreEqual(expectedSparkJob.SubmitterId, actualSparkJob.SubmitterId);
            Assert.AreEqual(expectedSparkJob.ArtifactId, actualSparkJob.ArtifactId);
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
