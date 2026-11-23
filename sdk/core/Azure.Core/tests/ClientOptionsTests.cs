// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Azure.Core.Pipeline;
using Azure.Core.Samples;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [NonParallelizable]
    public class ClientOptionsTests
    {
        [Test]
        public void ModelProxies_IsEmptyMutableAndStable()
        {
            var options = new TestClientOptions();

            Assert.That(options.ModelProxies, Is.Empty);
            Assert.IsFalse(options.ModelProxies.IsReadOnly);
            Assert.AreSame(options.ModelProxies, options.ModelProxies);
            Assert.IsNull(typeof(ClientOptions).GetProperty(nameof(ClientOptions.ModelProxies))!.GetSetMethod());
        }

        [Test]
        public void ModelProxies_KeepOrderAndSupportListOperations()
        {
            var options = new TestClientOptions();
            var first = new LabelProxy("first");
            var second = new LabelProxy("second");
            var third = new LabelProxy("third");
            var replacement = new LabelProxy("replacement");

            options.ModelProxies.Add(first);
            options.ModelProxies.Add(second);
            options.ModelProxies.Insert(0, third);
            Assert.That(options.ModelProxies, Is.EqualTo(new ModelProxy[] { third, first, second }));
            Assert.AreEqual(1, options.ModelProxies.IndexOf(first));
            Assert.IsTrue(options.ModelProxies.Contains(second));

            options.ModelProxies[1] = replacement;
            Assert.IsTrue(options.ModelProxies.Remove(third));
            Assert.IsFalse(options.ModelProxies.Remove(first));
            var copy = new ModelProxy[2];
            options.ModelProxies.CopyTo(copy, 0);
            Assert.That(copy, Is.EqualTo(new ModelProxy[] { replacement, second }));

            options.ModelProxies.RemoveAt(0);
            Assert.That(options.ModelProxies, Is.EqualTo(new ModelProxy[] { second }));

            options.ModelProxies.Clear();
            Assert.That(options.ModelProxies, Is.Empty);
        }

        [Test]
        public void ModelProxies_RejectNull()
        {
            var options = new TestClientOptions();
            options.ModelProxies.Add(new LabelProxy("existing"));

            Assert.Throws<ArgumentNullException>(() => options.ModelProxies.Add(null!));
            Assert.Throws<ArgumentNullException>(() => options.ModelProxies.Insert(0, null!));
            Assert.Throws<ArgumentNullException>(() => options.ModelProxies[0] = null!);
            Assert.AreEqual(1, options.ModelProxies.Count);
        }

        [Test]
        public void ModelProxies_AreCopiedIntoAnIndependentCollection()
        {
            // Options created with the protected constructors are copied from ClientOptions.Default.
            var first = new LabelProxy("first");
            var second = new LabelProxy("second");
            ClientOptions.Default.ModelProxies.Add(first);
            ClientOptions.Default.ModelProxies.Add(second);

            var options = new TestClientOptions();

            Assert.AreNotSame(ClientOptions.Default.ModelProxies, options.ModelProxies);
            Assert.IsFalse(options.ModelProxies.IsReadOnly);
            Assert.That(options.ModelProxies, Is.EqualTo(new ModelProxy[] { first, second }));

            options.ModelProxies.RemoveAt(0);
            options.ModelProxies.Add(new LabelProxy("third"));
            ClientOptions.Default.ModelProxies.Add(new LabelProxy("fourth"));

            Assert.AreEqual(3, ClientOptions.Default.ModelProxies.Count);
            Assert.AreSame(first, ClientOptions.Default.ModelProxies[0]);
            Assert.AreEqual(2, options.ModelProxies.Count);
            Assert.AreSame(second, options.ModelProxies[0]);
        }

        [Test]
        public void ModelProxies_ApplyThroughClientModelReaderWriterOptions()
        {
            var options = new TestClientOptions();
            options.ModelProxies.Add(new LabelProxy("proxy"));

            ModelReaderWriterOptions clientOptions = CreateModelReaderWriterOptions(options);
            BinaryData written = ModelReaderWriter.Write(new TestJsonModel { Name = "original", Value = 5 }, clientOptions);
            TestJsonModel read = ModelReaderWriter.Read<TestJsonModel>(BinaryData.FromString("{\"name\":\"payload\",\"value\":7}"), clientOptions);

            StringAssert.Contains("\"name\":\"proxy:original\"", written.ToString());
            Assert.AreEqual("proxy", read.Name);
            Assert.AreEqual(7, read.Value);

            BinaryData unproxied = ModelReaderWriter.Write(new TestJsonModel { Name = "original" }, CreateModelReaderWriterOptions(new TestClientOptions()));
            StringAssert.Contains("\"name\":\"original\"", unproxied.ToString());
        }

        // Builds the options a client uses to read and write models from the proxies on its client options.
        private static ModelReaderWriterOptions CreateModelReaderWriterOptions(ClientOptions clientOptions)
        {
            var options = new ModelReaderWriterOptions("W");
            foreach (ModelProxy proxy in clientOptions.ModelProxies)
            {
                options.Proxies.Add(proxy);
            }
            return options;
        }

        [TearDown]
        public void TearDown()
        {
            Core.ClientOptions.ResetDefaultOptions();
        }

        [Theory]
        [TestCase("true")]
        [TestCase("TRUE")]
        [TestCase("1")]
        public void CanDisableDistributedTracingWithEnvironmentVariable(string value)
        {
            try
            {
                Environment.SetEnvironmentVariable("AZURE_TRACING_DISABLED", value);

                Core.ClientOptions.ResetDefaultOptions();

                var testOptions = new TestClientOptions();
                Assert.False(testOptions.Diagnostics.IsDistributedTracingEnabled);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_TRACING_DISABLED", null);
            }
        }

        [Test]
        public void UsesDefaultApplicationId()
        {
            try
            {
                DiagnosticsOptions.DefaultApplicationId = "Global-application-id";

                var testOptions = new TestClientOptions();
                Assert.AreEqual("Global-application-id", testOptions.Diagnostics.ApplicationId);
            }
            finally
            {
                DiagnosticsOptions.DefaultApplicationId = null;
            }
        }

        [Theory]
        [TestCase("true")]
        [TestCase("TRUE")]
        [TestCase("1")]
        public void CanDisableTelemetryWithEnvironmentVariable(string value)
        {
            try
            {
                Environment.SetEnvironmentVariable("AZURE_TELEMETRY_DISABLED", value);

                Core.ClientOptions.ResetDefaultOptions();

                var testOptions = new TestClientOptions();
                Assert.False(testOptions.Diagnostics.IsTelemetryEnabled);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_TELEMETRY_DISABLED", null);
            }
        }

#if NETCOREAPP
        [Test]
        public void DefaultTransportIsHttpClientTransport()
        {
            var options = new TestClientOptions();

            Assert.IsInstanceOf<HttpClientTransport>(options.Transport);
        }
#else
        [Test]
        public void DefaultTransportIsHttpWebRequestTransport()
        {
            var options = new TestClientOptions();

            Assert.IsInstanceOf<HttpWebRequestTransport>(options.Transport);
            Assert.IsFalse(options.IsCustomTransportSet);
        }

        [Test]
        public void IsCustomTransportSetIsTrueAfterCallingTransportSetter()
        {
            var options = new TestClientOptions();
            options.Transport = new MockTransport();

            Assert.IsTrue(options.IsCustomTransportSet);
        }

        [Test]
        public void DefaultTransportIsHttpClientTransportIfEnvVarSet()
        {
            string oldValue = Environment.GetEnvironmentVariable("AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT");

            try
            {
                Environment.SetEnvironmentVariable("AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT", "true");

                Core.ClientOptions.ResetDefaultOptions();

                var options = new TestClientOptions();

                Assert.IsInstanceOf<HttpClientTransport>(options.Transport);
                Assert.IsFalse(options.IsCustomTransportSet);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT", oldValue);
            }
        }

        [Test]
        public void DefaultTransportIsHttpClientTransportIfSwitchIsSet()
        {
            AppContext.TryGetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", out bool oldSwitch);

            try
            {
                AppContext.SetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", true);

                Core.ClientOptions.ResetDefaultOptions();

                var options = new TestClientOptions();

                Assert.IsInstanceOf<HttpClientTransport>(options.Transport);
                Assert.IsFalse(options.IsCustomTransportSet);
            }
            finally
            {
                AppContext.SetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", oldSwitch);
            }
        }

#endif

        [TestCaseSource(nameof(ClientOptionsTestValues))]
        public void GlobalConfigurationIsApplied(Func<ClientOptions, object> set, Func<ClientOptions, object> get)
        {
            var initial = get(Core.ClientOptions.Default);
            var expected = set(Core.ClientOptions.Default);
            var testOptions = new TestClientOptions();

            Assert.AreNotEqual(initial, expected);
            Assert.AreEqual(expected, get(testOptions));
        }

        public static IEnumerable<object[]> ClientOptionsTestValues()
        {
            object[] M(Func<ClientOptions, object> set, Func<ClientOptions, object> get) => new[] { set, get };

            yield return M(o => o.Transport = new MockTransport(), o => o.Transport);
            yield return M(o =>
            {
                var policy = new PipelineSamples.StopwatchPolicy();
                o.AddPolicy(policy, HttpPipelinePosition.PerCall);
                return policy;
            }, o => o.Policies?.LastOrDefault(p => p.Position == HttpPipelinePosition.PerCall).Policy);

            yield return M(o =>
            {
                var policy = new PipelineSamples.StopwatchPolicy();
                o.AddPolicy(policy, HttpPipelinePosition.PerRetry);
                return policy;
            }, o => o.Policies?.LastOrDefault(p => p.Position == HttpPipelinePosition.PerRetry).Policy);

            yield return M(o =>
            {
                var policy = new PipelineSamples.StopwatchPolicy();
                o.AddPolicy(policy, HttpPipelinePosition.BeforeTransport);
                return policy;
            }, o => o.Policies?.LastOrDefault(p => p.Position == HttpPipelinePosition.BeforeTransport).Policy);

            yield return M(o => o.Retry.Delay = TimeSpan.FromDays(5), o => o.Retry.Delay);
            yield return M(o => o.Retry.Mode = RetryMode.Fixed, o => o.Retry.Mode);
            yield return M(o => o.Retry.MaxDelay = TimeSpan.FromDays(5), o => o.Retry.MaxDelay);
            yield return M(o => o.Retry.NetworkTimeout = TimeSpan.FromDays(5), o => o.Retry.NetworkTimeout);
            yield return M(o => o.Retry.MaxRetries = 44, o => o.Retry.MaxRetries);

            yield return M(o => o.RetryPolicy = new TestRetryPolicy(), o => o.RetryPolicy);

            yield return M(o => o.Diagnostics.ApplicationId = "a", o => o.Diagnostics.ApplicationId);
            yield return M(o => o.Diagnostics.IsLoggingEnabled = false, o => o.Diagnostics.IsLoggingEnabled);
            yield return M(o => o.Diagnostics.IsTelemetryEnabled = false, o => o.Diagnostics.IsTelemetryEnabled);
            yield return M(o => o.Diagnostics.IsLoggingContentEnabled = true, o => o.Diagnostics.IsLoggingContentEnabled);
            yield return M(o => o.Diagnostics.LoggedContentSizeLimit = 100, o => o.Diagnostics.LoggedContentSizeLimit);
            yield return M(o => o.Diagnostics.IsDistributedTracingEnabled = false, o => o.Diagnostics.IsDistributedTracingEnabled);

            yield return M(o =>
            {
                o.Diagnostics.LoggedHeaderNames.Add("abc");
                return "abc";
            }, o => o.Diagnostics.LoggedHeaderNames.LastOrDefault());

            yield return M(o =>
            {
                o.Diagnostics.LoggedQueryParameters.Add("abc");
                return "abc";
            }, o => o.Diagnostics.LoggedQueryParameters.LastOrDefault());
        }

        [Test]
        public void AcceptsCustomDiagnosticsOptions([Values(true, false)] bool useCustomOptions)
        {
            var target = new TestClienOptionsWithDiagnostics(useCustomOptions);

            if (useCustomOptions)
            {
                Assert.NotNull(target.Diagnostics);
                Assert.That(target.Diagnostics, Is.TypeOf(typeof(TestDiagnosticsOptions)));
                Assert.AreNotEqual(target.Diagnostics, ClientOptions.Default.Diagnostics);
            }
            else
            {
                Assert.IsNull(target.Diagnostics);
            }
        }

        [Test]
        public void DefaultMaxApplicationIdLengthIs24()
        {
            var options = new TestClientOptionsWithCustomMaxApplicationIdLength();
            Assert.AreEqual(24, options.GetMaxApplicationIdLength());
        }

        [Test]
        public void ApplicationIdExceedingDefaultMaxLengthIsAcceptedByOptions()
        {
            var options = new TestClientOptions();
            var longApplicationId = new string('a', 25);

            options.Diagnostics.ApplicationId = longApplicationId;

            Assert.AreEqual(longApplicationId, options.Diagnostics.ApplicationId);
        }

        [TestCase(23)]
        [TestCase(0)]
        [TestCase(-1)]
        public void SettingMaxApplicationIdLengthBelowDefaultThrows(int maxLength)
        {
            var options = new TestClientOptions();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => options.Diagnostics.MaxApplicationIdLength = maxLength);
            Assert.That(ex.Message, Does.Contain("MaxApplicationIdLength must be at least 24"));
        }

        [Test]
        public void SettingMaxApplicationIdLengthToLargeValueSucceeds()
        {
            var options = new TestClientOptionsWithCustomMaxApplicationIdLength(1000);

            Assert.AreEqual(1000, options.GetMaxApplicationIdLength());
        }

        private class TestClientOptions : ClientOptions
        {
        }

        private sealed class LabelProxy : ModelProxy<TestJsonModel>, IJsonModel<TestJsonModel>
        {
            private readonly string _label;

            public LabelProxy(string label)
            {
                _label = label;
            }

            public override BinaryData Write(ModelReaderWriterOptions options)
            {
                using var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(stream))
                {
                    ((IJsonModel<TestJsonModel>)this).Write(writer, options);
                }
                return BinaryData.FromBytes(stream.ToArray());
            }

            void IJsonModel<TestJsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                var original = (TestJsonModel)options.ProxiedModel!;
                writer.WriteStartObject();
                writer.WriteString("name", $"{_label}:{original.Name}");
                writer.WriteNumber("value", original.Value);
                writer.WriteEndObject();
            }

            public override TestJsonModel Create(BinaryData data, ModelReaderWriterOptions options)
            {
                using JsonDocument document = JsonDocument.Parse(data);
                return Create(document.RootElement);
            }

            TestJsonModel IJsonModel<TestJsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                return Create(document.RootElement);
            }

            private TestJsonModel Create(JsonElement element)
                => new TestJsonModel { Name = _label, Value = element.GetProperty("value").GetInt32() };

            public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        }

        private class TestClientOptionsWithCustomMaxApplicationIdLength : ClientOptions
        {
            public TestClientOptionsWithCustomMaxApplicationIdLength(int maxApplicationIdLength = 24)
            {
                MaxApplicationIdLength = maxApplicationIdLength;
            }

            public int GetMaxApplicationIdLength() => MaxApplicationIdLength;
        }

        private class TestDiagnosticsOptions : DiagnosticsOptions
        {
            public int MeExtraProperty { get; set; }
        }

        private class TestClienOptionsWithDiagnostics : ClientOptions
        {
            public TestClienOptionsWithDiagnostics(bool setCustomDiagnosticsOptions)
                : base(setCustomDiagnosticsOptions ? new TestDiagnosticsOptions() : null)
            { }

            /// <summary>
            /// Gets the credential diagnostic options.
            /// </summary>
            public new TestDiagnosticsOptions Diagnostics => base.Diagnostics as TestDiagnosticsOptions;
        }

        private class TestRetryPolicy : RetryPolicy
        {
        }
    }
}
