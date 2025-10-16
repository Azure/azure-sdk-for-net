// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    // Custom deserialization hook for handling mixed-type status codes.
    // Addresses issue where the status code can be either a string or an integer in the JSON response.
    [CodeGenSerialization(nameof(StatusCode), DeserializationValueHook = nameof(DeserializeStatusCode))]
    public partial class ArmDeploymentOperationProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeStatusCode(JsonProperty property, ref string statusCode)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            statusCode = property.Value.ValueKind == JsonValueKind.Number
                ? property.Value.GetInt32().ToString()
                : property.Value.GetString();
        }
    }
}
