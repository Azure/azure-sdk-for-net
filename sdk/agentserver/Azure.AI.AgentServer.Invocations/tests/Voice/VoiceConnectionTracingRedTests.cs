// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
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
            Assert.That(callback?.TagObjects.Select(tag => tag.Key),
                Is.EquivalentTo(new[] { "voice.event.type" }));
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

    [Test]
    public async Task MiddlewareRejection_WithoutTraceparent_CreatesTrueRootSpan()
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
                "A parentless rejection must not inherit the suppressed ASP.NET request Activity.");
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

        var connection = VoiceConnectionTelemetry.Start(headers);
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

        var connections = exporter.GetFinishedActivities().Where(IsSemanticConnection).ToArray();
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
            static () => { },
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

        var connection = exporter.GetFinishedActivities().SingleOrDefault(IsSemanticConnection);
        Assert.Multiple(() =>
        {
            Assert.That(observed, Is.True);
            Assert.That(connection?.GetTagItem("bridge.outcome"), Is.EqualTo("cancelled"));
            Assert.That(connection?.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
            Assert.That(connection?.GetTagItem("error.type"), Is.Null);
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
        TaskCompletionSource<Activity?>? requestActivityAfterEndpoint = null) =>
        await StartVoiceServerAsync<PassiveVoiceHandler>(
            exporter,
            prefix,
            configureServicesBeforeVoice,
            configureServicesAfterVoice,
            loggerProvider: loggerProvider,
            configureApplication: configureApplication,
            requestActivityAfterEndpoint: requestActivityAfterEndpoint);

    private static async Task<TestServer> StartVoiceServerAsync<THandler>(
        CapturingActivityExporter exporter,
        string? prefix = null,
        Action<IServiceCollection>? configureServicesBeforeVoice = null,
        Action<IServiceCollection>? configureServicesAfterVoice = null,
        Func<IHttpWebSocketFeature, IHttpWebSocketFeature>? decorateWebSocketFeature = null,
        CancellationToken requestAborted = default,
        ILoggerProvider? loggerProvider = null,
        Action<WebApplication>? configureApplication = null,
        TaskCompletionSource<Activity?>? requestActivityAfterEndpoint = null)
        where THandler : VoiceHandler
    {
        var builder = CreateBuilder(exporter);
        if (loggerProvider is not null)
        {
            builder.Logging.AddProvider(loggerProvider);
        }
        builder.Services.AddAgentServerCore();
        configureServicesBeforeVoice?.Invoke(builder.Services);
        builder.Services.AddVoice<THandler>();
        configureServicesAfterVoice?.Invoke(builder.Services);
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
        return await StartAsync(app, prefix);
    }

    private static async Task<TestServer> StartRawServerAsync(
        CapturingActivityExporter exporter,
        Func<IHttpWebSocketFeature, IHttpWebSocketFeature>? decorateWebSocketFeature = null,
        CancellationToken requestAborted = default,
        ILoggerProvider? loggerProvider = null)
    {
        var builder = CreateBuilder(exporter);
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
        app.MapInvocationsServer();
        return await StartAsync(app, prefix: null);
    }

    private static WebApplicationBuilder CreateBuilder(CapturingActivityExporter exporter)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Logging.ClearProviders();
        builder.Services.AddOpenTelemetry()
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddSource(InvocationsSourceName)
                .AddSource(TargetTurnCustomerSourceName)
                .AddProcessor(new SimpleActivityExportProcessor(exporter)));
        return builder;
    }

    private static async Task<TestServer> StartAsync(WebApplication app, string? prefix)
    {
        await app.StartAsync().WaitAsync(TestTimeout);
        var addresses = app.Services.GetRequiredService<IServer>()
            .Features.Get<IServerAddressesFeature>()!;
        var baseAddress = new Uri(addresses.Addresses.Single());
        var route = $"{prefix?.TrimEnd('/')}/invocations_ws";
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
        string? baggage = null)
    {
        using var client = new ClientWebSocket();
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

        await client.ConnectAsync(uri, CancellationToken.None).WaitAsync(TestTimeout);
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
        bool recorded = true)
    {
        using var client = new ClientWebSocket();
        if (traceId is { } propagatedTraceId && parentSpanId is { } propagatedParentSpanId)
        {
            client.Options.SetRequestHeader(
                "traceparent",
                $"00-{propagatedTraceId}-{propagatedParentSpanId}-{(recorded ? "01" : "00")}");
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

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
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

        public static void Reset()
        {
            Captured = new(TaskCreationOptions.RunContinuationsAsynchronously);
            TraceId = default;
            TraceFlags = default;
            OperationName = null;
            ParentSpanId = default;
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
