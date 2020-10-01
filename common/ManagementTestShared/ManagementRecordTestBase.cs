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

        // copied the Windows version https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/IO/Path.Windows.cs
        // as it is the most restrictive of all platforms
        private static readonly HashSet<char> s_invalidChars = new HashSet<char>(new char[]
        {
            '\"', '<', '>', '|', '\0',
            (char)1, (char)2, (char)3, (char)4, (char)5, (char)6, (char)7, (char)8, (char)9, (char)10,
            (char)11, (char)12, (char)13, (char)14, (char)15, (char)16, (char)17, (char)18, (char)19, (char)20,
            (char)21, (char)22, (char)23, (char)24, (char)25, (char)26, (char)27, (char)28, (char)29, (char)30,
            (char)31, ':', '*', '?', '\\', '/'
        });

#if DEBUG
        /// <summary>
        /// Flag you can (temporarily) enable to save failed test recordings
        /// and debug/re-run at the point of failure without re-running
        /// potentially lengthy live tests.  This should never be checked in
        /// and will be compiled out of release builds to help make that easier
        /// to spot.
        /// </summary>
        public bool SaveDebugRecordingsOnFailure { get; set; } = false;
#endif

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

        private string GetSessionFilePath()
        {
            TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

            string name = new string(testAdapter.Name.Select(c => s_invalidChars.Contains(c) ? '%' : c).ToArray());
            string additionalParameterName = testAdapter.Properties.ContainsKey(ClientTestFixtureAttribute.RecordingDirectorySuffixKey) ?
                testAdapter.Properties.Get(ClientTestFixtureAttribute.RecordingDirectorySuffixKey).ToString() :
                null;

            string className = testAdapter.ClassName.Substring(testAdapter.ClassName.LastIndexOf('.') + 1);

            string fileName = name + (IsAsync ? "Async" : string.Empty) + ".json";
            return Path.Combine(TestContext.CurrentContext.TestDirectory,
                "SessionRecords",
                additionalParameterName == null ? className : $"{className}({additionalParameterName})",
                fileName);
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

        protected T GetManagementClient<T>(ClientOptions options, string subscriptionId) where T : class
        {
            return this.CreateClient<T>(subscriptionId,
                TestEnvironment.Credential, Recording.InstrumentClientOptions(options));
        }

    }
}
