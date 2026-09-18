// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// The Core resilient-task input (<c>TInput</c>) for a response invocation. It carries exactly the
/// <see cref="ResponseRecoveryPayload"/> — the request plus the platform/session context that must
/// survive a process crash so the response can be re-invoked in a subsequent process lifetime.
/// <para>
/// Core serializes task inputs with plain <see cref="System.Text.Json.JsonSerializer"/>, whereas the
/// <see cref="Models.CreateResponse"/> model serializes via <c>ModelReaderWriter</c>. This type
/// therefore carries a <see cref="JsonConverterAttribute"/> that emits/parses the exact 9-field
/// wire schema shared with Python (<c>ResilientResponseInput.to_task_input()</c>) by delegating to
/// the tested <see cref="ResponseRecoveryPayload.ToTaskInput"/> /
/// <see cref="ResponseRecoveryPayload.FromTaskInput(JsonElement)"/> round-trip. The Core task
/// store's <c>payload.input</c> is thus byte-identical to Python's.
/// </para>
/// </summary>
[JsonConverter(typeof(ResponseTaskInputJsonConverter))]
internal sealed class ResponseTaskInput
{
    /// <summary>Initializes a new instance of the <see cref="ResponseTaskInput"/> class.</summary>
    public ResponseTaskInput(ResponseRecoveryPayload payload)
    {
        Argument.AssertNotNull(payload, nameof(payload));
        Payload = payload;
    }

    /// <summary>Gets the recovery payload (request + platform context) carried as the task input.</summary>
    public ResponseRecoveryPayload Payload { get; }
}

/// <summary>
/// System.Text.Json converter that (de)serializes <see cref="ResponseTaskInput"/> as the flat
/// 9-field wire schema, delegating to <see cref="ResponseRecoveryPayload"/>'s fail-closed
/// serialization so the Core task input is byte-identical to Python's <c>ResilientResponseInput</c>.
/// </summary>
internal sealed class ResponseTaskInputJsonConverter : JsonConverter<ResponseTaskInput>
{
    /// <inheritdoc/>
    public override ResponseTaskInput Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        return new ResponseTaskInput(ResponseRecoveryPayload.FromTaskInput(doc.RootElement));
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, ResponseTaskInput value, JsonSerializerOptions options)
    {
        using JsonDocument doc = JsonDocument.Parse(value.Payload.ToTaskInput().ToMemory());
        doc.RootElement.WriteTo(writer);
    }
}
