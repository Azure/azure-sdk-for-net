// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.Projects.Tests
{
    public partial class Sample_Telemetry_CustomAttributes : SamplesBase<AIProjectsTestEnvironment>
    {
        #region Snippet:AI_Projects_TelemetryCustomAttributeProcessor
        // Custom processor that adds attributes to spans
        public class CustomAttributeProcessor : BaseProcessor<Activity>
        {
            public override void OnStart(Activity activity)
            {
                // Add custom attributes to all spans
                activity.SetTag("custom.session_id", "session_123");

                // Add specific attributes based on span name
                if (activity.DisplayName == "GetWeather")
                {
                    activity.SetTag("custom.operation_type", "weather_query");
                    activity.SetTag("custom.priority", "normal");
                }

                base.OnStart(activity);
            }
        }
        #endregion

        public class WeatherService
        {
            private static readonly ActivitySource ActivitySource = new("SimpleTracingSample");

            public async Task<string> GetWeatherAsync(string location)
            {
                using var activity = ActivitySource.StartActivity("GetWeather");
                activity?.SetTag("weather.location", location);

                // Simulate some work
                await Task.Delay(100);

                var result = "It is sunny";
                activity?.SetTag("weather.result", result);

                return result;
            }

            public string GetWeather(string location)
            {
                using var activity = ActivitySource.StartActivity("GetWeather");
                activity?.SetTag("weather.location", location);

                var result = "It is sunny";
                activity?.SetTag("weather.result", result);

                return result;
            }
        }

        [Test]
        [AsyncOnly]
        public async Task TracingCustomAttributesExample()
        {
            #region Snippet:AI_Projects_TelemetryAddCustomAttributeProcessor
            // Setup tracing to console with custom processor
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("SimpleTracingSample")
                .SetResourceBuilder(ResourceBuilder.CreateDefault()
                    .AddService("WeatherApp", "1.0.0"))
                .AddProcessor(new CustomAttributeProcessor())
                .AddConsoleExporter()
                .Build();
            #endregion

            var weatherService = new WeatherService();

            Console.WriteLine("Calling async GetWeatherAsync...");
            var asyncResult = await weatherService.GetWeatherAsync("Portland");
            Console.WriteLine($"Result: {asyncResult}\n");

            // Cleanup
            tracerProvider?.Dispose();
        }

        [Test]
        [SyncOnly]
        public void TracingCustomAttributesExampleSync()
        {
            // Setup tracing to console with custom processor
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("SimpleTracingSample")
                .SetResourceBuilder(ResourceBuilder.CreateDefault()
                    .AddService("WeatherApp", "1.0.0"))
                .AddProcessor(new CustomAttributeProcessor())
                .AddConsoleExporter()
                .Build();

            var weatherService = new WeatherService();

            // Test sync version
            Console.WriteLine("Calling sync GetWeather...");
            var syncResult = weatherService.GetWeather("Seattle");
            Console.WriteLine($"Result: {syncResult}\n");

            // Cleanup
            tracerProvider?.Dispose();
            Console.WriteLine("Check console output above for spans with custom attributes!");
        }
    }
}
