// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.Core
{
    internal interface IAzureModelInternal : IAzureModel
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="options"></param>
        void Serialize(Utf8JsonWriter writer, SerializableOptions? options = default);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        void Deserialize(ref Utf8JsonReader reader, SerializableOptions? options = default);
    }
}
