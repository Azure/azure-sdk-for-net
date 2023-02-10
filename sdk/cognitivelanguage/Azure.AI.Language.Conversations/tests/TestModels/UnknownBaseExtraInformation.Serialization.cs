// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    internal partial class UnknownBaseExtraInformation
    {
        internal static UnknownBaseExtraInformation DeserializeUnknownBaseExtraInformation(JsonElement element)
        {
            ExtraInformationKind extraInformationKind = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("extraInformationKind"))
                {
                    extraInformationKind = new ExtraInformationKind(property.Value.GetString());
                    continue;
                }
            }
            return new UnknownBaseExtraInformation(extraInformationKind);
        }
    }
}
