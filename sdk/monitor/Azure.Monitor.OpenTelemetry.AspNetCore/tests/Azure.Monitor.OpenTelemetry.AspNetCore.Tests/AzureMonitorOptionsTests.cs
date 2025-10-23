// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Azure.Monitor.OpenTelemetry.Exporter;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class AzureMonitorOptionsTests
    {
        private const string TestConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        [Fact]
        public void AzureMonitorOptions_EnableTraceBasedLogsSampler_DefaultValue_IsTrue()
        {
            // Arrange & Act
            var options = new AzureMonitorOptions();

            // Assert
            Assert.True(options.EnableTraceBasedLogsSampler);
        }

        [Fact]
        public void AzureMonitorOptions_EnableTraceBasedLogsSampler_CanBeDisabled()
        {
            // Arrange & Act
            var options = new AzureMonitorOptions
            {
                EnableTraceBasedLogsSampler = false
            };

            // Assert
            Assert.False(options.EnableTraceBasedLogsSampler);
        }

        [Fact]
        public void AzureMonitorOptions_SetValueToExporterOptions_CopiesEnableTraceBasedLogsSampler()
        {
            // Arrange
            var azureMonitorOptions = new AzureMonitorOptions
            {
                ConnectionString = TestConnectionString,
                EnableTraceBasedLogsSampler = false
            };

            var exporterOptions = new AzureMonitorExporterOptions();

            // Act
            azureMonitorOptions.SetValueToExporterOptions(exporterOptions);

            // Assert
            Assert.False(exporterOptions.EnableTraceBasedLogsSampler);
            Assert.Equal(TestConnectionString, exporterOptions.ConnectionString);
        }

        [Fact]
        public void UseAzureMonitor_DefaultEnableTraceBasedLogsSampler()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = TestConnectionString;
                    options.DisableOfflineStorage = true;
                });

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert
            var azureMonitorOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorOptions>>()
                .Get(Options.DefaultName);

            Assert.True(azureMonitorOptions.EnableTraceBasedLogsSampler);

            var exporterOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>()
                .Get(Options.DefaultName);

            Assert.True(exporterOptions.EnableTraceBasedLogsSampler);
        }

        [Fact]
        public void UseAzureMonitor_CanDisableTraceBasedLogsSampler()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = TestConnectionString;
                    options.EnableTraceBasedLogsSampler = false;
                    options.DisableOfflineStorage = true;
                });

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert
            var azureMonitorOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorOptions>>()
                .Get(Options.DefaultName);

            Assert.False(azureMonitorOptions.EnableTraceBasedLogsSampler);

            var exporterOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>()
                .Get(Options.DefaultName);

            Assert.False(exporterOptions.EnableTraceBasedLogsSampler);
        }

        [Fact]
        public void UseAzureMonitor_EnableTraceBasedLogsSampler_PropagatesCorrectly()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act - Test with true
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = TestConnectionString;
                    options.EnableTraceBasedLogsSampler = true;
                    options.DisableOfflineStorage = true;
                });

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert
            var azureMonitorOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorOptions>>()
                .Get(Options.DefaultName);

            var exporterOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>()
                .Get(Options.DefaultName);

            Assert.Equal(azureMonitorOptions.EnableTraceBasedLogsSampler, exporterOptions.EnableTraceBasedLogsSampler);
            Assert.True(exporterOptions.EnableTraceBasedLogsSampler);
        }

        [Fact]
        public void UseAzureMonitor_WithoutConfiguration_UsesDefaultValue()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = TestConnectionString;
                    options.DisableOfflineStorage = true;

                    // Not setting EnableTraceBasedLogsSampler, should use default
                });

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert
            var azureMonitorOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorOptions>>()
                .Get(Options.DefaultName);

            var exporterOptions = serviceProvider.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>()
                .Get(Options.DefaultName);

            // Both should be true (default value)
            Assert.True(azureMonitorOptions.EnableTraceBasedLogsSampler);
            Assert.True(exporterOptions.EnableTraceBasedLogsSampler);
        }
    }
}
