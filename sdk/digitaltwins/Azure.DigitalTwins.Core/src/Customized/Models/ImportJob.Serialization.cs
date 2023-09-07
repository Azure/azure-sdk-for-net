// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    public partial class ImportJob : IUtf8JsonSerializable
    {
        // This class definition overrides deserialization implementation in order to allow finishedDateTime to be null in the response.
        internal static ImportJob DeserializeImportJob(JsonElement element)
        {
            Optional<string> id = default;
            Uri inputBlobUri = default;
            Uri outputBlobUri = default;
            Optional<ImportJobStatus> status = default;
            Optional<DateTimeOffset> createdDateTime = default;
            Optional<DateTimeOffset> lastActionDateTime = default;
            Optional<DateTimeOffset?> finishedDateTime = default;
            Optional<DateTimeOffset> purgeDateTime = default;
            Optional<ResponseError> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("inputBlobUri"))
                {
                    inputBlobUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("outputBlobUri"))
                {
                    outputBlobUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new ImportJobStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("createdDateTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    createdDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastActionDateTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    lastActionDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("finishedDateTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        // manual change: instead of throwing NonNullablePropertyIsNull, set value to null.
                        finishedDateTime = null;
                        continue;
                    }
                    continue;
                }
                if (property.NameEquals("purgeDateTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    purgeDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("error"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    error = JsonSerializer.Deserialize<ResponseError>(property.Value.GetRawText());
                    continue;
                }
            }
            return new ImportJob(id.Value, inputBlobUri, outputBlobUri, Optional.ToNullable(status), Optional.ToNullable(createdDateTime), Optional.ToNullable(lastActionDateTime), Optional.ToNullable(finishedDateTime), Optional.ToNullable(purgeDateTime), error.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeErrorValue(Utf8JsonWriter writer)
        {
            writer.WriteObjectValue(Error);
        }
    }
}
