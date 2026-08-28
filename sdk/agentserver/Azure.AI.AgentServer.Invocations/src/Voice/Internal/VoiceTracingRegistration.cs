// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Instrumentation.AspNetCore;

namespace Azure.AI.AgentServer.Invocations.Voice;

internal static class VoiceTracingRegistration
{
    private static readonly ActivitySource s_activitySource = new(InvocationsActivitySource.DefaultName);
    private static readonly object s_endpointEntered = new();
    private static readonly object s_rejectionTraceRegistered = new();
    private static readonly object s_tracedWebSocketCandidate = new();
    private static readonly AsyncLocal<object?> s_rejectionStartToken = new();

    internal static void Add(IServiceCollection services)
    {
        services.PostConfigure<AspNetCoreTraceInstrumentationOptions>(options =>
        {
            var applicationFilter = options.Filter;
            options.Filter = httpContext =>
            {
                var applicationTracingEnabled = applicationFilter?.Invoke(httpContext) ?? true;
                if (!applicationTracingEnabled)
                {
                    return false;
                }

                if (!IsWebSocketUpgrade(httpContext))
                {
                    return true;
                }

                httpContext.Items[s_tracedWebSocketCandidate] = null;
                RegisterRejectionTrace(httpContext);
                return true;
            };
        });
    }

    internal static void MarkEndpointEntered(HttpContext httpContext)
    {
        httpContext.Items[s_endpointEntered] = null;
        if (!httpContext.Items.ContainsKey(s_tracedWebSocketCandidate))
        {
            return;
        }

        var requestActivity = Activity.Current;
        if (requestActivity?.Source.Name == "Microsoft.AspNetCore")
        {
            requestActivity.IsAllDataRequested = false;
            requestActivity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
        }
    }

    private static void RegisterRejectionTrace(HttpContext httpContext)
    {
        if (!httpContext.Items.TryAdd(s_rejectionTraceRegistered, null))
        {
            return;
        }

        var requestActivity = Activity.Current;
        var parentContext = ExtractParentContext(httpContext.Request.Headers);
        var startTime = requestActivity is null
            ? DateTimeOffset.UtcNow
            : new DateTimeOffset(requestActivity.StartTimeUtc);
        var state = new RejectionTraceState(
            httpContext,
            requestActivity,
            parentContext,
            startTime);
        httpContext.Response.OnCompleted(
            static state =>
            {
                EmitRejectionTrace((RejectionTraceState)state);
                return Task.CompletedTask;
            },
            state);
    }

    private static ActivityContext ExtractParentContext(IHeaderDictionary headers)
    {
        try
        {
            return Propagators.DefaultTextMapPropagator.Extract(
                default,
                headers,
                static (carrier, key) => carrier.TryGetValue(key, out var values)
                    ? values
                    : Array.Empty<string>())
                .ActivityContext;
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
            return default;
        }
    }

    private static void EmitRejectionTrace(RejectionTraceState state)
    {
        if (state.HttpContext.Items.ContainsKey(s_endpointEntered))
        {
            return;
        }

        if (state.HttpContext.GetEndpoint() is not RouteEndpoint endpoint ||
            endpoint.Metadata.GetMetadata<VoiceWebSocketEndpointMetadata>() is null ||
            endpoint.RoutePattern.RawText is not { } rawRoutePattern)
        {
            return;
        }

        if (state.RequestActivity?.Source.Name == "Microsoft.AspNetCore")
        {
            SuppressRequestActivity(state.RequestActivity);
        }

        var routePattern = NormalizeRoutePattern(rawRoutePattern);
        var operationName = $"{state.HttpContext.Request.Method} {routePattern}";

        var previousActivity = Activity.Current;
        var previousStartToken = s_rejectionStartToken.Value;
        var startToken = new object();
        Activity? activity = null;
        Activity? startedActivity = null;
        // ActivitySource names are not unique. Recovery may own only a live rejection
        // surfaced by this exact SDK source during the current synchronous start window.
        bool IsStartCandidate(Activity? candidate) =>
            candidate?.Id is not null &&
            candidate.Duration == default &&
            !ReferenceEquals(candidate, previousActivity) &&
            IsRejectionActivity(candidate, operationName);
        EventHandler<ActivityChangedEventArgs> captureStartedActivity = (_, args) =>
        {
            if (!ReferenceEquals(s_rejectionStartToken.Value, startToken) || startedActivity is not null)
            {
                return;
            }

            if (IsStartCandidate(args.Current))
            {
                startedActivity = args.Current;
            }
            else if (IsStartCandidate(args.Previous))
            {
                startedActivity = args.Previous;
            }
        };
        try
        {
            var statusCode = state.HttpContext.Response.StatusCode;
            var tags = new ActivityTagsCollection
            {
                ["http.request.method"] = state.HttpContext.Request.Method,
                ["http.route"] = routePattern,
                ["url.path"] = routePattern,
                ["http.response.status_code"] = statusCode,
            };
            TrySetCurrent(null);
            s_rejectionStartToken.Value = startToken;
            Activity.CurrentChanged += captureStartedActivity;
            try
            {
                activity = s_activitySource.StartActivity(
                    operationName,
                    ActivityKind.Server,
                    state.ParentContext,
                    tags,
                    startTime: state.StartTime);
            }
            catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
            {
                activity = IsStartCandidate(startedActivity) ? startedActivity : null;
                if (activity is null && IsStartCandidate(Activity.Current))
                {
                    activity = Activity.Current;
                }
            }
            if (!IsStartCandidate(activity))
            {
                activity = null;
            }
            if (statusCode >= StatusCodes.Status500InternalServerError)
            {
                TryInvokeTelemetry(() => activity?.SetStatus(ActivityStatusCode.Error));
                TryInvokeTelemetry(() =>
                    activity?.SetTag("error.type", statusCode.ToString(CultureInfo.InvariantCulture)));
            }
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
        }
        finally
        {
            Activity.CurrentChanged -= captureStartedActivity;
            try
            {
                TrySetCurrent(previousActivity);
                if (activity is not null)
                {
                    TryInvokeTelemetry(activity.Stop);
                }
                TrySetCurrent(previousActivity);
            }
            finally
            {
                s_rejectionStartToken.Value = previousStartToken;
            }
        }
    }

    private static bool IsRejectionActivity(Activity? activity, string operationName) =>
        ReferenceEquals(activity?.Source, s_activitySource) &&
        activity.OperationName == operationName;

    private static void SuppressRequestActivity(Activity requestActivity)
    {
        requestActivity.IsAllDataRequested = false;
        requestActivity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
    }

    private static string NormalizeRoutePattern(string routePattern) =>
        routePattern.StartsWith('/') ? routePattern : $"/{routePattern}";

    private static bool IsWebSocketUpgrade(HttpContext httpContext)
    {
        var request = httpContext.Request;
        if (HttpMethods.IsGet(request.Method))
        {
            return
            HeaderContainsToken(request.Headers.Connection, "upgrade") &&
            HeaderContainsToken(request.Headers.Upgrade, "websocket") &&
            HasValidWebSocketKey(request.Headers.SecWebSocketKey) &&
            HeaderContainsToken(request.Headers.SecWebSocketVersion, "13");
        }

        var extendedConnect = httpContext.Features.Get<IHttpExtendedConnectFeature>();
        return HttpMethods.IsConnect(request.Method) &&
            extendedConnect?.IsExtendedConnect == true &&
            string.Equals(extendedConnect.Protocol, "websocket", StringComparison.OrdinalIgnoreCase);
    }

    private static bool HasValidWebSocketKey(
        Microsoft.Extensions.Primitives.StringValues values)
    {
        if (values.Count != 1 || values[0] is not { } value)
        {
            return false;
        }

        Span<byte> decoded = stackalloc byte[16];
        return Convert.TryFromBase64String(value, decoded, out var bytesWritten) &&
            bytesWritten == decoded.Length;
    }

    private static bool HeaderContainsToken(
        Microsoft.Extensions.Primitives.StringValues values,
        string expected)
    {
        foreach (var value in values)
        {
            if (value is null)
            {
                continue;
            }
            foreach (var token in value.Split(','))
            {
                if (string.Equals(token.Trim(), expected, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private static bool ContainsOutOfMemoryException(Exception exception)
    {
        if (exception is OutOfMemoryException)
        {
            return true;
        }
        return exception is AggregateException aggregateException &&
            aggregateException.InnerExceptions.Any(ContainsOutOfMemoryException);
    }

    private static void TryInvokeTelemetry(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
        }
    }

    private static void TrySetCurrent(Activity? activity)
    {
        try
        {
            Activity.Current = activity;
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
        }
    }

    private sealed record RejectionTraceState(
        HttpContext HttpContext,
        Activity? RequestActivity,
        ActivityContext ParentContext,
        DateTimeOffset StartTime);
}

internal sealed class VoiceWebSocketEndpointMetadata
{
    internal static VoiceWebSocketEndpointMetadata Instance { get; } = new();
}
