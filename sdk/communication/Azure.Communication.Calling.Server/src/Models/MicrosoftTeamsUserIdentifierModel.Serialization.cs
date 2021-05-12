// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication
{
    internal partial class MicrosoftTeamsUserIdentifierModel : IUtf8JsonSerializable
    {
        internal static MicrosoftTeamsUserIdentifierModel DeserializeMicrosoftTeamsUserIdentifierModel(JsonElement element)
        {
            string userId = default;
            Optional<bool> isAnonymous = default;
            Optional<CommunicationCloudEnvironmentModel> cloud = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("userId"))
                {
                    userId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("isAnonymous"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    isAnonymous = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("cloud"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    cloud = new CommunicationCloudEnvironmentModel(property.Value.GetString());
                    continue;
                }
            }
            return new MicrosoftTeamsUserIdentifierModel(userId)
            {
                Cloud = cloud,
                IsAnonymous = isAnonymous
            };
        }
    }
}
