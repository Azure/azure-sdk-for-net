// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using System.Diagnostics;

using System.Threading.Tasks;
using NUnit.Framework;


namespace Azure.ResourceManager.TestFramework
{
    [Category("Recorded")]
    public abstract class ManagementRecordTestBase<TEnvironment> : ClientTestBase where TEnvironment : TestEnvironment, new()
    {
        protected RecordedTestSanitizer Sanitizer { get; set; }

        protected RecordMatcher Matcher { get; set; }

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
        protected virtual Task AfterOneTimeSetupAsync()
        {
            this.InitializeClients();
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Setup of resources that will run before each test in a test fixture or suite
        /// This should be overriden if resources need to be setup before each test.
        /// </summary>
        protected virtual Task AfterSetupAsync()
        {
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Teardown of resources that will be run after all test in a test fixture or suite have run
        /// This should be overriden if customization for resource teardown needs done, else the teardown of
        /// resources will be handled automaticall by the framework
        /// </summary>
        protected virtual Task AfterOneTimeTearDownAsync()
        {
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Teardown of resources that will be run after each test in test fixture or suite
        /// This should be overriden if customization for resource teardown needs done, else the teardown of
        /// resources will be handled automaticall by the framework
        /// </summary>
        protected virtual Task AfterTearDownAsync()
        {
            return Task.FromResult<object>(null);
        }
        /// <summary>
        /// Called by NUnit for one time setup, calls on setup
        /// </summary>
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
            await AfterOneTimeSetupAsync();
            await this.RunTearDown();
        }
        /// <summary>
        /// Called by NUnit to run one time tear down and runs user defined on one time teardown
        /// </summary>
        [OneTimeTearDown]
        protected async Task RunOneTimeTearDown()
        {
            await RunTearDown();
            CleanupResourceGroupsAsync();
            Logger?.Dispose();
            Logger = null;
            await AfterOneTimeTearDownAsync();
        }
        /// <summary>
        /// A method called by NUnit framework to setup recordings for new test and run onsetup
        /// </summary>
        [SetUp]
        protected async Task RunSetup()
        {
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            if (Mode != RecordedTestMode.Live &&
                test.Properties.ContainsKey("SkipRecordings"))
            {
                throw new IgnoreException((string)test.Properties.Get("SkipRecordings") +
                " test is not running live but the recording is marked to be skipped");
            }
            Recording = new TestRecording(Mode, GetSessionFilePath(), Sanitizer, Matcher);
            TestEnvironment.Mode = Mode;
            TestEnvironment.SetRecording(Recording);
            InitializeClients();
            await AfterSetupAsync();
        }
        /// <summary>
        /// Called by NUnit upon completion of test and saves the recording if running in record mode
        /// </summary>
        [TearDown]
        protected async Task RunTearDown()
        {
            bool save = TestContext.CurrentContext.Result.FailCount == 0;
#if DEBUG
            save |= SaveDebugRecordingsOnFailure;
#endif
            Recording?.Dispose(save);
            await AfterTearDownAsync();
        }

        /// <summary>
        /// Create a resource group to be monitored by the test framework.
        /// </summary>
        protected ResourcesManagementClient GetResourceManagementClient()
        {
            return GetManagementClient<ResourcesManagementClient>(new ResourcesManagementClientOptions());
        }

        /// <summary>
        /// Delete all monitored resource groups.
        /// </summary>
        protected void CleanupResourceGroupsAsync()
        {
            if (CleanupPolicy != null && Mode != RecordedTestMode.Playback)
            {
                var resourceGroupsClient = new ResourcesManagementClient(
                    TestEnvironment.SubscriptionId,
                    TestEnvironment.Credential).ResourceGroups;
                foreach (var resourceGroup in CleanupPolicy.ResourceGroupsCreated)
                {
                    _ = resourceGroupsClient.StartDeleteAsync(resourceGroup);
                }
                CleanupPolicy.ResourceGroupsCreated.Clear();
            }
        }
        /// <summary>
        /// Get a management client with the test enviroment subscription
        /// </summary>
        protected T GetManagementClient<T>(ClientOptions options) where T : class
        {
            if (typeof(T) == typeof(ResourcesManagementClient))
            {
                options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);
            }
            return this.CreateClient<T>(TestEnvironment.SubscriptionId,
                TestEnvironment.Credential, InstrumentClientOptions(options));
        }

    }
}