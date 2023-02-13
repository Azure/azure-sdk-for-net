// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    internal partial class UnknownBaseResolution
    {
        internal static UnknownBaseResolution DeserializeUnknownBaseResolution(JsonElement element)
        {
            ResolutionKind resolutionKind = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resolutionKind"))
                {
                    resolutionKind = new ResolutionKind(property.Value.GetString());
                    continue;
                }
            }
            return new UnknownBaseResolution(resolutionKind);
        }
    }
}
