// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.Core.TestFramework
{
    [Category("Recorded")]
    public abstract class RecordedTestBase : ClientTestBase
    {
        protected RecordedTestSanitizer Sanitizer { get; set; }

        protected RecordMatcher Matcher { get; set; }

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
                if (value && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SYSTEM_TEAMPROJECTID")))
                {
                    throw new AssertionException($"Setting {nameof(SaveDebugRecordingsOnFailure)} must not be merged");
                }

                _saveDebugRecordingsOnFailure = value;
            }
        }
        private bool _saveDebugRecordingsOnFailure;
        protected bool ValidateClientInstrumentation { get; set; }

        protected RecordedTestBase(bool isAsync) : this(isAsync, RecordedTestUtilities.GetModeFromEnvironment())
        {
        }

        protected RecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync)
        {
            Sanitizer = new RecordedTestSanitizer();
            Matcher = new RecordMatcher();
            Mode = mode;
        }

        public T InstrumentClientOptions<T>(T clientOptions) where T : ClientOptions
        {
            clientOptions.Transport = Recording.CreateTransport(clientOptions.Transport);
            if (Mode == RecordedTestMode.Playback)
            {
                // Not making the timeout zero so retry code still goes async
                clientOptions.Retry.Delay = TimeSpan.FromMilliseconds(10);
                clientOptions.Retry.Mode = RetryMode.Fixed;
            }
            return clientOptions;
        }

        private string GetSessionFilePath()
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

        /// <summary>
        /// Add a static TestEventListener which will redirect SDK logging
        /// to Console.Out for easy debugging.
        /// </summary>
        private static TestLogger Logger { get; set; }

        /// <summary>
        /// Start logging events to the console if debugging or in Live mode.
        /// This will run once before any tests.
        /// </summary>
        [OneTimeSetUp]
        public void StartLoggingEvents()
        {
            if (Mode == RecordedTestMode.Live || Debugger.IsAttached)
            {
                Logger = new TestLogger();
            }
        }

        /// <summary>
        /// Stop logging events and do necessary cleanup.
        /// This will run once after all tests have finished.
        /// </summary>
        [OneTimeTearDown]
        public void StopLoggingEvents()
        {
            Logger?.Dispose();
            Logger = null;
        }

        [SetUp]
        public virtual void StartTestRecording()
        {
            // Only create test recordings for the latest version of the service
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            if (Mode != RecordedTestMode.Live &&
                test.Properties.ContainsKey("SkipRecordings"))
            {
                throw new IgnoreException((string) test.Properties.Get("SkipRecordings"));
            }
            Recording = new TestRecording(Mode, GetSessionFilePath(), Sanitizer, Matcher);
            ValidateClientInstrumentation = Recording.HasRequests;
        }

        [TearDown]
        public virtual void StopTestRecording()
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
            Recording?.Dispose(save);
        }

        protected internal override object InstrumentClient(Type clientType, object client, IEnumerable<IInterceptor> preInterceptors)
        {
            ValidateClientInstrumentation = false;
            return base.InstrumentClient(clientType, client, preInterceptors);
        }
    }
}
