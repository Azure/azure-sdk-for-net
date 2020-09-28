// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Azure.ResourceManager.TestFramework
{
    [Category("Recorded")]
    public abstract class MgmtRecordTestBase<TEnvironment> : ClientTestBase where TEnvironment : TestEnvironment, new()
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

        protected MgmtRecordTestBase(bool isAsync) : this(isAsync, RecordedTestUtilities.GetModeFromEnvironment())
        {
        }

        protected MgmtRecordTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync)
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

        protected abstract void InitializeClients();

        protected virtual Task OnOneTimeSetupAsync()
        {
            return Task.FromResult<object>(null);
        }
        protected virtual Task OnSetupAsync()
        {
            return Task.FromResult<object>(null);
        }

        protected virtual Task OnOneTimeTearDownAsync()
        {
            return Task.FromResult<object>(null);
        }

        protected virtual Task OnTearDownAsync()
        {
            return Task.FromResult<object>(null);
        }

        [OneTimeSetUp]
        private void RunOneTimeSetup()
        {
            if (Mode == RecordedTestMode.Live || Debugger.IsAttached)
            {
                Logger = new TestLogger();
            }
            Recording = new TestRecording(Mode, GetSessionFilePath(), Sanitizer, Matcher);
            TestEnvironment.SetRecording(Recording);
            InitializeClients();
            OnOneTimeSetupAsync();
        }

        [OneTimeTearDown]
        private async Task RunOneTimeTearDown()
        {
            StopTestRecording();
            await CleanupResourceGroupsAsync();
            Logger?.Dispose();
            Logger = null;
            await OnOneTimeTearDownAsync();
        }

        [SetUp]
        private void StartTestRecording()
        {
            StopTestRecording();
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
            OnSetupAsync();
        }

        [TearDown]
        private void StopTestRecording()
        {
            bool save = TestContext.CurrentContext.Result.FailCount == 0;
#if DEBUG
            save |= SaveDebugRecordingsOnFailure;
#endif
            Recording?.Dispose(save);
            OnTearDownAsync();
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

    }
}
