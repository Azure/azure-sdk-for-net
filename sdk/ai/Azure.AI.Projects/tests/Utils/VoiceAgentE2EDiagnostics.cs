// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using OpenAI.Realtime;

#pragma warning disable AAIP001, OPENAI002

namespace Azure.AI.Projects.Tests.Utils;

internal static class VoiceAgentE2EDiagnostics
{
    internal static AIProjectClient CreateProject(string endpoint)
    {
        AIProjectClientOptions options = new();
        options.AddPolicy(new HttpStatusPolicy(), PipelinePosition.BeforeTransport);
        return new(new Uri(endpoint), new DefaultAzureCredential(), options);
    }

    internal static void LogRealtimeEvent(RealtimeServerUpdate update, AudioTransfer transfer = null)
    {
        if (update is RealtimeServerUpdateResponseOutputAudioDelta audio)
        {
            int bytes = audio.Delta.ToMemory().Length;
            transfer?.Received(bytes);
            Console.WriteLine($"\n[Realtime receive] {update.Kind}: audio bytes={bytes}");
            return;
        }
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(update));
        LogEvent("Realtime", document.RootElement);
        if (update is RealtimeServerUpdateError)
        {
            throw new InvalidOperationException("Realtime service error: " + document.RootElement.GetProperty("error").GetRawText());
        }
    }

    internal static void LogLiveEvent(LiveServerEvent serverEvent, AudioTransfer transfer = null)
    {
        if (serverEvent is LiveServerEventLiveInputTranscriptDelta input)
        {
            transfer?.InputTranscript(input.Delta);
        }
        if (serverEvent is LiveServerEventLiveOutputTranscriptDelta output)
        {
            transfer?.OutputTranscript(output.Delta);
        }
        if (serverEvent is LiveOutputAudioDelta audio)
        {
            int bytes = Convert.FromBase64String(audio.Delta).Length;
            transfer?.Received(bytes);
            Console.WriteLine($"\n[Live receive] session.output_audio.delta: audio bytes={bytes}");
            return;
        }
        if (serverEvent is LiveInputAudioAppend reflected)
        {
            int bytes = Convert.FromBase64String(reflected.Audio).Length;
            transfer?.Reflected(bytes);
            Console.WriteLine($"\n[Live receive] session.input_audio.append: reflected input audio bytes={bytes} (not assistant output)");
            return;
        }
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(
            serverEvent, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));
        LogEvent("Live", document.RootElement);
    }

    private static void LogEvent(string protocol, JsonElement root)
    {
        if (root.ValueKind != JsonValueKind.Object || !root.TryGetProperty("type", out JsonElement typeValue) ||
            typeValue.ValueKind != JsonValueKind.String || string.IsNullOrEmpty(typeValue.GetString()))
        {
            throw new InvalidDataException($"{protocol} event must contain a nonempty string type.");
        }
        string type = typeValue.GetString();
        StringBuilder details = new();
        foreach (string name in new[] { "event_id", "client_event_id", "delegation_id", "delta", "text", "transcript", "reason", "code", "message" })
        {
            if (root.TryGetProperty(name, out JsonElement value) && value.ValueKind == JsonValueKind.String)
            {
                string text = value.GetString();
                details.Append(' ').Append(name).Append('=').Append(text.Length > 512 ? text.Substring(0, 512) + "..." : text);
            }
        }
        foreach (string name in new[] { "session", "response", "item", "delegation", "error", "usage" })
        {
            if (root.TryGetProperty(name, out JsonElement value) && value.ValueKind == JsonValueKind.Object)
            {
                foreach (string field in new[] { "id", "type", "status", "model", "name", "call_id", "arguments", "output", "code", "message", "seconds" })
                {
                    if (value.TryGetProperty(field, out JsonElement fieldValue) &&
                        fieldValue.ValueKind is JsonValueKind.String or JsonValueKind.Number)
                    {
                        string text = fieldValue.ToString();
                        details.Append(' ').Append(name).Append('.').Append(field).Append('=')
                            .Append(text.Length > 512 ? text.Substring(0, 512) + "..." : text);
                    }
                }
            }
        }
        Console.WriteLine($"\n[{protocol} receive] {type}:{details}");
        if (root.TryGetProperty("event", out JsonElement backend) && backend.ValueKind == JsonValueKind.Object)
        {
            LogEvent("Responses backend", backend);
        }
    }

    internal static byte[] ReadPcmWave(Stream stream)
    {
        using BinaryReader reader = new(stream, Encoding.ASCII, leaveOpen: true);
        if (new string(reader.ReadChars(4)) != "RIFF")
        {
            throw new InvalidDataException("A RIFF/WAVE speech file is required.");
        }
        reader.ReadUInt32();
        if (new string(reader.ReadChars(4)) != "WAVE")
        {
            throw new InvalidDataException("A WAVE speech file is required.");
        }
        bool formatVerified = false;
        while (stream.Position + 8 <= stream.Length)
        {
            string chunk = new(reader.ReadChars(4));
            uint length = reader.ReadUInt32();
            long end = stream.Position + length;
            if (end > stream.Length)
            {
                throw new EndOfStreamException("The speech file is truncated.");
            }
            if (chunk == "fmt ")
            {
                ushort format = reader.ReadUInt16();
                ushort channels = reader.ReadUInt16();
                uint rate = reader.ReadUInt32();
                reader.ReadUInt32();
                reader.ReadUInt16();
                formatVerified = format == 1 && channels == 1 && rate == 24000 && reader.ReadUInt16() == 16;
            }
            else if (chunk == "data")
            {
                if (!formatVerified || length == 0 || length % 2 != 0 || length > int.MaxValue)
                {
                    throw new InvalidDataException("Use nonempty mono PCM16LE/24 kHz speech.");
                }
                return reader.ReadBytes((int)length);
            }
            stream.Position = end + (length & 1);
        }
        throw new InvalidDataException("The speech file contains no PCM data.");
    }

    internal static string SpeechWavePath([CallerFilePath] string sourceFile = "")
        => Environment.GetEnvironmentVariable("VOICE_SAMPLE_AUDIO_PATH") ?? Path.GetFullPath(Path.Combine(
            Path.GetDirectoryName(sourceFile), "..", "..", "..", "..", "..", "openai", "Azure.AI.OpenAI", "tests", "Assets",
            "whats_the_weather_pcm16_24khz_mono.wav"));

    internal sealed class AudioTransfer
    {
        private long _input;
        private long _output;
        private long _reflected;
        private readonly StringBuilder _inputText = new();
        private readonly StringBuilder _outputText = new();
        internal long InputBytes => Interlocked.Read(ref _input);
        internal long OutputBytes => Interlocked.Read(ref _output);
        internal long ReflectedBytes => Interlocked.Read(ref _reflected);
        internal string InputText => _inputText.ToString();
        internal string OutputText => _outputText.ToString();
        internal void InputTranscript(string delta) => _inputText.Append(delta);
        internal void OutputTranscript(string delta) => _outputText.Append(delta);

        internal void Sent(int bytes)
        {
            if (bytes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes));
            }
            Interlocked.Add(ref _input, bytes);
        }

        internal void Received(int bytes)
        {
            if (bytes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes));
            }
            Interlocked.Add(ref _output, bytes);
        }

        internal void Reflected(int bytes)
        {
            if (bytes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes));
            }
            Interlocked.Add(ref _reflected, bytes);
        }

        internal void Report(TextWriter output = null)
        {
            output ??= Console.Out;
            output.WriteLine($"Input audio transferred: {InputBytes} bytes ({InputBytes / 1024.0:F2} KiB), {InputBytes / 48000.0:F3}s PCM16LE / 24000 Hz / mono");
            output.WriteLine($"Output audio transferred: {OutputBytes} bytes ({OutputBytes / 1024.0:F2} KiB), {OutputBytes / 48000.0:F3}s PCM16LE / 24000 Hz / mono");
            output.WriteLine($"Reflected input audio received: {ReflectedBytes} bytes ({ReflectedBytes / 1024.0:F2} KiB; not assistant output)");
            long total = checked(InputBytes + OutputBytes + ReflectedBytes);
            output.WriteLine($"Total audio transferred: {total} bytes ({total / 1024.0:F2} KiB; {total / (1024.0 * 1024):F3} MiB)");
            if (_inputText.Length > 0)
            {
                output.WriteLine("[Audio verification] input transcript: " + InputText);
            }
            if (_outputText.Length > 0)
            {
                output.WriteLine("[Audio verification] output transcript: " + OutputText);
            }
        }
    }

    private sealed class HttpStatusPolicy : PipelinePolicy
    {
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            ProcessNext(message, pipeline, currentIndex);
            Report(message);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            await ProcessNextAsync(message, pipeline, currentIndex);
            Report(message);
        }

        private static void Report(PipelineMessage message)
            => Console.WriteLine($"[REST] {message.Request.Method} {message.Request.Uri?.AbsolutePath}: HTTP {message.Response.Status}");
    }
}
