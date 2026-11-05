// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;

using Azure.Monitor.OpenTelemetry.AspNetCore;
using Azure.Monitor.OpenTelemetry.AspNetCore.MultiEndpoint.Demo;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using OpenTelemetry.Resources;

const string HostConnectionStringVariable = "MULTIENDPOINT_HOST_CONNECTION_STRING";
const string RouteConnectionStringsVariable = "MULTIENDPOINT_ROUTE_CONNECTION_STRINGS";
const string DemoUrlVariable = "MULTIENDPOINT_DEMO_URL";
const string ActivitySourceName = "MultiEndpoint.AspNetCoreDemo";
const string MeterName = "MultiEndpoint.AspNetCoreDemo";
const string InstrumentationKeyAttribute = "microsoft.instrumentation_key";
const string IngestionEndpointAttribute = "microsoft.ingestion_endpoint";
const string CloudRoleAttribute = "microsoft.multi_endpoint_cloud_role";

var hostConnectionString = Environment.GetEnvironmentVariable(HostConnectionStringVariable);
var routes = ParseRoutes(Environment.GetEnvironmentVariable(RouteConnectionStringsVariable));

if (string.IsNullOrWhiteSpace(hostConnectionString) || routes.Count == 0)
{
    Console.WriteLine($"Set {HostConnectionStringVariable} to the distro's host connection string.");
    Console.WriteLine($"Set {RouteConnectionStringsVariable} to a comma-separated list of destination connection strings.");
    return;
}

AppContext.SetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiEndpointRouting", true);

using var activitySource = new ActivitySource(ActivitySourceName);
using var meter = new Meter(MeterName);
var requestCount = meter.CreateCounter<long>("demo.request.count");
var requestDuration = meter.CreateHistogram<double>("demo.request.duration", unit: "ms");
var random = new Random(42);

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls(Environment.GetEnvironmentVariable(DemoUrlVariable) ?? "http://127.0.0.1:5058");
builder.Services
    .AddOpenTelemetry()
    .UseAzureMonitor(options =>
    {
        options.ConnectionString = hostConnectionString;
        options.EnableLiveMetrics = false;
        options.TracesPerSecond = null;
        options.SamplingRatio = 1.0F;
    })
    .WithTracing(tracing => tracing.AddSource(ActivitySourceName))
    .WithMetrics(metrics => metrics.AddMeter(MeterName))
    .ConfigureResource(resource => resource.AddAttributes(new Dictionary<string, object>
    {
        ["service.name"] = "multi-endpoint-aspnetcore-demo",
        ["service.instance.id"] = Environment.MachineName,
        ["service.version"] = "1.0.0-demo",
    }));

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    message = "Call /emit/{route}?count=2 to emit a routed request span, child spans, logs, and metrics.",
    routes = routes.Select(route => route.Name),
}));

app.MapGet("/emit/{routeName}", (string routeName, int? count, ILoggerFactory loggerFactory) =>
{
    var route = routes.FirstOrDefault(candidate => string.Equals(candidate.Name, routeName, StringComparison.OrdinalIgnoreCase));
    if (route == null)
    {
        return Results.NotFound(new { message = $"Unknown route '{routeName}'.", routes = routes.Select(candidate => candidate.Name) });
    }

    var emissionCount = Math.Max(1, count ?? 1);
    var runId = Guid.NewGuid().ToString("N");
    var logger = loggerFactory.CreateLogger("MultiEndpoint.AspNetCoreDemo");

    AddRoute(Activity.Current, route, runId, iteration: 0);

    for (var i = 0; i < emissionCount; i++)
    {
        using (var dependency = activitySource.StartActivity($"MultiEndpointDependency-{i}", ActivityKind.Client))
        {
            AddRoute(dependency, route, runId, i);
            dependency?.SetStatus(ActivityStatusCode.Ok);
        }

        LogWithRoute(logger, route, runId, i);

        var tags = CreateRouteTags(route, runId, i);
        requestCount.Add(1, tags);
        requestDuration.Record(random.Next(1, 500), tags);
    }

    return Results.Ok(new
    {
        runId,
        route = route.Name,
        emitted = new
        {
            requestSpans = 1,
            dependencySpans = emissionCount,
            logs = emissionCount,
            metricMeasurements = emissionCount * 2,
        },
    });
});

await app.RunAsync();

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
        (_, _) => $"Multi-endpoint ASP.NET Core log {iteration}");
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
#endif
