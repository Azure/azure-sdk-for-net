// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.EventSourceListener;
using Microsoft.ApplicationInsights.Extensibility;
using NUnit.Framework;

// This class is without namespace on purpose, to make sure it runs once per test assembly regardless of how tests are packaged.
// It must be compiled into test assembly in order to work. Therefore using shared sources or making a copy is necessary.
[SetUpFixture]
public class AppInsightsNUnitFixture
{
    public static TelemetryClient TelemetryClient { get; private set; }

    private TelemetryConfiguration configuration;
    private DependencyTrackingTelemetryModule dependencyModule;
    private EventSourceTelemetryModule eventSourceModule;

    [OneTimeSetUp]
    public void SetUp()
    {
        string instrumentationKey = Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY");
        if (!string.IsNullOrWhiteSpace(instrumentationKey))
        {
            configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = instrumentationKey;

            configuration.TelemetryInitializers.Add(new CustomTelemetryInitializer());

            dependencyModule = new DependencyTrackingTelemetryModule();
            dependencyModule.Initialize(configuration);

            eventSourceModule = new EventSourceTelemetryModule();
            eventSourceModule.Sources.Add(new EventSourceListeningRequest()
            {
                Name = "Azure",
                PrefixMatch = true,
                Level = System.Diagnostics.Tracing.EventLevel.LogAlways
            });
            eventSourceModule.Initialize(configuration);

            TelemetryClient = new TelemetryClient(configuration);
        }
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        dependencyModule?.Dispose();
        eventSourceModule?.Dispose();
        configuration?.Dispose();
    }

    private class CustomTelemetryInitializer : ITelemetryInitializer
    {
        private string _testRunId = Environment.GetEnvironmentVariable("AZURE_STORAGE_TEST_RUN_ID") ?? Guid.NewGuid().ToString(); // there should be more info from pipeline.
        private string _testRunStartTime = Environment.GetEnvironmentVariable("AZURE_STORAGE_TEST_RUN_START_TIME");
        private string _assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        public void Initialize(ITelemetry telemetry)
        {
            var telemetryWithProperties = telemetry as ISupportProperties;
            if (telemetryWithProperties != null)
            {
                telemetryWithProperties.Properties.Add("TestAssembly", _assemblyName);
                telemetryWithProperties.Properties.Add("TestRunId", _testRunId);
                telemetryWithProperties.Properties.Add("TestRunStartTime", _testRunStartTime);
                var testContext = TestContext.CurrentContext;
                if (testContext != null)
                {
                    telemetryWithProperties.Properties.Add("TestName", testContext.Test.FullName);
                }
            }
        }
    }
}
