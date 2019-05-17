// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Testing
{
    [Category("Recorded")]
    public abstract class RecordedTestBase: ClientTestBase
    {
        private const string ModeEnvironmentVariableName = "AZURE_TEST_MODE";

        protected RecordedTestSanitizer Sanitizer { get; set; } = new RecordedTestSanitizer();

        protected TestRecording Recording { get; private set; }

        protected RecordedTestBase(bool isAsync) : base(isAsync) { }

        protected virtual RecordedTestMode Mode
        {
            get
            {
                string modeString = Environment.GetEnvironmentVariable(ModeEnvironmentVariableName);

                if (!string.IsNullOrEmpty(modeString) ||
                    !Enum.TryParse(modeString, true, out RecordedTestMode mode))
                {
                    mode = RecordedTestMode.None;
                }

                return mode;
            }
        }

        protected virtual string SessionFilePath
        {
            get
            {
                TestContext.TestAdapter testAdapter = TestContext.CurrentContext.Test;
                var className = testAdapter.ClassName.Substring(testAdapter.ClassName.LastIndexOf('.') + 1);
                return Path.Combine(TestContext.CurrentContext.TestDirectory , "SessionRecords", className, testAdapter.Name + (IsAsync ? "Async": string.Empty) + ".json");
            }
        }

        [SetUp]
        public virtual void StartTestRecording()
        {
            Recording = new TestRecording(Mode, SessionFilePath, Sanitizer);
            Recording.Start();
        }

        [TearDown]
        public virtual void StopTestRecording()
        {
            Recording.Stop();
        }

        public T InstrumentClientOptions<T>(T clientOptions) where T: HttpClientOptions
        {
            clientOptions.Transport = Recording.CreateTransport(clientOptions.Transport);
            return clientOptions;
        }
    }
}
