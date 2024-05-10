// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement.Models
{
    [CodeGenSerialization(nameof(BackendResponseCode), SerializationValueHook = nameof(SerializeBackendResponseCodeValue),DeserializationValueHook = nameof(DeserializeBackendResponseCodeValue))]
    public partial class RequestReportRecordContract : IUtf8JsonSerializable, IJsonModel<RequestReportRecordContract>
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
