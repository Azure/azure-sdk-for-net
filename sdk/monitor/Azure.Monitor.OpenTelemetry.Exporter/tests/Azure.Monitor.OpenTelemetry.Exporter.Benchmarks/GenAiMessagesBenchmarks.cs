// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI;

using BenchmarkDotNet.Attributes;

using OpenTelemetry;

/*
Measures the cost of GenAI message attributes (gen_ai.input.messages / gen_ai.output.messages)
of increasing size: the Activity -> TelemetryItem conversion alone, and conversion plus NDJSON
serialization (the request body that is sent to ingestion or written to offline storage).
The gen_ai_input_output_limit_increase experimental switch is enabled for the run, so messages
are kept up to 4 MiB; without it they are truncated at 256 KiB.

Content shapes:
- Ascii: plain ASCII text, written as is by Utf8JsonWriter.
- Base64Blob: messages JSON with a base64 blob part (multimodal). The default encoder escapes '+'
  and '"' as \uXXXX, so the serialized size is a few percent larger than the character count.
- NonAscii: non-ASCII text. The default encoder escapes every non-ASCII character as \uXXXX
  (6 bytes per character), the worst case for serialized size.

Run with:
  dotnet run -c Release -f net10.0 -- --filter *GenAiMessagesBenchmarks*

BenchmarkDotNet v0.15.8, Linux Ubuntu 24.04.4 LTS (Noble Numbat)
Intel Xeon Silver 4114 CPU 2.20GHz (Max: 2.19GHz), 1 CPU, 40 logical and 20 physical cores
  [Host]   : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4
Job=ShortRun  IterationCount=3  LaunchCount=1  WarmupCount=3

Convert costs ~1.2-1.3 us and 1.44 KB per item at every MessageLength: values within the limit
are referenced, not copied. ConvertAndSerialize (both message attributes set to MessageLength):

| MessageLength | Content    | BatchSize | Mean       | Allocated  |
|-------------- |----------- |---------- |-----------:|-----------:|
| 262144        | Ascii      | 1         |    1.47 ms |    2.77 MB |
| 262144        | Base64Blob | 1         |    4.03 ms |    2.99 MB |
| 262144        | NonAscii   | 1         |   19.29 ms |   16.52 MB |
| 262144        | Ascii      | 32        |   42.62 ms |   63.59 MB |
| 262144        | Base64Blob | 32        |  111.55 ms |   68.62 MB |
| 262144        | NonAscii   | 32        |  465.75 ms |  379.84 MB |
| 4194304       | Ascii      | 1         |   28.15 ms |   44.02 MB |
| 4194304       | Base64Blob | 1         |   47.95 ms |   47.44 MB |
| 4194304       | NonAscii   | 1         |  256.41 ms |  264.02 MB |
| 4194304       | Ascii      | 32        |  574.77 ms | 1012.34 MB |
| 4194304       | Base64Blob | 32        | 1619.69 ms | 1090.89 MB |
| 4194304       | NonAscii   | 32        |         NA |         NA |

The 4194304/NonAscii/32 case fails: the ~1.6 GB request body exceeds what
Azure.Core.ArrayBufferWriter<byte> can grow to (OverflowException past ~1 GiB).
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class GenAiMessagesBenchmarks
    {
        private const string InstrumentationKey = "00000000-0000-0000-0000-000000000000";

        private ActivitySource? _activitySource;
        private ActivityListener? _listener;
        private Activity[] _activities = Array.Empty<Activity>();
        private bool _originalIsInputOutputLimitIncreaseEnabled;

        public enum ContentShape
        {
            Ascii,
            Base64Blob,
            NonAscii,
        }

        [Params(8 * 1024, 256 * 1024, 1024 * 1024, 4 * 1024 * 1024)]
        public int MessageLength { get; set; }

        [Params(ContentShape.Ascii, ContentShape.Base64Blob, ContentShape.NonAscii)]
        public ContentShape Content { get; set; }

        [Params(1, 32)]
        public int BatchSize { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _originalIsInputOutputLimitIncreaseEnabled = GenAiTruncationConfig.IsInputOutputLimitIncreaseEnabled;
            GenAiTruncationConfig.IsInputOutputLimitIncreaseEnabled = true;

            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            _listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == nameof(GenAiMessagesBenchmarks),
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };
            ActivitySource.AddActivityListener(_listener);
            _activitySource = new ActivitySource(nameof(GenAiMessagesBenchmarks));

            var message = CreateMessage(Content, MessageLength);

            _activities = Enumerable.Range(0, BatchSize).Select(_ =>
            {
                var activity = _activitySource.StartActivity("chat gpt-4o", ActivityKind.Client)!;
                activity.SetTag("gen_ai.operation.name", "chat");
                activity.SetTag("gen_ai.request.model", "gpt-4o");
                activity.SetTag("gen_ai.input.messages", message);
                activity.SetTag("gen_ai.output.messages", message);
                activity.Stop();
                return activity;
            }).ToArray();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            foreach (var activity in _activities)
            {
                activity.Dispose();
            }

            _activitySource?.Dispose();
            _listener?.Dispose();

            GenAiTruncationConfig.IsInputOutputLimitIncreaseEnabled = _originalIsInputOutputLimitIncreaseEnabled;
        }

        [Benchmark]
        public int Convert()
        {
            var (telemetryItems, _) = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(_activities, _activities.Length), null, InstrumentationKey, 1.0f);
            return telemetryItems.Count;
        }

        [Benchmark]
        public int ConvertAndSerialize()
        {
            var (telemetryItems, _) = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(_activities, _activities.Length), null, InstrumentationKey, 1.0f);
            return HttpPipelineHelper.GetSerializedContent(telemetryItems).Length;
        }

        private static string CreateMessage(ContentShape shape, int length)
        {
            switch (shape)
            {
                case ContentShape.Ascii:
                    return Repeat("The quick brown fox jumps over the lazy dog. ", length);
                case ContentShape.NonAscii:
                    return Repeat("敏捷的棕色狐狸跳过了懒狗。", length);
                default:
                    const string prefix = "[{\"role\":\"user\",\"parts\":[{\"type\":\"text\",\"content\":\"Describe this image\"},{\"type\":\"blob\",\"modality\":\"image\",\"mime_type\":\"image/png\",\"content\":\"";
                    const string suffix = "\"}]}]";
                    var bytes = new byte[Math.Max(1, (length - prefix.Length - suffix.Length) / 4 * 3)];
                    new Random(42).NextBytes(bytes);
                    return prefix + System.Convert.ToBase64String(bytes) + suffix;
            }
        }

        private static string Repeat(string value, int length)
        {
            var builder = new StringBuilder(length + value.Length);
            while (builder.Length < length)
            {
                builder.Append(value);
            }

            return builder.ToString(0, length);
        }
    }
}
