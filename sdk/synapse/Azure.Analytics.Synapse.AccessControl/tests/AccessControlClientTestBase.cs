// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Analytics.Synapse.AccessControl;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.IO;

namespace Azure.Analytics.Synapse.Tests.AccessControl
{
    [NonParallelizable]
    public abstract class AccessControlClientTestBase : RecordedTestBase<SynapseTestEnvironment>
    {
        public AccessControlClient AccessControlClient { get; set; }

        protected AccessControlClientTestBase(bool isAsync) : base(isAsync)
        {
#if DEBUG
            SaveDebugRecordingsOnFailure = true;
#endif
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            AccessControlClient = CreateAccessControlClient();
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

        internal AccessControlClient CreateAccessControlClient(TestRecording recording = null)
        {
            recording ??= Recording;
            return InstrumentClient(new AccessControlClient(
                new Uri(TestEnvironment.WorkspaceUrl),
                TestEnvironment.Credential,
                recording.InstrumentClientOptions(new AccessControlClientOptions())));
        }
    }
}
