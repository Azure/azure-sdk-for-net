// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Castle.DynamicProxy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class ManagementRecordedTestBase<TEnvironment> : RecordedTestBase<TEnvironment>
        where TEnvironment: TestEnvironment, new()
    {
        protected ResourceGroupCleanupPolicy ResourceGroupCleanupPolicy = new ResourceGroupCleanupPolicy();

        protected ResourceGroupCleanupPolicy OneTimeResourceGroupCleanupPolicy = new ResourceGroupCleanupPolicy();

        protected ManagementGroupCleanupPolicy ManagementGroupCleanupPolicy = new ManagementGroupCleanupPolicy();

        protected ManagementGroupCleanupPolicy OneTimeManagementGroupCleanupPolicy = new ManagementGroupCleanupPolicy();

        protected ArmClient GlobalClient { get; private set; }

        public TestEnvironment SessionEnvironment { get; private set; }

        public TestRecording SessionRecording { get; private set; }

        private ArmClient _cleanupClient;
        private bool _waitForCleanup;

        protected ManagementRecordedTestBase(bool isAsync, bool useLegacyTransport = false) : base(isAsync, useLegacyTransport: useLegacyTransport)
        {
            SessionEnvironment = new TEnvironment();
            SessionEnvironment.Mode = Mode;
            Initialize();
        }

        protected ManagementRecordedTestBase(bool isAsync, RecordedTestMode mode, bool useLegacyTransport = false) : base(isAsync, mode, useLegacyTransport)
        {
            SessionEnvironment = new TEnvironment();
            SessionEnvironment.Mode = Mode;
            Initialize();
        }

        private void Initialize()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                var pollField = typeof(OperationInternals).GetField("<DefaultPollingInterval>k__BackingField", BindingFlags.Static | BindingFlags.NonPublic);
                pollField.SetValue(null, TimeSpan.Zero);
            }

            _waitForCleanup = Mode == RecordedTestMode.Live;
        }

        private ArmClient GetCleanupClient()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                return new ArmClient(
                        TestEnvironment.SubscriptionId,
                        GetUri(TestEnvironment.ResourceManagerUrl),
                        TestEnvironment.Credential,
                        new ArmClientOptions());
            }
            return null;
        }

        protected TClient InstrumentClientExtension<TClient>(TClient client) => (TClient)InstrumentClient(typeof(TClient), client, new IInterceptor[] { new ManagementInterceptor(this) });

        protected ArmClient GetArmClient(ArmClientOptions clientOptions = default)
        {
            var options = InstrumentClientOptions(clientOptions ?? new ArmClientOptions());
            options.AddPolicy(ResourceGroupCleanupPolicy, HttpPipelinePosition.PerCall);
            options.AddPolicy(ManagementGroupCleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<ArmClient>(
                TestEnvironment.SubscriptionId,
                GetUri(TestEnvironment.ResourceManagerUrl),
                TestEnvironment.Credential,
                options);
        }

        private Uri GetUri(string endpoint)
        {
            return !string.IsNullOrEmpty(endpoint) ? new Uri(endpoint) : null;
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
                Parallel.ForEach(ResourceGroupCleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    try
                    {
                        var sub = _cleanupClient.GetSubscriptions().GetIfExists(TestEnvironment.SubscriptionId);
                        sub.Value?.GetResourceGroups().Get(resourceGroup).Value.Delete(waitForCompletion: _waitForCleanup);
                    }
                    catch (RequestFailedException e) when (e.Status == 404)
                    {
                        //we assume the test case cleaned it up if it no longer exists.
                    }
                });

                Parallel.ForEach(ManagementGroupCleanupPolicy.ManagementGroupsCreated, mgmtGroupId =>
                {
                    try
                    {
                        _cleanupClient.GetManagementGroup(new ResourceIdentifier(mgmtGroupId)).Delete(waitForCompletion: _waitForCleanup);
                    }
                    catch (RequestFailedException e) when (e.Status == 404 || e.Status == 403)
                    {
                        //we assume the test case cleaned it up if it no longer exists.
                    }
                });
            }
        }

        private async Task StartSessionRecordingAsync()
        {
            // Only create test recordings for the latest version of the service
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            if (Mode != RecordedTestMode.Live &&
                test.Properties.ContainsKey("SkipRecordings"))
            {
                throw new IgnoreException((string)test.Properties.Get("SkipRecordings"));
            }
            SessionRecording = await CreateTestRecordingAsync(Mode, GetSessionFilePath(), Sanitizer, Matcher);
            SessionEnvironment.SetRecording(SessionRecording);
            ValidateClientInstrumentation = SessionRecording.HasRequests;
        }

        protected async Task StopSessionRecordingAsync()
        {
            if (ValidateClientInstrumentation)
            {
                throw new InvalidOperationException("The test didn't instrument any clients but had recordings. Please call InstrumentClient for the client being recorded.");
            }

            if (SessionRecording != null)
            {
                await SessionRecording.DisposeAsync(true);
            }

            GlobalClient = null;
        }

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            if (!HasOneTimeSetup())
                return;

            await StartSessionRecordingAsync();

            var options = InstrumentClientOptions(new ArmClientOptions(), SessionRecording);
            options.AddPolicy(OneTimeResourceGroupCleanupPolicy, HttpPipelinePosition.PerCall);
            options.AddPolicy(OneTimeManagementGroupCleanupPolicy, HttpPipelinePosition.PerCall);

            GlobalClient = CreateClient<ArmClient>(
                SessionEnvironment.SubscriptionId,
                GetUri(SessionEnvironment.ResourceManagerUrl),
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
                Parallel.ForEach(OneTimeResourceGroupCleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    var sub = _cleanupClient.GetSubscriptions().GetIfExists(SessionEnvironment.SubscriptionId);
                    sub.Value?.GetResourceGroups().Get(resourceGroup).Value.Delete(waitForCompletion: _waitForCleanup);
                });
                Parallel.ForEach(OneTimeManagementGroupCleanupPolicy.ManagementGroupsCreated, mgmtGroupId =>
                {
                    _cleanupClient.GetManagementGroup(new ResourceIdentifier(mgmtGroupId)).Delete(waitForCompletion: _waitForCleanup);
                });
            }

            if (!(GlobalClient is null))
                throw new InvalidOperationException("StopSessionRecording was never called please make sure you call that at the end of your OneTimeSetup");
        }

        protected override object InstrumentOperation(Type operationType, object operation)
        {
            return InstrumentMgmtOperation(operationType, operation, new ManagementInterceptor(this));
        }
    }
}
