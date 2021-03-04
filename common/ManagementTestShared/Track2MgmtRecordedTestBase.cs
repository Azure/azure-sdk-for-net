// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class Track2ManagementRecordedTestBase<TEnvironment> : RecordedTestBase<TEnvironment>
        where TEnvironment: TestEnvironment, new()
    {
        protected ResourceGroupCleanupPolicy CleanupPolicy = new ResourceGroupCleanupPolicy();

        protected ResourceGroupCleanupPolicy OneTimeCleanupPolicy = new ResourceGroupCleanupPolicy();

        protected static AzureResourceManagerClient GlobalClient { get; private set; }

        public TestEnvironment SessionEnvironment { get; private set; }

        public TestRecording SessionRecording { get; private set; }

        private AzureResourceManagerClient _cleanupClient;

        protected Track2ManagementRecordedTestBase(bool isAsync) : base(isAsync)
        {
            SessionEnvironment = new TEnvironment();
            SessionEnvironment.Mode = Mode;
        }

        protected Track2ManagementRecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            SessionEnvironment = new TEnvironment();
            SessionEnvironment.Mode = Mode;
        }

        private AzureResourceManagerClient GetCleanupClient()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                return new AzureResourceManagerClient(
                        SessionEnvironment.SubscriptionId,
                        SessionEnvironment.Credential,
                        new AzureResourceManagerClientOptions());
            }
            return null;
        }

        protected AzureResourceManagerClient GetArmClient()
        {
            var options = InstrumentClientOptions(new AzureResourceManagerClientOptions());
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<AzureResourceManagerClient>(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }

        [TearDown]
        protected void CleanupResourceGroups()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                Parallel.ForEach(CleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    _cleanupClient.GetResourceGroupOperations(TestEnvironment.SubscriptionId, resourceGroup).StartDelete();
                });
            }
        }

        private void StartSessionRecording()
        {
            // Only create test recordings for the latest version of the service
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            if (Mode != RecordedTestMode.Live &&
                test.Properties.ContainsKey("SkipRecordings"))
            {
                throw new IgnoreException((string)test.Properties.Get("SkipRecordings"));
            }
            SessionRecording = new TestRecording(Mode, GetSessionFilePath(), Sanitizer, Matcher);
            SessionEnvironment.SetRecording(SessionRecording);
            ValidateClientInstrumentation = SessionRecording.HasRequests;
        }

        private void StopSessionRecording()
        {
            if (ValidateClientInstrumentation)
            {
                throw new InvalidOperationException("The test didn't instrument any clients but had recordings. Please call InstrumentClient for the client being recorded.");
            }

            SessionRecording?.Dispose(true);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            StartSessionRecording();

            _cleanupClient = GetCleanupClient();

            var options = InstrumentClientOptions(new AzureResourceManagerClientOptions(), SessionRecording);
            options.AddPolicy(OneTimeCleanupPolicy, HttpPipelinePosition.PerCall);

            GlobalClient = CreateClient<AzureResourceManagerClient>(
                SessionEnvironment.SubscriptionId,
                SessionEnvironment.Credential,
                options);
        }

        [OneTimeTearDown]
        public void OneTimeCleanupResourceGroups()
        {
            StopSessionRecording();

            if (Mode != RecordedTestMode.Playback)
            {
                Parallel.ForEach(OneTimeCleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    _cleanupClient.GetResourceGroupOperations(resourceGroup).StartDelete();
                });
            }
        }
    }
}
