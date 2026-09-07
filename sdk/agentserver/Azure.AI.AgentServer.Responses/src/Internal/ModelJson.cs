// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Serializes and deserializes the polymorphic Responses models.
/// <para>
/// The source-generated <see cref="AzureAIAgentServerResponsesContext"/> emits builders only for
/// the types this package declares. The item, event and response hierarchies are owned by the
/// OpenAI SDK and by <c>Azure.AI.Extensions.OpenAI</c>, so a context-based round-trip silently
/// collapses those instances to their base shape and drops every derived property. The
/// reflection-based overloads dispatch on the runtime type and are therefore the only correct
/// choice here. This package is not trim/AOT-annotated, so the analyzer's AOT concern does not apply.
/// </para>
/// </summary>
internal static class ModelJson
{
    /// <summary>Writes a model using runtime type dispatch.</summary>
    /// <param name="model">The model to serialize.</param>
    /// <param name="options">The serialization options; defaults to JSON.</param>
    /// <returns>The serialized model.</returns>
    public static BinaryData Write(object model, ModelReaderWriterOptions? options = null)
    {
#pragma warning disable AZC0150
        return ModelReaderWriter.Write(model, options ?? ModelReaderWriterOptions.Json);
#pragma warning restore AZC0150
    }

    /// <summary>Reads a model using runtime type dispatch.</summary>
    /// <typeparam name="T">The model type to materialize.</typeparam>
    /// <param name="data">The serialized model.</param>
    /// <param name="options">The serialization options; defaults to JSON.</param>
    /// <returns>The deserialized model, or <see langword="null"/>.</returns>
    public static T? Read<T>(BinaryData data, ModelReaderWriterOptions? options = null)
        where T : class
    {
#pragma warning disable AZC0150
        return ModelReaderWriter.Read<T>(data, options ?? ModelReaderWriterOptions.Json);
#pragma warning restore AZC0150
    }

    /// <summary>Reads a model of the given runtime type.</summary>
    /// <param name="data">The serialized model.</param>
    /// <param name="returnType">The model type to materialize.</param>
    /// <param name="options">The serialization options; defaults to JSON.</param>
    /// <returns>The deserialized model, or <see langword="null"/>.</returns>
    public static object? Read(BinaryData data, Type returnType, ModelReaderWriterOptions? options = null)
    {
#pragma warning disable AZC0150
        return ModelReaderWriter.Read(data, returnType, options ?? ModelReaderWriterOptions.Json);
#pragma warning restore AZC0150
    }
}
