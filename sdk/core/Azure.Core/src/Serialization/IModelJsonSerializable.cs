// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Indicates that the implementer can be serialized and deserialized as JSON.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON value into.</typeparam>
    public interface IModelJsonSerializable<out T> : IModelSerializable<T>
    {
        /// <summary>
        /// Serializes the model to the provided <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to serialize into.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API

        /// <summary>
        /// Reads one JSON value (including objects or arrays) from the provided reader and converts it to a model.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the JSON value.</returns>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        T Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API
    }
}
