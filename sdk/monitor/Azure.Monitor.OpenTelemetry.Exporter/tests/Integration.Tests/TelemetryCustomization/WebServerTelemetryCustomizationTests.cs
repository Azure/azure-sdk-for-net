// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TelemetryCustomization;

public class WebServerTelemetryCustomizationTests : WebApplicationTestsBase
{
    private const string TestServerPort = "9996";
    private const string TestServerTarget = $"localhost:{TestServerPort}";
    private const string TestServerUrl = $"http://{TestServerTarget}/";

    public WebServerTelemetryCustomizationTests(ITestOutputHelper output)
    : base(output)
    {}

#if !NET462
    [Fact]
    public async Task ActivityDisplayName_CanBeSetForRequests()
    {
        List<TelemetryItem>? telemetryItems = null;

        var builder = WebApplication.CreateBuilder();
        builder.Services.AddOpenTelemetry()
            .WithTracing(builder =>
            {
                builder.AddAspNetCoreInstrumentation()
                    .AddProcessor<FixupDisplayNameProcessor>()
                    .AddAzureMonitorTraceExporterForTest(out telemetryItems);
            });
        builder.Services.AddRouting();

        await using var app = builder.Build();
        app.UseRouting();
        app.Map("{**path}",
                context =>
                {
                    // Here I'm setting the Activity.DisplayName to something more useful for this specific route
                    // However, I have to store a value for use by FixupDisplayNameProcessor due to https://github.com/open-telemetry/opentelemetry-dotnet-contrib/issues/1948
                    var activity = context.Features.Get<IHttpActivityFeature>()?.Activity;
                    if (activity?.IsAllDataRequested == true)
                    {
                        var request = context.Request;
                        var spanName = $"{request.Method.ToUpperInvariant()} {request.Path}";
                        activity.AddTag(FixupDisplayNameProcessor.OverrideSpanNameTag, spanName);
                    }

                    context.Response.StatusCode = 200;
                    return Task.CompletedTask;
                });

        _ = app.RunAsync(TestServerUrl);

        // ACT
        using var httpClient = new HttpClient { BaseAddress = new Uri(TestServerUrl) };
        var res = await httpClient.GetAsync("/foo/bar");

        // SHUTDOWN
        var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
        tracerProvider.ForceFlush();
        tracerProvider.Shutdown();

        // ASSERT
        Assert.NotNull(telemetryItems);
        WaitForActivityExport(telemetryItems);

        // Assert
        Assert.True(telemetryItems.Any(), "test project did not capture telemetry");
        var telemetryItem = telemetryItems.Last()!;
        telemetryOutput.Write(telemetryItem);

        AssertRequestTelemetry(
            telemetryItem: telemetryItem,
            expectedResponseCode: "200",
            expectedUrl: TestServerUrl + "foo/bar");

        // BUG: Both of these Asserts fail, b/c the value for both is "GET {**path}",
        // even though Activity.DisplayName was set to "GET /foo/bar" before the telemetryItem was created
        Assert.Equal("GET /foo/bar", (telemetryItem.Data.BaseData as RequestData)!.Name);
        Assert.Equal("GET /foo/bar", telemetryItem.Tags["ai.operation.name"]);
    }
#endif

    private class FixupDisplayNameProcessor : BaseProcessor<Activity>
    {
        public const string OverrideSpanNameTag = "override.span.name";

        public override void OnEnd(Activity activity)
        {
            // Have to set Activity.DisplayName here instead of where I want to due to https://github.com/open-telemetry/opentelemetry-dotnet-contrib/issues/1948
            if (activity.IsAllDataRequested == true)
            {
                var overrideSpanName = activity.GetTagItem(OverrideSpanNameTag)?.ToString();
                if (overrideSpanName != null)
                {
                    activity.DisplayName = overrideSpanName;
                    activity.SetTag(OverrideSpanNameTag, null); // Delete the tag
                }
            }
        }
    }
}
