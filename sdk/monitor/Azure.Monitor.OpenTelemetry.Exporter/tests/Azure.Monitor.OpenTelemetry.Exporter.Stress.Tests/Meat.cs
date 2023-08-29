// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Taken from https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/test/OpenTelemetry.Tests.Stress
using System;
using System.Runtime.CompilerServices;
using OpenTelemetry.Trace;
using Azure.Core.TestFramework;
using System.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Stress.Tests;

public partial class Program
{
    private const string ActivitySourceName = "StressTest";
    private static ActivitySource s_activitySource = new ActivitySource(ActivitySourceName);
    private static AzureMonitorTraceExporter? s_azureMonitorTraceExporter;
    private static Batch<Activity> s_batch;
    private static readonly MockResponse s_response = new MockResponse(200, "OK");

    public static void Main()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", "InstrumentationKey=00000000-0000-0000-0000-000000000000");

        //TODO: Metrics and Logs
        InitTraces();

        Stress(concurrency: 1, prometheusPort: 9464);
    }

    private static void InitTraces()
    {
        // Set up SDK
        var options = new AzureMonitorExporterOptions();
        options.Transport = new MockTransport((_) => s_response);
        s_azureMonitorTraceExporter = new AzureMonitorTraceExporter(options);
        Sdk.CreateTracerProviderBuilder()
            .SetSampler(new AlwaysOnSampler())
            .AddSource(ActivitySourceName)
            .AddProcessor(new BatchActivityExportProcessor(s_azureMonitorTraceExporter))
            .Build();

        // Create Batch
        Activity[] activities = new Activity[2];
        using (var client = s_activitySource.StartActivity("Client", ActivityKind.Client))
        {
            client?.SetStatus(Status.Ok);
            client?.SetTag(SemanticConventions.AttributeHttpRequestMethod, "Get");
            client?.SetTag(SemanticConventions.AttributeUrlFull, "https://localhost:8080/api/123");
            client?.SetTag(SemanticConventions.AttributeNetworkProtocolVersion, "1.1");
            client?.SetTag(SemanticConventions.AttributeServerAddress, "localhost");
            client?.SetTag(SemanticConventions.AttributeServerPort, "8080");
            client?.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, 200);
            client?.SetTag(SemanticConventions.AttributeUserAgentOriginal, "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:72.0) Gecko/20100101 Firefox/72.0");

            using (var server = s_activitySource.StartActivity("Client", ActivityKind.Server))
            {
                server?.SetStatus(Status.Ok);
                server?.SetTag(SemanticConventions.AttributeHttpRequestMethod, "Get");
                server?.SetTag(SemanticConventions.AttributeUrlScheme, "https");
                server?.SetTag(SemanticConventions.AttributeUrlPath, "/api/123");
                server?.SetTag(SemanticConventions.AttributeMessagingProtocolVersion, "1.1");
                server?.SetTag(SemanticConventions.AttributeHttpRoute, "api/{searchId}");
                server?.SetTag(SemanticConventions.AttributeServerAddress, "localhost");
                server?.SetTag(SemanticConventions.AttributeServerPort, "8080");
                server?.SetTag(SemanticConventions.AttributeUserAgentOriginal, "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:72.0) Gecko/20100101 Firefox/72.0");
                server?.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, 200);

                activities[0] = server!;
            }

            activities[1] = client!;
        }

        s_batch = new Batch<Activity>(activities, 2);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected static void Run()
    {
        s_azureMonitorTraceExporter?.Export(s_batch);
    }
}
