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
                return new PhoneNumberIdentifier(AssertNotNull(identifier.PhoneNumber, nameof(identifier.PhoneNumber), kind), AssertNotNull(id, nameof(identifier.Id), kind));
            if (kind == CommunicationIdentifierKind.MicrosoftTeamsUser)
            {
                return new MicrosoftTeamsUserIdentifier(
                    AssertNotNull(identifier.MicrosoftTeamsUserId, nameof(identifier.MicrosoftTeamsUserId), kind),
                    AssertNotNull(identifier.IsAnonymous, nameof(identifier.IsAnonymous), kind),
                    AssertNotNull(id, nameof(identifier.Id), kind),
                    Deserialize(AssertNotNull(identifier.Cloud, nameof(identifier.Cloud), kind)));
            }

            return new UnknownIdentifier(AssertNotNull(id, nameof(identifier.Id), kind));
        }

        private static CommunicationCloudEnvironment Deserialize(CommunicationCloudEnvironmentModel cloud)
        {
            if (cloud == CommunicationCloudEnvironmentModel.Public)
                return CommunicationCloudEnvironment.Public;
            if (cloud == CommunicationCloudEnvironmentModel.Gcch)
                return CommunicationCloudEnvironment.Gcch;
            if (cloud == CommunicationCloudEnvironmentModel.Dod)
                return CommunicationCloudEnvironment.Dod;

            return new CommunicationCloudEnvironment(cloud.ToString());
        }

        public static CommunicationIdentifierModel Serialize(CommunicationIdentifier identifier)
            => identifier switch
            {
                CommunicationUserIdentifier u => new CommunicationIdentifierModel(CommunicationIdentifierKind.CommunicationUser)
                {
                    Id = u.Id
                },
                CallingApplicationIdentifier a => new CommunicationIdentifierModel(CommunicationIdentifierKind.CallingApplication)
                {
                    Id = a.Id
                },
                PhoneNumberIdentifier p => new CommunicationIdentifierModel(CommunicationIdentifierKind.PhoneNumber)
                {
                    Id = p.Id,
                    PhoneNumber = p.PhoneNumber,
                },
                MicrosoftTeamsUserIdentifier u => new CommunicationIdentifierModel(CommunicationIdentifierKind.MicrosoftTeamsUser)
                {
                    Id = u.Id,
                    MicrosoftTeamsUserId = u.UserId,
                    IsAnonymous = u.IsAnonymous,
                    Cloud = Serialize(u.Cloud),
                },
                UnknownIdentifier u => new CommunicationIdentifierModel(CommunicationIdentifierKind.Unknown)
                {
                    Id = u.Id
                },
                _ => throw new NotSupportedException(),
            };

        private static CommunicationCloudEnvironmentModel Serialize(CommunicationCloudEnvironment cloud)
        {
            if (cloud == CommunicationCloudEnvironment.Public)
                return CommunicationCloudEnvironmentModel.Public;
            if (cloud == CommunicationCloudEnvironment.Gcch)
                return CommunicationCloudEnvironmentModel.Gcch;
            if (cloud == CommunicationCloudEnvironment.Dod)
                return CommunicationCloudEnvironmentModel.Dod;

            return new CommunicationCloudEnvironmentModel(cloud.ToString());
        }

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
