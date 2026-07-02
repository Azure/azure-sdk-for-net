// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // The generated deserializer calls RequestMethod.DeserializeRequestMethod() which doesn't exist.
    // RequestMethod is an Azure.Core struct that uses RequestMethod.Parse(string) for deserialization.
    // Also, backendResponseCode comes as an int on the wire but the old SDK exposed it as string.
    [CodeGenSerialization(nameof(Method), DeserializationValueHook = nameof(DeserializeMethodValue))]
    [CodeGenSerialization(nameof(BackendResponseCode), DeserializationValueHook = nameof(DeserializeBackendResponseCodeValue))]
    public partial class RequestReportRecordContract
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeMethodValue(JsonProperty property, ref RequestMethod? method)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                method = null;
            }
            else
            {
                method = RequestMethod.Parse(property.Value.GetString());
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeBackendResponseCodeValue(JsonProperty property, ref string backendResponseCode)
        {
            if (property.Value.ValueKind == JsonValueKind.Number)
            {
                backendResponseCode = property.Value.GetInt32().ToString();
            }
            else
            {
                backendResponseCode = property.Value.GetString();
            }
        }
    }
}
