// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
#if RESOURCES_RP
using Azure.ResourceManager.Resources;
#else
using Azure.Management.Resources;
#endif
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

        public TestRecording Recording { get; private set; }

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
            await OnOneTimeSetupAsync();
        }
        /// <summary>
        /// Called by NUnit to run one time tear down and runs user defined on one time teardown
        /// </summary>
        [OneTimeTearDown]
        protected async Task RunOneTimeTearDown()
        {
            await StopTestRecording();
            await CleanupResourceGroupsAsync();
            Logger?.Dispose();
            Logger = null;
            await OnOneTimeTearDownAsync();
        }
        /// <summary>
        /// A method called by NUnit framework to setup recordings for new test and run onsetup
        /// </summary>
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
        /// <summary>
        /// Called by NUnit upon completion of test and saves the recording if running in record mode
        /// </summary>
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

        /// <summary>
        /// Create a resource group to be monitored by the test framework.
        /// </summary>
        protected ResourcesManagementClient GetResourceManagementClient()
        {
            var options = Recording.InstrumentClientOptions(new ResourcesManagementClientOptions());
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);
            return GetManagementClient<ResourcesManagementClient>(options);
        }

        /// <summary>
        /// Delete all monitored resource groups.
        /// </summary>
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
        /// <summary>
        /// Get a management client with the test enviroment subscription
        /// </summary>
        protected T GetManagementClient<T>(ClientOptions options) where T : class
        {
            return this.CreateClient<T>(TestEnvironment.SubscriptionId,
                TestEnvironment.Credential, Recording.InstrumentClientOptions(options));
        }

    }
}
