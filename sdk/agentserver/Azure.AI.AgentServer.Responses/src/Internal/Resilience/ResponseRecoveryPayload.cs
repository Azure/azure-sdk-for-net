// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// The typed, fail-closed persisted recovery payload for a resilient background response.
/// <para>
/// This is the .NET port of the Python <c>ResilientResponseInput</c> boundary
/// (<c>hosting/_resilient_input.py</c>). It captures exactly the fields that must survive a
/// process crash so the response can be re-invoked (or marked failed) in a subsequent process
/// lifetime. Everything else (<c>store</c>, <c>stream</c>, <c>background</c>, <c>model</c>,
/// <c>previous_response_id</c>, the resolved conversation id, and the resolved input items) is
/// deterministically re-derived from <see cref="Request"/> on recovery and is therefore NOT
/// persisted here.
/// </para>
/// <para>
/// Serialization is JSON-only and fail-closed: no process-local runtime references are ever
/// stored, <see cref="ToTaskInput"/> performs a JSON-safety round-trip so a non-serializable
/// field fails loudly at persist time rather than silently leaking, and
/// <see cref="FromTaskInput(JsonElement)"/> rejects missing/malformed required fields with a
/// deterministic <see cref="RecoveryPayloadFormatException"/> (never a partial re-invoke).
/// </para>
/// </summary>
internal sealed class ResponseRecoveryPayload
{
    /// <summary>Disposition: re-invoke the handler in the next lifetime (Row 1).</summary>
    public const string DispositionReinvoke = "re-invoke";

    /// <summary>Disposition: mark the response failed in the next lifetime (Rows 2/3).</summary>
    public const string DispositionMarkFailed = "mark-failed";

    // Wire key constants — must match the Python schema byte-for-byte.
    private const string KResponseId = "response_id";
    private const string KDisposition = "disposition";
    private const string KRequest = "request";
    private const string KAgentReference = "agent_reference";
    private const string KAgentSessionId = "agent_session_id";
    private const string KUserIdKey = "user_id_key";
    private const string KCallId = "call_id";
    private const string KClientHeaders = "client_headers";
    private const string KQueryParameters = "query_parameters";

    private static readonly ModelReaderWriterOptions JsonOptions = ModelReaderWriterOptions.Json;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResponseRecoveryPayload"/> class.
    /// </summary>
    public ResponseRecoveryPayload(
        string responseId,
        string disposition,
        CreateResponse request,
        AgentReference? agentReference = null,
        string? agentSessionId = null,
        string? userIdKey = null,
        string? callId = null,
        IReadOnlyDictionary<string, string>? clientHeaders = null,
        IReadOnlyDictionary<string, string>? queryParameters = null)
    {
        Argument.AssertNotNullOrEmpty(responseId, nameof(responseId));
        Argument.AssertNotNull(request, nameof(request));

        ResponseId = responseId;
        Disposition = string.IsNullOrEmpty(disposition) ? DispositionReinvoke : disposition;
        Request = request;
        AgentReference = agentReference;
        AgentSessionId = agentSessionId;
        UserIdKey = userIdKey;
        CallId = callId;
        ClientHeaders = clientHeaders ?? EmptyStringMap;
        QueryParameters = queryParameters ?? EmptyStringMap;
    }

    private static readonly IReadOnlyDictionary<string, string> EmptyStringMap =
        new Dictionary<string, string>(StringComparer.Ordinal);

    /// <summary>Gets the stable response id (<c>caresp_...</c>). Persisted; never re-derived.</summary>
    public string ResponseId { get; }

    /// <summary>
    /// Gets the recovery disposition (<see cref="DispositionReinvoke"/> or
    /// <see cref="DispositionMarkFailed"/>). Persisted; never re-derived.
    /// </summary>
    public string Disposition { get; }

    /// <summary>
    /// Gets the full original request. Persisted; the source of truth from which all
    /// re-derived fields (store/stream/background/model/previous_response_id/conversation
    /// id/input items) are recomputed on recovery.
    /// </summary>
    public CreateResponse Request { get; }

    /// <summary>Gets the normalized agent reference, if any. Persisted; never re-derived.</summary>
    public AgentReference? AgentReference { get; }

    /// <summary>Gets the agent session id, if any. Persisted; never re-derived.</summary>
    public string? AgentSessionId { get; }

    /// <summary>
    /// Gets the platform user id key. Persisted so the exact same identity pair is replayed
    /// against storage on recovery.
    /// </summary>
    public string? UserIdKey { get; }

    /// <summary>
    /// Gets the platform per-request call id. Persisted so the exact same identity pair is
    /// replayed against storage on recovery.
    /// </summary>
    public string? CallId { get; }

    /// <summary>
    /// Gets the forwarded client headers. Persisted verbatim (never dropped to an empty map)
    /// so a recovered handler observes the identical request shape.
    /// </summary>
    public IReadOnlyDictionary<string, string> ClientHeaders { get; }

    /// <summary>
    /// Gets the request query parameters. Persisted verbatim so a recovered handler observes
    /// the identical request shape.
    /// </summary>
    public IReadOnlyDictionary<string, string> QueryParameters { get; }

    /// <summary>
    /// Serializes this payload to the JSON task-input representation. Performs a JSON-safety
    /// round-trip: if any field is not JSON-serializable, this throws
    /// <see cref="RecoveryPayloadFormatException"/> immediately rather than silently persisting
    /// a corrupt/non-serializable payload (matches the Python <c>json.dumps</c> guard).
    /// </summary>
    public BinaryData ToTaskInput()
    {
        try
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                writer.WriteStartObject();

                writer.WriteString(KResponseId, ResponseId);
                writer.WriteString(KDisposition, Disposition);

                writer.WritePropertyName(KRequest);
                ((IJsonModel<CreateResponse>)Request).Write(writer, JsonOptions);

                writer.WritePropertyName(KAgentReference);
                if (AgentReference is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IJsonModel<AgentReference>)AgentReference).Write(writer, JsonOptions);
                }

                WriteNullableString(writer, KAgentSessionId, AgentSessionId);
                WriteNullableString(writer, KUserIdKey, UserIdKey);
                WriteNullableString(writer, KCallId, CallId);

                WriteStringMap(writer, KClientHeaders, ClientHeaders);
                WriteStringMap(writer, KQueryParameters, QueryParameters);

                writer.WriteEndObject();
            }

            byte[] bytes = stream.ToArray();

            // JSON-safety guard: re-parse to guarantee the persisted bytes are valid JSON.
            using (JsonDocument.Parse(bytes))
            {
            }

            return new BinaryData(bytes);
        }
        catch (Exception ex) when (ex is not RecoveryPayloadFormatException)
        {
            throw new RecoveryPayloadFormatException(
                $"Failed to serialize resilient recovery payload for response '{ResponseId}': {ex.Message}",
                ex);
        }
    }

    /// <summary>
    /// Deserializes a recovery payload from its JSON task-input representation. Fail-closed:
    /// a missing or wrong-typed required field (<c>response_id</c> / <c>request</c>) throws
    /// <see cref="RecoveryPayloadFormatException"/> so the caller marks the response failed
    /// rather than re-invoking with partial input. Absent optional fields default to
    /// <see langword="null"/> / empty; an absent or empty <c>disposition</c> defaults to
    /// <see cref="DispositionReinvoke"/> for backward compatibility.
    /// </summary>
    public static ResponseRecoveryPayload FromTaskInput(BinaryData taskInput)
    {
        Argument.AssertNotNull(taskInput, nameof(taskInput));
        try
        {
            using JsonDocument doc = JsonDocument.Parse(taskInput.ToMemory());
            return FromTaskInput(doc.RootElement);
        }
        catch (JsonException ex)
        {
            throw new RecoveryPayloadFormatException(
                $"Resilient recovery payload is not valid JSON: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Deserializes a recovery payload from an already-parsed JSON element. See
    /// <see cref="FromTaskInput(BinaryData)"/> for fail-closed semantics.
    /// </summary>
    public static ResponseRecoveryPayload FromTaskInput(JsonElement root)
    {
        if (root.ValueKind != JsonValueKind.Object)
        {
            throw new RecoveryPayloadFormatException(
                $"Resilient recovery payload must be a JSON object, got '{root.ValueKind}'.");
        }

        string responseId = RequireNonEmptyString(root, KResponseId);
        CreateResponse request = RequireRequest(root);

        string disposition = TryGetString(root, KDisposition) ?? DispositionReinvoke;
        if (string.IsNullOrEmpty(disposition))
        {
            disposition = DispositionReinvoke;
        }

        // Fail-closed (FR-026/027/028): an unrecognized disposition token must NOT silently dispatch
        // a re-invoke (the least-safe outcome — it runs handler side effects). Reject it so the
        // scanner skips the corrupt entry rather than acting on ambiguous intent.
        if (disposition is not (DispositionReinvoke or DispositionMarkFailed))
        {
            throw new RecoveryPayloadFormatException(
                $"Resilient recovery payload has an unrecognized disposition '{disposition}'; "
                + $"expected '{DispositionReinvoke}' or '{DispositionMarkFailed}'.");
        }

        AgentReference? agentReference = null;
        if (root.TryGetProperty(KAgentReference, out var arElement)
            && arElement.ValueKind == JsonValueKind.Object)
        {
            agentReference = ModelReaderWriter.Read<AgentReference>(
                BinaryData.FromString(arElement.GetRawText()), JsonOptions, AzureAIAgentServerResponsesContext.Default);
        }

        return new ResponseRecoveryPayload(
            responseId,
            disposition,
            request,
            agentReference,
            agentSessionId: TryGetString(root, KAgentSessionId),
            userIdKey: TryGetString(root, KUserIdKey),
            callId: TryGetString(root, KCallId),
            clientHeaders: ReadStringMap(root, KClientHeaders),
            queryParameters: ReadStringMap(root, KQueryParameters));
    }

    private static string RequireNonEmptyString(JsonElement root, string key)
    {
        if (!root.TryGetProperty(key, out var element)
            || element.ValueKind != JsonValueKind.String
            || string.IsNullOrEmpty(element.GetString()))
        {
            throw new RecoveryPayloadFormatException(
                $"Resilient recovery payload is missing required string field '{key}'.");
        }

        return element.GetString()!;
    }

    private static CreateResponse RequireRequest(JsonElement root)
    {
        if (!root.TryGetProperty(KRequest, out var element)
            || element.ValueKind != JsonValueKind.Object)
        {
            throw new RecoveryPayloadFormatException(
                $"Resilient recovery payload is missing required object field '{KRequest}'.");
        }

        try
        {
            CreateResponse? request = ModelReaderWriter.Read<CreateResponse>(
                BinaryData.FromString(element.GetRawText()), JsonOptions, AzureAIAgentServerResponsesContext.Default);
            if (request is null)
            {
                throw new RecoveryPayloadFormatException(
                    $"Resilient recovery payload '{KRequest}' could not be deserialized.");
            }

            return request;
        }
        catch (Exception ex) when (ex is not RecoveryPayloadFormatException)
        {
            throw new RecoveryPayloadFormatException(
                $"Resilient recovery payload '{KRequest}' could not be deserialized: {ex.Message}", ex);
        }
    }

    private static string? TryGetString(JsonElement root, string key)
    {
        if (root.TryGetProperty(key, out var element) && element.ValueKind == JsonValueKind.String)
        {
            return element.GetString();
        }

        return null;
    }

    private static IReadOnlyDictionary<string, string> ReadStringMap(JsonElement root, string key)
    {
        if (!root.TryGetProperty(key, out var element) || element.ValueKind != JsonValueKind.Object)
        {
            return EmptyStringMap;
        }

        // Rebuild with OrdinalIgnoreCase to preserve the case-insensitive lookup semantics the
        // handler observed on the original invocation (ingress builds both the client-header and
        // query maps with OrdinalIgnoreCase). The comparer is not carried in JSON, so it must be
        // re-established here on read.
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.Value.ValueKind == JsonValueKind.String)
            {
                map[prop.Name] = prop.Value.GetString()!;
            }
        }

        return map;
    }

    private static void WriteNullableString(Utf8JsonWriter writer, string key, string? value)
    {
        if (value is null)
        {
            writer.WriteNull(key);
        }
        else
        {
            writer.WriteString(key, value);
        }
    }

    private static void WriteStringMap(Utf8JsonWriter writer, string key, IReadOnlyDictionary<string, string> map)
    {
        writer.WritePropertyName(key);
        writer.WriteStartObject();
        foreach (var pair in map)
        {
            writer.WriteString(pair.Key, pair.Value);
        }

        writer.WriteEndObject();
    }
}
