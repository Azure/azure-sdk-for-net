// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.EventSourceListener;
using Microsoft.ApplicationInsights.Extensibility;
using NUnit.Framework;

// This class is without namespace on purpose, to make sure it runs once per test assembly regardless of how tests are packaged.
// It must be compiled into test assembly in order to work. Therefore using shared sources or making a copy is necessary.
[SetUpFixture]
public class AppInsightsNUnitFixture
{
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
        }
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        dependencyModule?.Dispose();
        eventSourceModule?.Dispose();
        configuration?.Dispose();
    }
}
