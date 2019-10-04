// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using NUnit.Framework;

namespace Azure.Core.Testing
{
    [Category("Recorded")]
    public abstract class RecordedTestBase : ClientTestBase
    {
        protected RecordedTestSanitizer Sanitizer { get; set; }

        protected RecordMatcher Matcher { get; set; }

        protected TestRecording Recording { get; private set; }

        protected RecordedTestMode Mode { get; }

        protected RecordedTestBase(bool isAsync) : this(isAsync, RecordedTestUtilities.GetModeFromEnvironment())
        {
        }

        protected RecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync)
        {
            Sanitizer = new RecordedTestSanitizer();
            Matcher = new RecordMatcher(Sanitizer);
            Mode = mode;
        }

        private string GetSessionFilePath(string name = null)
        {
            TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;

            name ??= testAdapter.Name;

            string className = testAdapter.ClassName.Substring(testAdapter.ClassName.LastIndexOf('.') + 1);
            string fileName = name + (IsAsync ? "Async" : string.Empty) + ".json";
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "SessionRecords", className, fileName);
        }

        public TestRecording StartRecording(string name)
        {
            return new TestRecording(Mode, GetSessionFilePath(name), Sanitizer, Matcher);
        }

        [SetUp]
        public virtual void StartTestRecording()
        {
            Recording = new TestRecording(Mode, GetSessionFilePath(), Sanitizer, Matcher);
        }

        [TearDown]
        public virtual void StopTestRecording()
        {
            Recording?.Dispose(TestContext.CurrentContext.Result.FailCount == 0);
        }
    }
}
