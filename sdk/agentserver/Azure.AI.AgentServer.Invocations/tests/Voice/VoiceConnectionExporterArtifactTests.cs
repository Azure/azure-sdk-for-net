// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Binary;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Voice;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

[TestFixture]
[NonParallelizable]
public class VoiceConnectionExporterArtifactTests
{
    private const string ActivitySourceName = "Azure.AI.AgentServer.Invocations";
    private const string ConnectionOperationName = "agentserver.connection";
    private const string SessionId = "session_artifact";
    private const string SecretSentinel = "customer-secret-must-not-export";
    private static readonly ActivityTraceId s_traceId =
        ActivityTraceId.CreateFromString("0123456789abcdef0123456789abcdef".AsSpan());
    private static readonly ActivitySpanId s_parentSpanId =
        ActivitySpanId.CreateFromString("0123456789abcdef".AsSpan());

    [Test]
    public async Task OtlpHttpProtobuf_ExportsSemanticConnectionArtifact()
    {
        await using var receiver = await OtlpHttpReceiver.StartAsync();
        var options = new OtlpExporterOptions
        {
            Endpoint = new Uri(receiver.BaseUri, "/v1/traces"),
            Protocol = OtlpExportProtocol.HttpProtobuf,
            ExportProcessorType = ExportProcessorType.Simple,
            TimeoutMilliseconds = 3000,
        };
        using var provider = Sdk.CreateTracerProviderBuilder()
            .AddSource(ActivitySourceName)
            .AddProcessor(new SimpleActivityExportProcessor(new OtlpTraceExporter(options)))
            .Build();

        EmitCompletedConnection();
        Assert.That(provider.ForceFlush(), Is.True);
        var request = await receiver.Request.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var span = OtlpSpanArtifact.ParseSingle(request.Body, ConnectionOperationName);

        Assert.Multiple(() =>
        {
            Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
            Assert.That(request.Uri.AbsolutePath, Is.EqualTo("/v1/traces"));
            Assert.That(request.ContentType, Is.EqualTo("application/x-protobuf"));
            Assert.That(span.TraceId, Is.EqualTo(s_traceId.ToHexString()));
            Assert.That(span.ParentSpanId, Is.EqualTo(s_parentSpanId.ToHexString()));
            Assert.That(span.TraceState, Is.EqualTo("vendor=value"));
            Assert.That(span.Kind, Is.EqualTo(2), "OTLP SpanKind SERVER must be 2.");
            Assert.That(span.Attributes["azure.ai.agentserver.invocations_ws.session_id"], Is.EqualTo(SessionId));
            Assert.That(span.Attributes["azure.ai.agentserver.invocations_ws.close_code"], Is.EqualTo(1000L));
            Assert.That(span.Attributes["bridge.outcome"], Is.EqualTo("completed"));
            Assert.That(span.Attributes, Does.Not.ContainKey("error.type"));
            Assert.That(Encoding.UTF8.GetString(request.Body), Does.Not.Contain(SecretSentinel));
        });
    }

    [Test]
    public void AzureMonitor_ExportsRequestEnvelopeArtifact()
    {
        byte[]? requestBody = null;
        var transport = MockTransport.FromMessageCallback(message =>
        {
            using var stream = new MemoryStream();
            message.Request.Content.WriteTo(stream, CancellationToken.None);
            requestBody = stream.ToArray();
            return new MockResponse(200).SetContent(
                "{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}");
        });
        var options = new AzureMonitorExporterOptions
        {
            ConnectionString =
                "InstrumentationKey=00000000-0000-0000-0000-000000000000;" +
                "IngestionEndpoint=https://ingestion.test/",
            DisableOfflineStorage = true,
            SamplingRatio = 1.0F,
            TracesPerSecond = null,
            Transport = transport,
        };
        using var provider = Sdk.CreateTracerProviderBuilder()
            .AddSource(ActivitySourceName)
            .AddProcessor(new SimpleActivityExportProcessor(new AzureMonitorTraceExporter(options)))
            .Build();

        EmitCompletedConnection();
        Assert.That(provider.ForceFlush(), Is.True);
        Assert.That(requestBody, Is.Not.Null);
        var envelopeText = Encoding.UTF8.GetString(requestBody!)
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Single(IsAzureMonitorRequestEnvelope);
        using var document = JsonDocument.Parse(envelopeText);
        var envelope = document.RootElement;
        var tags = envelope.GetProperty("tags");
        var baseData = envelope.GetProperty("data").GetProperty("baseData");
        var properties = baseData.GetProperty("properties");

        Assert.Multiple(() =>
        {
            Assert.That(envelope.GetProperty("name").GetString(), Is.EqualTo("Request"));
            Assert.That(tags.GetProperty("ai.operation.id").GetString(), Is.EqualTo(s_traceId.ToHexString()));
            Assert.That(tags.GetProperty("ai.operation.parentId").GetString(), Is.EqualTo(s_parentSpanId.ToHexString()));
            Assert.That(baseData.GetProperty("name").GetString(), Is.EqualTo(ConnectionOperationName));
            Assert.That(baseData.GetProperty("success").GetBoolean(), Is.True);
            Assert.That(properties.GetProperty("azure.ai.agentserver.invocations_ws.session_id").GetString(),
                Is.EqualTo(SessionId));
            Assert.That(properties.GetProperty("azure.ai.agentserver.invocations_ws.close_code").GetString(),
                Is.EqualTo("1000"));
            Assert.That(properties.GetProperty("bridge.outcome").GetString(), Is.EqualTo("completed"));
            Assert.That(properties.TryGetProperty("error.type", out _), Is.False);
            Assert.That(Encoding.UTF8.GetString(requestBody!), Does.Not.Contain(SecretSentinel));
        });
    }

    private static void EmitCompletedConnection()
    {
        var headers = new HeaderDictionary
        {
            [PlatformHeaders.TraceParent] = $"00-{s_traceId}-{s_parentSpanId}-01",
            ["tracestate"] = "vendor=value",
            ["baggage"] = $"customer-secret={SecretSentinel}",
        };
        var telemetry = VoiceConnectionTelemetry.Start(headers);

        telemetry.Complete(
            SessionId,
            closeCode: 1000,
            errorCode: null,
            handlerOutcome: null,
            durationMs: 42);
    }

    private static bool IsAzureMonitorRequestEnvelope(string value)
    {
        using var document = JsonDocument.Parse(value);
        return document.RootElement.GetProperty("name").GetString() == "Request";
    }

    private sealed class OtlpHttpReceiver : IAsyncDisposable
    {
        private readonly WebApplication _application;

        private OtlpHttpReceiver(WebApplication application, Uri baseUri)
        {
            _application = application;
            BaseUri = baseUri;
        }

        public Uri BaseUri { get; }

        public TaskCompletionSource<CapturedHttpRequest> Request { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static async Task<OtlpHttpReceiver> StartAsync()
        {
            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseUrls("http://127.0.0.1:0");
            builder.Logging.ClearProviders();
            var application = builder.Build();
            OtlpHttpReceiver? receiver = null;
            application.MapPost("/{**path}", async context =>
            {
                using var stream = new MemoryStream();
                await context.Request.Body.CopyToAsync(stream, context.RequestAborted);
                receiver!.Request.TrySetResult(new CapturedHttpRequest(
                    HttpMethod.Post,
                    new Uri($"http://receiver.test{context.Request.Path}"),
                    context.Request.ContentType,
                    stream.ToArray()));
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.ContentType = "application/x-protobuf";
            });
            await application.StartAsync();
            var addresses = application.Services.GetRequiredService<IServer>()
                .Features.Get<IServerAddressesFeature>()!;
            receiver = new OtlpHttpReceiver(application, new Uri(addresses.Addresses.Single()));
            return receiver;
        }

        public async ValueTask DisposeAsync()
        {
            await _application.StopAsync();
            await _application.DisposeAsync();
        }
    }

    private sealed record CapturedHttpRequest(
        HttpMethod Method,
        Uri Uri,
        string? ContentType,
        byte[] Body);

    private sealed record OtlpSpanArtifact(
        string TraceId,
        string ParentSpanId,
        string TraceState,
        int Kind,
        IReadOnlyDictionary<string, object> Attributes)
    {
        internal static OtlpSpanArtifact ParseSingle(byte[] payload, string operationName)
        {
            var spans = new List<OtlpSpanArtifact>();
            ParseRepeatedMessage(payload, fieldNumber: 1, resourceSpans =>
                ParseRepeatedMessage(resourceSpans, fieldNumber: 2, scopeSpans =>
                    ParseRepeatedMessage(scopeSpans, fieldNumber: 2, span =>
                    {
                        var parsed = ParseSpan(span);
                        if (parsed.Name == operationName)
                        {
                            spans.Add(parsed.Artifact);
                        }
                    })));
            Assert.That(spans, Has.Count.EqualTo(1));
            return spans[0];
        }

        private static (string Name, OtlpSpanArtifact Artifact) ParseSpan(ReadOnlySpan<byte> span)
        {
            var reader = new ProtobufReader(span);
            var traceId = string.Empty;
            var parentSpanId = string.Empty;
            var traceState = string.Empty;
            var name = string.Empty;
            var kind = 0;
            var attributes = new Dictionary<string, object>(StringComparer.Ordinal);
            while (reader.TryReadField(out var field))
            {
                switch (field.Number)
                {
                    case 1:
                        traceId = Convert.ToHexString(field.Bytes).ToLowerInvariant();
                        break;
                    case 3:
                        traceState = Encoding.UTF8.GetString(field.Bytes);
                        break;
                    case 4:
                        parentSpanId = Convert.ToHexString(field.Bytes).ToLowerInvariant();
                        break;
                    case 5:
                        name = Encoding.UTF8.GetString(field.Bytes);
                        break;
                    case 6:
                        kind = checked((int)field.Varint);
                        break;
                    case 9:
                        var attribute = ParseAttribute(field.Bytes);
                        attributes.Add(attribute.Key, attribute.Value);
                        break;
                }
            }
            return (name, new OtlpSpanArtifact(traceId, parentSpanId, traceState, kind, attributes));
        }

        private static KeyValuePair<string, object> ParseAttribute(ReadOnlySpan<byte> message)
        {
            var reader = new ProtobufReader(message);
            var key = string.Empty;
            object? value = null;
            while (reader.TryReadField(out var field))
            {
                if (field.Number == 1)
                {
                    key = Encoding.UTF8.GetString(field.Bytes);
                }
                else if (field.Number == 2)
                {
                    value = ParseAnyValue(field.Bytes);
                }
            }
            return new KeyValuePair<string, object>(key, value!);
        }

        private static object ParseAnyValue(ReadOnlySpan<byte> message)
        {
            var reader = new ProtobufReader(message);
            while (reader.TryReadField(out var field))
            {
                return field.Number switch
                {
                    1 => Encoding.UTF8.GetString(field.Bytes),
                    2 => field.Varint != 0,
                    3 => unchecked((long)field.Varint),
                    4 => BitConverter.Int64BitsToDouble(unchecked((long)field.Fixed64)),
                    _ => throw new InvalidDataException($"Unsupported OTLP AnyValue field {field.Number}."),
                };
            }
            throw new InvalidDataException("OTLP AnyValue was empty.");
        }

        private static void ParseRepeatedMessage(
            ReadOnlySpan<byte> message,
            int fieldNumber,
            MessageParser parse)
        {
            var reader = new ProtobufReader(message);
            while (reader.TryReadField(out var field))
            {
                if (field.Number == fieldNumber)
                {
                    parse(field.Bytes);
                }
            }
        }

        private delegate void MessageParser(ReadOnlySpan<byte> message);
    }

    private ref struct ProtobufReader
    {
        private readonly ReadOnlySpan<byte> _message;
        private int _offset;

        internal ProtobufReader(ReadOnlySpan<byte> message) => _message = message;

        internal bool TryReadField(out ProtobufField field)
        {
            if (_offset >= _message.Length)
            {
                field = default;
                return false;
            }

            var tag = ReadVarint();
            var number = checked((int)(tag >> 3));
            var wireType = checked((int)(tag & 0x07));
            field = wireType switch
            {
                0 => new ProtobufField(number, ReadVarint(), 0, default),
                1 => new ProtobufField(number, 0, ReadFixed64(), default),
                2 => new ProtobufField(number, 0, 0, ReadBytes()),
                5 => new ProtobufField(number, 0, ReadFixed32(), default),
                _ => throw new InvalidDataException($"Unsupported protobuf wire type {wireType}."),
            };
            return true;
        }

        private ulong ReadVarint()
        {
            ulong value = 0;
            for (var shift = 0; shift < 64; shift += 7)
            {
                if (_offset >= _message.Length)
                {
                    throw new EndOfStreamException();
                }
                var current = _message[_offset++];
                value |= (ulong)(current & 0x7f) << shift;
                if ((current & 0x80) == 0)
                {
                    return value;
                }
            }
            throw new InvalidDataException("Protobuf varint exceeded 64 bits.");
        }

        private ReadOnlySpan<byte> ReadBytes()
        {
            var length = checked((int)ReadVarint());
            if (length > _message.Length - _offset)
            {
                throw new EndOfStreamException();
            }
            var value = _message.Slice(_offset, length);
            _offset += length;
            return value;
        }

        private ulong ReadFixed64()
        {
            if (_offset + sizeof(ulong) > _message.Length)
            {
                throw new EndOfStreamException();
            }
            var value = BinaryPrimitives.ReadUInt64LittleEndian(_message[_offset..]);
            _offset += sizeof(ulong);
            return value;
        }

        private uint ReadFixed32()
        {
            if (_offset + sizeof(uint) > _message.Length)
            {
                throw new EndOfStreamException();
            }
            var value = BinaryPrimitives.ReadUInt32LittleEndian(_message[_offset..]);
            _offset += sizeof(uint);
            return value;
        }
    }

    private readonly ref struct ProtobufField
    {
        internal ProtobufField(
            int number,
            ulong varint,
            ulong fixed64,
            ReadOnlySpan<byte> bytes)
        {
            Number = number;
            Varint = varint;
            Fixed64 = fixed64;
            Bytes = bytes;
        }

        internal int Number { get; }
        internal ulong Varint { get; }
        internal ulong Fixed64 { get; }
        internal ReadOnlySpan<byte> Bytes { get; }
    }
}
