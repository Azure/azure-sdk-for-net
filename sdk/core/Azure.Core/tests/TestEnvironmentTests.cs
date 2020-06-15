// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        }
    }
}