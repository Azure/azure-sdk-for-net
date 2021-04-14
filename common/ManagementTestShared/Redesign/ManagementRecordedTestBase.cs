// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class ManagementRecordedTestBase<TEnvironment> : RecordedTestBase<TEnvironment>
        where TEnvironment: TestEnvironment, new()
    {
        protected ResourceGroupCleanupPolicy CleanupPolicy = new ResourceGroupCleanupPolicy();

        protected ResourceGroupCleanupPolicy OneTimeCleanupPolicy = new ResourceGroupCleanupPolicy();

        protected ArmClient GlobalClient { get; private set; }

        public TestEnvironment SessionEnvironment { get; private set; }

        public TestRecording SessionRecording { get; private set; }

        private ArmClient _cleanupClient;

        protected ManagementRecordedTestBase(bool isAsync) : base(isAsync)
        {
            SessionEnvironment = new TEnvironment();
            SessionEnvironment.Mode = Mode;
        }

        protected ManagementRecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            SessionEnvironment = new TEnvironment();
            SessionEnvironment.Mode = Mode;
        }

        private ArmClient GetCleanupClient()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                return new ArmClient(
                        TestEnvironment.SubscriptionId,
                        TestEnvironment.Credential,
                        new ArmClientOptions());
            }
            return null;
        }

        protected ArmClient GetArmClient(ArmClientOptions clientOptions = default)
        {
            var options = InstrumentClientOptions(clientOptions ?? new ArmClientOptions());
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<ArmClient>(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }

        [SetUp]
        protected void CreateCleanupClient()
        {
            _cleanupClient ??= GetCleanupClient();
        }

        [TearDown]
        protected void CleanupResourceGroups()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                Parallel.ForEach(CleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    try
                    {
                        var sub = _cleanupClient.GetSubscriptions().TryGet(TestEnvironment.SubscriptionId);
                        sub?.GetResourceGroups().Get(resourceGroup).Value.StartDelete();
                    }
                    catch (RequestFailedException e) when (e.Status == 404)
                    {
                        //we assume the test case cleaned up it up if it no longer exists.
                    }
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

        protected void StopSessionRecording()
        {
            if (ValidateClientInstrumentation)
            {
                throw new InvalidOperationException("The test didn't instrument any clients but had recordings. Please call InstrumentClient for the client being recorded.");
            }

            SessionRecording?.Dispose(true);
            GlobalClient = null;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            if (!HasOneTimeSetup())
                return;

            StartSessionRecording();

            var options = InstrumentClientOptions(new ArmClientOptions(), SessionRecording);
            options.AddPolicy(OneTimeCleanupPolicy, HttpPipelinePosition.PerCall);

            GlobalClient = CreateClient<ArmClient>(
                SessionEnvironment.SubscriptionId,
                SessionEnvironment.Credential,
                options);
        }

        private bool HasOneTimeSetup()
        {
            HashSet<Type> types = new HashSet<Type>();
            Type type = GetType();
            Type endType = typeof(ManagementRecordedTestBase<TEnvironment>);
            while (type != endType)
            {
                types.Add(type);
                type = type.BaseType;
            }

            var methods = GetType().GetMethods().Where(m => types.Contains(m.DeclaringType));
            foreach (var method in methods)
            {
                foreach (var attr in method.GetCustomAttributes(false))
                {
                    if (attr is OneTimeSetUpAttribute)
                        return true;
                }
            }
            return false;
        }

        [OneTimeTearDown]
        public void OneTimeCleanupResourceGroups()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                Parallel.ForEach(OneTimeCleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    var sub = _cleanupClient.GetSubscriptions().TryGet(SessionEnvironment.SubscriptionId);
                    sub?.GetResourceGroups().Get(resourceGroup).Value.StartDelete();
                });
            }

            if (!(GlobalClient is null))
                throw new InvalidOperationException("StopSessionRecording was never called please make sure you call that at the end of your OneTimeSetup");
        }
    }
}
