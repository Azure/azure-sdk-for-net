// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.AI.AgentServer.Invocations.Internal;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// Content-free protocol metrics. Tags are closed, low-cardinality runtime
/// classifications and never include payload text, IDs, caller data, or digits.
/// </summary>
internal static class VoiceMetrics
{
    private static readonly Meter Meter = new(InvocationsTelemetry.SourceName);
    private static readonly Counter<long> Activations = Meter.CreateCounter<long>(
        "azure.ai.agentserver.invocations.voice.activations");
    private static readonly Histogram<double> CallbackDuration = Meter.CreateHistogram<double>(
        "azure.ai.agentserver.invocations.voice.callback.duration",
        unit: "ms");
    private static readonly Counter<long> CallbackErrors = Meter.CreateCounter<long>(
        "azure.ai.agentserver.invocations.voice.callback.errors");
    private static readonly Histogram<double> FirstOutputDuration = Meter.CreateHistogram<double>(
        "azure.ai.agentserver.invocations.voice.first_output.duration",
        unit: "ms");
    private static readonly Counter<long> ResponseTerminals = Meter.CreateCounter<long>(
        "azure.ai.agentserver.invocations.voice.response.terminals");
    private static readonly Counter<long> ProtocolViolations = Meter.CreateCounter<long>(
        "azure.ai.agentserver.invocations.voice.protocol.violations");
    private static readonly ObservableGauge<long> ActiveConnections = Meter.CreateObservableGauge(
        "azure.ai.agentserver.invocations.voice.active_connections",
        () => Interlocked.Read(ref _activeConnections));
    private static readonly Counter<long> SelectedCloseCodes = Meter.CreateCounter<long>(
        "azure.ai.agentserver.invocations.voice.selected_close_codes");
    private static readonly Counter<long> ParentFallbacks = Meter.CreateCounter<long>(
        "azure.ai.agentserver.invocations.voice.trace.parent_fallbacks");
    private static long _activeConnections;

    internal static long ActiveConnectionCount => Interlocked.Read(ref _activeConnections);

    public static void ConnectionOpened(TelemetryCallbackDispatcher dispatcher)
    {
        _ = dispatcher;
        Interlocked.Increment(ref _activeConnections);
    }

    public static void ConnectionClosed(TelemetryCallbackDispatcher dispatcher)
    {
        _ = dispatcher;
        Interlocked.Decrement(ref _activeConnections);
    }

    public static void RecordActivation(TelemetryCallbackDispatcher dispatcher, string result) =>
        InvocationsTelemetry.QueueCallback(dispatcher, () =>
            Activations.Add(1, new KeyValuePair<string, object?>("result", result)));

    public static void RecordCallback(
        TelemetryCallbackDispatcher dispatcher,
        string kind,
        long startedTimestamp,
        bool failed)
    {
        var duration = Stopwatch.GetElapsedTime(startedTimestamp).TotalMilliseconds;
        InvocationsTelemetry.QueueCallback(dispatcher, () =>
        {
            CallbackDuration.Record(
                duration,
                new KeyValuePair<string, object?>("kind", kind));
            if (failed)
            {
                CallbackErrors.Add(1, new KeyValuePair<string, object?>("kind", kind));
            }
        });
    }

    public static void RecordTerminal(TelemetryCallbackDispatcher dispatcher, string kind) =>
        InvocationsTelemetry.QueueCallback(dispatcher, () =>
            ResponseTerminals.Add(1, new KeyValuePair<string, object?>("kind", kind)));

    public static void RecordFirstOutput(TelemetryCallbackDispatcher dispatcher, long startedTimestamp)
    {
        var duration = Stopwatch.GetElapsedTime(startedTimestamp).TotalMilliseconds;
        InvocationsTelemetry.QueueCallback(dispatcher, () => FirstOutputDuration.Record(duration));
    }

    public static void RecordProtocolViolation(TelemetryCallbackDispatcher dispatcher, int closeCode) =>
        InvocationsTelemetry.QueueCallback(dispatcher, () =>
            ProtocolViolations.Add(1, new KeyValuePair<string, object?>("close_code", closeCode)));

    public static void RecordSelectedCloseCode(TelemetryCallbackDispatcher dispatcher, int closeCode) =>
        InvocationsTelemetry.QueueCallback(dispatcher, () =>
            SelectedCloseCodes.Add(1, new KeyValuePair<string, object?>("code", closeCode)));

    public static void RecordParentFallback(TelemetryCallbackDispatcher dispatcher) =>
        InvocationsTelemetry.QueueCallback(dispatcher, () =>
            ParentFallbacks.Add(
                1,
                new KeyValuePair<string, object?>("reason", "connection_activity_pending")));
}
