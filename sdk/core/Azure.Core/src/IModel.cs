// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure
{
    /// <summary>
    /// TODO
    /// </summary>
#pragma warning disable AZC0012 // Avoid single word type names
    public interface IModel
#pragma warning restore AZC0012 // Avoid single word type names
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
