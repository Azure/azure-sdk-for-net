// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    public partial class BulkImportJob : IUtf8JsonSerializable
    {
        // This class definition overrides deserialization implementation in order to allow finishedDateTime to be null in the response.
        internal static BulkImportJob DeserializeBulkImportJob(JsonElement element)
        {
            Optional<string> id = default;
            string inputBlobUri = default;
            string outputBlobUri = default;
            Optional<ImportJobStatus> status = default;
            Optional<DateTimeOffset> createdDateTime = default;
            Optional<DateTimeOffset> lastActionDateTime = default;
            Optional<DateTimeOffset?> finishedDateTime = default;
            Optional<DateTimeOffset> purgeDateTime = default;
            Optional<ErrorInformation> error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("inputBlobUri"))
                {
                    inputBlobUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("outputBlobUri"))
                {
                    outputBlobUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = property.Value.GetString().ToImportJobStatus();
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
                    finishedDateTime = property.Value.GetDateTimeOffset("O");
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
                    error = ErrorInformation.DeserializeErrorInformation(property.Value);
                    continue;
                }
            }
            return new BulkImportJob(id.Value, inputBlobUri, outputBlobUri, Optional.ToNullable(status), Optional.ToNullable(createdDateTime), Optional.ToNullable(lastActionDateTime), Optional.ToNullable(finishedDateTime), Optional.ToNullable(purgeDateTime), error.Value);
        }
    }
}
