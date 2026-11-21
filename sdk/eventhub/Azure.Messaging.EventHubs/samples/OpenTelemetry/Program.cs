// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

bool noProviders = args.Contains("--no-providers");
bool otlp = args.Contains("--otlp");
bool live = args.Contains("--live");
var endpoint = new Uri((Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT") ?? "http://localhost:4318").TrimEnd('/') + "/");
var resource = ResourceBuilder.CreateDefault().AddService("eventhubs-dotnet-example");

// Set the Azure SDK tracing switch before constructing clients or diagnostics providers.
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", !noProviders);

using var traces = noProviders ? null : CreateTracerProvider();
using var metrics = noProviders ? null : CreateMeterProvider();

using var loggerFactory = noProviders ? null : LoggerFactory.Create(builder => builder.AddOpenTelemetry(options =>
{
    options.SetResourceBuilder(resource);
    options.AddConsoleExporter();
    if (otlp)
    {
        options.AddOtlpExporter(exporter => ConfigureExporter(exporter, "logs"));
    }
}));
var logger = loggerFactory?.CreateLogger("Azure.Messaging.EventHubs.Lifecycle");

// Bridge the structured lifecycle record only. Other EventSource records can contain
// broker descriptions and should be reviewed before forwarding to an external service.
using var logs = noProviders ? null : new AzureEventSourceListener((record, _) =>
{
    if (record.EventSource.Name == "Azure-Messaging-EventHubs" && record.EventName == "AmqpLifecycle")
    {
        var payload = record.Payload!;
        logger!.LogInformation("AMQP lifecycle: {server_address} {eventhub} {client_id} {component} {generation} {outcome}",
            payload[0], payload[1], payload[2], payload[3], payload[4], payload[5]);
    }
}, EventLevel.Informational);

try
{
    var connectionString = live
        ? Environment.GetEnvironmentVariable("EVENTHUBS_CONNECTION_STRING") ?? throw new InvalidOperationException("Set EVENTHUBS_CONNECTION_STRING, including EntityPath, for --live.")
        : "Endpoint=sb://127.0.0.1;SharedAccessKeyName=sample;SharedAccessKey=c2FtcGxl;EntityPath=smoke";
    var options = new EventHubProducerClientOptions();
    if (!live)
    {
        // Port zero cannot host a service. The failure exercises real SDK instrumentation.
        options.ConnectionOptions.CustomEndpointAddress = new Uri("amqps://127.0.0.1:0");
        options.RetryOptions.MaximumRetries = 0;
        options.RetryOptions.TryTimeout = TimeSpan.FromSeconds(5);
    }
    await using var producer = new EventHubProducerClient(connectionString, options);
    try
    {
        await producer.SendAsync(new[] { new EventData("OpenTelemetry example") });
        if (!live)
        {
            throw new InvalidOperationException("The local connection unexpectedly succeeded.");
        }
    }
    catch (Exception exception) when (!live && (exception is EventHubsException || exception is System.Net.Sockets.SocketException))
    {
        Console.WriteLine("Expected local connection failure recorded.");
    }
}
finally
{
    // Flush on success and failure. Disposing the logging provider also flushes its exporter.
    traces?.ForceFlush();
    metrics?.ForceFlush();
}

void ConfigureExporter(OtlpExporterOptions options, string signal)
{
    options.Protocol = OtlpExportProtocol.HttpProtobuf;
    options.Endpoint = new Uri(endpoint, "v1/" + signal);
}

TracerProvider CreateTracerProvider()
{
    var builder = Sdk.CreateTracerProviderBuilder()
        .SetResourceBuilder(resource)
        .AddSource("Azure.Messaging.EventHubs.*")
        .AddConsoleExporter();
    if (otlp)
    {
        builder.AddOtlpExporter(options => ConfigureExporter(options, "traces"));
    }
    return builder.Build();
}

MeterProvider CreateMeterProvider()
{
    var builder = Sdk.CreateMeterProviderBuilder()
        .SetResourceBuilder(resource)
        .AddMeter("Azure.Messaging.EventHubs")
        .AddView("az.eventhubs.operation.duration", new ExplicitBucketHistogramConfiguration
        {
            Boundaries = new double[] { 0.005, 0.01, 0.025, 0.05, 0.1, 0.25, 0.5, 1, 2.5, 5, 10, 30, 60 }
        })
        .AddConsoleExporter();
    if (otlp)
    {
        builder.AddOtlpExporter(options => ConfigureExporter(options, "metrics"));
    }
    return builder.Build();
}
