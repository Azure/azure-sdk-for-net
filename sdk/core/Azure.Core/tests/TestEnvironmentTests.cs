// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class TestEnvironmentTests
    {
        [SetUp]
        public void SetUp()
        {
            Environment.SetEnvironmentVariable("CORE_RECORDED", "1");
            Environment.SetEnvironmentVariable("CORE_NOTRECORDED", "2");

            Environment.SetEnvironmentVariable("CORE_Base64Secret", "1");
            Environment.SetEnvironmentVariable("CORE_CustomSecret", "1");
            Environment.SetEnvironmentVariable("CORE_DefaultSecret", "1");
            Environment.SetEnvironmentVariable("CORE_ConnectionStringWithSecret", "endpoint=1;key=2");
        }

        [Theory]
        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.Playback)]
        [TestCase(RecordedTestMode.Record)]
        [TestCase(RecordedTestMode.None)]
        public void ReadingRecordedValueInCtorThrows(RecordedTestMode mode)
        {
            Assert.Throws<InvalidOperationException>(() => new RecordedVariableMisuse(true, mode));
        }

        [Theory]
        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.Playback)]
        [TestCase(RecordedTestMode.Record)]
        [TestCase(RecordedTestMode.None)]
        public void ReadingNonRecordedValueInCtorWorks(RecordedTestMode mode)
        {
            var test = new RecordedVariableMisuse(false, mode);
            Assert.AreEqual("2", test.Value);
        }

        [Test]
        public void ReadingRecordedValueOutsideRecordedTestWorks()
        {
            Assert.AreEqual("1", MockTestEnvironment.Instance.RecordedValue);
        }

        [Test]
        public void ReadingNonRecordedValueOutsideRecordedTestWorks()
        {
            Assert.AreEqual("2", MockTestEnvironment.Instance.NotRecordedValue);
        }

        [Test]
        public void RecordedVariableSanitized()
        {
            var tempFile = Path.GetTempFileName();
            var env = new MockTestEnvironment();
            var testRecording = new TestRecording(RecordedTestMode.Record, tempFile, new RecordedTestSanitizer(), new RecordMatcher());
            env.Mode = RecordedTestMode.Record;
            env.SetRecording(testRecording);

            Assert.AreEqual("1", env.Base64Secret);
            Assert.AreEqual("1", env.CustomSecret);
            Assert.AreEqual("1", env.DefaultSecret);
            Assert.AreEqual("endpoint=1;key=2", env.ConnectionStringWithSecret);

            testRecording.Dispose();

            testRecording = new TestRecording(RecordedTestMode.Playback, tempFile, new RecordedTestSanitizer(), new RecordMatcher());

            Assert.AreEqual("Kg==", testRecording.GetVariable("Base64Secret", ""));
            Assert.AreEqual("Custom", testRecording.GetVariable("CustomSecret", ""));
            Assert.AreEqual("Sanitized", testRecording.GetVariable("DefaultSecret", ""));
            Assert.AreEqual("endpoint=1;key=Sanitized", testRecording.GetVariable("ConnectionStringWithSecret", ""));
        }

        private class RecordedVariableMisuse : RecordedTestBase<MockTestEnvironment>
        {
            // To make NUnit happy
            public RecordedVariableMisuse(bool isAsync) : base(isAsync)
            {
            }

            public RecordedVariableMisuse(bool recorded, RecordedTestMode mode) : base(true, mode)
            {
                if (recorded)
                {
                    Value = TestEnvironment.RecordedValue;
                }
                else
                {
                    Value = TestEnvironment.NotRecordedValue;
                }
            }

            public string Value { get; }
        }

        private class MockTestEnvironment: TestEnvironment
        {
            public MockTestEnvironment(): base("core")
            {
            }

            public static MockTestEnvironment Instance { get; } = new MockTestEnvironment();
            public string RecordedValue => GetRecordedVariable("RECORDED");
            public string NotRecordedValue => GetVariable("NOTRECORDED");

            public string Base64Secret => GetRecordedVariable("Base64Secret", option => option.IsSecret(SanitizedValue.Base64));
            public string DefaultSecret => GetRecordedVariable("DefaultSecret", option => option.IsSecret(SanitizedValue.Default));
            public string CustomSecret => GetRecordedVariable("CustomSecret", option => option.IsSecret("Custom"));
            public string ConnectionStringWithSecret => GetRecordedVariable("ConnectionStringWithSecret", option => option.HasSecretConnectionStringParameter("key"));

        }
    }
}