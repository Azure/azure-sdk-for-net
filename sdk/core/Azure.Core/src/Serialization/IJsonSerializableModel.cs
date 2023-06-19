// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Data;
using System.Text.Json;
using System.Xml;
using Azure.Core.Serialization;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IJsonSerializableModel
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
