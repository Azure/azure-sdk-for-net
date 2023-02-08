// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class JobState
    {
        internal static JobState DeserializeJobState(JsonElement element)
        {
            Optional<string> displayName = default;
            DateTimeOffset createdDateTime = default;
            Optional<DateTimeOffset> expirationDateTime = default;
            string jobId = default;
            DateTimeOffset lastUpdatedDateTime = default;
            State status = default;
            Optional<IReadOnlyList<Error>> errors = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("displayName"))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("createdDateTime"))
                {
                    createdDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("expirationDateTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    expirationDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("jobId"))
                {
                    jobId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lastUpdatedDateTime"))
                {
                    lastUpdatedDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    status = new State(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("errors"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<Error> array = new List<Error>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Error.DeserializeError(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new JobState(displayName.Value, createdDateTime, Optional.ToNullable(expirationDateTime), jobId, lastUpdatedDateTime, status, Optional.ToList(errors), nextLink.Value);
        }
    }
}
