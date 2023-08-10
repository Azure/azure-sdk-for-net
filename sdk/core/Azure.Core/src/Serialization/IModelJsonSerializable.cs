// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Allows an object to control its own JSON serialization and deserialization.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON value into.</typeparam>
    public interface IModelJsonSerializable<out T> : IModelSerializable<T>
    {
        /// <summary>
        /// Serializes the model to the provided <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to serialize into.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerOptions.Format"/>.</exception>
        /// <exception cref="InvalidOperationException">If <see cref="ModelSerializerFormat.Wire"/> format is passed in and the model does not use JSON for its wire format.</exception>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API

        /// <summary>
        /// Reads one JSON value (including objects or arrays) from the provided reader and converts it to a model.
        /// </summary>
        /// <param name="reader">The <see cref="Utf8JsonReader"/> to read.</param>
        /// <param name="options">The <see cref="ModelSerializerOptions"/> to use.</param>
        /// <returns>A <typeparamref name="T"/> representation of the JSON value.</returns>
        /// <exception cref="FormatException">If the model does not support the requested <see cref="ModelSerializerOptions.Format"/>.</exception>
        /// <exception cref="InvalidOperationException">If <see cref="ModelSerializerFormat.Wire"/> format is passed in and the model does not use JSON for its wire format.</exception>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        T Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API
    }
}
