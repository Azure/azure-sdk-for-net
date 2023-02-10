// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Communication.Rooms.Models
{
    // The CommunicationIdentifierSerializer is a clone of Shared/CommunicationIdentifireSerializer.cs file.
    // Right now Rooms do not support Phone number and Team's User Identifier.
    // Once Rooms support all identifiers as defined by Shared/CommunicationIdentifireSerializer.cs we will refer to the Shard class.
    internal class CommunicationIdentifierSerializer
    {
        public static CommunicationIdentifier Deserialize(CommunicationIdentifierModel identifier)
        {
            string rawId = AssertNotNull(identifier.RawId, nameof(identifier.RawId), nameof(CommunicationIdentifierModel));

            AssertMaximumOneNestedModel(identifier);

            if (identifier.CommunicationUser is CommunicationUserIdentifierModel user)
                return new CommunicationUserIdentifier(AssertNotNull(user.Id, nameof(user.Id), nameof(CommunicationUserIdentifierModel)));

            return new UnknownIdentifier(rawId);

            static void AssertMaximumOneNestedModel(CommunicationIdentifierModel identifier)
            {
                List<string> presentProperties = new List<string>();
                if (identifier.CommunicationUser is not null)
                    presentProperties.Add(nameof(identifier.CommunicationUser));

                if (presentProperties.Count > 1)
                    throw new JsonException($"Only one of the properties in {{{string.Join(", ", presentProperties)}}} should be present.");
            }
        }

        public static CommunicationIdentifierModel Serialize(CommunicationIdentifier identifier)
            => identifier switch
            {
                CommunicationUserIdentifier u => new CommunicationIdentifierModel
                {
                    CommunicationUser = new CommunicationUserIdentifierModel(u.Id),
                },
                UnknownIdentifier u => new CommunicationIdentifierModel
                {
                    RawId = u.Id
                },
                _ => throw new NotSupportedException("Unsupported communication identifer received: Supported identifier is CommunicationUserIdentifier"),
            };

        private static T AssertNotNull<T>(T value, string name, string type) where T : class
            => value ?? throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");

        private static T AssertNotNull<T>(T? value, string name, string type) where T : struct
        {
            if (value is null)
                throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");

            return value.Value;
        }
    }
}
