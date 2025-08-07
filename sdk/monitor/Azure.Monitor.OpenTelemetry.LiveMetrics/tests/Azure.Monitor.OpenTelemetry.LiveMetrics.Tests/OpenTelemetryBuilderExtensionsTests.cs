// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests
{
    public class OpenTelemetryBuilderExtensionsTests
    {
        private const string ApplicationInsightsConnectionString = "APPLICATIONINSIGHTS_CONNECTION_STRING";

        [Fact]
        public void UseAzureMonitorExporter_ConfiguresConnectionStringFromAppsettings()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:ConnectionString", "InstrumentationKey=test-key")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            Assert.Equal("InstrumentationKey=test-key", options.ConnectionString);
        }

        [Fact]
        public void UseAzureMonitorExporter_ConfiguresSamplingRatioFromAppsettings()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:SamplingRatio", "0.5")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            Assert.Equal(0.5f, options.SamplingRatio);
        }

        [Fact]
        public void UseAzureMonitorExporter_ConfiguresStorageDirectoryFromAppsettings()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:StorageDirectory", "/custom/storage/path")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            Assert.Equal("/custom/storage/path", options.StorageDirectory);
        }

        [Fact]
        public void UseAzureMonitorExporter_ConfiguresDisableOfflineStorageFromAppsettings()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:DisableOfflineStorage", "true")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            Assert.True(options.DisableOfflineStorage);
        }

        [Fact]
        public void UseAzureMonitorExporter_ConfiguresEnableLiveMetricsFromAppsettings()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:EnableLiveMetrics", "false")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            Assert.False(options.EnableLiveMetrics);
        }

        [Fact]
        public void UseAzureMonitorExporter_ConfiguresVersionFromAppsettings()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:Version", "v2_1")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            Assert.Equal(AzureMonitorExporterOptions.ServiceVersion.v2_1, options.Version);
        }

        [Fact]
        public void UseAzureMonitorExporter_ConfiguresConnectionStringFromEnvVar()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>(ApplicationInsightsConnectionString, "InstrumentationKey=env-var-key")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            Assert.Equal("InstrumentationKey=env-var-key", options.ConnectionString);
        }

        [Fact]
        public void UseAzureMonitorExporter_ConfiguresMultipleOptionsFromAppsettings()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:ConnectionString", "InstrumentationKey=test-key"),
                new KeyValuePair<string, string?>("AzureMonitorExporter:SamplingRatio", "0.25"),
                new KeyValuePair<string, string?>("AzureMonitorExporter:DisableOfflineStorage", "true"),
                new KeyValuePair<string, string?>("AzureMonitorExporter:EnableLiveMetrics", "false"),
                new KeyValuePair<string, string?>("AzureMonitorExporter:StorageDirectory", "/test/path")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            Assert.Equal("InstrumentationKey=test-key", options.ConnectionString);
            Assert.Equal(0.25f, options.SamplingRatio);
            Assert.True(options.DisableOfflineStorage);
            Assert.False(options.EnableLiveMetrics);
            Assert.Equal("/test/path", options.StorageDirectory);
        }

        [Fact]
        public void UseAzureMonitorExporter_ConnectionStringEnvVarOverridesSectionValue()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:ConnectionString", "InstrumentationKey=section-key"),
                new KeyValuePair<string, string?>(ApplicationInsightsConnectionString, "InstrumentationKey=env-var-key")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            // The value from the environment variable should take precedence
            Assert.Equal("InstrumentationKey=env-var-key", options.ConnectionString);
        }

        [Fact]
        public void UseAzureMonitorExporter_ProgrammaticOptionsOverrideConfiguration()
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:ConnectionString", "InstrumentationKey=config-key"),
                new KeyValuePair<string, string?>("AzureMonitorExporter:SamplingRatio", "0.5")
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter(options =>
            {
                options.ConnectionString = "InstrumentationKey=programmatic-key";
                options.SamplingRatio = 0.75f;
            });

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;
            // Programmatic options should override configuration values
            Assert.Equal("InstrumentationKey=programmatic-key", options.ConnectionString);
            Assert.Equal(0.75f, options.SamplingRatio);
        }

        /// <summary>
        /// The AzureMonitorExporterOptions class inherits a base class ClientOptions.
        /// The base class has several other public properties availabel for users.
        /// This test is to ensure that we don't inadvertantly break those configuration options.
        /// </summary>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void UseAzureMonitorExporter_ClientOptionsDiagnosticsLoggingEnabledFromAppsettings(bool isLoggingEnabled)
        {
            // Arrange
            var configValues = new List<KeyValuePair<string, string?>>
            {
                new KeyValuePair<string, string?>("AzureMonitorExporter:ConnectionString", "InstrumentationKey=test-key"),
                new KeyValuePair<string, string?>("AzureMonitorExporter:Diagnostics:IsLoggingEnabled", isLoggingEnabled.ToString())
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);

            var builder = new TestOpenTelemetryBuilder(services);

            // Act
            builder.UseAzureMonitorExporter();

            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().CurrentValue;

            // Verify the Diagnostics.IsLoggingEnabled property is set from configuration
            Assert.Equal(isLoggingEnabled, options.Diagnostics.IsLoggingEnabled);
        }

        // Test helper class to implement IOpenTelemetryBuilder
        private class TestOpenTelemetryBuilder : IOpenTelemetryBuilder
        {
            public TestOpenTelemetryBuilder(IServiceCollection services)
            {
                Services = services;
            }

            public IServiceCollection Services { get; }
        }
    }
}
