// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    public class TestEnvironmentTests
    {
        private string _envFilePath;

        private static readonly bool s_isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        [OneTimeSetUp]
        public void SetUp()
        {
            Environment.SetEnvironmentVariable("CORE_RECORDED", "1");
            Environment.SetEnvironmentVariable("CORE_NOTRECORDED", "2");
            Environment.SetEnvironmentVariable("TENANT_ID", "4");
            Environment.SetEnvironmentVariable("ENVIRONMENT", "5");

            Environment.SetEnvironmentVariable("CORE_Base64Secret", "1");
            Environment.SetEnvironmentVariable("CORE_CustomSecret", "1");
            Environment.SetEnvironmentVariable("CORE_DefaultSecret", "1");
            Environment.SetEnvironmentVariable("CORE_ConnectionStringWithSecret", "endpoint=1;key=2");

            // Env file is only supported on Windows.
            if (s_isWindows)
            {
                _envFilePath = Path.Combine(TestEnvironment.RepositoryRoot, "sdk", "core", "test-resources.json.env");
                using FileStream stream = File.Create(_envFilePath);
                Dictionary<string, string> envFile = new Dictionary<string, string>
                {
                    { "CORE_TENANT_ID", "7" }
                };
                byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(envFile, typeof(Dictionary<string, string>));
#pragma warning disable CA1416 // Platform is checked in if statement
                bytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
#pragma warning restore CA1416
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (_envFilePath != null)
            {
                File.Delete(_envFilePath);
            }
        }

        [TestCase(RecordedTestMode.Playback)]
        [TestCase(RecordedTestMode.Record)]
        public void ReadingRecordedValueInCtorThrowsInRecordedOrPlayback(RecordedTestMode mode)
        {
            Assert.Throws<InvalidOperationException>(() => new RecordedVariableMisuse(true, mode));
        }

        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.None)]
        public void ReadingRecordedValueInCtorDoesNotThrowInLive(RecordedTestMode mode)
        {
            // this is allowed when in Live mode since we are not going to look at any record sessions anyway
            var test = new RecordedVariableMisuse(true, mode);
            Assert.AreEqual("1", test.Value);
        }

        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.Playback)]
        [TestCase(RecordedTestMode.Record)]
        [TestCase(RecordedTestMode.None)]
        public void ReadingNonRecordedValueInCtorWorks(RecordedTestMode mode)
        {
            var test = new RecordedVariableMisuse(false, mode);
            Assert.AreEqual("2", test.Value);
        }

        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.Playback)]
        [TestCase(RecordedTestMode.Record)]
        [TestCase(RecordedTestMode.None)]
        public void ReadingRecordedValueInCtorWorksForSamples(RecordedTestMode mode)
        {
            var test = new SampleTestClass();
            Assert.AreEqual("1", test.Value);
        }

        [TestCase(RecordedTestMode.Live)]
        [TestCase(RecordedTestMode.Playback)]
        [TestCase(RecordedTestMode.Record)]
        [TestCase(RecordedTestMode.None)]
        public void ReadingRecordedValueInCtorWorksForLiveTests(RecordedTestMode mode)
        {
            var test = new LiveTestClass();
            Assert.AreEqual("1", test.Value);
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
        public async Task RecordedVariableSanitized()
        {
            var tempFile = Path.GetTempFileName();
            var env = new MockTestEnvironment();
            var proxy = TestProxy.Start();
            var testRecording = await TestRecording.CreateAsync(RecordedTestMode.Record, tempFile, proxy, new RecordedTestBaseTests(true));
            env.Mode = RecordedTestMode.Record;
            env.SetRecording(testRecording);

            Assert.AreEqual("1", env.Base64Secret);
            Assert.AreEqual("1", env.CustomSecret);
            Assert.AreEqual("1", env.DefaultSecret);
            Assert.AreEqual("endpoint=1;key=2", env.ConnectionStringWithSecret);

            await testRecording.DisposeAsync();

            testRecording = await TestRecording.CreateAsync(RecordedTestMode.Playback, tempFile, proxy, new RecordedTestBaseTests(true));

            Assert.AreEqual("Kg==", testRecording.GetVariable("Base64Secret", ""));
            Assert.AreEqual("Custom", testRecording.GetVariable("CustomSecret", ""));
            Assert.AreEqual("Sanitized", testRecording.GetVariable("DefaultSecret", ""));
            Assert.AreEqual("endpoint=1;key=Sanitized", testRecording.GetVariable("ConnectionStringWithSecret", ""));
        }

        [Test]
        public async Task RecordedOptionalVariableNotSanitizedIfMissing()
        {
            var tempFile = Path.GetTempFileName();
            var env = new MockTestEnvironment();
            var proxy = TestProxy.Start();
            var testRecording = await TestRecording.CreateAsync(RecordedTestMode.Record, tempFile, proxy, new RecordedTestBaseTests(true));
            env.Mode = RecordedTestMode.Record;
            env.SetRecording(testRecording);

            Assert.IsNull(env.MissingOptionalSecret);

            await testRecording.DisposeAsync();
            testRecording = await TestRecording.CreateAsync(RecordedTestMode.Playback, tempFile, proxy, new RecordedTestBaseTests(true));

            Assert.IsNull(testRecording.GetVariable(nameof(env.MissingOptionalSecret), null));
        }

        [Test]
        public void RecordedOptionalVariablePrefersPrefix()
        {
            var env = new MockTestEnvironment();
            Assert.AreEqual("1", env.RecordedValue);
            if (_envFilePath != null)
            {
                Assert.AreEqual("7", env.TenantId);
            }
            else
            {
                Assert.AreEqual("4", env.TenantId);
            }
            Assert.AreEqual("5", env.AzureEnvironment);
        }

        [Test]
        public async Task ShouldCacheExceptionIfWaitingForEnvironmentFailed()
        {
            if (TestEnvironment.GlobalIsRunningInCI)
            {
                var env = new WaitForEnvironmentTestEnvironmentFailureMode();

                try
                {
                    await env.WaitForEnvironmentAsync();
                    Assert.Fail();
                }
                catch (InvalidOperationException e)
                {
                    StringAssert.Contains("kaboom", e.Message);
                }

                try
                {
                    await env.WaitForEnvironmentAsync();
                    Assert.Fail();
                }
                catch (InvalidOperationException e)
                {
                    StringAssert.Contains("kaboom", e.Message);
                }

                Assert.AreEqual(1, WaitForEnvironmentTestEnvironmentFailureMode.InvocationCount);
            }
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

        private class LiveTestClass : LiveTestBase<MockTestEnvironment>
        {
            public LiveTestClass()
            {
                Value = TestEnvironment.RecordedValue;
            }

            public string Value { get; }
        }

        private class SampleTestClass : SamplesBase<MockTestEnvironment>
        {
            public SampleTestClass()
            {
                Value = TestEnvironment.RecordedValue;
            }

            public string Value { get; }
        }

        internal class MockTestEnvironment : TestEnvironment
        {
            public static MockTestEnvironment Instance { get; } = new MockTestEnvironment();
            public string RecordedValue => GetRecordedVariable("RECORDED");
            public string NotRecordedValue => GetVariable("NOTRECORDED");

            public string Base64Secret => GetRecordedVariable("Base64Secret", option => option.IsSecret(SanitizedValue.Base64));
            public string DefaultSecret => GetRecordedVariable("DefaultSecret", option => option.IsSecret(SanitizedValue.Default));
            public string CustomSecret => GetRecordedVariable("CustomSecret", option => option.IsSecret("Custom"));
            public string MissingOptionalSecret => GetRecordedOptionalVariable("MissingOptionalSecret", option => option.IsSecret("INVALID"));
            public string ConnectionStringWithSecret => GetRecordedVariable("ConnectionStringWithSecret", option => option.HasSecretConnectionStringParameter("key"));
        }

        public class WaitForEnvironmentTestClassOne : RecordedTestBase<WaitForEnvironmentTestEnvironmentOne>
        {
            public WaitForEnvironmentTestClassOne(bool isAsync) : base(isAsync, RecordedTestMode.Live)
            {
            }

            [Test]
            public void ShouldCacheStateCorrectly()
            {
                if (Core.TestFramework.TestEnvironment.GlobalIsRunningInCI)
                {
                    Assert.AreEqual(2, WaitForEnvironmentTestEnvironmentOne.InvocationCount);
                }
            }
        }

        public class WaitForEnvironmentTestClassTwo : RecordedTestBase<WaitForEnvironmentTestEnvironmentTwo>
        {
            public WaitForEnvironmentTestClassTwo(bool isAsync) : base(isAsync, RecordedTestMode.Live)
            {
            }

            [Test]
            public void ShouldCacheStateCorrectly()
            {
                if (Core.TestFramework.TestEnvironment.GlobalIsRunningInCI)
                {
                    Assert.AreEqual(2, WaitForEnvironmentTestEnvironmentTwo.InvocationCount);
                }
            }
        }

        // This one uses same env as WaitForEnvironmentTestClassTwo to prove value is cached.
        public class WaitForEnvironmentTestClassThree : RecordedTestBase<WaitForEnvironmentTestEnvironmentTwo>
        {
            public WaitForEnvironmentTestClassThree(bool isAsync) : base(isAsync, RecordedTestMode.Live)
            {
            }

            [Test]
            public void ShouldCacheStateCorrectly()
            {
                if (Core.TestFramework.TestEnvironment.GlobalIsRunningInCI)
                {
                    Assert.AreEqual(2, WaitForEnvironmentTestEnvironmentTwo.InvocationCount);
                }
            }
        }

        public class WaitForEnvironmentTestEnvironmentOne : TestEnvironment
        {
            public static int InvocationCount { get; private set; }

            protected override ValueTask<bool> IsEnvironmentReadyAsync()
            {
                return new ValueTask<bool>(InvocationCount++ < 1 ? false : true);
            }
        }

        public class WaitForEnvironmentTestEnvironmentTwo : TestEnvironment
        {
            public static int InvocationCount { get; private set; }

            protected override ValueTask<bool> IsEnvironmentReadyAsync()
            {
                return new ValueTask<bool>(InvocationCount++ < 1 ? false : true);
            }
        }

        public class WaitForEnvironmentTestEnvironmentFailureMode : TestEnvironment
        {
            public WaitForEnvironmentTestEnvironmentFailureMode()
            {
                Mode = RecordedTestMode.Live;
            }

            public static int InvocationCount { get; private set; }

            protected override ValueTask<bool> IsEnvironmentReadyAsync()
            {
                InvocationCount++;
                throw new InvalidOperationException("kaboom");
            }
        }
    }
}
