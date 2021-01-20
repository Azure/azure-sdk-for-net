// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Analytics.Synapse.Monitoring;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.IO;

namespace Azure.Analytics.Synapse.Tests.Monitoring
{
    [NonParallelizable]
    public abstract class MonitoringClientTestBase : RecordedTestBase<SynapseTestEnvironment>
    {
        public MonitoringClient MonitoringClient { get; set; }

        protected MonitoringClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            MonitoringClient = CreateMonitoringClient();
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

        internal MonitoringClient CreateMonitoringClient(TestRecording recording = null)
        {
            recording ??= Recording;
            return InstrumentClient(new MonitoringClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new MonitoringClientOptions())));
        }
    }
}
