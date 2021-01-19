// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Communication
{
    internal class CommunicationIdentifierSerializer
    {
        public static CommunicationIdentifier Deserialize(CommunicationIdentifierModel identifier)
        {
            var id = identifier.Id;
            var kind = identifier.Kind;

            if (kind == CommunicationIdentifierKind.CommunicationUser)
                return new CommunicationUserIdentifier(AssertNotNull(id, nameof(identifier.Id), kind));
            if (kind == CommunicationIdentifierKind.CallingApplication)
                return new CallingApplicationIdentifier(AssertNotNull(id, nameof(identifier.Id), kind));
            if (kind == CommunicationIdentifierKind.PhoneNumber)
                return new PhoneNumberIdentifier(AssertNotNull(identifier.PhoneNumber, nameof(identifier.PhoneNumber), kind));
            if (kind == CommunicationIdentifierKind.MicrosoftTeamsUser)
            {
                return new MicrosoftTeamsUserIdentifier(
                        AssertNotNull(identifier.MicrosoftTeamsUserId, nameof(identifier.MicrosoftTeamsUserId), kind),
                        AssertNotNull(identifier.IsAnonymous, nameof(identifier.IsAnonymous), kind));
            }

            return new UnknownIdentifier(AssertNotNull(id, nameof(identifier.Id), kind));
        }

        public static CommunicationIdentifierModel Serialize(CommunicationIdentifier identifier)
            => identifier switch
            {
                CommunicationUserIdentifier u => new CommunicationIdentifierModel(CommunicationIdentifierKind.CommunicationUser) { Id = u.Id },
                CallingApplicationIdentifier a => new CommunicationIdentifierModel(CommunicationIdentifierKind.CallingApplication) { Id = a.Id },
                PhoneNumberIdentifier p => new CommunicationIdentifierModel(CommunicationIdentifierKind.PhoneNumber) { PhoneNumber = p.Value },
                MicrosoftTeamsUserIdentifier u => new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser) { MicrosoftTeamsUserId = u.UserId, IsAnonymous = u.IsAnonymous },
                UnknownIdentifier u => new CommunicationIdentifierModel(CommunicationIdentifierKind.Unknown) { Id = u.Id },
                _ => throw new NotSupportedException(),
            };

        private static T AssertNotNull<T>(T value, string name, CommunicationIdentifierKind kind) where T : class?
            => value ?? throw new JsonException($"Property '{name}' is required for identifier of kind `{kind}`.");

        private static T AssertNotNull<T>(T? value, string name, CommunicationIdentifierKind kind) where T : struct
        {
            if (value is null)
                throw new JsonException($"Property '{name}' is required for identifier of kind `{kind}`.");

            return value.Value;
        }
    }
}
