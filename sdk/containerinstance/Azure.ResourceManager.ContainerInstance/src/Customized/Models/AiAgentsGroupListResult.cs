// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    [CodeGenSerialization(nameof(NextLink), SerializationValueHook = nameof(SerializeNextLink))]
    internal partial class AiAgentsGroupListResult
    {
        // Preserve relative next-link URIs when writing the guarded wire value.
        /// <summary> Serializes the next-link URI while preserving relative URI text. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        private void SerializeNextLink(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(NextLink.OriginalString);
        }
    }
}
