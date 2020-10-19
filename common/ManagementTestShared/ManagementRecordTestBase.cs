// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
#if RESOURCES_RP
using Azure.ResourceManager.Resources;
#else
using Azure.Management.Resources;
#endif
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using System.Threading.Tasks;
using NUnit.Framework;


namespace Azure.ResourceManager.TestFramework
{
    [Category("Recorded")]
    public abstract class ManagementRecordTestBase<TEnvironment> : ClientTestBase where TEnvironment : TestEnvironment, new()
    {
        protected RecordedTestSanitizer Sanitizer { get; set; }

        protected RecordMatcher Matcher { get; set; }

        public TestRecording Recording { get; private set; }

        public RecordedTestMode Mode { get; set; }

        public TEnvironment TestEnvironment { get; }

        private ResourceGroupCleanupPolicy CleanupPolicy { get; set; }

        protected ManagementRecordTestBase(bool isAsync) : this(isAsync, RecordedTestUtilities.GetModeFromEnvironment())
        {
        }

        protected ManagementRecordTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync)
        {
            Sanitizer = new RecordedTestSanitizer();
            Matcher = new RecordMatcher();
            Mode = mode;
            TestEnvironment = new TEnvironment();
            TestEnvironment.Mode = Mode;
            CleanupPolicy = new ResourceGroupCleanupPolicy();
        }

        /// <summary>
        /// Initializes the clients for a test scenario so the recordings are setup and saved
        /// correctly
        /// </summary>
        protected abstract void InitializeClients();

        /// <summary>
        /// Setup of resources that will be run before a test fixture or suite
        /// This should be overriden if resources need to be setup once for a suite of test
        /// </summary>
        protected virtual Task OnOneTimeSetupAsync()
        {
            this.InitializeClients();
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Setup of resources that will run before each test in a test fixture or suite
        /// This should be overriden if resources need to be setup before each test.
        /// </summary>
        protected virtual Task OnSetupAsync()
        {
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Teardown of resources that will be run after all test in a test fixture or suite have run
        /// This should be overriden if customization for resource teardown needs done, else the teardown of
        /// resources will be handled automaticall by the framework
        /// </summary>
        protected virtual Task OnOneTimeTearDownAsync()
        {
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Teardown of resources that will be run after each test in test fixture or suite
        /// This should be overriden if customization for resource teardown needs done, else the teardown of
        /// resources will be handled automaticall by the framework
        /// </summary>
        protected virtual Task OnTearDownAsync()
        {
            return Task.FromResult<object>(null);
        }

        [OneTimeSetUp]
        protected async Task RunOneTimeSetup()
        {
            if (Mode == RecordedTestMode.Live || Debugger.IsAttached)
            {
                Logger = new TestLogger();
            }
            Recording = new TestRecording(Mode, GetSessionFilePath(), Sanitizer, Matcher);
            TestEnvironment.SetRecording(Recording);
            InitializeClients();
            await OnOneTimeSetupAsync();
        }

        [OneTimeTearDown]
        protected async Task RunOneTimeTearDown()
        {
            await StopTestRecording();
            await CleanupResourceGroupsAsync();
            Logger?.Dispose();
            Logger = null;
            await OnOneTimeTearDownAsync();
        }

        [SetUp]
        protected async Task StartTestRecording()
        {
            await StopTestRecording();
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            if (Mode != RecordedTestMode.Live &&
                test.Properties.ContainsKey("SkipRecordings"))
            {
                throw new IgnoreException((string)test.Properties.Get("SkipRecordings"));
            }
            Recording = new TestRecording(Mode, GetSessionFilePath(), Sanitizer, Matcher);
            TestEnvironment.Mode = Mode;
            TestEnvironment.SetRecording(Recording);
            InitializeClients();
            await OnSetupAsync();
        }

        [TearDown]
        protected async Task StopTestRecording()
        {
            bool save = TestContext.CurrentContext.Result.FailCount == 0;
#if DEBUG
            save |= SaveDebugRecordingsOnFailure;
#endif
            Recording?.Dispose(save);
            await OnTearDownAsync();
        }

        protected ResourcesManagementClient GetResourceManagementClient()
        {
            var options = Recording.InstrumentClientOptions(new ResourcesManagementClientOptions());
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<ResourcesManagementClient>(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }

        protected ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return operation.WaitForCompletionAsync(TimeSpan.FromSeconds(0), default);
            }
            else
            {
                return operation.WaitForCompletionAsync();
            }
        }

        protected async Task CleanupResourceGroupsAsync()
        {
            if (CleanupPolicy != null && Mode != RecordedTestMode.Playback)
            {
                var resourceGroupsClient = new ResourcesManagementClient(
                    TestEnvironment.SubscriptionId,
                    TestEnvironment.Credential,
                    new ResourcesManagementClientOptions()).ResourceGroups;
                foreach (var resourceGroup in CleanupPolicy.ResourceGroupsCreated)
                {
                    await resourceGroupsClient.StartDeleteAsync(resourceGroup);
                }
                CleanupPolicy.ResourceGroupsCreated.Clear();
            }
        }

        protected T GetManagementClient<T>(ClientOptions options) where T : class
        {
            return this.CreateClient<T>(TestEnvironment.SubscriptionId,
                TestEnvironment.Credential, Recording.InstrumentClientOptions(options));
        }

    }
}
