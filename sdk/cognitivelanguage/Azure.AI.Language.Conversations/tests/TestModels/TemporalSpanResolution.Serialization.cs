// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class TemporalSpanResolution
    {
        internal static TemporalSpanResolution DeserializeTemporalSpanResolution(JsonElement element)
        {
            Optional<string> begin = default;
            Optional<string> end = default;
            Optional<string> duration = default;
            Optional<TemporalModifier> modifier = default;
            ResolutionKind resolutionKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("begin"))
                {
                    begin = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("end"))
                {
                    end = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("duration"))
                {
                    duration = property.Value.GetString();
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
            return new TemporalSpanResolution(resolutionKind, begin.Value, end.Value, duration.Value, Optional.ToNullable(modifier));
        }
    }
}
