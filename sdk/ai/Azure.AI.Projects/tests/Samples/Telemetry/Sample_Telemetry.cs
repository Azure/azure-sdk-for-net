// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Projects.Tests
{
    public class Sample_Telemetry : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void TelemetryExample()
        {
            #region Snippet:AI_Projects_TelemetryExampleSync
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
#endif
            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine("Get the Application Insights connection string.");
            var connectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();

            Console.WriteLine("Assign the retrieved string to the required environment variable.");
            Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", connectionString);
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task TelemetryExampleAsync()
        {
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
#endif
            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine("Get the Application Insights connection string.");
            var connectionString = await projectClient.Telemetry.GetApplicationInsightsConnectionStringAsync();

            Console.WriteLine("Assign the retrieved string to the required environment variable.");
            Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", connectionString);
        }

        [Test]
        [SyncOnly]
        public void TracingToAzureMonitorExampleSync()
        {
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
            var projectEndpoint = TestEnvironment.PROJECTENDPOINT;
#endif
            #region Snippet:AI_Projects_TelemetrySetupTracingToAzureMonitor
            // Create a new tracer provider builder and add an Azure Monitor trace exporter to the tracer provider builder.
            // It is important to keep the TracerProvider instance active throughout the process lifetime.
            // See https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/trace#tracerprovider-management
            var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
                .AddAzureMonitorTraceExporter();

            // Add an Azure Monitor metric exporter to the metrics provider builder.
            // It is important to keep the MetricsProvider instance active throughout the process lifetime.
            // See https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/metrics#meterprovider-management
            var metricsProvider = OpenTelemetry.Sdk.CreateMeterProviderBuilder()
                .AddAzureMonitorMetricExporter();

            // Create a new logger factory.
            // It is important to keep the LoggerFactory instance active throughout the process lifetime.
            // See https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/logs#logger-management
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(logging =>
                {
                    logging.AddAzureMonitorLogExporter();
                });
            });
            #endregion
        }
    }
}
