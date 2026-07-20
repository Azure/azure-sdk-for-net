// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Extension for translating between model types that share the same underlying
    /// JSON wire contract. This works because both the Azure.AI.AgentServer.Responses
    /// and OpenAI .NET SDK model stacks are generated from the same TypeSpec
    /// definitions and produce identical JSON on the wire.
    /// <para>
    /// <strong>Important:</strong> Only use this for types whose JSON serialization
    /// is wire-compatible. If the source and target types do not share the same JSON
    /// schema (property names, discriminators, structure), deserialization will
    /// silently produce incomplete objects or throw.
    /// </para>
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
    public static class WireFormatExtensions
    {
        /// <summary>
        /// Serializes <paramref name="model"/> to its JSON wire format, returning
        /// an intermediate <see cref="WireFormatData"/> that can be deserialized
        /// as a different (wire-compatible) model type via
        /// <see cref="WireFormatData.To{T}"/>.
        /// </summary>
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
        public T To<T>() where T : IPersistableModel<T>
            => ModelReaderWriter.Read<T>(_data)!;
    }
}
