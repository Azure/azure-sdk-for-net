// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// .
    /// </summary>
    public interface IJsonModelSerializable<out T> : IModelSerializable<T>
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="options"></param>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API

        /// <summary>
        /// .
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        T Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API
    }

    /// <summary>
    /// .
    /// </summary>
    public interface IJsonModelSerializable : IJsonModelSerializable<object>, IModelSerializable { }
}
