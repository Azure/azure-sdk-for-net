// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ListKey
    {
        internal static ListKey DeserializeListKey(JsonElement element)
        {
            Optional<string> key = default;
            ExtraInformationKind extraInformationKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key"))
                {
                    key = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("extraInformationKind"))
                {
                    extraInformationKind = new ExtraInformationKind(property.Value.GetString());
                    continue;
                }
            }
            return new ListKey(extraInformationKind, key.Value);
        }
    }
}
