// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core.Internal;
using Azure.Core;
using Azure.Identity;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
[Category("Live")]
[NonParallelizable]
public class AzureSdkInstrumentationLiveTests
{
    private const string AzureSdkSpanName = "LogsQueryClient.QueryResource";
    private static readonly TimeSpan s_maxIngestionWait = TimeSpan.FromMinutes(6);
    private static readonly TimeSpan s_pollInterval = TimeSpan.FromSeconds(30);
    private static readonly Lazy<AgentServerTestEnvironment> s_lazyEnvironment =
        new(() => new AgentServerTestEnvironment());

    private static AgentServerTestEnvironment TestEnvironment => s_lazyEnvironment.Value;

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", null);
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER", null);
        Environment.SetEnvironmentVariable("OTEL_TRACES_SAMPLER_ARG", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public async Task AzureSdkDependencySpan_DisabledByDefault()
    {
        var scenario = await EmitAzureSdkScenarioAsync(enableAzureSdkInstrumentation: false);

        await AssertScenarioInApplicationInsightsAsync(scenario, expectAzureSdkSpan: false);
    }

    [Test]
    public async Task AzureSdkDependencySpan_EmittedWhenEnabled()
    {
        var scenario = await EmitAzureSdkScenarioAsync(enableAzureSdkInstrumentation: true);

        await AssertScenarioInApplicationInsightsAsync(scenario, expectAzureSdkSpan: true);
    }

    private static async Task<TraceScenario> EmitAzureSdkScenarioAsync(bool enableAzureSdkInstrumentation)
    {
        Environment.SetEnvironmentVariable(
            "APPLICATIONINSIGHTS_CONNECTION_STRING",
            TestEnvironment.ApplicationInsightsConnectionString);
        FoundryEnvironment.Reload();

        var controlSpanName = enableAzureSdkInstrumentation
            ? $"AzureSdkEnabledControl-{Guid.NewGuid():N}"
            : $"AzureSdkDisabledControl-{Guid.NewGuid():N}";
        var controlSourceName = $"AgentServer.Test.AzureSdk.{Guid.NewGuid():N}";
        using var controlSource = new ActivitySource(controlSourceName);

        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddAgentHostTelemetry(tracing =>
        {
            tracing.AddSource(controlSourceName);
            if (enableAzureSdkInstrumentation)
            {
                tracing.AddSource("Azure.*");
            }
        });

        using var host = builder.Build();
        await host.StartAsync();

        var credential = new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                ExcludeInteractiveBrowserCredential = true,
                TenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID"),
            });
        var logsClient = new LogsQueryClient(credential);
        var resourceId = new ResourceIdentifier(TestEnvironment.ApplicationInsightsResourceId);

        string traceId;
        string controlSpanId;
        using (var controlActivity = controlSource.StartActivity(controlSpanName, ActivityKind.Internal))
        {
            Assert.That(controlActivity, Is.Not.Null, "The control span should be sampled.");
            controlActivity!.SetTag("test.azure_sdk.enabled", enableAzureSdkInstrumentation);
            traceId = controlActivity!.TraceId.ToString();
            controlSpanId = controlActivity.SpanId.ToString();

            _ = await logsClient.QueryResourceAsync(
                resourceId,
                "print AgentServerAzureSdkInstrumentationTest=1",
                new LogsQueryTimeRange(TimeSpan.FromMinutes(5)));
        }

        await host.StopAsync();
        return new TraceScenario(traceId, controlSpanId, controlSpanName);
    }

    private static async Task AssertScenarioInApplicationInsightsAsync(
        TraceScenario scenario,
        bool expectAzureSdkSpan)
    {
        var credential = new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                ExcludeInteractiveBrowserCredential = true,
                TenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID"),
            });
        var logsClient = new LogsQueryClient(credential);
        var resourceId = new ResourceIdentifier(TestEnvironment.ApplicationInsightsResourceId);
        var deadline = DateTimeOffset.UtcNow + s_maxIngestionWait;
        var controlSpanSeen = false;

        string query = $@"
            union requests, dependencies
            | where operation_Id == '{scenario.TraceId}'
            | project name, id, operation_ParentId";

        while (DateTimeOffset.UtcNow < deadline)
        {
            await Task.Delay(s_pollInterval);
            var result = await logsClient.QueryResourceAsync(
                resourceId,
                query,
                new LogsQueryTimeRange(TimeSpan.FromMinutes(30)));
            var table = result.Value.Table;
            var nameIndex = table.Columns.ToList().FindIndex(column => column.Name == "name");
            var parentIndex = table.Columns.ToList().FindIndex(column => column.Name == "operation_ParentId");
            var controlRow = table.Rows.FirstOrDefault(
                row => row[nameIndex]?.ToString() == scenario.ControlSpanName);
            var azureSdkRow = table.Rows.FirstOrDefault(
                row => row[nameIndex]?.ToString() == AzureSdkSpanName);

            controlSpanSeen |= controlRow is not null;
            if (expectAzureSdkSpan && controlRow is not null && azureSdkRow is not null)
            {
                Assert.That(
                    azureSdkRow[parentIndex]?.ToString(),
                    Is.EqualTo(scenario.ControlSpanId),
                    $"{AzureSdkSpanName} should be a child of the control span.");
                return;
            }

            if (!expectAzureSdkSpan && azureSdkRow is not null)
            {
                Assert.Fail(
                    $"{AzureSdkSpanName} was emitted even though Azure SDK instrumentation was disabled.");
            }
        }

        Assert.That(
            controlSpanSeen,
            Is.True,
            $"Control span '{scenario.ControlSpanName}' was not ingested within " +
            $"{s_maxIngestionWait.TotalMinutes} minutes.");

        if (expectAzureSdkSpan)
        {
            Assert.Fail(
                $"{AzureSdkSpanName} was not ingested within {s_maxIngestionWait.TotalMinutes} minutes.");
        }
    }

    private sealed record TraceScenario(
        string TraceId,
        string ControlSpanId,
        string ControlSpanName);
}
