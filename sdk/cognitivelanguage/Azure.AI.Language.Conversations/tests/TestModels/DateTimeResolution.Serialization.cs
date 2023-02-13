// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class DateTimeResolution
    {
        internal static DateTimeResolution DeserializeDateTimeResolution(JsonElement element)
        {
            string timex = default;
            DateTimeSubKind dateTimeSubKind = default;
            string value = default;
            Optional<TemporalModifier> modifier = default;
            ResolutionKind resolutionKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("timex"))
                {
                    timex = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dateTimeSubKind"))
                {
                    dateTimeSubKind = new DateTimeSubKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("modifier"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    modifier = new TemporalModifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("resolutionKind"))
                {
                    resolutionKind = new ResolutionKind(property.Value.GetString());
                    continue;
                }
            }
            return new DateTimeResolution(resolutionKind, timex, dateTimeSubKind, value, Optional.ToNullable(modifier));
        }
    }
}
