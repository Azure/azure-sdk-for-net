// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Resources.Deployments.Models
{
    [CodeGenSerialization(nameof(StatusCode), DeserializationValueHook = nameof(DeserializeStatusCode))]
    public partial class ArmDeploymentOperationProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeStatusCode(JsonProperty property, ref string statusCode, ModelReaderWriterOptions options)
        {
            statusCode = property.Value.ValueKind == JsonValueKind.Number
                ? property.Value.GetRawText()
                : property.Value.GetString();
        }
    }
}
