// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using Azure.Monitor.OpenTelemetry.Exporter;

namespace Azure.AI.Projects.Tests
{
    public partial class Sample_Telemetry_FunctionTracer : SamplesBase<AIProjectsTestEnvironment>
    {
        #region Snippet:AI_Projects_TelemetrySyncFunctionExample
        // Simple sync function to trace
        public static string ProcessOrder(string orderId, int quantity, decimal price)
        {
            var total = quantity * price;
            return $"Order {orderId}: {quantity} items, Total: ${total:F2}";
        }
        #endregion

        #region Snippet:AI_Projects_TelemetryAsyncFunctionExample
        // Simple async function to trace
        public static async Task<string> ProcessOrderAsync(string orderId, int quantity, decimal price)
        {
            await Task.Delay(100); // Simulate async work
            var total = quantity * price;
            return $"Order {orderId}: {quantity} items, Total: ${total:F2}";
        }
        #endregion

        [Test]
        [AsyncOnly]
        public async Task TracingToConsoleExample()
        {
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                            .AddSource("Azure.AI.Projects.*") // Add the required sources name
                            .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("FunctionTracerSample"))
                            .AddConsoleExporter() // Export traces to the console
                            .Build();

            #region Snippet:AI_Projects_TelemetryTraceFunctionExampleAsync
            using (tracerProvider)
            {
                var asyncResult = await FunctionTracer.TraceAsync(() => ProcessOrderAsync("ORD-456", 3, 15.50m));
            }
            #endregion
        }

        [Test]
        [SyncOnly]
        public void TracingToConsoleExampleSync()
        {
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                            .AddSource("Azure.AI.Projects.*") // Add the required sources name
                            .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("AgentTracingSample"))
                            .AddConsoleExporter() // Export traces to the console
                            .Build();

            #region Snippet:AI_Projects_TelemetryTraceFunctionExampleSync
            using (tracerProvider)
            {
                var syncResult = FunctionTracer.Trace(() => ProcessOrder("ORD-123", 5, 29.99m));
            }
            #endregion
        }
    }
}
