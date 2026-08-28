// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Azure.AI.AgentServer.Core.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenTelemetry;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
[NonParallelizable]
public class OpenTelemetryExtensionsTests
{
    private const string FakeConnectionString =
        "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://localhost";

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", null);
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", null);
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", null);
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void AgentHostTelemetry_HasDefaultSourceName()
    {
        Assert.That(AgentHostTelemetry.ResponsesSourceName, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void AgentHostTelemetry_HasDefaultMeterName()
    {
        Assert.That(AgentHostTelemetry.ResponsesMeterName, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void OtlpEndpointDetection_WhenSet_IsNotNull()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        var value = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT");
        Assert.That(value, Is.Not.Null);
    }

    [Test]
    public void AppInsightsDetection_WhenSet_IsNotNull()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", "InstrumentationKey=abc");
        var value = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        Assert.That(value, Is.Not.Null);
    }

    [Test]
    public void BothExporters_CanCoexist()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", "InstrumentationKey=abc");

        var otlp = Environment.GetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT");
        var appInsights = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        Assert.That(otlp, Is.Not.Null);
        Assert.That(appInsights, Is.Not.Null);
    }

    [Test]
    public void AzureMonitorSampling_DefaultsToAllTraces()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", FakeConnectionString);
        FoundryEnvironment.Reload();

        using var host = BuildHost();
        var options = host.Services.GetRequiredService<IOptions<AzureMonitorOptions>>().Value;

        Assert.That(options.SamplingRatio, Is.EqualTo(1.0F));
        Assert.That(options.TracesPerSecond, Is.Null);
    }

    [Test]
    public void AzureMonitorSampling_ExplicitRateLimitTakesPrecedence()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", FakeConnectionString);
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.rate_limited");
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "7");
        FoundryEnvironment.Reload();

        var options = new AzureMonitorOptions();
        OpenTelemetryExtensions.ConfigureAzureMonitorSampling(options);

        Assert.That(options.TracesPerSecond, Is.EqualTo(7));
    }

    [Test]
    public void AzureMonitorSampling_ExplicitFixedPercentageTakesPrecedence()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", FakeConnectionString);
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.fixed_percentage");
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", "0.25");
        FoundryEnvironment.Reload();

        var options = new AzureMonitorOptions();
        OpenTelemetryExtensions.ConfigureAzureMonitorSampling(options);

        Assert.That(options.SamplingRatio, Is.EqualTo(0.25F));
        Assert.That(options.TracesPerSecond, Is.Null);
    }

    [Test]
    public void AzureMonitorSampling_InvalidExplicitSamplerFallsBackToAllTraces()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", FakeConnectionString);
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", "microsoft.rate_limited");
        FoundryEnvironment.Reload();

        var options = new AzureMonitorOptions();
        OpenTelemetryExtensions.ConfigureAzureMonitorSampling(options);

        Assert.That(options.SamplingRatio, Is.EqualTo(1.0F));
        Assert.That(options.TracesPerSecond, Is.Null);
    }

    [Test]
    public void AzureMonitorSampling_WithoutApplicationInsights_PreservesDistroDefault()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        FoundryEnvironment.Reload();

        using var host = BuildHost();
        var options = host.Services.GetRequiredService<IOptions<AzureMonitorOptions>>().Value;

        Assert.That(options.TracesPerSecond, Is.EqualTo(5));
    }

    [Test]
    public void AzureSdkInstrumentation_DisabledByDefault()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        FoundryEnvironment.Reload();

        using var serviceProvider = BuildServiceProvider();
        _ = serviceProvider.GetRequiredService<TracerProvider>();
        using var azureSource = new ActivitySource("Azure.Core.Http");

        using var activity = azureSource.StartActivity("AzureSdkDependency");

        Assert.That(activity, Is.Null);
    }

    [Test]
    public void AzureSdkInstrumentation_CanBeEnabledWithConfigureTracing()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        FoundryEnvironment.Reload();

        using var serviceProvider = BuildServiceProvider(tracing => tracing.AddSource("Azure.*"));
        _ = serviceProvider.GetRequiredService<TracerProvider>();
        using var azureSource = new ActivitySource("Azure.Core.Http");

        using var activity = azureSource.StartActivity("AzureSdkDependency");

        Assert.That(activity, Is.Not.Null);
    }

    [Test]
    public async Task HttpClientInstrumentation_DisabledByDefault()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        FoundryEnvironment.Reload();
        var processor = new CapturingProcessor();

        using var serviceProvider = BuildServiceProvider(tracing => tracing.AddProcessor(processor));
        _ = serviceProvider.GetRequiredService<TracerProvider>();

        await SendLocalRequestAsync();

        Assert.That(
            processor.Activities,
            Has.None.Matches<Activity>(activity => activity.Source.Name == "System.Net.Http"));
    }

    [Test]
    public async Task HttpClientInstrumentation_CanBeEnabledWithConfigureTracing()
    {
        Environment.SetEnvironmentVariable("OTEL_EXPORTER_OTLP_ENDPOINT", "http://localhost:4317");
        FoundryEnvironment.Reload();
        var processor = new CapturingProcessor();

        using var serviceProvider = BuildServiceProvider(tracing =>
        {
            tracing.AddHttpClientInstrumentation();
            tracing.AddProcessor(processor);
        });
        _ = serviceProvider.GetRequiredService<TracerProvider>();

        await SendLocalRequestAsync();

        Assert.That(
            processor.Activities,
            Has.Some.Matches<Activity>(activity => activity.Source.Name == "System.Net.Http"));
    }

    private static ServiceProvider BuildServiceProvider(
        Action<TracerProviderBuilder>? configureTracing = null)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddAgentHostTelemetry(configureTracing);
        return services.BuildServiceProvider();
    }

    private static IHost BuildHost()
    {
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddAgentHostTelemetry();
        return builder.Build();
    }

    private static async Task SendLocalRequestAsync()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();

        try
        {
            var endpoint = (IPEndPoint)listener.LocalEndpoint;
            using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
            var responseTask = client.GetAsync($"http://127.0.0.1:{endpoint.Port}/");
            using var connection = await listener.AcceptTcpClientAsync();
            await using var stream = connection.GetStream();
            var requestBuffer = new byte[4096];
            _ = await stream.ReadAsync(requestBuffer);
            var responseBytes = Encoding.ASCII.GetBytes(
                "HTTP/1.1 200 OK\r\nContent-Length: 0\r\nConnection: close\r\n\r\n");
            await stream.WriteAsync(responseBytes);
            using var response = await responseTask;
            response.EnsureSuccessStatusCode();
        }
        finally
        {
            listener.Stop();
        }
    }

    private sealed class CapturingProcessor : BaseProcessor<Activity>
    {
        public ConcurrentQueue<Activity> Activities { get; } = new();

        public override void OnEnd(Activity data)
        {
            Activities.Enqueue(data);
        }
    }
}
