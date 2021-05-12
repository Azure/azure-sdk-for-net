// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication
{
    internal partial class CommunicationIdentifierModel
    {
        internal static CommunicationIdentifierModel DeserializeCommunicationIdentifierModel(JsonElement element)
        {
            Optional<string> rawId = default;
            Optional<CommunicationUserIdentifierModel> communicationUser = default;
            Optional<PhoneNumberIdentifierModel> phoneNumber = default;
            Optional<MicrosoftTeamsUserIdentifierModel> microsoftTeamsUser = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rawId") || property.NameEquals("RawId"))
                {
                    rawId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("communicationUser") || property.NameEquals("CommunicationUser"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    communicationUser = CommunicationUserIdentifierModel.DeserializeCommunicationUserIdentifierModel(property.Value);
                    continue;
                }
                if (property.NameEquals("phoneNumber") || property.NameEquals("PhoneNumber"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    phoneNumber = PhoneNumberIdentifierModel.DeserializePhoneNumberIdentifierModel(property.Value);
                    continue;
                }
                if (property.NameEquals("microsoftTeamsUser") || property.NameEquals("MicrosoftTeamsUser"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    microsoftTeamsUser = MicrosoftTeamsUserIdentifierModel.DeserializeMicrosoftTeamsUserIdentifierModel(property.Value);
                    continue;
                }
            }

            return new CommunicationIdentifierModel()
            {
                RawId = rawId.Value,
                CommunicationUser = communicationUser.Value,
                PhoneNumber = phoneNumber.Value,
                MicrosoftTeamsUser = microsoftTeamsUser.Value
            };
        }
    }
}
