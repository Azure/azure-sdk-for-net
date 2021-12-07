// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.Core.TestFramework
{
    public abstract class RecordedTestBase : ClientTestBase
    {
        static RecordedTestBase()
        {
            // remove once https://github.com/Azure/azure-sdk-for-net/pull/25328 is shipped
            ServicePointManager.Expect100Continue = false;
        }

        protected RecordedTestSanitizer Sanitizer { get; set; }

        protected internal RecordMatcher Matcher { get; set; }

        public TestRecording Recording { get; private set; }

        public RecordedTestMode Mode { get; set; }

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

        /// <summary>
        /// Flag you can (temporarily) enable to save failed test recordings
        /// and debug/re-run at the point of failure without re-running
        /// potentially lengthy live tests.  This should never be checked in
        /// and will throw an exception from CI builds to help make that easier
        /// to spot.
        /// </summary>
        public bool SaveDebugRecordingsOnFailure
        {
            get => _saveDebugRecordingsOnFailure;
            set
            {
                if (value && TestEnvironment.GlobalIsRunningInCI)
                {
                    throw new AssertionException($"Setting {nameof(SaveDebugRecordingsOnFailure)} must not be merged");
                }

                _saveDebugRecordingsOnFailure = value;
            }
        }
        private bool _saveDebugRecordingsOnFailure;

        private TestProxy _proxy;

        private readonly bool _useLegacyTransport;
        private DateTime _testStartTime;

        protected bool ValidateClientInstrumentation { get; set; }

        protected override DateTime TestStartTime => _testStartTime;

        protected RecordedTestBase(bool isAsync, RecordedTestMode? mode = null, bool useLegacyTransport = false) : base(isAsync)
        {
            Sanitizer = new RecordedTestSanitizer();
            Matcher = new RecordMatcher();
            Mode = mode ?? TestEnvironment.GlobalTestMode;
            _useLegacyTransport = useLegacyTransport;
        }

        protected async Task<TestRecording> CreateTestRecordingAsync(RecordedTestMode mode, string sessionFile,
            RecordedTestSanitizer sanitizer, RecordMatcher matcher)
        {
            var recording = new TestRecording(mode, sessionFile, sanitizer, matcher, _proxy, _useLegacyTransport);
            await recording.InitializeProxySettingsAsync();
            return recording;
        }

        public T InstrumentClientOptions<T>(T clientOptions, TestRecording recording = default) where T : ClientOptions
        {
            recording ??= Recording;

            if (Mode == RecordedTestMode.Playback)
            {
                // Not making the timeout zero so retry code still goes async
                clientOptions.Retry.Delay = TimeSpan.FromMilliseconds(10);
                clientOptions.Retry.Mode = RetryMode.Fixed;
            }

            clientOptions.Transport = recording.CreateTransport(clientOptions.Transport);

            return clientOptions;
        }

        protected internal string GetSessionFilePath()
        {
            TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

            string name = new string(testAdapter.Name.Select(c => s_invalidChars.Contains(c) ? '%' : c).ToArray());
            string additionalParameterName = testAdapter.Properties.ContainsKey(ClientTestFixtureAttribute.RecordingDirectorySuffixKey) ?
                testAdapter.Properties.Get(ClientTestFixtureAttribute.RecordingDirectorySuffixKey).ToString() :
                null;

            // Use the current class name instead of the name of the class that declared a test.
            // This can be used in inherited tests that, for example, use a different endpoint for the same tests.
            string className = GetType().Name;

            string fileName = name + (IsAsync ? "Async" : string.Empty) + ".json";

            string path = TestEnvironment.GetSourcePath(GetType().Assembly);

            return Path.Combine(path,
                "SessionRecords",
                additionalParameterName == null ? className : $"{className}({additionalParameterName})",
                fileName);
        }

        public override void GlobalTimeoutTearDown()
        {
            // Only enforce the timeout on playback.
            if (Mode == RecordedTestMode.Playback)
            {
                base.GlobalTimeoutTearDown();
            }
        }

        /// <summary>
        /// Add a static <see cref="Diagnostics.AzureEventSourceListener"/> which will redirect SDK logging
        /// to Console.Out for easy debugging.
        /// </summary>
        private static TestLogger Logger { get; set; }

        /// <summary>
        /// Start logging events to the console if debugging or in Live mode.
        /// This will run once before any tests.
        /// </summary>
        [OneTimeSetUp]
        public void InitializeRecordedTestClass()
        {
            if (Mode == RecordedTestMode.Live || Debugger.IsAttached)
            {
                Logger = new TestLogger();
            }

            if (!_useLegacyTransport && Mode != RecordedTestMode.Live)
            {
                _proxy = TestProxy.Start();
            }
        }

        /// <summary>
        /// Do necessary cleanup.
        /// This will run once after all tests have finished.
        /// </summary>
        [OneTimeTearDown]
        public void TearDownRecordedTestClass()
        {
            Logger?.Dispose();
            Logger = null;
            _proxy?.Stop();
        }

        [SetUp]
        public virtual async Task StartTestRecordingAsync()
        {
            // initialize test start time in case test is skipped
            _testStartTime = DateTime.UtcNow;

            // Only create test recordings for the latest version of the service
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            if (Mode != RecordedTestMode.Live &&
                test.Properties.ContainsKey("_SkipRecordings"))
            {
                throw new IgnoreException((string) test.Properties.Get("_SkipRecordings"));
            }

            if (Mode == RecordedTestMode.Live &&
                test.Properties.ContainsKey("_SkipLive"))
            {
                throw new IgnoreException((string) test.Properties.Get("_SkipLive"));
            }

            Recording = await CreateTestRecordingAsync(Mode, GetSessionFilePath(), Sanitizer, Matcher);
            ValidateClientInstrumentation = Recording.HasRequests;

            // don't include test proxy overhead as part of test time
            _testStartTime = DateTime.UtcNow;
        }

        [TearDown]
        public virtual async Task StopTestRecordingAsync()
        {
            bool testPassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            if (ValidateClientInstrumentation && testPassed)
            {
                throw new InvalidOperationException("The test didn't instrument any clients but had recordings. Please call InstrumentClient for the client being recorded.");
            }

            bool save = testPassed;
#if DEBUG
            save |= SaveDebugRecordingsOnFailure;
#endif
            if (Recording != null)
            {
                await Recording.DisposeAsync(save);
            }

            _proxy?.CheckForErrors();
        }

        protected internal override object InstrumentClient(Type clientType, object client, IEnumerable<IInterceptor> preInterceptors)
        {
            ValidateClientInstrumentation = false;
            return base.InstrumentClient(clientType, client, preInterceptors);
        }

        protected internal T InstrumentOperation<T>(T operation) where T: Operation
        {
            return (T) InstrumentOperation(typeof(T), operation);
        }

        protected internal override object InstrumentOperation(Type operationType, object operation)
        {
            return ProxyGenerator.CreateClassProxyWithTarget(
                operationType,
                new[] { typeof(IInstrumented) },
                operation,
                new GetOriginalInterceptor(operation),
                new OperationInterceptor(Mode == RecordedTestMode.Playback));
        }

        protected object InstrumentMgmtOperation(Type operationType, object operation, ManagementInterceptor managementInterceptor)
        {
            return ProxyGenerator.CreateClassProxyWithTarget(
                operationType,
                new[] { typeof(IInstrumented) },
                operation,
                managementInterceptor,
                new GetOriginalInterceptor(operation),
                new OperationInterceptor(Mode == RecordedTestMode.Playback));
        }

        /// <summary>
        /// A number of our tests have built in delays while we wait an expected
        /// amount of time for a service operation to complete and this method
        /// allows us to wait (unless we're playing back recordings, which can
        /// complete immediately).
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait.</param>
        /// <param name="playbackDelayMilliseconds">
        /// An optional number of milliseconds to wait if we're playing back a
        /// recorded test.  This is useful for allowing client side events to
        /// get processed.
        /// </param>
        /// <returns>A task that will (optionally) delay.</returns>
        public Task Delay(int milliseconds = 1000, int? playbackDelayMilliseconds = null) =>
            Delay(Mode, milliseconds, playbackDelayMilliseconds);

        /// <summary>
        /// A number of our tests have built in delays while we wait an expected
        /// amount of time for a service operation to complete and this method
        /// allows us to wait (unless we're playing back recordings, which can
        /// complete immediately).
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait.</param>
        /// <param name="playbackDelayMilliseconds">
        /// An optional number of milliseconds to wait if we're playing back a
        /// recorded test.  This is useful for allowing client side events to
        /// get processed.
        /// </param>
        /// <returns>A task that will (optionally) delay.</returns>
        public static Task Delay(RecordedTestMode mode, int milliseconds = 1000, int? playbackDelayMilliseconds = null)
        {
            if (mode != RecordedTestMode.Playback)
            {
                return Task.Delay(milliseconds);
            }
            else if (playbackDelayMilliseconds != null)
            {
                return Task.Delay(playbackDelayMilliseconds.Value);
            }
            return Task.CompletedTask;
        }

        protected TestRetryHelper TestRetryHelper => new TestRetryHelper(Mode == RecordedTestMode.Playback);
    }
}
