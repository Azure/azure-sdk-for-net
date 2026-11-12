// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    [CodeGenSerialization(nameof(Endpoint), SerializationValueHook = nameof(SerializeEndpoint))]
    public partial class AiAgentsGroupAccessToken
    {
        // Preserve relative endpoint URIs when writing the wire value.
        /// <summary> Serializes the endpoint URI while preserving relative URI text. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        private void SerializeEndpoint(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(Endpoint?.OriginalString);
        }
    }
}
