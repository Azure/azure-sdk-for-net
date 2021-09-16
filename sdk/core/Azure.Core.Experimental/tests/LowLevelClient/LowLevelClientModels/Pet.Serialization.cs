// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Core.Experimental.Tests.Models
{
    public partial class Pet
    {
        internal static Pet DeserializePet(JsonElement element)
        {
            Optional<int> id = default;
            Optional<string> name = default;
            Optional<string> species = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    species = property.Value.GetString();
                    continue;
                }
            }
            return new Pet(Optional.ToNullable(id), name.Value, species.Value);
        }
    }
}
