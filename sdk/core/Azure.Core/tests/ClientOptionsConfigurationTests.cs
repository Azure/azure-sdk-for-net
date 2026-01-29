// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002 // Use of experimental ClientOptions configuration constructor

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [NonParallelizable]
    public class ClientOptionsConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            ClientOptions.ResetDefaultOptions();
        }

        [Test]
        public void LoadsAllDiagnosticsOptionsFromConfiguration()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Diagnostics:ApplicationId", "MyApp" },
                { "TestClient:Diagnostics:IsLoggingEnabled", "false" },
                { "TestClient:Diagnostics:IsTelemetryEnabled", "false" },
                { "TestClient:Diagnostics:IsDistributedTracingEnabled", "false" },
                { "TestClient:Diagnostics:IsLoggingContentEnabled", "true" },
                { "TestClient:Diagnostics:LoggedContentSizeLimit", "8192" },
                { "TestClient:Diagnostics:LoggedHeaderNames:0", "custom-header-1" },
                { "TestClient:Diagnostics:LoggedHeaderNames:1", "custom-header-2" },
                { "TestClient:Diagnostics:LoggedQueryParameters:0", "param1" },
                { "TestClient:Diagnostics:LoggedQueryParameters:1", "param2" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);
            Assert.AreEqual("MyApp", options.Diagnostics.ApplicationId);
            Assert.IsFalse(options.Diagnostics.IsLoggingEnabled);
            Assert.IsFalse(options.Diagnostics.IsTelemetryEnabled);
            Assert.IsFalse(options.Diagnostics.IsDistributedTracingEnabled);
            Assert.IsTrue(options.Diagnostics.IsLoggingContentEnabled);
            Assert.AreEqual(8192, options.Diagnostics.LoggedContentSizeLimit);
            CollectionAssert.AreEqual(new[] { "custom-header-1", "custom-header-2" }, options.Diagnostics.LoggedHeaderNames);
            CollectionAssert.AreEqual(new[] { "param1", "param2" }, options.Diagnostics.LoggedQueryParameters);
        }

        [Test]
        public void LoadsAllRetryOptionsFromConfiguration()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Retry:MaxRetries", "5" },
                { "TestClient:Retry:Delay", "00:00:02" },
                { "TestClient:Retry:MaxDelay", "00:01:00" },
                { "TestClient:Retry:Mode", "Fixed" },
                { "TestClient:Retry:NetworkTimeout", "00:05:00" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            Assert.AreEqual(5, options.Retry.MaxRetries);
            Assert.AreEqual(TimeSpan.FromSeconds(2), options.Retry.Delay);
            Assert.AreEqual(TimeSpan.FromMinutes(1), options.Retry.MaxDelay);
            Assert.AreEqual(RetryMode.Fixed, options.Retry.Mode);
            Assert.AreEqual(TimeSpan.FromMinutes(5), options.Retry.NetworkTimeout);
        }

        [Test]
        public void LoadsAllOptionsFromConfiguration()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Diagnostics:ApplicationId", "FullTestApp" },
                { "TestClient:Diagnostics:IsLoggingEnabled", "false" },
                { "TestClient:Diagnostics:IsTelemetryEnabled", "true" },
                { "TestClient:Retry:MaxRetries", "10" },
                { "TestClient:Retry:Delay", "00:00:01" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            Assert.AreEqual("FullTestApp", options.Diagnostics.ApplicationId);
            Assert.IsFalse(options.Diagnostics.IsLoggingEnabled);
            Assert.IsTrue(options.Diagnostics.IsTelemetryEnabled);
            Assert.AreEqual(10, options.Retry.MaxRetries);
            Assert.AreEqual(TimeSpan.FromSeconds(1), options.Retry.Delay);
        }

        [Test]
        public void UseDefaultsWhenConfigurationSectionIsNull()
        {
            // When section doesn't exist, GetClientSettings returns settings with defaults
            var configuration = new ConfigurationBuilder().Build();
            var settings = configuration.GetClientSettings<TestClientSettings>("NonExistent");
            var options = settings.Options;

            Assert.IsNotNull(options);
            Assert.IsNotNull(options.Diagnostics);
            Assert.IsNotNull(options.Retry);
            Assert.IsTrue(options.Diagnostics.IsLoggingEnabled);
            Assert.AreEqual(3, options.Retry.MaxRetries);
        }

        [Test]
        public void UseDefaultsWhenConfigurationSectionDoesNotExist()
        {
            var configuration = new ConfigurationBuilder().Build();
            var settings = configuration.GetClientSettings<TestClientSettings>("NonExistent");
            var options = settings.Options;

            Assert.IsNotNull(options);
            Assert.IsNotNull(options.Diagnostics);
            Assert.IsNotNull(options.Retry);
            Assert.IsTrue(options.Diagnostics.IsLoggingEnabled);
            Assert.AreEqual(3, options.Retry.MaxRetries);
        }

        [Test]
        public void UseDefaultsWhenConfigurationIsEmpty()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            Assert.IsNotNull(options.Diagnostics);
            Assert.IsNotNull(options.Retry);
            Assert.IsTrue(options.Diagnostics.IsLoggingEnabled);
            Assert.AreEqual(3, options.Retry.MaxRetries);
        }

        [Test]
        public void PartialConfigurationUsesDefaultsForMissingValues()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Diagnostics:ApplicationId", "PartialApp" },
                { "TestClient:Retry:MaxRetries", "7" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            // Configured values
            Assert.AreEqual("PartialApp", options.Diagnostics.ApplicationId);
            Assert.AreEqual(7, options.Retry.MaxRetries);

            // Default values
            Assert.IsTrue(options.Diagnostics.IsLoggingEnabled);
            Assert.IsTrue(options.Diagnostics.IsTelemetryEnabled);
            Assert.IsTrue(options.Diagnostics.IsDistributedTracingEnabled);
            Assert.AreEqual(TimeSpan.FromSeconds(0.8), options.Retry.Delay);
            Assert.AreEqual(RetryMode.Exponential, options.Retry.Mode);
        }

        [Test]
        public void ConfigurationReferenceSyntaxWorks()
        {
            var configData = new Dictionary<string, string>
            {
                // Shared configuration
                { "Shared:Diagnostics:ApplicationId", "SharedApp" },
                { "Shared:Diagnostics:IsLoggingEnabled", "false" },
                { "Shared:Diagnostics:LoggedContentSizeLimit", "4096" },
                // Client1 references the shared Diagnostics section
                { "Client1:Diagnostics", "$Shared:Diagnostics" },
                { "Client1:Retry:MaxRetries", "5" },
                // Client2 also references the same shared Diagnostics section
                { "Client2:Diagnostics", "$Shared:Diagnostics" },
                { "Client2:Retry:MaxRetries", "10" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            // Both clients should get the shared diagnostics settings
            var settings1 = configuration.GetClientSettings<TestClientSettings>("Client1");
            var settings2 = configuration.GetClientSettings<TestClientSettings>("Client2");

            Assert.IsNotNull(settings1.Options);
            Assert.IsNotNull(settings2.Options);

            // Both should have the same diagnostics values from Shared section
            Assert.AreEqual("SharedApp", settings1.Options.Diagnostics.ApplicationId);
            Assert.AreEqual("SharedApp", settings2.Options.Diagnostics.ApplicationId);
            Assert.IsFalse(settings1.Options.Diagnostics.IsLoggingEnabled);
            Assert.IsFalse(settings2.Options.Diagnostics.IsLoggingEnabled);
            Assert.AreEqual(4096, settings1.Options.Diagnostics.LoggedContentSizeLimit);
            Assert.AreEqual(4096, settings2.Options.Diagnostics.LoggedContentSizeLimit);

            // But different retry settings
            Assert.AreEqual(5, settings1.Options.Retry.MaxRetries);
            Assert.AreEqual(10, settings2.Options.Retry.MaxRetries);
        }

        [Test]
        public void NullValuesInCollectionsAreFiltered()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Diagnostics:LoggedHeaderNames:0", "header1" },
                { "TestClient:Diagnostics:LoggedHeaderNames:1", null }, // Null value
                { "TestClient:Diagnostics:LoggedHeaderNames:2", "header2" },
                { "TestClient:Diagnostics:LoggedQueryParameters:0", "param1" },
                { "TestClient:Diagnostics:LoggedQueryParameters:1", null }, // Null value
                { "TestClient:Diagnostics:LoggedQueryParameters:2", "param2" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            // Null values should be filtered out
            CollectionAssert.AreEqual(new[] { "header1", "header2" }, options.Diagnostics.LoggedHeaderNames);
            CollectionAssert.AreEqual(new[] { "param1", "param2" }, options.Diagnostics.LoggedQueryParameters);
        }

        [Test]
        public void EmptyCollectionsUseDefaults()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Diagnostics:LoggedHeaderNames", "" },
                { "TestClient:Diagnostics:LoggedQueryParameters", "" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            // Empty collections should result in defaults being used
            Assert.IsNotEmpty(options.Diagnostics.LoggedHeaderNames);
            Assert.IsNotEmpty(options.Diagnostics.LoggedQueryParameters);
        }

        [Test]
        public void InvalidRetryModeUsesDefault()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Retry:Mode", "InvalidMode" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            // Invalid enum value should use default
            Assert.AreEqual(RetryMode.Exponential, options.Retry.Mode);
        }

        [Test]
        public void InvalidTimeSpanUsesDefault()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Retry:Delay", "invalid" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            // Invalid TimeSpan should use default
            Assert.AreEqual(TimeSpan.FromSeconds(0.8), options.Retry.Delay);
        }

        [Test]
        public void InvalidIntUsesDefault()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Retry:MaxRetries", "not-a-number" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            // Invalid int should use default
            Assert.AreEqual(3, options.Retry.MaxRetries);
        }

        [Test]
        public void InvalidBoolUsesDefault()
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Diagnostics:IsLoggingEnabled", "maybe" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            // Invalid bool should use default
            Assert.IsTrue(options.Diagnostics.IsLoggingEnabled);
        }

        [Test]
        public void ConfigurationOverridesEnvironmentVariables()
        {
            try
            {
                Environment.SetEnvironmentVariable("AZURE_TELEMETRY_DISABLED", "true");
                Environment.SetEnvironmentVariable("AZURE_TRACING_DISABLED", "true");

                ClientOptions.ResetDefaultOptions();

                var configData = new Dictionary<string, string>
                {
                    { "TestClient:Diagnostics:IsTelemetryEnabled", "true" },
                    { "TestClient:Diagnostics:IsDistributedTracingEnabled", "true" }
                };

                var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(configData)
                    .Build();

                var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
                var options = settings.Options;

                Assert.IsNotNull(options);

                // Configuration values explicitly set should override environment variables
                Assert.IsTrue(options.Diagnostics.IsTelemetryEnabled);
                Assert.IsTrue(options.Diagnostics.IsDistributedTracingEnabled);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_TELEMETRY_DISABLED", null);
                Environment.SetEnvironmentVariable("AZURE_TRACING_DISABLED", null);
            }
        }

        [Test]
        public void NestedConfigurationSectionWorks()
        {
            var configData = new Dictionary<string, string>
            {
                { "Azure:Client:Diagnostics:ApplicationId", "NestedApp" },
                { "Azure:Client:Retry:MaxRetries", "8" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("Azure:Client");
            var options = settings.Options;

            Assert.IsNotNull(options);
            Assert.AreEqual("NestedApp", options.Diagnostics.ApplicationId);
            Assert.AreEqual(8, options.Retry.MaxRetries);
        }

        [Test]
        public void AllHeadersAndParametersCanBeLoaded()
        {
            var headers = new List<string>();
            var parameters = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                headers.Add($"header-{i}");
                parameters.Add($"param-{i}");
            }

            var configData = new Dictionary<string, string>();
            for (int i = 0; i < headers.Count; i++)
            {
                configData[$"TestClient:Diagnostics:LoggedHeaderNames:{i}"] = headers[i];
                configData[$"TestClient:Diagnostics:LoggedQueryParameters:{i}"] = parameters[i];
            }

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);

            CollectionAssert.AreEqual(headers, options.Diagnostics.LoggedHeaderNames);
            CollectionAssert.AreEqual(parameters, options.Diagnostics.LoggedQueryParameters);
        }

        [TestCase("true", true)]
        [TestCase("True", true)]
        [TestCase("TRUE", true)]
        [TestCase("false", false)]
        [TestCase("False", false)]
        [TestCase("FALSE", false)]
        public void BooleanValuesAcceptMultipleFormats(string value, bool expected)
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Diagnostics:IsLoggingEnabled", value }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);
            Assert.AreEqual(expected, options.Diagnostics.IsLoggingEnabled);
        }

        [TestCase("00:00:30")]
        [TestCase("00:01:00")]
        [TestCase("01:00:00")]
        [TestCase("1.00:00:00")]
        public void TimeSpanValuesAcceptMultipleFormats(string value)
        {
            var expected = TimeSpan.Parse(value);
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Retry:Delay", value }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);
            Assert.AreEqual(expected, options.Retry.Delay);
        }

        [TestCase("Exponential", RetryMode.Exponential)]
        [TestCase("Fixed", RetryMode.Fixed)]
        public void RetryModeEnumValuesAreHandledCorrectly(string value, RetryMode expected)
        {
            var configData = new Dictionary<string, string>
            {
                { "TestClient:Retry:Mode", value }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var settings = configuration.GetClientSettings<TestClientSettings>("TestClient");
            var options = settings.Options;

            Assert.IsNotNull(options);
            Assert.AreEqual(expected, options.Retry.Mode);
        }

        private class TestClientSettings : ClientSettings
        {
            public TestClientOptions Options { get; set; }

            protected override void BindCore(IConfigurationSection section)
            {
                Options = new TestClientOptions(section);
            }
        }

        private class TestClientOptions : ClientOptions
        {
            public TestClientOptions(IConfigurationSection section) : base(section)
            {
            }
        }
    }
}
