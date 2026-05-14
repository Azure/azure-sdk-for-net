// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Resources.Models
{
    [CodeGenSerialization(nameof(Error), SerializationValueHook = nameof(SerializationError), DeserializationValueHook = nameof(DeserializeError))]
    public partial class ArmDeploymentValidateResult
    {
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
        // The Error model is omitted and use the ResponseError model instead in Azure.ResourceManager.Resources library.
        /// <summary> The deployment validation error. </summary>
        [WirePath("error")]
        public ResponseError Error { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializationError(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ResponseError>)Error).Write(writer, options);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeError(JsonProperty property, ref ResponseError error, ModelReaderWriterOptions options)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            error = ModelReaderWriter.Read<ResponseError>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), options, AzureResourceManagerResourcesContext.Default);
        }
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- //
    }
}
