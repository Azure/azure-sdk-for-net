// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using Azure.AI.AgentServer.Core.Internal;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

[TestFixture]
[NonParallelizable]
public class VoiceConnectionTracingRedTests
{
    private const string InvocationsSourceName = "Azure.AI.AgentServer.Invocations";
    private const string CallbackOperationName = "voice.callback";
    private const string ConnectionOperationName = "agentserver.connection";
    private const string TargetTurnCustomerSourceName = "VoiceConnectionTracingRedTests.Customer";
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan ObservationTimeout = TimeSpan.FromSeconds(1);

    [Test]
    public async Task VoiceWebSocket_ExportsSemanticConnectionWithoutGenericRequest_AndPreservesRemoteParent()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();
        const string traceState = "vendor=value";

        await ConnectAndCloseAsync(server.WebSocketUri, traceId, parentSpanId, traceState);
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        var connection = activities.SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(connection, Is.Not.Null, "Voice must export one semantic connection span.");
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False,
                "Voice must suppress the generic ASP.NET GET /invocations_ws span.");
            Assert.That(connection?.TraceId, Is.EqualTo(traceId));
            Assert.That(connection?.ParentSpanId, Is.EqualTo(parentSpanId));
            Assert.That(connection?.ActivityTraceFlags, Is.EqualTo(ActivityTraceFlags.Recorded));
            Assert.That(connection?.TraceStateString, Is.EqualTo(traceState));
            Assert.That(connection?.Kind, Is.EqualTo(ActivityKind.Server));
        });
    }

    [Test]
    public async Task VoiceTargetTurn_ExportsConnectionTargetAndCustomerTree()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<TargetTurnVoiceHandler>(exporter);
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();

        await ConnectSendAndCloseAsync(
            server.WebSocketUri,
            SessionStartPayload,
            traceId,
            parentSpanId);
        var connectionObserved = await exporter.TryWaitForAsync(IsSemanticConnection, ObservationTimeout);
        var callbackObserved = await exporter.TryWaitForAsync(IsCallbackDispatch, ObservationTimeout);
        var targetObserved = await exporter.TryWaitForAsync(IsTargetTurn, ObservationTimeout);
        var customerObserved = await exporter.TryWaitForAsync(IsTargetCustomerSpan, ObservationTimeout);

        var activities = exporter.GetFinishedActivities();
        var connection = activities.SingleOrDefault(IsSemanticConnection);
        var callback = activities.SingleOrDefault(IsCallbackDispatch);
        var target = activities.SingleOrDefault(IsTargetTurn);
        var customer = activities.SingleOrDefault(IsTargetCustomerSpan);
        Assert.Multiple(() =>
        {
            Assert.That(connectionObserved, Is.True);
            Assert.That(callbackObserved, Is.True);
            Assert.That(targetObserved, Is.True);
            Assert.That(customerObserved, Is.True);
            Assert.That(connection?.TraceId, Is.EqualTo(traceId));
            Assert.That(connection?.ParentSpanId, Is.EqualTo(parentSpanId));
            Assert.That(callback?.TraceId, Is.EqualTo(traceId));
            Assert.That(callback?.ParentSpanId, Is.EqualTo(connection?.SpanId));
            Assert.That(callback?.GetTagItem("voice.event.type"), Is.EqualTo("session.start"));
            Assert.That(target?.TraceId, Is.EqualTo(traceId));
            Assert.That(target?.ParentSpanId, Is.EqualTo(connection?.SpanId));
            Assert.That(customer?.TraceId, Is.EqualTo(traceId));
            Assert.That(customer?.ParentSpanId, Is.EqualTo(target?.SpanId));
            Assert.That(target?.GetTagItem("bridge.outcome"), Is.EqualTo("none"));
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [Test]
    public async Task DirectCallbackSpan_ExportsThroughDedicatedCallbackParent()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<DirectCallbackSpanVoiceHandler>(exporter);
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();

        await ConnectSendAndCloseAsync(
            server.WebSocketUri,
            SessionStartPayload,
            traceId,
            parentSpanId);
        var connectionObserved = await exporter.TryWaitForAsync(IsSemanticConnection, ObservationTimeout);
        var callbackObserved = await exporter.TryWaitForAsync(IsCallbackDispatch, ObservationTimeout);
        var customerObserved = await exporter.TryWaitForAsync(
            IsDirectCallbackCustomerSpan,
            ObservationTimeout);

        var activities = exporter.GetFinishedActivities();
        var connection = activities.SingleOrDefault(IsSemanticConnection);
        var callback = activities.SingleOrDefault(IsCallbackDispatch);
        var customer = activities.SingleOrDefault(IsDirectCallbackCustomerSpan);
        Assert.Multiple(() =>
        {
            Assert.That(connectionObserved, Is.True);
            Assert.That(callbackObserved, Is.True,
                "Voice must export a dedicated parent for spans created directly in callbacks.");
            Assert.That(customerObserved, Is.True);
            Assert.That(callback?.TraceId, Is.EqualTo(traceId));
            Assert.That(callback?.ParentSpanId, Is.EqualTo(connection?.SpanId));
            Assert.That(callback?.GetTagItem("voice.event.type"), Is.EqualTo("session.start"));
            Assert.That(
                callback?.GetTagItem("microsoft.session.id"),
                Is.EqualTo(callback?.GetBaggageItem("azure.ai.agentserver.session_id")));
            Assert.That(callback?.TagObjects.Select(tag => tag.Key),
                Is.EquivalentTo(new[] { "voice.event.type", "microsoft.session.id" }));
            Assert.That(customer?.TraceId, Is.EqualTo(traceId));
            Assert.That(customer?.ParentSpanId, Is.EqualTo(callback?.SpanId));
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [Test]
    public async Task AsyncAndBackgroundCallbackSpans_RetainExportedCallbackParent()
    {
        AsyncCallbackSpanVoiceHandler.Reset();
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<AsyncCallbackSpanVoiceHandler>(exporter);

        await ConnectSendAndCloseAsync(server.WebSocketUri, SessionStartPayload);
        await AsyncCallbackSpanVoiceHandler.BackgroundCompleted.Task.WaitAsync(TestTimeout);
        var callbackObserved = await exporter.TryWaitForAsync(IsCallbackDispatch, ObservationTimeout);
        var asyncObserved = await exporter.TryWaitForAsync(
            activity => activity.OperationName == "customer.callback.async",
            ObservationTimeout);
        var backgroundObserved = await exporter.TryWaitForAsync(
            activity => activity.OperationName == "customer.callback.background",
            ObservationTimeout);

        var activities = exporter.GetFinishedActivities();
        var callback = activities.SingleOrDefault(IsCallbackDispatch);
        var asyncCustomer = activities.SingleOrDefault(
            activity => activity.OperationName == "customer.callback.async");
        var backgroundCustomer = activities.SingleOrDefault(
            activity => activity.OperationName == "customer.callback.background");
        Assert.Multiple(() =>
        {
            Assert.That(callbackObserved, Is.True);
            Assert.That(asyncObserved, Is.True);
            Assert.That(backgroundObserved, Is.True);
            Assert.That(callback?.Duration, Is.Not.EqualTo(default(TimeSpan)));
            Assert.That(asyncCustomer?.ParentSpanId, Is.EqualTo(callback?.SpanId));
            Assert.That(backgroundCustomer?.ParentSpanId, Is.EqualTo(callback?.SpanId));
        });
    }

    [Test]
    public async Task RawWebSocket_KeepsGenericAspNetCoreRequest()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartRawServerAsync(exporter);

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom());
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        Assert.Multiple(() =>
        {
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.True,
                "Raw WebSocket hosts must retain their existing ASP.NET request span.");
            Assert.That(activities.Any(IsSemanticConnection), Is.False,
                "Raw WebSocket hosts must not emit the Voice semantic connection span.");
        });
    }

    [Test]
    public async Task RawWebSocket_CloseEventRetainsAspNetTraceAndCorrelationBaggage()
    {
        var exporter = new CapturingActivityExporter();
        var logs = new AmbientBaggageCapturingLoggerProvider();
        await using var server = await StartRawServerAsync(exporter, loggerProvider: logs);
        var traceId = ActivityTraceId.CreateRandom();

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            traceId,
            ActivitySpanId.CreateRandom());

        Assert.Multiple(() =>
        {
            Assert.That(logs.CloseEventTraceIds, Does.Contain(traceId));
            Assert.That(
                logs.CloseEventBaggageKeys,
                Does.Contain("azure.ai.agentserver.session_id"));
            Assert.That(
                logs.CloseEventBaggageKeys,
                Does.Contain("azure.ai.agentserver.invocation_id"));
        });
    }

    [Test]
    public async Task RawWebSocket_AcceptCancellationRetainsExistingFailureTelemetry()
    {
        using var requestCancellation = new CancellationTokenSource();
        await requestCancellation.CancelAsync();
        var acceptCancellation = new OperationCanceledException(requestCancellation.Token);
        var featureDecorator = new AcceptFailureFeatureDecorator(acceptCancellation);
        var exporter = new CapturingActivityExporter();
        var logs = new AmbientBaggageCapturingLoggerProvider();
        await using var server = await StartRawServerAsync(
            exporter,
            decorateWebSocketFeature: featureDecorator.Decorate,
            requestAborted: requestCancellation.Token,
            loggerProvider: logs);

        _ = await ConnectAndCaptureFailureAsync(server.WebSocketUri);

        Assert.Multiple(() =>
        {
            Assert.That(logs.CloseCodes, Does.Contain(1011));
            Assert.That(logs.ErrorCodes, Does.Contain("accept_failed"));
            Assert.That(logs.DiagnosticExceptions, Does.Contain(acceptCancellation));
        });
    }

    [Test]
    public async Task RawWebSocket_AcceptFailureScopeDisposeFailurePreservesPrimaryException()
    {
        var acceptFailure = new InvalidOperationException("injected raw accept failure");
        var featureDecorator = new AcceptFailureFeatureDecorator(acceptFailure);
        var logger = new ThrowOnceLoggerProvider(scopeFailureTarget: ScopeFailureTarget.Dispose);
        var escapedException = new TaskCompletionSource<Exception>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var exporter = new CapturingActivityExporter();
        await using var server = await StartRawServerAsync(
            exporter,
            decorateWebSocketFeature: featureDecorator.Decorate,
            loggerProvider: logger,
            configureApplication: app => app.Use(async (_, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception exception)
                {
                    escapedException.TrySetResult(exception);
                    throw;
                }
            }));

        _ = await ConnectAndCaptureFailureAsync(server.WebSocketUri);
        var escaped = await escapedException.Task.WaitAsync(TestTimeout);
        var retryCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);

        Assert.Multiple(() =>
        {
            Assert.That(escaped, Is.SameAs(acceptFailure));
            Assert.That(logger.FailureCount, Is.EqualTo(1));
            Assert.That(featureDecorator.AttemptCount, Is.EqualTo(2));
            Assert.That(retryCloseCode, Is.EqualTo(1000));
        });
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task VoiceFilter_ComposesApplicationFilter_IndependentOfRegistrationOrder(
        bool configureBeforeVoice)
    {
        var exporter = new CapturingActivityExporter();
        var applicationFilterCalls = 0;
        await using var server = await StartVoiceServerAsync(
            exporter,
            configureServicesBeforeVoice: services =>
            {
                if (configureBeforeVoice)
                {
                    services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
                        options.Filter = _ =>
                        {
                            Interlocked.Increment(ref applicationFilterCalls);
                            return true;
                        });
                }
            },
            configureServicesAfterVoice: services =>
            {
                if (!configureBeforeVoice)
                {
                    services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
                        options.Filter = _ =>
                        {
                            Interlocked.Increment(ref applicationFilterCalls);
                            return true;
                        });
                }
            });

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom());
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        Assert.Multiple(() =>
        {
            Assert.That(applicationFilterCalls, Is.EqualTo(1),
                "Voice filtering must evaluate the application filter exactly once.");
            Assert.That(activities.Any(IsSemanticConnection), Is.True);
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [Test]
    public async Task VoiceWebSocket_WithRoutePrefix_SuppressesGenericRequest()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter, prefix: "/v1");

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom());
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        Assert.Multiple(() =>
        {
            Assert.That(activities.Any(IsSemanticConnection), Is.True);
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [TestCase("v1", "/v1/invocations_ws")]
    [TestCase("/tenants/{tenantId}", "/tenants/contoso/invocations_ws")]
    [TestCase(null, "/invocations_ws/")]
    public async Task VoiceWebSocket_WithEquivalentRoute_SuppressesGenericRequest(
        string? prefix,
        string requestPath)
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            prefix: prefix,
            requestPath: requestPath);

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom());
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        Assert.Multiple(() =>
        {
            Assert.That(activities.Count(IsSemanticConnection), Is.EqualTo(1));
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [Test]
    public async Task VoiceRoute_WithRepeatedTrailingSlash_KeepsGenericRequestSpan()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var invalidUri = new Uri(server.WebSocketUri, "/invocations_ws//");

        _ = await ConnectAndCaptureFailureAsync(invalidUri);
        var observed = await exporter.TryWaitForAsync(
            activity => activity.Source.Name == "Microsoft.AspNetCore",
            ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(observed, Is.True);
            Assert.That(exporter.GetFinishedActivities().Any(IsSemanticConnection), Is.False);
        });
    }

    [Test]
    public async Task VoiceWebSocket_WithPathBase_SuppressesGenericRequest()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            requestPath: "/base/invocations_ws",
            pathBase: "/base");

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom());
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        Assert.Multiple(() =>
        {
            Assert.That(activities.Count(IsSemanticConnection), Is.EqualTo(1));
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [Test]
    public async Task VoiceWebSocket_OverHttp2_SuppressesGenericRequest()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            serverProtocols: HttpProtocols.Http2);

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom(),
            httpVersion: HttpVersion.Version20);
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        Assert.Multiple(() =>
        {
            Assert.That(activities.Count(IsSemanticConnection), Is.EqualTo(1));
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [Test]
    public async Task RawWebSocket_OverHttp2_KeepsGenericAspNetCoreRequest()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartRawServerAsync(
            exporter,
            serverProtocols: HttpProtocols.Http2);

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            httpVersion: HttpVersion.Version20);
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        Assert.Multiple(() =>
        {
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.True);
            Assert.That(activities.Any(IsSemanticConnection), Is.False);
        });
    }

    [Test]
    public async Task VoiceRoute_WithoutWebSocketUpgrade_KeepsGenericBadRequestSpan()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        using var client = new HttpClient();

        using var response = await client.GetAsync(server.HttpUri).WaitAsync(TestTimeout);
        await exporter.WaitForExportAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(exporter.GetFinishedActivities().Any(IsGenericWebSocketRequest), Is.True,
                "Only an admitted Voice WebSocket connection may replace the generic request span.");
        });
    }

    [Test]
    public async Task VoiceRoute_WithIncompleteUpgradeHeaders_KeepsGenericBadRequestSpan()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, server.HttpUri);
        request.Headers.Connection.Add("Upgrade");
        request.Headers.TryAddWithoutValidation("Upgrade", "websocket");
        request.Headers.TryAddWithoutValidation(
            "Sec-WebSocket-Key",
            Convert.ToBase64String(new byte[16]));

        using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
        var observed = await exporter.TryWaitForAsync(IsGenericWebSocketRequest, ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(observed, Is.True,
                "A malformed handshake rejected before Voice admission must retain the ASP.NET request span.");
            Assert.That(exporter.GetFinishedActivities().Any(IsSemanticConnection), Is.False);
        });
    }

    [Test]
    public async Task VoiceRoute_WithInvalidWebSocketKey_KeepsGenericBadRequestSpan()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        using var client = new HttpClient();
        using var request = CreateWebSocketCandidateRequest(server.HttpUri, "not-valid-base64");

        using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
        var observed = await exporter.TryWaitForAsync(IsGenericWebSocketRequest, ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(observed, Is.True,
                "A request rejected before WebSocket admission must retain the generic ASP.NET span.");
            Assert.That(exporter.GetFinishedActivities().Any(IsSemanticConnection), Is.False);
        });
    }

    [TestCase(null)]
    [TestCase("not-a-valid-traceparent")]
    public async Task MiddlewareRejection_WithoutValidTraceparent_CreatesTrueRootSpan(
        string? traceparent)
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            configureApplication: app => app.Run(context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            }));
        using var client = new HttpClient();
        using var request = CreateWebSocketCandidateRequest(
            server.HttpUri,
            Convert.ToBase64String(new byte[16]));
        if (traceparent is not null)
        {
            request.Headers.TryAddWithoutValidation("traceparent", traceparent);
        }

        using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
        var observed = await exporter.TryWaitForAsync(
            activity => activity.Source.Name == InvocationsSourceName &&
                activity.OperationName == "GET /invocations_ws",
            ObservationTimeout);
        var rejection = exporter.GetFinishedActivities().SingleOrDefault(activity =>
            activity.Source.Name == InvocationsSourceName &&
            activity.OperationName == "GET /invocations_ws");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(observed, Is.True);
            Assert.That(rejection, Is.Not.Null);
            Assert.That(rejection?.ParentSpanId, Is.EqualTo(default(ActivitySpanId)),
                "A rejection without a valid parent must not inherit the suppressed ASP.NET request Activity.");
        });
    }

    [Test]
    public async Task MiddlewareRejection_ActivityStartedFailure_StopsActivityAndNextRequestSucceeds()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            configureApplication: app => app.Run(context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return Task.CompletedTask;
            }));
        Activity? failedActivity = null;
        using var listener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity =>
            {
                if (activity.OperationName == "GET /invocations_ws" && failedActivity is null)
                {
                    failedActivity = activity;
                    Activity.Current = null;
                    throw new InvalidOperationException("injected rejection ActivityStarted failure");
                }
            },
        };
        ActivitySource.AddActivityListener(listener);
        using var client = new HttpClient();
        var firstTraceId = ActivityTraceId.CreateRandom();
        var secondTraceId = ActivityTraceId.CreateRandom();

        using (var firstRequest = CreateWebSocketCandidateRequest(
            server.HttpUri,
            Convert.ToBase64String(new byte[16])))
        {
            firstRequest.Headers.TryAddWithoutValidation(
                "traceparent",
                $"00-{firstTraceId}-{ActivitySpanId.CreateRandom()}-01");
            using var firstResponse = await client.SendAsync(firstRequest).WaitAsync(TestTimeout);
            Assert.That(firstResponse.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
        }

        using (var secondRequest = CreateWebSocketCandidateRequest(
            server.HttpUri,
            Convert.ToBase64String(new byte[16])))
        {
            secondRequest.Headers.TryAddWithoutValidation(
                "traceparent",
                $"00-{secondTraceId}-{ActivitySpanId.CreateRandom()}-01");
            using var secondResponse = await client.SendAsync(secondRequest).WaitAsync(TestTimeout);
            Assert.That(secondResponse.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
        }
        var secondObserved = await exporter.TryWaitForAsync(
            activity => IsRejectedVoiceRequest(activity, secondTraceId),
            ObservationTimeout);
        var rejections = exporter.GetFinishedActivities()
            .Where(activity =>
                activity.Source.Name == InvocationsSourceName &&
                activity.OperationName == "GET /invocations_ws")
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(failedActivity, Is.Not.Null);
            Assert.That(failedActivity?.Duration, Is.Not.EqualTo(default(TimeSpan)),
                "A listener failure must not abandon an already-started rejection Activity.");
            Assert.That(secondObserved, Is.True,
                "A listener failure must not pollute the following rejection request.");
            Assert.That(rejections, Has.Length.EqualTo(2));
            Assert.That(rejections.Select(activity => activity.TraceId),
                Is.EquivalentTo(new[] { firstTraceId, secondTraceId }));
        });
    }

    [Test]
    public async Task MiddlewareRejection_SampleFailureDoesNotAdoptSameNameForeignActivity()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            configureApplication: app => app.Run(context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Task.CompletedTask;
            }));
        using var foreignSource = new ActivitySource(InvocationsSourceName);
        Activity? foreignActivity = null;
        var failureCount = 0;
        using var listener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
            {
                if (options.Name == "GET /invocations_ws" &&
                    Interlocked.CompareExchange(ref failureCount, 1, 0) == 0)
                {
                    var previous = Activity.Current;
                    foreignActivity = foreignSource.StartActivity(options.Name);
                    Activity.Current = previous;
                    throw new InvalidOperationException("injected rejection Sample failure");
                }
                return ActivitySamplingResult.AllDataAndRecorded;
            },
        };
        ActivitySource.AddActivityListener(listener);
        using var client = new HttpClient();
        var firstTraceId = ActivityTraceId.CreateRandom();
        var secondTraceId = ActivityTraceId.CreateRandom();

        using (var firstRequest = CreateWebSocketCandidateRequest(
            server.HttpUri,
            Convert.ToBase64String(new byte[16])))
        {
            firstRequest.Headers.TryAddWithoutValidation(
                "traceparent",
                $"00-{firstTraceId}-{ActivitySpanId.CreateRandom()}-01");
            using var firstResponse = await client.SendAsync(firstRequest).WaitAsync(TestTimeout);
            Assert.That(firstResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        using (var secondRequest = CreateWebSocketCandidateRequest(
            server.HttpUri,
            Convert.ToBase64String(new byte[16])))
        {
            secondRequest.Headers.TryAddWithoutValidation(
                "traceparent",
                $"00-{secondTraceId}-{ActivitySpanId.CreateRandom()}-01");
            using var secondResponse = await client.SendAsync(secondRequest).WaitAsync(TestTimeout);
            Assert.That(secondResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
        var retryObserved = await exporter.TryWaitForAsync(
            activity => IsRejectedVoiceRequest(activity, secondTraceId),
            ObservationTimeout);
        var foreignStatusAfterFailure = foreignActivity?.Status;
        var foreignErrorAfterFailure = foreignActivity?.GetTagItem("error.type");

        Assert.Multiple(() =>
        {
            Assert.That(failureCount, Is.EqualTo(1));
            Assert.That(foreignActivity, Is.Not.Null);
            Assert.That(foreignActivity?.Source, Is.SameAs(foreignSource));
            Assert.That(foreignStatusAfterFailure, Is.EqualTo(ActivityStatusCode.Unset));
            Assert.That(foreignErrorAfterFailure, Is.Null);
            Assert.That(retryObserved, Is.True);
        });
    }

    [TestCase(StatusCodes.Status401Unauthorized, ActivityStatusCode.Unset, null)]
    [TestCase(StatusCodes.Status403Forbidden, ActivityStatusCode.Unset, null)]
    [TestCase(StatusCodes.Status429TooManyRequests, ActivityStatusCode.Unset, null)]
    [TestCase(StatusCodes.Status500InternalServerError, ActivityStatusCode.Error, "500")]
    public async Task MiddlewareRejection_ExportsParentedRequestSpan_AndNextConnectionSucceeds(
        int rejectionStatusCode,
        ActivityStatusCode expectedActivityStatus,
        string? expectedErrorType)
    {
        var rejectNextRequest = 1;
        var exporter = new CapturingActivityExporter();
        int actualRejectionStatusCode;
        bool rejectionObserved;
        int? closeCode;
        bool connectionObserved;
        var rejectedTraceId = ActivityTraceId.CreateRandom();
        var rejectedParentSpanId = ActivitySpanId.CreateRandom();
        const string rejectedTraceState = "vendor=value";
        var successfulTraceId = ActivityTraceId.CreateRandom();
        var successfulParentSpanId = ActivitySpanId.CreateRandom();
        await using (var server = await StartVoiceServerAsync(
            exporter,
            configureApplication: app => app.Use(async (context, next) =>
            {
                if (Interlocked.Exchange(ref rejectNextRequest, 0) == 1)
                {
                    context.Response.StatusCode = rejectionStatusCode;
                    return;
                }
                await next();
            })))
        {
            using var client = new HttpClient();
            using var request = CreateWebSocketCandidateRequest(
                server.HttpUri,
                Convert.ToBase64String(new byte[16]));
            request.Headers.TryAddWithoutValidation(
                "traceparent",
                $"00-{rejectedTraceId}-{rejectedParentSpanId}-01");
            request.Headers.TryAddWithoutValidation("tracestate", rejectedTraceState);

            using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
            actualRejectionStatusCode = (int)response.StatusCode;
            rejectionObserved = await exporter.TryWaitForAsync(
                activity => IsRejectedVoiceRequest(activity, rejectedTraceId),
                ObservationTimeout);

            closeCode = await ConnectAndCloseAsync(
                server.WebSocketUri,
                successfulTraceId,
                successfulParentSpanId);
            connectionObserved = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);
        }
        var activities = exporter.GetFinishedActivities();
        var rejection = activities.SingleOrDefault(
            activity => IsRejectedVoiceRequest(activity, rejectedTraceId));

        Assert.Multiple(() =>
        {
            Assert.That(actualRejectionStatusCode, Is.EqualTo(rejectionStatusCode));
            Assert.That(rejectionObserved, Is.True,
                "A middleware rejection must retain an exported request trace.");
            Assert.That(rejection?.ParentSpanId, Is.EqualTo(rejectedParentSpanId));
            Assert.That(rejection?.Kind, Is.EqualTo(ActivityKind.Server));
            Assert.That(rejection?.ActivityTraceFlags, Is.EqualTo(ActivityTraceFlags.Recorded));
            Assert.That(rejection?.TraceStateString, Is.EqualTo(rejectedTraceState));
            Assert.That(rejection?.GetTagItem("http.response.status_code"), Is.EqualTo(rejectionStatusCode));
            Assert.That(rejection?.GetTagItem("error.type"), Is.EqualTo(expectedErrorType));
            Assert.That(rejection?.Status, Is.EqualTo(expectedActivityStatus));
            Assert.That(
                activities.Any(activity =>
                    IsSemanticConnection(activity) && activity.TraceId == rejectedTraceId),
                Is.False);
            Assert.That(closeCode, Is.EqualTo(1000));
            Assert.That(connectionObserved, Is.True);
            Assert.That(
                activities.Count(activity =>
                    IsSemanticConnection(activity) && activity.TraceId == successfulTraceId),
                Is.EqualTo(1));
            Assert.That(
                activities.Any(activity => IsRejectedVoiceRequest(activity, successfulTraceId)),
                Is.False);
            Assert.That(
                activities.Any(activity =>
                    IsGenericWebSocketRequest(activity) && activity.TraceId == successfulTraceId),
                Is.False);
        });
    }

    [TestCase(
        "/tenants/{tenantId}",
        "/tenants/contoso/invocations_ws",
        null,
        "/tenants/{tenantId}/invocations_ws",
        "contoso")]
    [TestCase(
        "/tenants/{tenantId}",
        "/base/tenants/contoso/invocations_ws",
        "/base",
        "/tenants/{tenantId}/invocations_ws",
        "contoso")]
    [TestCase(
        "/tenants/{tenantId:int}",
        "/tenants/42/invocations_ws",
        null,
        "/tenants/{tenantId:int}/invocations_ws",
        "42")]
    public async Task MiddlewareRejection_UsesSelectedRoutePatternWithoutRouteValues(
        string prefix,
        string requestPath,
        string? pathBase,
        string routePattern,
        string routeValue)
    {
        var exporter = new CapturingActivityExporter();
        var traceId = ActivityTraceId.CreateRandom();
        await using var server = await StartVoiceServerAsync(
            exporter,
            prefix: prefix,
            configureApplication: app => app.Run(context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return Task.CompletedTask;
            }),
            requestPath: requestPath,
            pathBase: pathBase);
        using var client = new HttpClient();
        using var request = CreateWebSocketCandidateRequest(
            server.HttpUri,
            Convert.ToBase64String(new byte[16]));
        request.Headers.TryAddWithoutValidation(
            "traceparent",
            $"00-{traceId}-{ActivitySpanId.CreateRandom()}-01");

        using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
        var observed = await exporter.TryWaitForAsync(
            activity =>
                activity.Source.Name == InvocationsSourceName &&
                activity.TraceId == traceId,
            ObservationTimeout);
        var activities = exporter.GetFinishedActivities();
        var rejection = activities.SingleOrDefault(activity =>
            activity.Source.Name == InvocationsSourceName &&
            activity.TraceId == traceId);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(observed, Is.True);
            Assert.That(rejection?.OperationName, Is.EqualTo($"GET {routePattern}"));
            Assert.That(rejection?.GetTagItem("http.route"), Is.EqualTo(routePattern));
            Assert.That(rejection?.GetTagItem("url.path"), Is.EqualTo(routePattern));
            Assert.That(rejection?.OperationName, Does.Not.Contain(routeValue));
            Assert.That(rejection?.TagObjects.Select(tag => tag.Value?.ToString()),
                Has.None.Contains(routeValue));
            Assert.That(activities.Any(activity =>
                activity.Source.Name == "Microsoft.AspNetCore"), Is.False);
        });
    }

    [Test]
    public async Task ConstrainedVoiceRoute_NonMatchingValueKeepsGenericRequestSpan()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            prefix: "/tenants/{tenantId:int}",
            requestPath: "/tenants/contoso/invocations_ws");
        using var client = new HttpClient();
        using var request = CreateWebSocketCandidateRequest(
            server.HttpUri,
            Convert.ToBase64String(new byte[16]));

        using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
        var genericObserved = await exporter.TryWaitForAsync(
            activity => activity.Source.Name == "Microsoft.AspNetCore",
            ObservationTimeout);
        var activities = exporter.GetFinishedActivities();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(genericObserved, Is.True);
            Assert.That(activities.Any(activity =>
                activity.Source.Name == InvocationsSourceName), Is.False);
        });
    }

    [Test]
    public async Task HigherPrecedenceNonVoiceRoute_KeepsGenericRequestSpan()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            prefix: "/tenants/{tenantId}",
            configureApplication: app =>
                app.MapGet(
                    "/tenants/admin/invocations_ws",
                    () => Results.Ok()).WithOrder(-1),
            requestPath: "/tenants/admin/invocations_ws");
        using var client = new HttpClient();
        using var request = CreateWebSocketCandidateRequest(
            server.HttpUri,
            Convert.ToBase64String(new byte[16]));

        using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
        var genericObserved = await exporter.TryWaitForAsync(
            activity => activity.Source.Name == "Microsoft.AspNetCore",
            ObservationTimeout);
        var activities = exporter.GetFinishedActivities();

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(genericObserved, Is.True);
            Assert.That(activities.Any(activity =>
                activity.Source.Name == InvocationsSourceName), Is.False);
        });
    }

    [Test]
    public async Task MiddlewareRejection_UnrecordedRemoteParent_IsNotPromoted_AndNextConnectionSucceeds()
    {
        using var propagatorScope = UseTraceContextPropagator();
        using var forceLocalRequestRecording = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == "Microsoft.AspNetCore",
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
        };
        ActivitySource.AddActivityListener(forceLocalRequestRecording);
        var rejectNextRequest = 1;
        var exporter = new CapturingActivityExporter();
        var rejectedTraceId = ActivityTraceId.CreateRandom();
        var rejectedParentSpanId = ActivitySpanId.CreateRandom();
        const string rejectedTraceState = "vendor=unsampled";
        var successfulTraceId = ActivityTraceId.CreateRandom();
        var successfulParentSpanId = ActivitySpanId.CreateRandom();
        int rejectionStatusCode;
        int? closeCode;
        bool connectionObserved;
        await using (var server = await StartVoiceServerAsync(
            exporter,
            configureApplication: app => app.Use(async (context, next) =>
            {
                if (Interlocked.Exchange(ref rejectNextRequest, 0) == 1)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
                await next();
            })))
        {
            using var client = new HttpClient();
            using var request = CreateWebSocketCandidateRequest(
                server.HttpUri,
                Convert.ToBase64String(new byte[16]));
            request.Headers.TryAddWithoutValidation(
                "traceparent",
                $"00-{rejectedTraceId}-{rejectedParentSpanId}-00");
            request.Headers.TryAddWithoutValidation("tracestate", rejectedTraceState);

            using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
            rejectionStatusCode = (int)response.StatusCode;

            closeCode = await ConnectAndCloseAsync(
                server.WebSocketUri,
                successfulTraceId,
                successfulParentSpanId);
            connectionObserved = await exporter.TryWaitForAsync(
                activity => IsSemanticConnection(activity) && activity.TraceId == successfulTraceId,
                ObservationTimeout);
        }

        var activities = exporter.GetFinishedActivities();
        Assert.Multiple(() =>
        {
            Assert.That(rejectionStatusCode, Is.EqualTo(StatusCodes.Status401Unauthorized));
            Assert.That(
                activities.Any(activity => IsRejectedVoiceRequest(activity, rejectedTraceId)),
                Is.False,
                "An unrecorded remote parent must not be promoted into an exported rejection span.");
            Assert.That(
                activities.Any(activity =>
                    IsSemanticConnection(activity) && activity.TraceId == rejectedTraceId),
                Is.False);
            Assert.That(
                activities.Any(activity =>
                    IsGenericWebSocketRequest(activity) && activity.TraceId == rejectedTraceId),
                Is.False);
            Assert.That(closeCode, Is.EqualTo(1000));
            Assert.That(connectionObserved, Is.True);
            Assert.That(
                activities.Count(activity =>
                    IsSemanticConnection(activity) && activity.TraceId == successfulTraceId),
                Is.EqualTo(1));
        });
    }

    [Test]
    public async Task NonVoiceRouteEndingWithInvocationsWs_KeepsGenericRequestSpan()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            configureApplication: app =>
                app.MapGet("/raw/invocations_ws", () => Results.Ok()));
        using var client = new HttpClient();
        var unrelatedUri = new Uri(server.HttpUri, "/raw/invocations_ws");
        using var request = CreateWebSocketCandidateRequest(
            unrelatedUri,
            Convert.ToBase64String(new byte[16]));

        using var response = await client.SendAsync(request).WaitAsync(TestTimeout);
        var observed = await exporter.TryWaitForAsync(
            activity => IsGenericRequestFor(activity, "/raw/invocations_ws"),
            ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(observed, Is.True,
                "Voice filtering must not suppress an unrelated endpoint with the same path suffix.");
            Assert.That(exporter.GetFinishedActivities().Any(IsSemanticConnection), Is.False);
        });
    }

    [Test]
    public async Task UnknownRouteEndingWithInvocationsWs_KeepsGenericRequestSpan()
    {
        var exporter = new CapturingActivityExporter();
        var requestObserved = new TaskCompletionSource<(string Path, string? Endpoint, bool? IsAllDataRequested)>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        await using var server = await StartVoiceServerAsync(
            exporter,
            configureApplication: app => app.Use(async (context, next) =>
            {
                await next();
                requestObserved.TrySetResult((
                    context.Request.Path.Value!,
                    context.GetEndpoint()?.DisplayName,
                    Activity.Current?.IsAllDataRequested));
            }));
        var unknownUri = new Uri(server.WebSocketUri, "/unknown/invocations_ws");

        _ = await ConnectAndCaptureFailureAsync(unknownUri);
        var request = await requestObserved.Task.WaitAsync(TestTimeout);
        var observed = await exporter.TryWaitForAsync(
            activity => activity.Source.Name == "Microsoft.AspNetCore",
            ObservationTimeout);
        var genericRequest = exporter.GetFinishedActivities().SingleOrDefault(
            activity => activity.Source.Name == "Microsoft.AspNetCore");

        Assert.Multiple(() =>
        {
            Assert.That(request.Path, Is.EqualTo("/unknown/invocations_ws"));
            Assert.That(request.Endpoint, Is.Null);
            Assert.That(request.IsAllDataRequested, Is.True);
            Assert.That(observed, Is.True,
                "An unmapped path must retain the generic ASP.NET request span.");
            Assert.That(genericRequest?.GetTagItem("url.path"),
                Is.EqualTo("/unknown/invocations_ws"));
            Assert.That(exporter.GetFinishedActivities().Any(IsSemanticConnection), Is.False);
        });
    }

    [Test]
    public async Task VoiceWebSocket_WithoutTraceparent_CreatesTrueRootConnection()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);

        await ConnectAndCloseAsync(server.WebSocketUri);
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        var connection = activities.SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(connection, Is.Not.Null);
            Assert.That(connection?.ParentSpanId, Is.EqualTo(default(ActivitySpanId)),
                "A missing remote parent must not make the semantic span a child of the suppressed ASP.NET Activity.");
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [Test]
    public async Task VoiceWebSocket_WithInvalidTraceparent_CreatesTrueRootConnection()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);

        await ConnectAndCloseAsync(server.WebSocketUri, rawTraceparent: "not-a-valid-traceparent");
        await exporter.WaitForExportAsync(TestTimeout);

        var activities = exporter.GetFinishedActivities();
        var connection = activities.SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(connection, Is.Not.Null);
            Assert.That(connection?.ParentSpanId, Is.EqualTo(default(ActivitySpanId)),
                "An invalid remote parent must not make the semantic span a child of the suppressed ASP.NET Activity.");
            Assert.That(activities.Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    [Test]
    public async Task VoiceWebSocket_DoesNotImportArbitraryBaggageIntoSemanticConnection()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();

        await ConnectAndCloseAsync(
            server.WebSocketUri,
            traceId,
            parentSpanId,
            baggage: "customer-secret=must-not-propagate");
        await exporter.WaitForExportAsync(TestTimeout);

        var connection = exporter.GetFinishedActivities().Single(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(connection.Baggage.Any(item => item.Key == "customer-secret"), Is.False);
            Assert.That(connection.TagObjects.Any(item => item.Key == "customer-secret"), Is.False);
        });
    }

    [Test]
    public async Task VoiceHierarchy_PropagatesOnlySanctionedCorrelationBaggage()
    {
        var requestId = new string('r', 300);
        var expectedRequestId = requestId[..256];
        TargetTurnVoiceHandler.Reset();
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<TargetTurnVoiceHandler>(exporter);

        await ConnectSendAndCloseAsync(
            server.WebSocketUri,
            SessionStartPayload,
            requestId: requestId,
            baggage:
                "azure.ai.agentserver.invocation_id=inbound-invocation," +
                "azure.ai.agentserver.session_id=inbound-session," +
                "x-request-id=inbound-request," +
                "customer-secret=must-not-propagate");

        var connectionObserved = await exporter.TryWaitForAsync(
            IsSemanticConnection,
            ObservationTimeout);
        var callbackObserved = await exporter.TryWaitForAsync(
            IsCallbackDispatch,
            ObservationTimeout);
        var targetObserved = await exporter.TryWaitForAsync(
            IsTargetTurn,
            ObservationTimeout);
        var customerObserved = await exporter.TryWaitForAsync(
            IsTargetCustomerSpan,
            ObservationTimeout);

        var activities = exporter.GetFinishedActivities();
        var hierarchy = new[]
        {
            activities.Single(IsSemanticConnection),
            activities.Single(IsCallbackDispatch),
            activities.Single(IsTargetTurn),
            activities.Single(IsTargetCustomerSpan),
        };

        Assert.Multiple(() =>
        {
            Assert.That(connectionObserved, Is.True);
            Assert.That(callbackObserved, Is.True);
            Assert.That(targetObserved, Is.True);
            Assert.That(customerObserved, Is.True);
            Assert.That(TargetTurnVoiceHandler.InvocationId, Is.Not.Null.And.Not.Empty);
            Assert.That(TargetTurnVoiceHandler.SessionId, Is.Not.Null.And.Not.Empty);
            foreach (var activity in hierarchy)
            {
                var baggage = activity.Baggage.ToArray();
                Assert.That(baggage, Has.Length.EqualTo(3), activity.OperationName);
                Assert.That(
                    baggage.Single(item => item.Key == "azure.ai.agentserver.invocation_id").Value,
                    Is.EqualTo(TargetTurnVoiceHandler.InvocationId),
                    activity.OperationName);
                Assert.That(
                    baggage.Single(item => item.Key == "azure.ai.agentserver.session_id").Value,
                    Is.EqualTo(TargetTurnVoiceHandler.SessionId),
                    activity.OperationName);
                Assert.That(
                    baggage.Single(item => item.Key == PlatformHeaders.RequestId).Value,
                    Is.EqualTo(expectedRequestId),
                    activity.OperationName);
                Assert.That(
                    baggage.Any(item => item.Key == "customer-secret"),
                    Is.False,
                    activity.OperationName);
            }
        });
    }

    [TestCase("session_on_start", "session_on_start")]
    [TestCase("", null)]
    public void VoiceHierarchy_ProvidesSessionEnrichmentAtProcessorStart(
        string sessionId,
        string? expectedSessionId)
    {
        var started = new ConcurrentQueue<(string OperationName, object? SessionId)>();
        using var provider = Sdk.CreateTracerProviderBuilder()
            .AddSource(InvocationsSourceName)
            .AddProcessor(new FoundryEnrichmentProcessor())
            .AddProcessor(new OnStartSessionCapturingProcessor(started))
            .Build();
        var correlationBaggage = new InvocationCorrelationBaggage(
            "invocation_on_start",
            sessionId,
            "request_on_start");
        var connection = VoiceConnectionTelemetry.Start(
            new HeaderDictionary(),
            correlationBaggage);

        using (var callback = VoiceCallbackTrace.Start(connection.Context, "session.start"))
        {
        }
        using (var turn = VoiceTurnTrace.Start(
            connection.Context,
            VoiceTurnOrigin.User,
            inputCount: 1))
        {
            turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
        }
        connection.Complete("session_on_start", 1000, null, null, 0);

        var semanticStarts = started.Where(item =>
            item.OperationName is ConnectionOperationName or "voice.callback" or "invoke_agent")
            .ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(semanticStarts, Has.Length.EqualTo(3));
            Assert.That(
                semanticStarts.Select(item => item.OperationName),
                Is.EquivalentTo(new[] { ConnectionOperationName, "voice.callback", "invoke_agent" }));
            Assert.That(
                semanticStarts.Select(item => item.SessionId),
                Is.All.EqualTo(expectedSessionId));
        });
    }

    [Test]
    public async Task VoiceHierarchy_CorrelationDoesNotDependOnAmbientRequestActivity()
    {
        const string requestId = "request_without_ambient_activity";
        TargetTurnVoiceHandler.Reset();
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<TargetTurnVoiceHandler>(
            exporter,
            configureApplication: app => app.Use(async (_, next) =>
            {
                var previous = Activity.Current;
                Activity.Current = null;
                try
                {
                    await next();
                }
                finally
                {
                    Activity.Current = previous;
                }
            }));

        await ConnectSendAndCloseAsync(
            server.WebSocketUri,
            SessionStartPayload,
            requestId: requestId);

        var connectionObserved = await exporter.TryWaitForAsync(
            IsSemanticConnection,
            ObservationTimeout);
        var callbackObserved = await exporter.TryWaitForAsync(
            IsCallbackDispatch,
            ObservationTimeout);
        var targetObserved = await exporter.TryWaitForAsync(
            IsTargetTurn,
            ObservationTimeout);
        var customerObserved = await exporter.TryWaitForAsync(
            IsTargetCustomerSpan,
            ObservationTimeout);
        var hierarchy = exporter.GetFinishedActivities()
            .Where(activity =>
                IsSemanticConnection(activity) ||
                IsCallbackDispatch(activity) ||
                IsTargetTurn(activity) ||
                IsTargetCustomerSpan(activity))
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(connectionObserved, Is.True);
            Assert.That(callbackObserved, Is.True);
            Assert.That(targetObserved, Is.True);
            Assert.That(customerObserved, Is.True);
            Assert.That(hierarchy, Has.Length.EqualTo(4));
            Assert.That(
                hierarchy.Select(activity => activity.GetBaggageItem(
                    "azure.ai.agentserver.invocation_id")),
                Is.All.EqualTo(TargetTurnVoiceHandler.InvocationId));
            Assert.That(
                hierarchy.Select(activity => activity.GetBaggageItem(
                    "azure.ai.agentserver.session_id")),
                Is.All.EqualTo(TargetTurnVoiceHandler.SessionId));
            Assert.That(
                hierarchy.Select(activity => activity.GetBaggageItem(PlatformHeaders.RequestId)),
                Is.All.EqualTo(requestId));
        });
    }

    [Test]
    public async Task CallbackTelemetryCannotContaminateSemanticConnectionOrStructuredCloseLog()
    {
        ContaminatingVoiceHandler.Reset();
        var exporter = new CapturingActivityExporter();
        var logs = new AmbientBaggageCapturingLoggerProvider();
        await using var server = await StartVoiceServerAsync<ContaminatingVoiceHandler>(
            exporter,
            loggerProvider: logs);

        await ConnectSendAndCloseAsync(server.WebSocketUri, SessionStartPayload);
        await ContaminatingVoiceHandler.Contaminated.Task.WaitAsync(TestTimeout);
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        var activities = exporter.GetFinishedActivities();
        var connection = activities.SingleOrDefault(IsSemanticConnection);
        var callback = activities.SingleOrDefault(IsCallbackDispatch);
        Assert.Multiple(() =>
        {
            Assert.That(observed, Is.True);
            Assert.That(callback, Is.Not.Null);
            Assert.That(callback?.ParentSpanId, Is.EqualTo(connection?.SpanId));
            Assert.That(connection?.Baggage.Any(item => item.Key == "customer-secret"), Is.False);
            Assert.That(connection?.GetTagItem("customer-secret"), Is.Null);
            Assert.That(connection?.Events.Any(activityEvent => activityEvent.Name == "customer-secret"), Is.False);
            Assert.That(logs.CloseEventBaggageKeys, Does.Not.Contain("customer-secret"));
        });
    }

    [TestCase(CallbackActivityFailureTarget.Started)]
    [TestCase(CallbackActivityFailureTarget.Stopped)]
    public async Task CallbackActivityListenerFailure_DoesNotChangeWireOrNextCallback(
        CallbackActivityFailureTarget failureTarget)
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<DirectCallbackSpanVoiceHandler>(exporter);
        var failureCount = 0;
        void InjectFailure(Activity activity)
        {
            if (IsCallbackDispatch(activity) &&
                Interlocked.CompareExchange(ref failureCount, 1, 0) == 0)
            {
                Activity.Current = null;
                throw new InvalidOperationException("injected callback Activity listener failure");
            }
        }
        using var listener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = failureTarget == CallbackActivityFailureTarget.Started
                ? InjectFailure
                : null,
            ActivityStopped = failureTarget == CallbackActivityFailureTarget.Stopped
                ? InjectFailure
                : null,
        };
        ActivitySource.AddActivityListener(listener);

        var firstCloseCode = await ConnectSendAndCloseAsync(server.WebSocketUri, SessionStartPayload);
        var secondCloseCode = await ConnectSendAndCloseAsync(server.WebSocketUri, SessionStartPayload);
        var callbacks = exporter.GetFinishedActivities().Where(IsCallbackDispatch).ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(firstCloseCode, Is.EqualTo(1000));
            Assert.That(secondCloseCode, Is.EqualTo(1000));
            Assert.That(failureCount, Is.EqualTo(1));
            Assert.That(callbacks, Has.Length.EqualTo(2));
            Assert.That(callbacks.Select(activity => activity.Duration),
                Is.All.Not.EqualTo(default(TimeSpan)));
            Assert.That(callbacks.Select(activity => activity.TraceId).Distinct().Count(), Is.EqualTo(2));
        });
    }

    [Test]
    public void CallbackSampleFailure_DoesNotAdoptSameNameForeignActivityAndRetrySucceeds()
    {
        var connectionContext = new ActivityContext(
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom(),
            ActivityTraceFlags.Recorded);
        using var foreignSource = new ActivitySource(InvocationsSourceName);
        var stopped = new ConcurrentQueue<Activity>();
        Activity? foreignActivity = null;
        var sampleCount = 0;
        using var listener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
            {
                if (Interlocked.Increment(ref sampleCount) == 1)
                {
                    var previous = Activity.Current;
                    foreignActivity = foreignSource.StartActivity(CallbackOperationName);
                    Activity.Current = previous;
                    throw new InvalidOperationException("injected callback Sample failure");
                }
                return ActivitySamplingResult.AllDataAndRecorded;
            },
            ActivityStopped = stopped.Enqueue,
        };
        ActivitySource.AddActivityListener(listener);

        using (var failed = VoiceCallbackTrace.Start(connectionContext, "session.start"))
        {
            failed.RecordFailure(new ApplicationException("must not reach foreign activity"));
        }

        var foreignStatusAfterFailure = foreignActivity?.Status;
        var foreignErrorAfterFailure = foreignActivity?.GetTagItem("error.type");

        Activity? retryActivity;
        using (var retry = VoiceCallbackTrace.Start(connectionContext, "session.start"))
        {
            using var activation = retry.Activate();
            retryActivity = Activity.Current;
        }

        Assert.Multiple(() =>
        {
            Assert.That(foreignActivity, Is.Not.Null);
            Assert.That(foreignActivity?.Source, Is.SameAs(foreignSource));
            Assert.That(foreignStatusAfterFailure, Is.EqualTo(ActivityStatusCode.Unset));
            Assert.That(foreignErrorAfterFailure, Is.Null);
            Assert.That(retryActivity, Is.Not.Null);
            Assert.That(retryActivity?.Source, Is.Not.SameAs(foreignSource));
            Assert.That(retryActivity?.OperationName, Is.EqualTo(CallbackOperationName));
            Assert.That(retryActivity?.Duration, Is.Not.EqualTo(default(TimeSpan)));
            Assert.That(stopped.Count(activity => ReferenceEquals(activity, retryActivity)), Is.EqualTo(1));
        });
    }

    [Test]
    public async Task CallbackFailure_StopListenerFailure_PreservesWireAndNextCallback()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<ThrowingVoiceHandler>(exporter);
        var failureCount = 0;
        using var listener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                if (IsCallbackDispatch(activity) &&
                    Interlocked.CompareExchange(ref failureCount, 1, 0) == 0)
                {
                    throw new InvalidOperationException("injected callback stop failure");
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var firstCloseCode = await ConnectSendAndReadCloseAsync(
            server.WebSocketUri,
            SessionStartPayload);
        var secondCloseCode = await ConnectSendAndReadCloseAsync(
            server.WebSocketUri,
            SessionStartPayload);
        var callbacks = exporter.GetFinishedActivities().Where(IsCallbackDispatch).ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(firstCloseCode, Is.EqualTo(1011));
            Assert.That(secondCloseCode, Is.EqualTo(1011));
            Assert.That(failureCount, Is.EqualTo(1));
            Assert.That(callbacks, Has.Length.EqualTo(2));
            Assert.That(callbacks.Select(activity => activity.Status),
                Is.All.EqualTo(ActivityStatusCode.Error));
            Assert.That(callbacks.Select(activity => activity.GetTagItem("error.type")),
                Is.All.EqualTo(typeof(InvalidOperationException).FullName));
        });
    }

    [Test]
    public async Task UnsampledRemoteParent_PropagatesContextWithoutExportingConnection()
    {
        ContextCapturingVoiceHandler.Reset();
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<ContextCapturingVoiceHandler>(exporter);
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();

        await ConnectSendAndCloseAsync(
            server.WebSocketUri,
            SessionStartPayload,
            traceId,
            parentSpanId,
            recorded: false);
        await ContextCapturingVoiceHandler.Captured.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(ContextCapturingVoiceHandler.TraceId, Is.EqualTo(traceId));
            Assert.That(ContextCapturingVoiceHandler.TraceFlags, Is.EqualTo(ActivityTraceFlags.None));
            Assert.That(ContextCapturingVoiceHandler.OperationName, Is.EqualTo("invoke_agent"));
            Assert.That(ContextCapturingVoiceHandler.ParentSpanId, Is.Not.EqualTo(parentSpanId));
            Assert.That(ContextCapturingVoiceHandler.ParentSpanId, Is.Not.EqualTo(default(ActivitySpanId)));
            Assert.That(exporter.GetFinishedActivities().Any(IsSemanticConnection), Is.False);
            Assert.That(exporter.GetFinishedActivities().Any(IsTargetTurn), Is.False);
        });
    }

    [Test]
    public async Task UnsampledRemoteParent_PropagatesOnlySanctionedBaggage()
    {
        const string requestId = "request_unsampled_voice";
        ContextCapturingVoiceHandler.Reset();
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<ContextCapturingVoiceHandler>(exporter);

        await ConnectSendAndCloseAsync(
            server.WebSocketUri,
            SessionStartPayload,
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom(),
            recorded: false,
            requestId: requestId,
            baggage:
                "azure.ai.agentserver.invocation_id=inbound-invocation," +
                "azure.ai.agentserver.session_id=inbound-session," +
                "x-request-id=inbound-request," +
                "customer-secret=must-not-propagate");
        await ContextCapturingVoiceHandler.Captured.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(ContextCapturingVoiceHandler.TraceFlags, Is.EqualTo(ActivityTraceFlags.None));
            Assert.That(ContextCapturingVoiceHandler.InvocationBaggage, Is.Not.Null.And.Not.Empty);
            Assert.That(ContextCapturingVoiceHandler.SessionBaggage, Is.Not.Null.And.Not.Empty);
            Assert.That(ContextCapturingVoiceHandler.RequestBaggage, Is.EqualTo(requestId));
            Assert.That(ContextCapturingVoiceHandler.ArbitraryBaggage, Is.Null);
            Assert.That(exporter.GetFinishedActivities().Any(IsSemanticConnection), Is.False);
            Assert.That(exporter.GetFinishedActivities().Any(IsTargetTurn), Is.False);
        });
    }

    [Test]
    public void Callback_WhenInvocationsSourceDrops_StillParentsCustomerSpan()
    {
        var traceId = ActivityTraceId.CreateRandom();
        var connectionSpanId = ActivitySpanId.CreateRandom();
        const string traceState = "vendor=value";
        var connectionContext = new ActivityContext(
            traceId,
            connectionSpanId,
            ActivityTraceFlags.Recorded,
            traceState,
            isRemote: false);
        var traceContext = new VoiceTraceContext(
            connectionContext,
            new InvocationCorrelationBaggage(
                "invocation_callback_drop",
                "session_callback_drop",
                "request_callback_drop"));
        Activity? customerActivity = null;
        using var customerListener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == TargetTurnCustomerSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity => customerActivity = activity,
        };
        ActivitySource.AddActivityListener(customerListener);
        using var customerSource = new ActivitySource(TargetTurnCustomerSourceName);
        var previousActivity = Activity.Current;

        using var callback = VoiceCallbackTrace.Start(
            traceContext,
            "session.start",
            static (_, _) => null);
        ActivitySpanId callbackSpanId;
        using (callback.Activate())
        {
            callbackSpanId = Activity.Current?.SpanId ?? default;
            using var customer = customerSource.StartActivity("customer.callback.sampled");
        }

        Assert.Multiple(() =>
        {
            Assert.That(callbackSpanId, Is.Not.EqualTo(default(ActivitySpanId)));
            Assert.That(callbackSpanId, Is.Not.EqualTo(connectionSpanId));
            Assert.That(customerActivity, Is.Not.Null);
            Assert.That(customerActivity?.TraceId, Is.EqualTo(traceId));
            Assert.That(customerActivity?.ParentSpanId, Is.EqualTo(callbackSpanId));
            Assert.That(customerActivity?.TraceStateString, Is.EqualTo(traceState));
            Assert.That(
                customerActivity?.GetBaggageItem("azure.ai.agentserver.invocation_id"),
                Is.EqualTo("invocation_callback_drop"));
            Assert.That(
                customerActivity?.GetBaggageItem("azure.ai.agentserver.session_id"),
                Is.EqualTo("session_callback_drop"));
            Assert.That(
                customerActivity?.GetBaggageItem(PlatformHeaders.RequestId),
                Is.EqualTo("request_callback_drop"));
            Assert.That(Activity.Current, Is.SameAs(previousActivity));
        });
    }

    [Test]
    public void CallbackPropagation_CurrentChangedFailure_DoesNotBreakNextActivation()
    {
        var connectionContext = new ActivityContext(
            ActivityTraceId.CreateRandom(),
            ActivitySpanId.CreateRandom(),
            ActivityTraceFlags.Recorded);
        using var invocationsListener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.None,
        };
        ActivitySource.AddActivityListener(invocationsListener);
        var customerActivities = new ConcurrentQueue<Activity>();
        using var customerListener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == TargetTurnCustomerSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = customerActivities.Enqueue,
        };
        ActivitySource.AddActivityListener(customerListener);
        using var customerSource = new ActivitySource(TargetTurnCustomerSourceName);
        var previousActivity = Activity.Current;
        var failureCount = 0;
        var callbackSpanIds = new List<ActivitySpanId>();
        EventHandler<ActivityChangedEventArgs> currentChanged = (_, args) =>
        {
            var callbackActivity = args.Current?.OperationName == "voice.callback"
                ? args.Current
                : args.Previous?.OperationName == "voice.callback"
                    ? args.Previous
                    : null;
            if (callbackActivity is not null &&
                Interlocked.CompareExchange(ref failureCount, 1, 0) == 0)
            {
                throw new InvalidOperationException("injected propagation activity change failure");
            }
        };
        Activity.CurrentChanged += currentChanged;
        try
        {
            for (var index = 0; index < 2; index++)
            {
                using var callback = VoiceCallbackTrace.Start(connectionContext, "session.start");
                using var activation = callback.Activate();
                callbackSpanIds.Add(Activity.Current?.SpanId ?? default);
                using var customer = customerSource.StartActivity($"customer.callback.{index}");
            }
        }
        finally
        {
            Activity.CurrentChanged -= currentChanged;
        }

        Assert.Multiple(() =>
        {
            Assert.That(failureCount, Is.EqualTo(1));
            Assert.That(callbackSpanIds, Has.Count.EqualTo(2));
            Assert.That(callbackSpanIds, Is.All.Not.EqualTo(default(ActivitySpanId)));
            Assert.That(callbackSpanIds.Distinct().Count(), Is.EqualTo(2));
            Assert.That(customerActivities.Select(activity => activity.ParentSpanId),
                Is.EqualTo(callbackSpanIds));
            Assert.That(Activity.Current, Is.SameAs(previousActivity));
        });
    }

    [Test]
    public void RecordedRemoteParent_WhenConnectionActivityDrops_CreatesDistinctPropagationChildren()
    {
        using var propagatorScope = UseTraceContextPropagator();
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();
        const string traceState = "vendor=value";
        var headers = new HeaderDictionary
        {
            ["traceparent"] = $"00-{traceId}-{parentSpanId}-01",
            ["tracestate"] = traceState,
        };
        using var listener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.None,
        };
        ActivitySource.AddActivityListener(listener);

        var first = VoiceConnectionTelemetry.Start(headers);
        var second = VoiceConnectionTelemetry.Start(headers);
        try
        {
            Assert.Multiple(() =>
            {
                Assert.That(first.Context.TraceId, Is.EqualTo(traceId));
                Assert.That(first.Context.SpanId, Is.Not.EqualTo(default(ActivitySpanId)));
                Assert.That(first.Context.SpanId, Is.Not.EqualTo(parentSpanId));
                Assert.That(first.Context.TraceFlags, Is.EqualTo(ActivityTraceFlags.Recorded));
                Assert.That(first.Context.TraceState, Is.EqualTo(traceState));
                Assert.That(second.Context.TraceId, Is.EqualTo(traceId));
                Assert.That(second.Context.SpanId, Is.Not.EqualTo(default(ActivitySpanId)));
                Assert.That(second.Context.SpanId, Is.Not.EqualTo(first.Context.SpanId));
            });
        }
        finally
        {
            first.Complete("session_first", 1000, null, null, 0);
            second.Complete("session_second", 1000, null, null, 0);
        }
    }

    [Test]
    public void RecordedRemoteParent_WhenInvocationsSourceDrops_StillParentsCustomerSpan()
    {
        using var propagatorScope = UseTraceContextPropagator();
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();
        var headers = new HeaderDictionary
        {
            ["traceparent"] = $"00-{traceId}-{parentSpanId}-01",
        };
        using var invocationsListener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.None,
        };
        ActivitySource.AddActivityListener(invocationsListener);
        Activity? customerActivity = null;
        using var customerListener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == TargetTurnCustomerSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity => customerActivity = activity,
        };
        ActivitySource.AddActivityListener(customerListener);
        using var customerSource = new ActivitySource(TargetTurnCustomerSourceName);

        var connection = VoiceConnectionTelemetry.Start(
            headers,
            new InvocationCorrelationBaggage(
                "invocation_turn_drop",
                "session_turn_drop",
                "request_turn_drop"));
        using var turn = VoiceTurnTrace.Start(
            connection.Context,
            VoiceTurnOrigin.User,
            inputCount: 1);
        ActivitySpanId turnSpanId;
        using (turn.Activate())
        {
            turnSpanId = Activity.Current?.SpanId ?? default;
            using var customer = customerSource.StartActivity("customer.model");
        }
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
        connection.Complete("session_recorded_drop", 1000, null, null, 0);

        Assert.Multiple(() =>
        {
            Assert.That(connection.Context.TraceId, Is.EqualTo(traceId));
            Assert.That(connection.Context.SpanId, Is.Not.EqualTo(parentSpanId));
            Assert.That(turnSpanId, Is.Not.EqualTo(default(ActivitySpanId)));
            Assert.That(turnSpanId, Is.Not.EqualTo(connection.Context.SpanId));
            Assert.That(customerActivity, Is.Not.Null);
            Assert.That(customerActivity?.TraceId, Is.EqualTo(traceId));
            Assert.That(customerActivity?.ParentSpanId, Is.EqualTo(turnSpanId));
            Assert.That(
                customerActivity?.GetBaggageItem("azure.ai.agentserver.invocation_id"),
                Is.EqualTo("invocation_turn_drop"));
            Assert.That(
                customerActivity?.GetBaggageItem("azure.ai.agentserver.session_id"),
                Is.EqualTo("session_turn_drop"));
            Assert.That(
                customerActivity?.GetBaggageItem(PlatformHeaders.RequestId),
                Is.EqualTo("request_turn_drop"));
        });
    }

    [Test]
    public void UnrecordedRemoteParent_WhenConnectionActivityDrops_DoesNotStartManualActivity()
    {
        using var propagatorScope = UseTraceContextPropagator();
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();
        var headers = new HeaderDictionary
        {
            ["traceparent"] = $"00-{traceId}-{parentSpanId}-00",
        };
        using var listener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.None,
        };
        ActivitySource.AddActivityListener(listener);
        var connectionActivityChanges = 0;
        EventHandler<ActivityChangedEventArgs> currentChanged = (_, args) =>
        {
            if (IsManualConnectionActivity(args.Current) ||
                IsManualConnectionActivity(args.Previous))
            {
                Interlocked.Increment(ref connectionActivityChanges);
            }
        };
        Activity.CurrentChanged += currentChanged;
        VoiceConnectionTelemetry? connection = null;
        try
        {
            connection = VoiceConnectionTelemetry.Start(headers);
        }
        finally
        {
            Activity.CurrentChanged -= currentChanged;
        }
        connection.Complete("session_unrecorded_drop", 1000, null, null, 0);

        Assert.Multiple(() =>
        {
            Assert.That(connection.Context.TraceId, Is.EqualTo(traceId));
            Assert.That(connection.Context.SpanId, Is.Not.EqualTo(parentSpanId));
            Assert.That(connection.Context.TraceFlags, Is.EqualTo(ActivityTraceFlags.None));
            Assert.That(connectionActivityChanges, Is.Zero);
        });
    }

    [Test]
    public async Task MissingAndInvalidTraceparent_RecordSanitizedPropagationFailureMetrics()
    {
        var measurements = new ConcurrentQueue<string?>();
        using var listener = new MeterListener
        {
            InstrumentPublished = (instrument, meterListener) =>
            {
                if (instrument.Meter.Name == InvocationsSourceName &&
                    instrument.Name == "azure.ai.agentserver.trace_context.propagation_failures")
                {
                    meterListener.EnableMeasurementEvents(instrument);
                }
            },
        };
        listener.SetMeasurementEventCallback<long>((_, _, tags, _) =>
        {
            foreach (var tag in tags)
            {
                if (tag.Key == "reason")
                {
                    measurements.Enqueue(tag.Value as string);
                }
            }
        });
        listener.Start();
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);

        await ConnectAndCloseAsync(server.WebSocketUri);
        await ConnectAndCloseAsync(server.WebSocketUri, rawTraceparent: "not-a-valid-traceparent");

        Assert.That(
            measurements.ToArray(),
            Is.EquivalentTo(new[] { "missing", "invalid" }));
    }

    [Test]
    public async Task CallbackFailure_ExportsErrorSpanWithoutChangingWireOutcome()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<ThrowingVoiceHandler>(exporter);

        var closeCode = await ConnectSendAndReadCloseAsync(
            server.WebSocketUri,
            SessionStartPayload);
        var callbackObserved = await exporter.TryWaitForAsync(
            IsCallbackDispatch,
            ObservationTimeout);

        var callbacks = exporter.GetFinishedActivities().Where(IsCallbackDispatch).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(closeCode, Is.EqualTo(1011));
            Assert.That(callbackObserved, Is.True);
            Assert.That(callbacks, Has.Length.EqualTo(1));
            Assert.That(callbacks[0].Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(
                callbacks[0].GetTagItem("error.type"),
                Is.EqualTo(typeof(InvalidOperationException).FullName));
        });
    }

    [Test]
    public async Task IndependentCallbackCancellation_IsReportedAsCallbackError()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<IndependentCancellationVoiceHandler>(exporter);

        var closeCode = await ConnectSendAndReadCloseAsync(
            server.WebSocketUri,
            SessionStartPayload);
        var callbackObserved = await exporter.TryWaitForAsync(
            IsCallbackDispatch,
            ObservationTimeout);
        var callback = exporter.GetFinishedActivities().SingleOrDefault(IsCallbackDispatch);

        Assert.Multiple(() =>
        {
            Assert.That(closeCode, Is.EqualTo(1011));
            Assert.That(callbackObserved, Is.True);
            Assert.That(callback?.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(
                callback?.GetTagItem("error.type"),
                Is.EqualTo(typeof(OperationCanceledException).FullName));
        });
    }

    [TestCase("normal", 1000, "completed")]
    [TestCase("protocol", 1002, "protocol_error")]
    [TestCase("callback", 1011, "callback_error")]
    public async Task ConnectionTerminalPath_ExportsExactlyOneFrozenOutcome(
        string scenario,
        int expectedCloseCode,
        string expectedOutcome)
    {
        var exporter = new CapturingActivityExporter();
        await using var server = scenario == "callback"
            ? await StartVoiceServerAsync<ThrowingVoiceHandler>(exporter)
            : await StartVoiceServerAsync(exporter);

        var actualCloseCode = scenario switch
        {
            "normal" => await ConnectAndCloseAsync(server.WebSocketUri),
            "protocol" => await ConnectSendAndReadCloseAsync(server.WebSocketUri, "{"),
            _ => await ConnectSendAndReadCloseAsync(server.WebSocketUri, SessionStartPayload),
        };
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        var connections = exporter.GetFinishedActivities().Where(IsSemanticConnection).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(actualCloseCode, Is.EqualTo(expectedCloseCode));
            Assert.That(observed, Is.True, "The terminal path must export its semantic connection span.");
            Assert.That(connections, Has.Length.EqualTo(1),
                "One physical connection must stop its semantic span exactly once.");
            Assert.That(
                connections.SingleOrDefault()?.GetTagItem(InvocationsWebSocketConstants.AttrSpanCloseCode),
                Is.EqualTo(expectedCloseCode));
            Assert.That(
                connections.SingleOrDefault()?.GetTagItem("bridge.outcome"),
                Is.EqualTo(expectedOutcome));
        });
    }

    [TestCase(ScopeFailureTarget.Begin)]
    [TestCase(ScopeFailureTarget.Dispose)]
    public async Task ScopeFailure_DoesNotChangeWireOrLeakConnection(
        ScopeFailureTarget failureTarget)
    {
        var exporter = new CapturingActivityExporter();
        var logger = new ThrowOnceLoggerProvider(scopeFailureTarget: failureTarget);
        await using var server = await StartVoiceServerAsync(
            exporter,
            loggerProvider: logger);

        var firstCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var secondCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(firstCloseCode, Is.EqualTo(1000));
            Assert.That(secondCloseCode, Is.EqualTo(1000));
            Assert.That(logger.FailureCount, Is.EqualTo(1));
            Assert.That(observed, Is.True);
            Assert.That(exporter.GetFinishedActivities().Count(IsSemanticConnection), Is.EqualTo(2));
        });
    }

    [Test]
    public async Task CallbackDiagnosticFailure_PreservesOutcomeAndNextConnection()
    {
        var exporter = new CapturingActivityExporter();
        var logger = new ThrowOnceLoggerProvider(throwOnException: true);
        await using var server = await StartVoiceServerAsync<ThrowingVoiceHandler>(
            exporter,
            loggerProvider: logger);

        var firstCloseCode = await ConnectSendAndReadCloseAsync(
            server.WebSocketUri,
            SessionStartPayload);
        var secondCloseCode = await ConnectSendAndReadCloseAsync(
            server.WebSocketUri,
            SessionStartPayload);
        var observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);
        var connections = exporter.GetFinishedActivities().Where(IsSemanticConnection).ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(firstCloseCode, Is.EqualTo(1011));
            Assert.That(secondCloseCode, Is.EqualTo(1011));
            Assert.That(logger.FailureCount, Is.EqualTo(1));
            Assert.That(observed, Is.True);
            Assert.That(connections, Has.Length.EqualTo(2));
            Assert.That(connections.Select(activity => activity.GetTagItem("bridge.outcome")),
                Is.All.EqualTo("callback_error"));
        });
    }

    [Test]
    public async Task FailedConnection_DoesNotPolluteFollowingSuccessfulConnection()
    {
        FailFirstVoiceHandler.Reset();
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<FailFirstVoiceHandler>(exporter);

        var failedCloseCode = await ConnectSendAndReadCloseAsync(server.WebSocketUri, SessionStartPayload);
        var successfulCloseCode = await ConnectSendAndCloseAsync(server.WebSocketUri, SessionStartPayload);
        var observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);

        var activities = exporter.GetFinishedActivities();
        var connections = activities.Where(IsSemanticConnection).ToArray();
        var callbacks = activities.Where(IsCallbackDispatch).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(failedCloseCode, Is.EqualTo(1011));
            Assert.That(successfulCloseCode, Is.EqualTo(1000));
            Assert.That(FailFirstVoiceHandler.CallbackCount, Is.EqualTo(2));
            Assert.That(observed, Is.True);
            Assert.That(connections, Has.Length.EqualTo(2));
            Assert.That(connections.Select(activity => activity.SpanId).Distinct().ToArray(), Has.Length.EqualTo(2));
            Assert.That(
                connections.Select(activity => activity.GetTagItem("bridge.outcome")),
                Is.EqualTo(new object?[] { "callback_error", "completed" }));
            Assert.That(
                connections.Select(activity => activity.GetTagItem(InvocationsWebSocketConstants.AttrSpanCloseCode)),
                Is.EqualTo(new object?[] { 1011, 1000 }));
            Assert.That(callbacks, Has.Length.EqualTo(2));
            Assert.That(
                callbacks.Select(activity => activity.Status),
                Is.EqualTo(new[] { ActivityStatusCode.Error, ActivityStatusCode.Unset }));
            Assert.That(
                callbacks.Select(activity => activity.GetTagItem("error.type")),
                Is.EqualTo(new object?[] { typeof(InvalidOperationException).FullName, null }));
        });
    }

    [Test]
    public async Task AcceptFailure_DoesNotPolluteSuccessfulRetry()
    {
        var acceptFailure = new InvalidOperationException("injected accept failure");
        var featureDecorator = new AcceptFailureFeatureDecorator(acceptFailure);
        var exporter = new CapturingActivityExporter();
        Exception observedFailure;
        int? retryCloseCode;
        bool observed;
        await using (var server = await StartVoiceServerAsync<PassiveVoiceHandler>(
            exporter,
            decorateWebSocketFeature: featureDecorator.Decorate))
        {
            observedFailure = await ConnectAndCaptureFailureAsync(server.WebSocketUri);
            retryCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
            observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);
        }

        var activities = exporter.GetFinishedActivities();
        var connections = activities.Where(IsSemanticConnection).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(observedFailure, Is.Not.Null);
            Assert.That(featureDecorator.AttemptCount, Is.EqualTo(2));
            Assert.That(retryCloseCode, Is.EqualTo(1000));
            Assert.That(observed, Is.True);
            Assert.That(connections, Has.Length.EqualTo(2));
            Assert.That(connections.Select(activity => activity.SpanId).Distinct().ToArray(), Has.Length.EqualTo(2));
            Assert.That(
                connections.Select(activity => activity.GetTagItem("bridge.outcome")),
                Is.EqualTo(new object?[] { "accept_error", "completed" }));
            Assert.That(
                connections.Select(activity => activity.GetTagItem(InvocationsWebSocketConstants.AttrSpanCloseCode)),
                Is.EqualTo(new object?[] { 1011, 1000 }));
            Assert.That(
                activities.Any(activity =>
                    activity.Source.Name == InvocationsSourceName &&
                    activity.OperationName == "GET /invocations_ws"),
                Is.False,
                "Endpoint admission must suppress rejection compensation even when accept fails.");
        });
    }

    [Test]
    public async Task AcceptFailure_LoggerFailurePreservesOutcomeAndSuccessfulRetry()
    {
        var acceptFailure = new InvalidOperationException("injected accept failure");
        var featureDecorator = new AcceptFailureFeatureDecorator(acceptFailure);
        var exporter = new CapturingActivityExporter();
        var logger = new ThrowOnceLoggerProvider(throwOnException: true);
        var escapedException = new TaskCompletionSource<Exception>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        Exception observedFailure;
        int? retryCloseCode;
        bool observed;
        await using (var server = await StartVoiceServerAsync<PassiveVoiceHandler>(
            exporter,
            decorateWebSocketFeature: featureDecorator.Decorate,
            loggerProvider: logger,
            configureApplication: app => app.Use(async (_, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception exception)
                {
                    escapedException.TrySetResult(exception);
                    throw;
                }
            })))
        {
            observedFailure = await ConnectAndCaptureFailureAsync(server.WebSocketUri);
            retryCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
            observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);
        }
        var escaped = await escapedException.Task.WaitAsync(TestTimeout);

        var connections = exporter.GetFinishedActivities().Where(IsSemanticConnection).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(observedFailure, Is.Not.Null);
            Assert.That(escaped, Is.SameAs(acceptFailure));
            Assert.That(logger.FailureCount, Is.EqualTo(1));
            Assert.That(featureDecorator.AttemptCount, Is.EqualTo(2));
            Assert.That(retryCloseCode, Is.EqualTo(1000));
            Assert.That(observed, Is.True);
            Assert.That(connections, Has.Length.EqualTo(2));
            Assert.That(
                connections.Select(activity => activity.GetTagItem("bridge.outcome")),
                Is.EqualTo(new object?[] { "accept_error", "completed" }));
            Assert.That(
                connections.Select(activity => activity.GetTagItem(
                    InvocationsWebSocketConstants.AttrSpanCloseCode)),
                Is.EqualTo(new object?[] { 1011, 1000 }));
        });
    }

    [Test]
    public async Task CloseFailure_IsSecondaryAndDoesNotOverwriteCompletedOutcome()
    {
        var closeFailure = new WebSocketException("injected close failure");
        var featureDecorator = new CloseFailureFeatureDecorator(closeFailure);
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<PassiveVoiceHandler>(
            exporter,
            decorateWebSocketFeature: featureDecorator.Decorate);

        using var client = new ClientWebSocket();
        await client.ConnectAsync(server.WebSocketUri, CancellationToken.None).WaitAsync(TestTimeout);
        await client.CloseOutputAsync(
            WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None).WaitAsync(TestTimeout);
        try
        {
            var buffer = new byte[1];
            _ = await client.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        }
        catch (Exception exception) when (
            exception is WebSocketException or OperationCanceledException or ObjectDisposedException)
        {
        }
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        var connection = exporter.GetFinishedActivities().SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(observed, Is.True);
            Assert.That(featureDecorator.CloseAttemptCount, Is.EqualTo(1));
            Assert.That(connection?.GetTagItem("bridge.outcome"), Is.EqualTo("completed"));
            Assert.That(connection?.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(connection?.GetTagItem("bridge.close.outcome"), Is.EqualTo("close_error"));
        });
    }

    [Test]
    public async Task VoiceLifecycleDuration_IncludesFinalizationDelay()
    {
        var exporter = new CapturingActivityExporter();
        using var provider = Sdk.CreateTracerProviderBuilder()
            .AddSource(InvocationsSourceName)
            .AddProcessor(new SimpleActivityExportProcessor(exporter))
            .Build();
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();
        var headers = new HeaderDictionary
        {
            [PlatformHeaders.TraceParent] = $"00-{traceId}-{parentSpanId}-01",
        };
        var lifecycle = VoiceWebSocketLifecycle.Start(new PassiveVoiceHandler(), headers);
        var started = Stopwatch.GetTimestamp();

        await lifecycle.FinalizeAsync(
            async () => await Task.Delay(TimeSpan.FromMilliseconds(75)),
            static _ => { },
            new WebSocketEndpointCompletion(
                "session_duration",
                1000,
                ErrorCode: null,
                HandlerOutcome: null,
                GetFinalDurationMs: () =>
                    (long)Stopwatch.GetElapsedTime(started).TotalMilliseconds));

        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);
        var connection = exporter.GetFinishedActivities().SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(observed, Is.True);
            Assert.That(
                connection?.GetTagItem(InvocationsWebSocketConstants.AttrSpanDurationMs),
                Is.GreaterThanOrEqualTo(50L));
            Assert.That(Stopwatch.GetElapsedTime(started), Is.GreaterThanOrEqualTo(TimeSpan.FromMilliseconds(50)));
        });
    }

    [Test]
    public async Task VoiceCloseLogAndSpan_ShareFrozenDuration_AfterBlockingLogAndRetry()
    {
        var exporter = new CapturingActivityExporter();
        var logs = new BlockingDurationLoggerProvider();
        await using var server = await StartVoiceServerAsync(
            exporter,
            loggerProvider: logs);

        var firstConnection = ConnectAndCloseAsync(server.WebSocketUri);
        await logs.FirstCloseStarted.Task.WaitAsync(TestTimeout);
        try
        {
            Assert.That(
                SpinWait.SpinUntil(
                    () => Stopwatch.GetElapsedTime(logs.FirstCloseTimestamp) >= TimeSpan.FromMilliseconds(75),
                    TestTimeout),
                Is.True,
                "The logger gate must hold long enough to distinguish pre- and post-log duration reads.");
        }
        finally
        {
            logs.ReleaseFirstClose.Set();
        }
        Assert.That(await firstConnection, Is.EqualTo(1000));
        Assert.That(await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout), Is.True);

        Assert.That(await ConnectAndCloseAsync(server.WebSocketUri), Is.EqualTo(1000));
        await logs.SecondCloseObserved.Task.WaitAsync(TestTimeout);
        Assert.That(await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout), Is.True);

        var closeEvents = logs.CloseEvents.ToArray();
        var connections = exporter.GetFinishedActivities()
            .Where(IsSemanticConnection)
            .ToArray();
        var connectionsBySession = connections.ToDictionary(
            activity => (string)activity.GetTagItem(InvocationsWebSocketConstants.AttrSpanSessionId)!);
        Assert.Multiple(() =>
        {
            Assert.That(closeEvents, Has.Length.EqualTo(2));
            Assert.That(connections, Has.Length.EqualTo(2));
            Assert.That(
                closeEvents.Select(closeEvent => closeEvent.SessionId),
                Is.Unique);
            Assert.That(connections.Select(activity => activity.SpanId).Distinct().Count(), Is.EqualTo(2));
        });
        foreach (var closeEvent in closeEvents)
        {
            Assert.That(
                connectionsBySession.TryGetValue(closeEvent.SessionId, out var connection),
                Is.True,
                $"No connection span was exported for session {closeEvent.SessionId}.");
            Assert.Multiple(() =>
            {
                Assert.That(
                    Convert.ToInt64(
                        connection!.GetTagItem(InvocationsWebSocketConstants.AttrSpanDurationMs),
                        System.Globalization.CultureInfo.InvariantCulture),
                    Is.EqualTo(closeEvent.DurationMs));
                Assert.That(
                    Math.Abs(connection.Duration.TotalMilliseconds - closeEvent.DurationMs),
                    Is.LessThan(25),
                    $"Session {closeEvent.SessionId} must use one frozen terminal duration.");
            });
        }
    }

    [Test]
    public async Task PeerProtocolClose_IsNotMisclassifiedAsCallbackFailure()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);

        var closeCode = await ConnectWithPeerCloseAsync(
            server.WebSocketUri,
            WebSocketCloseStatus.ProtocolError);
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        var connection = exporter.GetFinishedActivities().SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(closeCode, Is.EqualTo(1002));
            Assert.That(observed, Is.True);
            Assert.That(connection?.GetTagItem("bridge.outcome"), Is.EqualTo("protocol_error"));
            Assert.That(connection?.GetTagItem("error.type"), Is.EqualTo("protocol_error"));
        });
    }

    [Test]
    public async Task PeerInternalErrorClose_IsClassifiedAsTransportError()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);

        var closeCode = await ConnectWithPeerCloseAsync(
            server.WebSocketUri,
            WebSocketCloseStatus.InternalServerError);
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        var connection = exporter.GetFinishedActivities().SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(closeCode, Is.EqualTo(1011));
            Assert.That(observed, Is.True);
            Assert.That(connection?.GetTagItem("bridge.outcome"), Is.EqualTo("transport_error"));
            Assert.That(connection?.GetTagItem("error.type"), Is.EqualTo("transport_error"));
        });
    }

    [Test]
    public async Task RequestCancellationDuringAccept_ExportsCancelledWithoutErrorStatus()
    {
        using var requestCancellation = new CancellationTokenSource();
        await requestCancellation.CancelAsync();
        var acceptCancellation = new OperationCanceledException(requestCancellation.Token);
        var featureDecorator = new AcceptFailureFeatureDecorator(acceptCancellation);
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<PassiveVoiceHandler>(
            exporter,
            decorateWebSocketFeature: featureDecorator.Decorate,
            requestAborted: requestCancellation.Token);

        _ = await ConnectAndCaptureFailureAsync(server.WebSocketUri);
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        var connection = exporter.GetFinishedActivities().SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(observed, Is.True);
            Assert.That(connection?.GetTagItem("bridge.outcome"), Is.EqualTo("cancelled"));
            Assert.That(connection?.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(connection?.GetTagItem("error.type"), Is.Null);
        });
    }

    [Test]
    public async Task TokenlessRequestCancellationDuringAccept_IsCancelledAndDoesNotPolluteRetry()
    {
        using var requestCancellation = new CancellationTokenSource();
        await requestCancellation.CancelAsync();
        var acceptCancellation = new OperationCanceledException();
        var featureDecorator = new AcceptFailureFeatureDecorator(acceptCancellation);
        var requestCount = 0;
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<PassiveVoiceHandler>(
            exporter,
            decorateWebSocketFeature: featureDecorator.Decorate,
            configureApplication: app => app.Use(async (context, next) =>
            {
                if (Interlocked.Increment(ref requestCount) == 1)
                {
                    context.RequestAborted = requestCancellation.Token;
                }
                await next();
            }));

        _ = await ConnectAndCaptureFailureAsync(server.WebSocketUri);
        var retryCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);
        var connections = exporter.GetFinishedActivities().Where(IsSemanticConnection).ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(retryCloseCode, Is.EqualTo(1000));
            Assert.That(featureDecorator.AttemptCount, Is.EqualTo(2));
            Assert.That(observed, Is.True);
            Assert.That(connections, Has.Length.EqualTo(2));
            Assert.That(
                connections.Select(activity => activity.GetTagItem("bridge.outcome")),
                Is.EqualTo(new object?[] { "cancelled", "completed" }));
            Assert.That(connections[0].Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(connections[0].GetTagItem("error.type"), Is.Null);
        });
    }

    [Test]
    public async Task ActivityStoppedListenerFailure_DoesNotChangeWireOutcomeOrNextConnection()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var stoppedCallbackCount = 0;
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                if (IsSemanticConnection(activity))
                {
                    Interlocked.Increment(ref stoppedCallbackCount);
                    throw new InvalidOperationException("injected ActivityStopped failure");
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var failedCloseCode = await ConnectSendAndReadCloseAsync(server.WebSocketUri, "{");
        var successfulCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(failedCloseCode, Is.EqualTo(1002));
            Assert.That(successfulCloseCode, Is.EqualTo(1000));
            Assert.That(stoppedCallbackCount, Is.EqualTo(2));
            Assert.That(observed, Is.True,
                "A failing listener must not suppress exported connection outcomes.");
        });
    }

    [Test]
    public async Task ActivityStoppedListenerMutation_RestoresPriorRequestActivity()
    {
        var requestActivityAfterEndpoint = new TaskCompletionSource<Activity?>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(
            exporter,
            requestActivityAfterEndpoint: requestActivityAfterEndpoint);
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                if (IsSemanticConnection(activity))
                {
                    Activity.Current = null;
                    throw new InvalidOperationException("injected ActivityStopped mutation");
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var closeCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var restored = await requestActivityAfterEndpoint.Task.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(closeCode, Is.EqualTo(1000));
            Assert.That(restored, Is.Not.Null);
            Assert.That(restored?.Source.Name, Is.EqualTo("Microsoft.AspNetCore"));
        });
    }

    [Test]
    public async Task ActivityStartedListenerFailure_DoesNotChangeWireOutcomeOrLeakConnection()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var startedCallbackCount = 0;
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity =>
            {
                if (IsSemanticConnection(activity))
                {
                    Interlocked.Increment(ref startedCallbackCount);
                    throw new InvalidOperationException("injected ActivityStarted failure");
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var closeCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(closeCode, Is.EqualTo(1000));
            Assert.That(startedCallbackCount, Is.EqualTo(1));
            Assert.That(observed, Is.True,
                "A started-listener failure must not abandon an already-created connection Activity.");
        });
    }

    [Test]
    public async Task ActivityStartedListenerMutation_DoesNotLeakConnectionOrBreakNextConnection()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var startedCallbackCount = 0;
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity =>
            {
                if (IsSemanticConnection(activity) &&
                    Interlocked.Increment(ref startedCallbackCount) == 1)
                {
                    Activity.Current = null;
                    throw new InvalidOperationException("injected ActivityStarted mutation");
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var firstCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var secondCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(firstCloseCode, Is.EqualTo(1000));
            Assert.That(secondCloseCode, Is.EqualTo(1000));
            Assert.That(startedCallbackCount, Is.EqualTo(2));
            Assert.That(observed, Is.True,
                "A mutating start-listener failure must not abandon the first connection Activity.");
            Assert.That(
                exporter.GetFinishedActivities().Count(IsSemanticConnection),
                Is.EqualTo(2));
        });
    }

    [Test]
    public void ConnectionSampleFailure_DoesNotAdoptSameNameForeignActivityAndRetrySucceeds()
    {
        using var propagatorScope = UseTraceContextPropagator();
        var traceId = ActivityTraceId.CreateRandom();
        var parentSpanId = ActivitySpanId.CreateRandom();
        var headers = new HeaderDictionary
        {
            ["traceparent"] = $"00-{traceId}-{parentSpanId}-01",
        };
        using var foreignSource = new ActivitySource(InvocationsSourceName);
        var stopped = new ConcurrentQueue<Activity>();
        Activity? foreignActivity = null;
        var sampleCount = 0;
        using var listener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
            {
                if (Interlocked.Increment(ref sampleCount) == 1)
                {
                    var previous = Activity.Current;
                    foreignActivity = foreignSource.StartActivity(ConnectionOperationName);
                    Activity.Current = previous;
                    throw new InvalidOperationException("injected connection Sample failure");
                }
                return ActivitySamplingResult.AllDataAndRecorded;
            },
            ActivityStopped = stopped.Enqueue,
        };
        ActivitySource.AddActivityListener(listener);

        var failed = VoiceConnectionTelemetry.Start(headers);
        failed.Complete("must_not_reach_foreign", 1011, "callback_error", null, 17);

        var foreignSessionAfterFailure = foreignActivity?.GetTagItem(
            InvocationsWebSocketConstants.AttrSpanSessionId);
        var foreignOutcomeAfterFailure = foreignActivity?.GetTagItem("bridge.outcome");

        var retry = VoiceConnectionTelemetry.Start(headers);
        retry.Complete("session_retry", 1000, null, null, 23);
        var retryActivity = stopped.SingleOrDefault(activity =>
            activity.OperationName == ConnectionOperationName &&
            !ReferenceEquals(activity.Source, foreignSource));

        Assert.Multiple(() =>
        {
            Assert.That(foreignActivity, Is.Not.Null);
            Assert.That(foreignActivity?.Source, Is.SameAs(foreignSource));
            Assert.That(foreignSessionAfterFailure, Is.Null);
            Assert.That(foreignOutcomeAfterFailure, Is.Null);
            Assert.That(retryActivity, Is.Not.Null);
            Assert.That(
                retryActivity?.GetTagItem(InvocationsWebSocketConstants.AttrSpanSessionId),
                Is.EqualTo("session_retry"));
            Assert.That(retryActivity?.GetTagItem("bridge.outcome"), Is.EqualTo("completed"));
            Assert.That(retryActivity?.Duration, Is.Not.EqualTo(default(TimeSpan)));
            Assert.That(stopped.Count(activity => ReferenceEquals(activity, retryActivity)), Is.EqualTo(1));
        });
    }

    [Test]
    public async Task ConcurrentActivityStartedMutations_ExportDistinctConnectionsWithoutLeaks()
    {
        const int connectionCount = 8;
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var startedCallbackCount = 0;
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == InvocationsSourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                ActivitySamplingResult.AllDataAndRecorded,
            ActivityStarted = activity =>
            {
                if (IsSemanticConnection(activity))
                {
                    Interlocked.Increment(ref startedCallbackCount);
                    Activity.Current = null;
                    throw new InvalidOperationException("injected concurrent ActivityStarted mutation");
                }
            },
        };
        ActivitySource.AddActivityListener(listener);

        var closeCodes = await Task.WhenAll(
            Enumerable.Range(0, connectionCount)
                .Select(_ => ConnectAndCloseAsync(server.WebSocketUri)));
        var observed = await exporter.TryWaitForSemanticCountAsync(
            connectionCount,
            ObservationTimeout);
        var connections = exporter.GetFinishedActivities().Where(IsSemanticConnection).ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(closeCodes, Is.All.EqualTo(1000));
            Assert.That(startedCallbackCount, Is.EqualTo(connectionCount));
            Assert.That(observed, Is.True);
            Assert.That(connections, Has.Length.EqualTo(connectionCount));
            Assert.That(
                connections.Select(activity => activity.SpanId).Distinct().Count(),
                Is.EqualTo(connectionCount));
        });
    }

    [Test]
    public async Task ActivityCurrentChangedFailure_DoesNotChangeWireOutcomeOrLeakConnection()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var callbackCount = 0;
        EventHandler<ActivityChangedEventArgs> callback = (_, args) =>
        {
            if (args.Current is not null && IsSemanticConnection(args.Current))
            {
                Interlocked.Increment(ref callbackCount);
                throw new InvalidOperationException("injected Activity.CurrentChanged failure");
            }
        };
        Activity.CurrentChanged += callback;
        try
        {
            var closeCode = await ConnectAndCloseAsync(server.WebSocketUri);
            var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

            Assert.Multiple(() =>
            {
                Assert.That(closeCode, Is.EqualTo(1000));
                Assert.That(callbackCount, Is.GreaterThanOrEqualTo(1));
                Assert.That(observed, Is.True,
                    "A CurrentChanged failure must not abandon an already-created connection Activity.");
            });
        }
        finally
        {
            Activity.CurrentChanged -= callback;
        }
    }

    [Test]
    public async Task ActivityCurrentChangedMutationAndFailure_DoesNotLeakConnectionOrBreakNextConnection()
    {
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync(exporter);
        var mutationCount = 0;
        EventHandler<ActivityChangedEventArgs> callback = (_, args) =>
        {
            if (args.Current is not null &&
                IsSemanticConnection(args.Current) &&
                Interlocked.Increment(ref mutationCount) == 1)
            {
                Activity.Current = null;
                throw new InvalidOperationException("injected CurrentChanged mutation and failure");
            }
        };
        Activity.CurrentChanged += callback;
        try
        {
            var firstCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
            var secondCloseCode = await ConnectAndCloseAsync(server.WebSocketUri);
            var observed = await exporter.TryWaitForSemanticCountAsync(2, ObservationTimeout);

            Assert.Multiple(() =>
            {
                Assert.That(firstCloseCode, Is.EqualTo(1000));
                Assert.That(secondCloseCode, Is.EqualTo(1000));
                Assert.That(mutationCount, Is.GreaterThanOrEqualTo(2));
                Assert.That(observed, Is.True);
                Assert.That(
                    exporter.GetFinishedActivities().Count(IsSemanticConnection),
                    Is.EqualTo(2));
            });
        }
        finally
        {
            Activity.CurrentChanged -= callback;
        }
    }

    [Test]
    public async Task RequestCancellation_ExportsCancelledWithoutErrorStatus()
    {
        CancellationVoiceHandler.Reset();
        using var requestCancellation = new CancellationTokenSource();
        var exporter = new CapturingActivityExporter();
        await using var server = await StartVoiceServerAsync<CancellationVoiceHandler>(
            exporter,
            requestAborted: requestCancellation.Token);
        using var client = new ClientWebSocket();
        await client.ConnectAsync(server.WebSocketUri, CancellationToken.None).WaitAsync(TestTimeout);
        await client.SendAsync(
            Encoding.UTF8.GetBytes(SessionStartPayload),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None).WaitAsync(TestTimeout);
        await CancellationVoiceHandler.Started.Task.WaitAsync(TestTimeout);

        await requestCancellation.CancelAsync();
        try
        {
            var buffer = new byte[1];
            _ = await client.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        }
        catch (Exception exception) when (
            exception is WebSocketException or OperationCanceledException or ObjectDisposedException)
        {
        }
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        var activities = exporter.GetFinishedActivities();
        var connection = activities.SingleOrDefault(IsSemanticConnection);
        var callback = activities.SingleOrDefault(IsCallbackDispatch);
        Assert.Multiple(() =>
        {
            Assert.That(observed, Is.True);
            Assert.That(connection?.GetTagItem("bridge.outcome"), Is.EqualTo("cancelled"));
            Assert.That(connection?.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(connection?.GetTagItem("error.type"), Is.Null);
            Assert.That(callback?.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(callback?.GetTagItem("error.type"), Is.Null);
            Assert.That(CancellationVoiceHandler.TerminationCount, Is.EqualTo(1));
        });
    }

    [TestCase("false", true)]
    [TestCase("false", false)]
    [TestCase("throw", true)]
    [TestCase("throw", false)]
    public async Task VoiceFilter_PreservesApplicationSuppressionOrFailure_WithoutChangingProtocol(
        string filterBehavior,
        bool configureBeforeVoice)
    {
        var exporter = new CapturingActivityExporter();
        var applicationFilterCalls = 0;
        void ConfigureFilter(IServiceCollection services) =>
            services.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
                options.Filter = _ =>
                {
                    Interlocked.Increment(ref applicationFilterCalls);
                    return filterBehavior == "throw"
                        ? throw new InvalidOperationException("injected application filter failure")
                        : false;
                });

        await using var server = await StartVoiceServerAsync(
            exporter,
            configureServicesBeforeVoice: configureBeforeVoice ? ConfigureFilter : null,
            configureServicesAfterVoice: configureBeforeVoice ? null : ConfigureFilter);

        var closeCode = await ConnectAndCloseAsync(server.WebSocketUri);
        var observed = await exporter.TryWaitForSemanticCountAsync(1, ObservationTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(closeCode, Is.EqualTo(1000));
            Assert.That(applicationFilterCalls, Is.EqualTo(1));
            Assert.That(observed, Is.True,
                "Application suppression of the generic ASP.NET span must not suppress the Voice semantic span.");
            Assert.That(exporter.GetFinishedActivities().Any(IsGenericWebSocketRequest), Is.False);
        });
    }

    private static async Task<TestServer> StartVoiceServerAsync(
        CapturingActivityExporter exporter,
        string? prefix = null,
        Action<IServiceCollection>? configureServicesBeforeVoice = null,
        Action<IServiceCollection>? configureServicesAfterVoice = null,
        ILoggerProvider? loggerProvider = null,
        Action<WebApplication>? configureApplication = null,
        TaskCompletionSource<Activity?>? requestActivityAfterEndpoint = null,
        string? requestPath = null,
        string? pathBase = null,
        HttpProtocols? serverProtocols = null) =>
        await StartVoiceServerAsync<PassiveVoiceHandler>(
            exporter,
            prefix,
            configureServicesBeforeVoice,
            configureServicesAfterVoice,
            loggerProvider: loggerProvider,
            configureApplication: configureApplication,
            requestActivityAfterEndpoint: requestActivityAfterEndpoint,
            requestPath: requestPath,
            pathBase: pathBase,
            serverProtocols: serverProtocols);

    private static async Task<TestServer> StartVoiceServerAsync<THandler>(
        CapturingActivityExporter exporter,
        string? prefix = null,
        Action<IServiceCollection>? configureServicesBeforeVoice = null,
        Action<IServiceCollection>? configureServicesAfterVoice = null,
        Func<IHttpWebSocketFeature, IHttpWebSocketFeature>? decorateWebSocketFeature = null,
        CancellationToken requestAborted = default,
        ILoggerProvider? loggerProvider = null,
        Action<WebApplication>? configureApplication = null,
        TaskCompletionSource<Activity?>? requestActivityAfterEndpoint = null,
        string? requestPath = null,
        string? pathBase = null,
        HttpProtocols? serverProtocols = null)
        where THandler : VoiceHandler
    {
        var builder = CreateBuilder(exporter, serverProtocols);
        if (loggerProvider is not null)
        {
            builder.Logging.AddProvider(loggerProvider);
        }
        builder.Services.AddAgentServerCore();
        configureServicesBeforeVoice?.Invoke(builder.Services);
        builder.Services.AddVoice<THandler>();
        configureServicesAfterVoice?.Invoke(builder.Services);
        var app = builder.Build();
        if (pathBase is not null)
        {
            app.UsePathBase(pathBase);
        }
        app.UseAgentServerCore();
        if (decorateWebSocketFeature is not null)
        {
            app.Use(async (context, next) =>
            {
                var feature = context.Features.Get<IHttpWebSocketFeature>()
                    ?? throw new InvalidOperationException("The WebSocket feature is unavailable.");
                context.Features.Set(decorateWebSocketFeature(feature));
                await next();
            });
        }
        if (requestAborted.CanBeCanceled)
        {
            app.Use(async (context, next) =>
            {
                context.RequestAborted = requestAborted;
                await next();
            });
        }
        if (requestActivityAfterEndpoint is not null)
        {
            app.Use(async (_, next) =>
            {
                try
                {
                    await next();
                }
                finally
                {
                    requestActivityAfterEndpoint.TrySetResult(Activity.Current);
                }
            });
        }
        configureApplication?.Invoke(app);
        app.MapInvocationsServer(prefix);
        return await StartAsync(app, prefix, requestPath);
    }

    private static async Task<TestServer> StartRawServerAsync(
        CapturingActivityExporter exporter,
        Func<IHttpWebSocketFeature, IHttpWebSocketFeature>? decorateWebSocketFeature = null,
        CancellationToken requestAborted = default,
        ILoggerProvider? loggerProvider = null,
        HttpProtocols? serverProtocols = null,
        Action<WebApplication>? configureApplication = null)
    {
        var builder = CreateBuilder(exporter, serverProtocols);
        if (loggerProvider is not null)
        {
            builder.Logging.AddProvider(loggerProvider);
        }
        builder.Services.AddAgentServerCore();
        builder.Services.AddInvocationsServer();
        builder.Services.AddSingleton<InvocationHandler, PassiveRawHandler>();
        var app = builder.Build();
        app.UseAgentServerCore();
        if (decorateWebSocketFeature is not null)
        {
            app.Use(async (context, next) =>
            {
                var feature = context.Features.Get<IHttpWebSocketFeature>()
                    ?? throw new InvalidOperationException("The WebSocket feature is unavailable.");
                context.Features.Set(decorateWebSocketFeature(feature));
                await next();
            });
        }
        if (requestAborted.CanBeCanceled)
        {
            app.Use(async (context, next) =>
            {
                context.RequestAborted = requestAborted;
                await next();
            });
        }
        configureApplication?.Invoke(app);
        app.MapInvocationsServer();
        return await StartAsync(app, prefix: null, requestPath: null);
    }

    private static WebApplicationBuilder CreateBuilder(CapturingActivityExporter exporter)
        => CreateBuilder(exporter, serverProtocols: null);

    private static WebApplicationBuilder CreateBuilder(
        CapturingActivityExporter exporter,
        HttpProtocols? serverProtocols)
    {
        var builder = WebApplication.CreateBuilder();
        if (serverProtocols is { } protocols)
        {
            builder.WebHost.ConfigureKestrel(options =>
                options.Listen(
                    IPAddress.Loopback,
                    port: 0,
                    listenOptions => listenOptions.Protocols = protocols));
        }
        else
        {
            builder.WebHost.UseUrls("http://127.0.0.1:0");
        }
        builder.Logging.ClearProviders();
        builder.Services.AddOpenTelemetry()
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddSource(InvocationsSourceName)
                .AddSource(TargetTurnCustomerSourceName)
                .AddProcessor(new SimpleActivityExportProcessor(exporter)));
        return builder;
    }

    private static async Task<TestServer> StartAsync(
        WebApplication app,
        string? prefix,
        string? requestPath)
    {
        await app.StartAsync().WaitAsync(TestTimeout);
        var addresses = app.Services.GetRequiredService<IServer>()
            .Features.Get<IServerAddressesFeature>()!;
        var baseAddress = new Uri(addresses.Addresses.Single());
        var route = requestPath ?? $"{prefix?.TrimEnd('/')}/invocations_ws";
        if (!route.StartsWith("/", StringComparison.Ordinal))
        {
            route = $"/{route}";
        }
        return new TestServer(
            app,
            new UriBuilder(baseAddress) { Scheme = "ws", Path = route }.Uri,
            new Uri(baseAddress, route));
    }

    private static async Task<int?> ConnectAndCloseAsync(
        Uri uri,
        ActivityTraceId? traceId = null,
        ActivitySpanId? parentSpanId = null,
        string? traceState = null,
        string? rawTraceparent = null,
        string? baggage = null,
        Version? httpVersion = null)
    {
        using var client = new ClientWebSocket();
        if (httpVersion is not null)
        {
            client.Options.HttpVersion = httpVersion;
            client.Options.HttpVersionPolicy = HttpVersionPolicy.RequestVersionExact;
        }
        if (rawTraceparent is not null)
        {
            client.Options.SetRequestHeader("traceparent", rawTraceparent);
        }
        else if (traceId is { } propagatedTraceId && parentSpanId is { } propagatedParentSpanId)
        {
            client.Options.SetRequestHeader(
                "traceparent",
                $"00-{propagatedTraceId}-{propagatedParentSpanId}-01");
        }
        if (traceState is not null)
        {
            client.Options.SetRequestHeader("tracestate", traceState);
        }
        if (baggage is not null)
        {
            client.Options.SetRequestHeader("baggage", baggage);
        }

        using var invoker = httpVersion is null
            ? null
            : new HttpMessageInvoker(new SocketsHttpHandler());
        if (invoker is null)
        {
            await client.ConnectAsync(uri, CancellationToken.None).WaitAsync(TestTimeout);
        }
        else
        {
            await client.ConnectAsync(uri, invoker, CancellationToken.None).WaitAsync(TestTimeout);
        }
        await client.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None).WaitAsync(TestTimeout);
        return (int?)client.CloseStatus ?? 1000;
    }

    private static async Task<int?> ConnectSendAndCloseAsync(
        Uri uri,
        string payload,
        ActivityTraceId? traceId = null,
        ActivitySpanId? parentSpanId = null,
        bool recorded = true,
        string? requestId = null,
        string? baggage = null)
    {
        using var client = new ClientWebSocket();
        if (traceId is { } propagatedTraceId && parentSpanId is { } propagatedParentSpanId)
        {
            client.Options.SetRequestHeader(
                "traceparent",
                $"00-{propagatedTraceId}-{propagatedParentSpanId}-{(recorded ? "01" : "00")}");
        }
        if (requestId is not null)
        {
            client.Options.SetRequestHeader(PlatformHeaders.RequestId, requestId);
        }
        if (baggage is not null)
        {
            client.Options.SetRequestHeader("baggage", baggage);
        }
        await client.ConnectAsync(uri, CancellationToken.None).WaitAsync(TestTimeout);
        await client.SendAsync(
            Encoding.UTF8.GetBytes(payload),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None).WaitAsync(TestTimeout);
        await client.CloseAsync(
            WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None).WaitAsync(TestTimeout);
        return (int?)client.CloseStatus ?? 1000;
    }

    private static async Task<int?> ConnectSendAndReadCloseAsync(Uri uri, string payload)
    {
        using var client = new ClientWebSocket();
        await client.ConnectAsync(uri, CancellationToken.None).WaitAsync(TestTimeout);
        await client.SendAsync(
            Encoding.UTF8.GetBytes(payload),
            WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None).WaitAsync(TestTimeout);
        var buffer = new byte[64];
        var close = await client.ReceiveAsync(
            new ArraySegment<byte>(buffer),
            CancellationToken.None).WaitAsync(TestTimeout);
        Assert.That(close.MessageType, Is.EqualTo(WebSocketMessageType.Close));
        var closeCode = (int?)close.CloseStatus;
        if (client.State == WebSocketState.CloseReceived)
        {
            await client.CloseOutputAsync(
                WebSocketCloseStatus.NormalClosure,
                "ack",
                CancellationToken.None).WaitAsync(TestTimeout);
        }
        return closeCode;
    }

    private static async Task<int?> ConnectWithPeerCloseAsync(
        Uri uri,
        WebSocketCloseStatus closeStatus)
    {
        using var client = new ClientWebSocket();
        await client.ConnectAsync(uri, CancellationToken.None).WaitAsync(TestTimeout);
        await client.CloseOutputAsync(
            closeStatus,
            "peer-close",
            CancellationToken.None).WaitAsync(TestTimeout);
        var buffer = new byte[1];
        var close = await client.ReceiveAsync(buffer, CancellationToken.None).WaitAsync(TestTimeout);
        return (int?)close.CloseStatus;
    }

    private static HttpRequestMessage CreateWebSocketCandidateRequest(Uri uri, string key)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        request.Headers.Connection.Add("Upgrade");
        request.Headers.TryAddWithoutValidation("Upgrade", "websocket");
        request.Headers.TryAddWithoutValidation("Sec-WebSocket-Key", key);
        request.Headers.TryAddWithoutValidation("Sec-WebSocket-Version", "13");
        return request;
    }

    private static async Task<Exception> ConnectAndCaptureFailureAsync(Uri uri)
    {
        using var client = new ClientWebSocket();
        try
        {
            await client.ConnectAsync(uri, CancellationToken.None).WaitAsync(TestTimeout);
        }
        catch (TimeoutException)
        {
            throw;
        }
        catch (Exception exception)
        {
            return exception;
        }
        Assert.Fail("The injected WebSocket accept failure did not reach the client.");
        throw new InvalidOperationException("Unreachable.");
    }

    private static bool IsSemanticConnection(Activity activity) =>
        activity.Source.Name == InvocationsSourceName &&
        activity.OperationName == ConnectionOperationName;

    private static bool IsManualConnectionActivity(Activity? activity) =>
        activity?.OperationName == ConnectionOperationName &&
        activity.Source.Name != InvocationsSourceName;

    private static bool IsGenericWebSocketRequest(Activity activity) =>
        activity.Source.Name == "Microsoft.AspNetCore" &&
        activity.DisplayName.Contains("invocations_ws", StringComparison.Ordinal);

    private static bool IsGenericRequestFor(Activity activity, string path) =>
        activity.Source.Name == "Microsoft.AspNetCore" &&
        activity.GetTagItem("url.path") as string == path;

    private static bool IsRejectedVoiceRequest(Activity activity, ActivityTraceId traceId) =>
        activity.Source.Name == InvocationsSourceName &&
        activity.OperationName == "GET /invocations_ws" &&
        activity.TraceId == traceId;

    private static bool IsTargetTurn(Activity activity) =>
        activity.Source.Name == InvocationsSourceName &&
        activity.OperationName == "invoke_agent";

    private static bool IsCallbackDispatch(Activity activity) =>
        activity.Source.Name == InvocationsSourceName &&
        activity.OperationName == "voice.callback";

    private static bool IsTargetCustomerSpan(Activity activity) =>
        activity.Source.Name == TargetTurnCustomerSourceName &&
        activity.OperationName == "customer.model";

    private static bool IsDirectCallbackCustomerSpan(Activity activity) =>
        activity.Source.Name == TargetTurnCustomerSourceName &&
        activity.OperationName == "customer.callback";

    private static IDisposable UseTraceContextPropagator()
    {
        var previous = Propagators.DefaultTextMapPropagator;
        Sdk.SetDefaultTextMapPropagator(new TraceContextPropagator());
        return new RestorePropagator(previous);
    }

    private sealed class PassiveVoiceHandler : VoiceHandler;

    private sealed class RestorePropagator : IDisposable
    {
        private readonly TextMapPropagator _propagator;

        public RestorePropagator(TextMapPropagator propagator) => _propagator = propagator;

        public void Dispose() => Sdk.SetDefaultTextMapPropagator(_propagator);
    }

    private sealed class TargetTurnVoiceHandler : VoiceHandler
    {
        private static readonly ActivitySource s_customerSource = new(TargetTurnCustomerSourceName);

        public static string? InvocationId { get; private set; }

        public static string? SessionId { get; private set; }

        public static void Reset()
        {
            InvocationId = null;
            SessionId = null;
        }

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            InvocationId = session.InvocationContext.InvocationId;
            SessionId = session.InvocationContext.SessionId;
            using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
            using (turn.Activate())
            {
                using var child = s_customerSource.StartActivity("customer.model");
            }
            turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
            return Task.CompletedTask;
        }
    }

    private sealed class DirectCallbackSpanVoiceHandler : VoiceHandler
    {
        private static readonly ActivitySource s_customerSource = new(TargetTurnCustomerSourceName);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            using var activity = s_customerSource.StartActivity("customer.callback");
            return Task.CompletedTask;
        }
    }

    private sealed class AsyncCallbackSpanVoiceHandler : VoiceHandler
    {
        private static readonly ActivitySource s_customerSource = new(TargetTurnCustomerSourceName);

        public static TaskCompletionSource BackgroundCompleted { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static void Reset() =>
            BackgroundCompleted = new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            await Task.Yield();
            using (var activity = s_customerSource.StartActivity("customer.callback.async"))
            {
            }
            _ = Task.Run(() =>
            {
                using var activity = s_customerSource.StartActivity("customer.callback.background");
                BackgroundCompleted.TrySetResult();
            });
        }
    }

    private sealed class ThrowingVoiceHandler : VoiceHandler
    {
        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) =>
            throw new InvalidOperationException("injected callback failure");
    }

    private sealed class IndependentCancellationVoiceHandler : VoiceHandler
    {
        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken) =>
            throw new OperationCanceledException(new CancellationToken(canceled: true));
    }

    private sealed class FailFirstVoiceHandler : VoiceHandler
    {
        private static int _callbackCount;

        public static int CallbackCount => Volatile.Read(ref _callbackCount);

        public static void Reset() => Volatile.Write(ref _callbackCount, 0);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            if (Interlocked.Increment(ref _callbackCount) == 1)
            {
                throw new InvalidOperationException("injected first-connection failure");
            }
            return Task.CompletedTask;
        }
    }

    private sealed class CancellationVoiceHandler : VoiceHandler
    {
        private static int _terminationCount;

        public static TaskCompletionSource Started { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static int TerminationCount => Volatile.Read(ref _terminationCount);

        public static void Reset()
        {
            Started = new(TaskCreationOptions.RunContinuationsAsynchronously);
            Volatile.Write(ref _terminationCount, 0);
        }

        protected override async Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Started.TrySetResult();
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
        }

        protected override void OnConnectionTerminating(VoiceSession session) =>
            Interlocked.Increment(ref _terminationCount);
    }

    private sealed class ContextCapturingVoiceHandler : VoiceHandler
    {
        public static TaskCompletionSource Captured { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static ActivityTraceId TraceId { get; private set; }

        public static ActivityTraceFlags TraceFlags { get; private set; }

        public static string? OperationName { get; private set; }

        public static ActivitySpanId ParentSpanId { get; private set; }

        public static string? InvocationBaggage { get; private set; }

        public static string? SessionBaggage { get; private set; }

        public static string? RequestBaggage { get; private set; }

        public static string? ArbitraryBaggage { get; private set; }

        public static void Reset()
        {
            Captured = new(TaskCreationOptions.RunContinuationsAsynchronously);
            TraceId = default;
            TraceFlags = default;
            OperationName = null;
            ParentSpanId = default;
            InvocationBaggage = null;
            SessionBaggage = null;
            RequestBaggage = null;
            ArbitraryBaggage = null;
        }

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
            using (turn.Activate())
            {
                TraceId = Activity.Current?.TraceId ?? default;
                TraceFlags = Activity.Current?.ActivityTraceFlags ?? default;
                OperationName = Activity.Current?.OperationName;
                ParentSpanId = Activity.Current?.ParentSpanId ?? default;
                InvocationBaggage = Activity.Current?.GetBaggageItem(
                    "azure.ai.agentserver.invocation_id");
                SessionBaggage = Activity.Current?.GetBaggageItem(
                    "azure.ai.agentserver.session_id");
                RequestBaggage = Activity.Current?.GetBaggageItem(PlatformHeaders.RequestId);
                ArbitraryBaggage = Activity.Current?.GetBaggageItem("customer-secret");
            }
            turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
            Captured.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class ContaminatingVoiceHandler : VoiceHandler
    {
        public static TaskCompletionSource Contaminated { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static void Reset() =>
            Contaminated = new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Activity.Current?.AddBaggage("customer-secret", "sentinel");
            Activity.Current?.SetTag("customer-secret", "sentinel");
            Activity.Current?.AddEvent(new ActivityEvent("customer-secret"));
            Contaminated.TrySetResult();
            return Task.CompletedTask;
        }
    }

    private sealed class PassiveRawHandler : InvocationWebSocketHandler
    {
        public override async Task HandleWebSocketAsync(
            WebSocket webSocket,
            InvocationContext context,
            CancellationToken cancellationToken)
        {
            var buffer = new byte[1];
            _ = await webSocket.ReceiveAsync(buffer, cancellationToken);
        }
    }

    private sealed class CapturingActivityExporter : BaseExporter<Activity>
    {
        private readonly ConcurrentQueue<Activity> _activities = new();
        private readonly SemaphoreSlim _exported = new(0);

        public override ExportResult Export(in Batch<Activity> batch)
        {
            foreach (var activity in batch)
            {
                _activities.Enqueue(activity);
            }
            _exported.Release();
            return ExportResult.Success;
        }

        public async Task WaitForExportAsync(TimeSpan timeout)
        {
            if (!await _exported.WaitAsync(timeout))
            {
                throw new TimeoutException("No Activity was exported before the test deadline.");
            }
        }

        public async Task<bool> TryWaitForSemanticCountAsync(int expectedCount, TimeSpan timeout)
        {
            var started = Stopwatch.GetTimestamp();
            while (_activities.Count(IsSemanticConnection) < expectedCount)
            {
                var remaining = timeout - Stopwatch.GetElapsedTime(started);
                if (remaining <= TimeSpan.Zero || !await _exported.WaitAsync(remaining))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> TryWaitForAsync(Func<Activity, bool> predicate, TimeSpan timeout)
        {
            var started = Stopwatch.GetTimestamp();
            while (!_activities.Any(predicate))
            {
                var remaining = timeout - Stopwatch.GetElapsedTime(started);
                if (remaining <= TimeSpan.Zero || !await _exported.WaitAsync(remaining))
                {
                    return false;
                }
            }
            return true;
        }

        public IReadOnlyList<Activity> GetFinishedActivities() => _activities.ToArray();
    }

    private sealed class BlockingDurationLoggerProvider : ILoggerProvider
    {
        private int _closeCount;

        public ConcurrentQueue<CloseEvent> CloseEvents { get; } = new();

        public TaskCompletionSource FirstCloseStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource SecondCloseObserved { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public ManualResetEventSlim ReleaseFirstClose { get; } = new(initialState: false);

        public long FirstCloseTimestamp { get; private set; }

        public ILogger CreateLogger(string categoryName) => new BlockingDurationLogger(this);

        public void Dispose() => ReleaseFirstClose.Dispose();

        private sealed class BlockingDurationLogger : ILogger
        {
            private readonly BlockingDurationLoggerProvider _owner;

            public BlockingDurationLogger(BlockingDurationLoggerProvider owner) => _owner = owner;

            public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                if (state is not IEnumerable<KeyValuePair<string, object?>> pairs)
                {
                    return;
                }

                var fields = pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
                if (!fields.ContainsKey(InvocationsWebSocketConstants.AttrSpanCloseCode) ||
                    !fields.TryGetValue(InvocationsWebSocketConstants.AttrSpanDurationMs, out var duration))
                {
                    return;
                }

                if (!fields.TryGetValue(
                    InvocationsWebSocketConstants.AttrSpanSessionId,
                    out var sessionId) ||
                    sessionId is not string sessionIdValue)
                {
                    return;
                }

                _owner.CloseEvents.Enqueue(new CloseEvent(
                    sessionIdValue,
                    Convert.ToInt64(duration, System.Globalization.CultureInfo.InvariantCulture)));
                var count = Interlocked.Increment(ref _owner._closeCount);
                if (count == 1)
                {
                    _owner.FirstCloseTimestamp = Stopwatch.GetTimestamp();
                    _owner.FirstCloseStarted.TrySetResult();
                    if (!_owner.ReleaseFirstClose.Wait(TestTimeout))
                    {
                        throw new TimeoutException("The first close log was not released.");
                    }
                }
                else if (count == 2)
                {
                    _owner.SecondCloseObserved.TrySetResult();
                }
            }
        }

        internal readonly record struct CloseEvent(string SessionId, long DurationMs);
    }

    private sealed class AmbientBaggageCapturingLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentQueue<string> _closeEventBaggageKeys = new();
        private readonly ConcurrentQueue<ActivityTraceId> _closeEventTraceIds = new();
        private readonly ConcurrentQueue<int> _closeCodes = new();
        private readonly ConcurrentQueue<string> _errorCodes = new();
        private readonly ConcurrentQueue<Exception> _diagnosticExceptions = new();

        public IReadOnlyList<string> CloseEventBaggageKeys => _closeEventBaggageKeys.ToArray();

        public IReadOnlyList<ActivityTraceId> CloseEventTraceIds => _closeEventTraceIds.ToArray();

        public IReadOnlyList<int> CloseCodes => _closeCodes.ToArray();

        public IReadOnlyList<string> ErrorCodes => _errorCodes.ToArray();

        public IReadOnlyList<Exception> DiagnosticExceptions => _diagnosticExceptions.ToArray();

        public ILogger CreateLogger(string categoryName) => new CapturingLogger(this);

        public void Dispose()
        {
        }

        private sealed class CapturingLogger : ILogger
        {
            private readonly AmbientBaggageCapturingLoggerProvider _owner;

            public CapturingLogger(AmbientBaggageCapturingLoggerProvider owner) => _owner = owner;

            public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                if (exception is not null)
                {
                    _owner._diagnosticExceptions.Enqueue(exception);
                }
                if (state is IEnumerable<KeyValuePair<string, object?>> pairs)
                {
                    var fields = pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
                    if (!fields.TryGetValue(
                        InvocationsWebSocketConstants.AttrSpanCloseCode,
                        out var closeCode))
                    {
                        return;
                    }
                    if (closeCode is int typedCloseCode)
                    {
                        _owner._closeCodes.Enqueue(typedCloseCode);
                    }
                    if (fields.TryGetValue(
                        InvocationsWebSocketConstants.AttrSpanErrorCode,
                        out var errorCode) &&
                        errorCode is string typedErrorCode)
                    {
                        _owner._errorCodes.Enqueue(typedErrorCode);
                    }
                    if (Activity.Current is { } current)
                    {
                        _owner._closeEventTraceIds.Enqueue(current.TraceId);
                        foreach (var baggage in current.Baggage)
                        {
                            _owner._closeEventBaggageKeys.Enqueue(baggage.Key);
                        }
                    }
                }
            }
        }
    }

    private sealed class ThrowOnceLoggerProvider : ILoggerProvider
    {
        private readonly ScopeFailureTarget? _scopeFailureTarget;
        private readonly bool _throwOnException;
        private int _failureCount;

        public ThrowOnceLoggerProvider(
            ScopeFailureTarget? scopeFailureTarget = null,
            bool throwOnException = false)
        {
            _scopeFailureTarget = scopeFailureTarget;
            _throwOnException = throwOnException;
        }

        public int FailureCount => Volatile.Read(ref _failureCount);

        public ILogger CreateLogger(string categoryName) => new ThrowOnceLogger(
            this,
            categoryName == typeof(WebSocketEndpointHandler).FullName);

        public void Dispose()
        {
        }

        private void ThrowOnce()
        {
            if (Interlocked.CompareExchange(ref _failureCount, 1, 0) == 0)
            {
                throw new InvalidOperationException("injected logger failure");
            }
        }

        private sealed class ThrowOnceLogger : ILogger
        {
            private readonly ThrowOnceLoggerProvider _owner;
            private readonly bool _isEndpointLogger;

            public ThrowOnceLogger(ThrowOnceLoggerProvider owner, bool isEndpointLogger)
            {
                _owner = owner;
                _isEndpointLogger = isEndpointLogger;
            }

            public IDisposable? BeginScope<TState>(TState state) where TState : notnull
            {
                if (!_isEndpointLogger)
                {
                    return null;
                }
                if (_owner._scopeFailureTarget == ScopeFailureTarget.Begin)
                {
                    _owner.ThrowOnce();
                }
                return _owner._scopeFailureTarget == ScopeFailureTarget.Dispose
                    ? new ThrowOnceScope(_owner)
                    : null;
            }

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                if (_owner._throwOnException && exception is not null)
                {
                    _owner.ThrowOnce();
                }
            }
        }

        private sealed class ThrowOnceScope : IDisposable
        {
            private readonly ThrowOnceLoggerProvider _owner;

            public ThrowOnceScope(ThrowOnceLoggerProvider owner) => _owner = owner;

            public void Dispose() => _owner.ThrowOnce();
        }
    }

    private sealed class OnStartSessionCapturingProcessor : BaseProcessor<Activity>
    {
        private readonly ConcurrentQueue<(string OperationName, object? SessionId)> _started;

        public OnStartSessionCapturingProcessor(
            ConcurrentQueue<(string OperationName, object? SessionId)> started) =>
            _started = started;

        public override void OnStart(Activity activity) =>
            _started.Enqueue((activity.OperationName, activity.GetTagItem("microsoft.session.id")));
    }

    public enum ScopeFailureTarget
    {
        Begin,
        Dispose,
    }

    public enum CallbackActivityFailureTarget
    {
        Started,
        Stopped,
    }

    private sealed class AcceptFailureFeatureDecorator
    {
        private readonly Exception _exception;
        private int _attemptCount;

        public AcceptFailureFeatureDecorator(Exception exception) => _exception = exception;

        public int AttemptCount => Volatile.Read(ref _attemptCount);

        public IHttpWebSocketFeature Decorate(IHttpWebSocketFeature inner) =>
            new AcceptFailureFeature(inner, this);

        private sealed class AcceptFailureFeature : IHttpWebSocketFeature
        {
            private readonly IHttpWebSocketFeature _inner;
            private readonly AcceptFailureFeatureDecorator _owner;

            public AcceptFailureFeature(
                IHttpWebSocketFeature inner,
                AcceptFailureFeatureDecorator owner)
            {
                _inner = inner;
                _owner = owner;
            }

            public bool IsWebSocketRequest => _inner.IsWebSocketRequest;

            public Task<WebSocket> AcceptAsync(WebSocketAcceptContext context) =>
                Interlocked.Increment(ref _owner._attemptCount) == 1
                    ? Task.FromException<WebSocket>(_owner._exception)
                    : _inner.AcceptAsync(context);
        }
    }

    private sealed class CloseFailureFeatureDecorator
    {
        private readonly Exception _exception;
        private int _closeAttemptCount;

        public CloseFailureFeatureDecorator(Exception exception) => _exception = exception;

        public int CloseAttemptCount => Volatile.Read(ref _closeAttemptCount);

        public IHttpWebSocketFeature Decorate(IHttpWebSocketFeature inner) =>
            new CloseFailureFeature(inner, this);

        private sealed class CloseFailureFeature : IHttpWebSocketFeature
        {
            private readonly IHttpWebSocketFeature _inner;
            private readonly CloseFailureFeatureDecorator _owner;

            public CloseFailureFeature(
                IHttpWebSocketFeature inner,
                CloseFailureFeatureDecorator owner)
            {
                _inner = inner;
                _owner = owner;
            }

            public bool IsWebSocketRequest => _inner.IsWebSocketRequest;

            public async Task<WebSocket> AcceptAsync(WebSocketAcceptContext context) =>
                new CloseFailureWebSocket(await _inner.AcceptAsync(context), _owner);
        }

        private sealed class CloseFailureWebSocket : WebSocket
        {
            private readonly WebSocket _inner;
            private readonly CloseFailureFeatureDecorator _owner;

            public CloseFailureWebSocket(
                WebSocket inner,
                CloseFailureFeatureDecorator owner)
            {
                _inner = inner;
                _owner = owner;
            }

            public override WebSocketCloseStatus? CloseStatus => _inner.CloseStatus;
            public override string? CloseStatusDescription => _inner.CloseStatusDescription;
            public override WebSocketState State => _inner.State;
            public override string? SubProtocol => _inner.SubProtocol;
            public override void Abort() => _inner.Abort();
            public override Task CloseAsync(WebSocketCloseStatus closeStatus, string? statusDescription, CancellationToken cancellationToken) =>
                _inner.CloseAsync(closeStatus, statusDescription, cancellationToken);
            public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string? statusDescription, CancellationToken cancellationToken)
            {
                Interlocked.Increment(ref _owner._closeAttemptCount);
                return Task.FromException(_owner._exception);
            }
            public override void Dispose() => _inner.Dispose();
            public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken) =>
                _inner.ReceiveAsync(buffer, cancellationToken);
            public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken) =>
                _inner.SendAsync(buffer, messageType, endOfMessage, cancellationToken);
        }
    }

    private sealed class TestServer : IAsyncDisposable
    {
        private readonly WebApplication _app;

        public TestServer(WebApplication app, Uri webSocketUri, Uri httpUri)
        {
            _app = app;
            WebSocketUri = webSocketUri;
            HttpUri = httpUri;
        }

        public Uri WebSocketUri { get; }

        public Uri HttpUri { get; }

        public async ValueTask DisposeAsync()
        {
            await _app.StopAsync().WaitAsync(TestTimeout);
            await _app.DisposeAsync();
        }
    }

    private const string SessionStartPayload =
        "{\"type\":\"session.start\",\"id\":\"m_1\",\"ts\":\"2026-08-13T00:00:00.000Z\",\"protocol_version\":\"1.0\",\"reconnect\":false,\"response_timeouts\":{\"first_output_ms\":1,\"idle_ms\":2,\"max_duration_ms\":3}}";
}
