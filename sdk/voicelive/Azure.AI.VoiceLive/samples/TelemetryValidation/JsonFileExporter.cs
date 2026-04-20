// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using OpenTelemetry;

namespace Azure.AI.VoiceLive.Samples;

/// <summary>
/// An OpenTelemetry exporter that writes each completed span as a single JSON object
/// (one per line, NDJSON) to a file. Used to capture traces for offline comparison
/// with the Python ConsoleSpanExporter output.
///
/// Usage:
///   .AddProcessor(new SimpleExportActivityProcessor(new JsonFileExporter("csharp_traces.json")))
/// </summary>
internal sealed class JsonFileExporter : BaseExporter<Activity>
{
    private static readonly string s_otelSdkVersion =
        typeof(BaseExporter<Activity>).Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion?.Split('+')[0]
        ?? typeof(BaseExporter<Activity>).Assembly.GetName().Version?.ToString(3)
        ?? "1.0.0";

    private readonly StreamWriter _writer;
    private bool _disposed;
    private bool _firstSpan = true;

    public JsonFileExporter(string filePath)
    {
        _writer = new StreamWriter(filePath, append: false) { AutoFlush = false };
    }

    public override ExportResult Export(in Batch<Activity> batch)
    {
        if (_disposed)
            return ExportResult.Failure;

        foreach (Activity activity in batch)
        {
            if (!_firstSpan)
                _writer.WriteLine(",");
            _writer.Write(SerializeActivity(activity));
            _firstSpan = false;
        }

        _writer.Flush();
        return ExportResult.Success;
    }

    protected override bool OnShutdown(int timeoutMilliseconds)
    {
        _writer.Flush();
        return true;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && !_disposed)
        {
            _writer.Flush();
            _writer.Dispose();
            _disposed = true;
        }
        base.Dispose(disposing);
    }

    // ── Serialization ──────────────────────────────────────────────────────────

    private static string SerializeActivity(Activity activity)
    {
        using var ms = new System.IO.MemoryStream();
        using var writer = new Utf8JsonWriter(ms, new JsonWriterOptions { Indented = true });

        writer.WriteStartObject();

        writer.WriteString("name", activity.DisplayName);

        // Python-style context block with 0x-prefixed hex IDs
        writer.WritePropertyName("context");
        writer.WriteStartObject();
        writer.WriteString("trace_id", "0x" + activity.TraceId.ToString());
        writer.WriteString("span_id", "0x" + activity.SpanId.ToString());
        writer.WriteString("trace_state", "[]");
        writer.WriteEndObject();

        writer.WriteString("kind", FormatKind(activity.Kind));

        if (activity.ParentSpanId != default)
            writer.WriteString("parent_id", "0x" + activity.ParentSpanId.ToString());

        writer.WriteString("start_time", activity.StartTimeUtc.ToString("O"));
        writer.WriteString("end_time", activity.StartTimeUtc.Add(activity.Duration).ToString("O"));

        // Status with uppercase status_code to match Python
        writer.WritePropertyName("status");
        writer.WriteStartObject();
        writer.WriteString("status_code", activity.Status.ToString().ToUpperInvariant());
        if (activity.StatusDescription is { Length: > 0 } desc)
            writer.WriteString("description", desc);
        writer.WriteEndObject();

        // Tags / attributes
        writer.WritePropertyName("attributes");
        writer.WriteStartObject();
        foreach (KeyValuePair<string, object?> tag in activity.TagObjects)
        {
            writer.WritePropertyName(tag.Key);
            WriteValue(writer, tag.Value);
        }
        writer.WriteEndObject();

        // Events (always written, even if empty, to match Python ConsoleSpanExporter)
        writer.WritePropertyName("events");
        writer.WriteStartArray();
        foreach (ActivityEvent evt in activity.Events)
        {
            writer.WriteStartObject();
            writer.WriteString("name", evt.Name);
            writer.WriteString("timestamp", evt.Timestamp.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ"));
            writer.WritePropertyName("attributes");
            writer.WriteStartObject();
            foreach (KeyValuePair<string, object?> tag in evt.Tags)
            {
                writer.WritePropertyName(tag.Key);
                WriteValue(writer, tag.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
        writer.WriteEndArray();

        // Links (always written, even if empty, to match Python ConsoleSpanExporter)
        writer.WritePropertyName("links");
        writer.WriteStartArray();
        foreach (ActivityLink link in activity.Links)
        {
            writer.WriteStartObject();
            writer.WriteString("trace_id", "0x" + link.Context.TraceId.ToString());
            writer.WriteString("span_id", "0x" + link.Context.SpanId.ToString());
            writer.WriteEndObject();
        }
        writer.WriteEndArray();

        // Resource block to match Python ConsoleSpanExporter
        writer.WritePropertyName("resource");
        writer.WriteStartObject();
        writer.WritePropertyName("attributes");
        writer.WriteStartObject();
        writer.WriteString("telemetry.sdk.language", "dotnet");
        writer.WriteString("telemetry.sdk.name", "opentelemetry");
        writer.WriteString("telemetry.sdk.version", s_otelSdkVersion);
        writer.WriteString("service.name", "unknown_service");
        writer.WriteEndObject();
        writer.WriteString("schema_url", "");
        writer.WriteEndObject();

        writer.WriteEndObject();
        writer.Flush();

        return System.Text.Encoding.UTF8.GetString(ms.ToArray());
    }

    private static string FormatKind(ActivityKind kind) => kind switch
    {
        ActivityKind.Client => "SpanKind.CLIENT",
        ActivityKind.Server => "SpanKind.SERVER",
        ActivityKind.Producer => "SpanKind.PRODUCER",
        ActivityKind.Consumer => "SpanKind.CONSUMER",
        _ => "SpanKind.INTERNAL"
    };

    private static void WriteValue(Utf8JsonWriter writer, object? value)
    {
        switch (value)
        {
            case null:
                writer.WriteNullValue();
                break;
            case string s:
                writer.WriteStringValue(s);
                break;
            case bool b:
                writer.WriteBooleanValue(b);
                break;
            case int i:
                writer.WriteNumberValue(i);
                break;
            case long l:
                writer.WriteNumberValue(l);
                break;
            case double d:
                writer.WriteNumberValue(d);
                break;
            case float f:
                writer.WriteNumberValue(f);
                break;
            default:
                writer.WriteStringValue(value.ToString());
                break;
        }
    }
}
