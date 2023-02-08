// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.AI.Language.Conversations
{
    public partial class BaseExtraInformation
    {
        internal static BaseExtraInformation DeserializeBaseExtraInformation(JsonElement element)
        {
            if (element.TryGetProperty("extraInformationKind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "EntitySubtype": return EntitySubtype.DeserializeEntitySubtype(element);
                    case "ListKey": return ListKey.DeserializeListKey(element);
                    case "RegexKey": return RegexKey.DeserializeRegexKey(element);
                }
            }
            return UnknownBaseExtraInformation.DeserializeUnknownBaseExtraInformation(element);
        }
    }
}
