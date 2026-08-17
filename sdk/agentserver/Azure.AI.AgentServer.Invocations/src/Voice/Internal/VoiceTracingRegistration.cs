// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenTelemetry.Instrumentation.AspNetCore;

namespace Azure.AI.AgentServer.Invocations.Voice;

internal static class VoiceTracingRegistration
{
    private static readonly ActivitySource s_activitySource = new(InvocationsActivitySource.DefaultName);
    private static readonly object s_endpointEntered = new();
    private static readonly object s_rejectionTraceRegistered = new();
    private static readonly AsyncLocal<object?> s_rejectionStartToken = new();

    internal static void Add(IServiceCollection services)
    {
        services.PostConfigure<AspNetCoreTraceInstrumentationOptions>(options =>
        {
            var applicationFilter = options.Filter;
            options.Filter = httpContext =>
            {
                var applicationTracingEnabled = applicationFilter?.Invoke(httpContext) ?? true;
                if (!applicationTracingEnabled || !IsVoiceWebSocketUpgrade(httpContext))
                {
                    return applicationTracingEnabled;
                }

                RegisterRejectionTrace(httpContext);
                return false;
            };
        });
        services.TryAddSingleton<VoiceRouteRegistry>();
    }

    internal static void MarkEndpointEntered(HttpContext httpContext) =>
        httpContext.Items[s_endpointEntered] = null;

    private static void RegisterRejectionTrace(HttpContext httpContext)
    {
        if (!httpContext.Items.TryAdd(s_rejectionTraceRegistered, null))
        {
            return;
        }

        var requestActivity = Activity.Current;
        var parentContext = requestActivity is not null &&
            requestActivity.ParentSpanId != default
                ? new ActivityContext(
                    requestActivity.TraceId,
                    requestActivity.ParentSpanId,
                    requestActivity.ActivityTraceFlags,
                    requestActivity.TraceStateString,
                    isRemote: true)
                : default;
        var startTime = requestActivity is null
            ? DateTimeOffset.UtcNow
            : new DateTimeOffset(requestActivity.StartTimeUtc);
        var state = new RejectionTraceState(
            httpContext,
            parentContext,
            startTime,
            $"{httpContext.Request.Method} {httpContext.Request.Path}");
        httpContext.Response.OnCompleted(
            static state =>
            {
                EmitRejectionTrace((RejectionTraceState)state);
                return Task.CompletedTask;
            },
            state);
    }

    private static void EmitRejectionTrace(RejectionTraceState state)
    {
        if (state.HttpContext.Items.ContainsKey(s_endpointEntered))
        {
            return;
        }

        var previousActivity = Activity.Current;
        var previousStartToken = s_rejectionStartToken.Value;
        var startToken = new object();
        s_rejectionStartToken.Value = startToken;
        Activity? activity = null;
        Activity? startedActivity = null;
        EventHandler<ActivityChangedEventArgs> captureStartedActivity = (_, args) =>
        {
            if (!ReferenceEquals(s_rejectionStartToken.Value, startToken))
            {
                return;
            }

            var candidate = IsRejectionActivity(args.Current, state.OperationName)
                ? args.Current
                : IsRejectionActivity(args.Previous, state.OperationName)
                    ? args.Previous
                    : null;
            if (candidate is not null)
            {
                startedActivity = candidate;
            }
        };
        Activity.CurrentChanged += captureStartedActivity;
        try
        {
            var statusCode = state.HttpContext.Response.StatusCode;
            var tags = new ActivityTagsCollection
            {
                ["http.request.method"] = state.HttpContext.Request.Method,
                ["url.path"] = state.HttpContext.Request.Path.Value,
                ["http.response.status_code"] = statusCode,
            };
            TrySetCurrent(null);
            try
            {
                activity = s_activitySource.StartActivity(
                    state.OperationName,
                    ActivityKind.Server,
                    state.ParentContext,
                    tags,
                    startTime: state.StartTime);
            }
            catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
            {
                activity = startedActivity ?? Activity.Current;
                if (!IsRejectionActivity(activity, state.OperationName))
                {
                    activity = null;
                }
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
            s_rejectionStartToken.Value = previousStartToken;
            TrySetCurrent(previousActivity);
            if (activity is not null)
            {
                TryInvokeTelemetry(activity.Stop);
            }
            TrySetCurrent(previousActivity);
        }
    }

    private static bool IsRejectionActivity(Activity? activity, string operationName) =>
        activity?.Source.Name == InvocationsActivitySource.DefaultName &&
        activity.OperationName == operationName;

    private static bool IsVoiceWebSocketUpgrade(HttpContext httpContext)
    {
        var request = httpContext.Request;
        return HttpMethods.IsGet(request.Method) &&
            httpContext.RequestServices.GetRequiredService<VoiceRouteRegistry>()
                .Contains(request.Path) &&
            HeaderContainsToken(request.Headers.Connection, "upgrade") &&
            HeaderContainsToken(request.Headers.Upgrade, "websocket") &&
            HasValidWebSocketKey(request.Headers.SecWebSocketKey) &&
            HeaderContainsToken(request.Headers.SecWebSocketVersion, "13");
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
        ActivityContext ParentContext,
        DateTimeOffset StartTime,
        string OperationName);
}

internal sealed class VoiceRouteRegistry
{
    private readonly HashSet<string> _paths = new(StringComparer.OrdinalIgnoreCase);
    private readonly object _gate = new();

    internal void Add(string path)
    {
        lock (_gate)
        {
            _paths.Add(path);
        }
    }

    internal bool Contains(PathString path)
    {
        lock (_gate)
        {
            return path.Value is { } value && _paths.Contains(value);
        }
    }
}
