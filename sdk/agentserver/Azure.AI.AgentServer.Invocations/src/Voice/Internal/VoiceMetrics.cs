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
    private static readonly UpDownCounter<long> ActiveConnections = Meter.CreateUpDownCounter<long>(
        "azure.ai.agentserver.invocations.voice.active_connections");
    private static readonly Counter<long> CloseCodes = Meter.CreateCounter<long>(
        "azure.ai.agentserver.invocations.voice.close_codes");

    public static void ConnectionOpened() => ActiveConnections.Add(1);

    public static void ConnectionClosed() => ActiveConnections.Add(-1);

    public static void RecordActivation(string result) =>
        Activations.Add(1, new KeyValuePair<string, object?>("result", result));

    public static void RecordCallback(string kind, long startedTimestamp, bool failed)
    {
        CallbackDuration.Record(
            Stopwatch.GetElapsedTime(startedTimestamp).TotalMilliseconds,
            new KeyValuePair<string, object?>("kind", kind));
        if (failed)
        {
            CallbackErrors.Add(1, new KeyValuePair<string, object?>("kind", kind));
        }
    }

    public static void RecordTerminal(string kind) =>
        ResponseTerminals.Add(1, new KeyValuePair<string, object?>("kind", kind));

    public static void RecordFirstOutput(long startedTimestamp) =>
        FirstOutputDuration.Record(Stopwatch.GetElapsedTime(startedTimestamp).TotalMilliseconds);

    public static void RecordProtocolViolation(int closeCode) =>
        ProtocolViolations.Add(1, new KeyValuePair<string, object?>("close_code", closeCode));

    public static void RecordCloseCode(int closeCode) =>
        CloseCodes.Add(1, new KeyValuePair<string, object?>("code", closeCode));
}
