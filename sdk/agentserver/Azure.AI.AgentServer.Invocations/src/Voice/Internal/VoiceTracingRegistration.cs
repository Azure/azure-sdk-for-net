// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
                if (!httpContext.RequestServices.GetRequiredService<VoiceRouteRegistry>().Contains(httpContext))
                {
                    return true;
                }

                RegisterRejectionTrace(httpContext);
                return false;
            };
        });
        services.TryAddSingleton<VoiceRouteRegistry>();
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
        ActivityContext ParentContext,
        DateTimeOffset StartTime,
        string OperationName);
}

internal sealed class VoiceRouteRegistry
{
    private readonly Dictionary<string, TemplateMatcher> _routes = new(StringComparer.OrdinalIgnoreCase);
    private readonly object _gate = new();

    internal void Add(string path)
    {
        var normalizedPath = NormalizePath(path);
        var matcher = CreateMatcher(normalizedPath);
        lock (_gate)
        {
            _routes[normalizedPath] = matcher;
        }
    }

    internal bool Contains(HttpContext httpContext) =>
        MatchesVoiceRoute(new PathString(NormalizePath(httpContext.Request.Path.Value)));

    private bool MatchesVoiceRoute(PathString path)
    {
        lock (_gate)
        {
            foreach (var matcher in _routes.Values)
            {
                if (matcher.TryMatch(path, new RouteValueDictionary()))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static TemplateMatcher CreateMatcher(string pattern) =>
        new(TemplateParser.Parse(pattern.TrimStart('/')), new RouteValueDictionary());

    private static string NormalizePath(string? path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return "/";
        }

        var normalized = path[0] == '/' ? path : $"/{path}";
        return normalized.Length > 1 &&
            normalized[^1] == '/' &&
            normalized[^2] != '/'
                ? normalized[..^1] : normalized;
    }
}
