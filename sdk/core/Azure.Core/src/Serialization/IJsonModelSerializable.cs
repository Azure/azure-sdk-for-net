// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// .
    /// </summary>
    public interface IJsonModelSerializable : IModelSerializable
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="options"></param>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options);
#pragma warning restore AZC0014 // Avoid using banned types in public API
    }
}
