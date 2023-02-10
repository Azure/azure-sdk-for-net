// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class EntitySubtype
    {
        internal static EntitySubtype DeserializeEntitySubtype(JsonElement element)
        {
            Optional<string> value = default;
            ExtraInformationKind extraInformationKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("extraInformationKind"))
                {
                    extraInformationKind = new ExtraInformationKind(property.Value.GetString());
                    continue;
                }
            }
            return new EntitySubtype(extraInformationKind, value.Value);
        }
    }
}
