// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.OpenTelemetry.Exporter.MultiEndpoint.ConsoleDemo;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using OpenTelemetry;
using OpenTelemetry.Resources;

const string HostConnectionStringVariable = "MULTIENDPOINT_HOST_CONNECTION_STRING";
const string RouteConnectionStringsVariable = "MULTIENDPOINT_ROUTE_CONNECTION_STRINGS";
const string ActivitySourceName = "MultiEndpoint.ConsoleDemo";
const string MeterName = "MultiEndpoint.ConsoleDemo";
const string InstrumentationKeyAttribute = "microsoft.instrumentation_key";
const string IngestionEndpointAttribute = "microsoft.ingestion_endpoint";
const string CloudRoleAttribute = "microsoft.multi_endpoint_cloud_role";

var hostConnectionString = Environment.GetEnvironmentVariable(HostConnectionStringVariable);
var routes = ParseRoutes(Environment.GetEnvironmentVariable(RouteConnectionStringsVariable));

if (string.IsNullOrWhiteSpace(hostConnectionString) || routes.Count == 0)
{
    Console.WriteLine($"Set {HostConnectionStringVariable} to the exporter's host connection string.");
    Console.WriteLine($"Set {RouteConnectionStringsVariable} to a comma-separated list of destination connection strings.");
    return;
}

var count = args.Length > 0 && int.TryParse(args[0], out var parsedCount) ? parsedCount : 30;
var runId = Guid.NewGuid().ToString("N");

AppContext.SetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiEndpointRouting", true);

using var activitySource = new ActivitySource(ActivitySourceName);
using var meter = new Meter(MeterName);
var requestCount = meter.CreateCounter<long>("demo.request.count");
var requestDuration = meter.CreateHistogram<double>("demo.request.duration", unit: "ms");

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.SetMinimumLevel(LogLevel.Information);
builder.Services
    .AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddAttributes(new Dictionary<string, object>
    {
        ["service.name"] = "multi-endpoint-console-demo",
        ["service.instance.id"] = Environment.MachineName,
        ["service.version"] = "1.0.0-demo",
    }))
    .UseAzureMonitorExporter(options =>
    {
        options.ConnectionString = hostConnectionString;
        options.EnableLiveMetrics = false;
        options.TracesPerSecond = null;
        options.SamplingRatio = 1.0F;
    })
    .WithTracing(tracing => tracing.AddSource(ActivitySourceName))
    .WithMetrics(metrics => metrics.AddMeter(MeterName));

using var host = builder.Build();
await host.StartAsync();

var logger = host.Services.GetRequiredService<ILoggerFactory>().CreateLogger("MultiEndpoint.ConsoleDemo");
var random = new Random(42);
var emittedPerRoute = routes.ToDictionary(route => route.Name, _ => 0, StringComparer.Ordinal);

Console.WriteLine($"Run id       : {runId}");
Console.WriteLine($"Iterations   : {count}");
Console.WriteLine($"Routes       : {string.Join(", ", routes.Select(route => route.Name))}");
Console.WriteLine("Signals      : traces, logs, metrics");
Console.WriteLine("Registration : UseAzureMonitorExporter");
Console.WriteLine();

for (var i = 0; i < count; i++)
{
    var route = routes[i % routes.Count];
    emittedPerRoute[route.Name]++;

    using (var request = activitySource.StartActivity($"MultiEndpointRequest-{i}", ActivityKind.Server))
    {
        AddRoute(request, route, runId, i);
        request?.SetStatus(ActivityStatusCode.Ok);

        using var dependency = activitySource.StartActivity($"MultiEndpointDependency-{i}", ActivityKind.Client);
        AddRoute(dependency, route, runId, i);
        dependency?.SetStatus(ActivityStatusCode.Ok);
    }

    LogWithRoute(logger, route, runId, i);

    var tags = CreateRouteTags(route, runId, i);
    requestCount.Add(1, tags);
    requestDuration.Record(random.Next(1, 500), tags);
}

foreach (var pair in emittedPerRoute)
{
    Console.WriteLine($"  {pair.Key,-12} {pair.Value} iteration(s)");
}

Console.WriteLine();
Console.WriteLine("Waiting 15 seconds for batch and metric export...");
await Task.Delay(TimeSpan.FromSeconds(15));
await host.StopAsync();

Console.WriteLine($"Done. Query each component for demo.run_id == '{runId}'.");

static void AddRoute(Activity? activity, EndpointRoute route, string runId, int iteration)
{
    activity?.SetTag(InstrumentationKeyAttribute, route.InstrumentationKey);
    activity?.SetTag(IngestionEndpointAttribute, route.IngestionEndpoint);
    activity?.SetTag(CloudRoleAttribute, route.Name);
    activity?.SetTag("demo.run_id", runId);
    activity?.SetTag("demo.route", route.Name);
    activity?.SetTag("demo.iteration", iteration);
}

static void LogWithRoute(ILogger logger, EndpointRoute route, string runId, int iteration)
{
    var attributes = new List<KeyValuePair<string, object?>>
    {
        new(InstrumentationKeyAttribute, route.InstrumentationKey),
        new(IngestionEndpointAttribute, route.IngestionEndpoint),
        new(CloudRoleAttribute, route.Name),
        new("demo.run_id", runId),
        new("demo.route", route.Name),
        new("demo.iteration", iteration),
    };

    logger.Log(
        LogLevel.Information,
        new EventId(iteration),
        attributes,
        exception: null,
        (_, _) => $"Multi-endpoint console log {iteration}");
}

static TagList CreateRouteTags(EndpointRoute route, string runId, int iteration)
{
    return new TagList
    {
        { InstrumentationKeyAttribute, route.InstrumentationKey },
        { IngestionEndpointAttribute, route.IngestionEndpoint },
        { CloudRoleAttribute, route.Name },
        { "demo.run_id", runId },
        { "demo.route", route.Name },
        { "demo.iteration", iteration },
    };
}

static List<EndpointRoute> ParseRoutes(string? connectionStrings)
{
    var routes = new List<EndpointRoute>();

    if (string.IsNullOrWhiteSpace(connectionStrings))
    {
        return routes;
    }

    foreach (var connectionString in connectionStrings!.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
    {
        string? instrumentationKey = null;
        string? ingestionEndpoint = null;

        foreach (var part in connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var separator = part.IndexOf('=');
            if (separator < 0)
            {
                continue;
            }

            var key = part.Substring(0, separator).Trim();
            var value = part.Substring(separator + 1).Trim();

            if (string.Equals(key, "InstrumentationKey", StringComparison.OrdinalIgnoreCase))
            {
                instrumentationKey = value;
            }
            else if (string.Equals(key, "IngestionEndpoint", StringComparison.OrdinalIgnoreCase))
            {
                ingestionEndpoint = value;
            }
        }

        if (!string.IsNullOrWhiteSpace(instrumentationKey) && !string.IsNullOrWhiteSpace(ingestionEndpoint))
        {
            routes.Add(new EndpointRoute($"route{routes.Count + 1}", instrumentationKey!, ingestionEndpoint!));
        }
    }

    return routes;
}
