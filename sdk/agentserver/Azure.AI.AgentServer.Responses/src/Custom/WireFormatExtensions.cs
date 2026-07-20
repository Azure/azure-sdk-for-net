// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Responses
{
    /// <summary>
    /// Extension methods for translating between model types that share the same
    /// underlying JSON wire contract. The Azure Responses models and the OpenAI
    /// .NET SDK models are wire-compatible — OpenAI payloads are generally a subset
    /// while Azure Responses is a superset with additional item types and extensions.
    /// <para>
    /// <strong>Important:</strong> Only use this for types whose JSON serialization
    /// is wire-compatible. If the source and target types do not share the same JSON
    /// schema (property names, discriminators, structure), deserialization may
    /// silently produce incomplete objects or throw.
    /// </para>
    /// </summary>
    public static class WireFormatExtensions
    {
        /// <summary>
        /// Serializes <paramref name="model"/> to its JSON wire format, returning
        /// an intermediate <see cref="WireFormatData"/> that can be deserialized
        /// as a different (wire-compatible) model type via
        /// <see cref="WireFormatData.To{T}"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// // Azure Item → OpenAI ResponseItem
        /// ResponseItem openAiItem = ourItem.Translate().To&lt;ResponseItem&gt;();
        ///
        /// // OpenAI StreamingResponseUpdate → Azure ResponseStreamEvent
        /// ResponseStreamEvent evt = update.Translate().To&lt;ResponseStreamEvent&gt;();
        /// </code>
        /// </example>
        [SuppressMessage("Usage", "AZC0150:Use ModelReaderWriterContext overload",
            Justification = "Cross-SDK translation: source type may be from OpenAI SDK which has no shared ModelReaderWriterContext.")]
        public static WireFormatData Translate<T>(this T model) where T : IPersistableModel<T>
            => new(ModelReaderWriter.Write(model));
    }

    /// <summary>
    /// Intermediate wire-format bytes produced by
    /// <see cref="WireFormatExtensions.Translate{T}"/>.
    /// Call <see cref="To{T}"/> to deserialize as the target model type.
    /// </summary>
    public readonly struct WireFormatData
    {
        private readonly BinaryData _data;
        internal WireFormatData(BinaryData data) => _data = data;

        /// <summary>
        /// Deserializes the wire-format bytes as <typeparamref name="T"/>.
        /// The target type must share the same JSON wire contract as the
        /// source type that produced this data.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The payload could not be deserialized as <typeparamref name="T"/>.
        /// </exception>
        [SuppressMessage("Usage", "AZC0150:Use ModelReaderWriterContext overload",
            Justification = "Cross-SDK translation: target type may be from OpenAI SDK which has no shared ModelReaderWriterContext.")]
        public T To<T>() where T : IPersistableModel<T>
        {
            T? result = ModelReaderWriter.Read<T>(_data);
            if (result is null)
            {
                throw new InvalidOperationException(
                    $"Wire-format translation failed: the payload could not be deserialized as {typeof(T).Name}. " +
                    "Ensure the source and target types share the same JSON wire contract.");
            }

            return result;
        }
    }
}
