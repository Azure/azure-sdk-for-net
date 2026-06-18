// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using System.ClientModel.Primitives;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class RequestReportRecordContract
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeBackendResponseCodeValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(BackendResponseCode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeBackendResponseCodeValue(JsonProperty property, ref string backendResponseCode)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                backendResponseCode = property.Value.GetInt32().ToString();
            }
        }
    }
}
