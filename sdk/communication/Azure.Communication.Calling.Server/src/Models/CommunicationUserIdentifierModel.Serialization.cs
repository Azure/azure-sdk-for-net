// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication
{
    internal partial class CommunicationUserIdentifierModel : IUtf8JsonSerializable
    {
        internal static CommunicationUserIdentifierModel DeserializeCommunicationUserIdentifierModel(JsonElement element)
        {
            string id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new CommunicationUserIdentifierModel(id);
        }
    }
}
