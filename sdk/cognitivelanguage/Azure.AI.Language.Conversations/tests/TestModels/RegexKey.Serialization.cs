// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class RegexKey
    {
        internal static RegexKey DeserializeRegexKey(JsonElement element)
        {
            Optional<string> key = default;
            Optional<string> regexPattern = default;
            ExtraInformationKind extraInformationKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key"))
                {
                    key = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("regexPattern"))
                {
                    regexPattern = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("extraInformationKind"))
                {
                    extraInformationKind = new ExtraInformationKind(property.Value.GetString());
                    continue;
                }
            }
            return new RegexKey(extraInformationKind, key.Value, regexPattern.Value);
        }
    }
}
