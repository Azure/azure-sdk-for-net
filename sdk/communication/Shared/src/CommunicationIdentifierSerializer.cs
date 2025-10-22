// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Communication
{
    internal class CommunicationIdentifierSerializer
    {
        public static CommunicationIdentifier Deserialize(CommunicationIdentifierModel identifier)
        {
            string rawId = AssertNotNull(identifier.RawId, nameof(identifier.RawId), nameof(CommunicationIdentifierModel));

            AssertMaximumOneNestedModel(identifier);

            var kind = identifier.Kind ?? GetKind(identifier);

            if (kind == CommunicationIdentifierModelKind.CommunicationUser
                && identifier.CommunicationUser is not null)
            {
                return new CommunicationUserIdentifier(AssertNotNull(identifier.CommunicationUser.Id, nameof(identifier.CommunicationUser.Id), nameof(CommunicationUserIdentifierModel)));
            }

            if (kind == CommunicationIdentifierModelKind.PhoneNumber
                && identifier.PhoneNumber is not null)
            {
                return new PhoneNumberIdentifier(
                    AssertNotNull(identifier.PhoneNumber.Value, nameof(identifier.PhoneNumber.Value), nameof(PhoneNumberIdentifierModel)),
                    AssertNotNull(identifier.RawId, nameof(identifier.RawId), nameof(PhoneNumberIdentifierModel)));
            }

            if (kind == CommunicationIdentifierModelKind.MicrosoftTeamsUser
                && identifier.MicrosoftTeamsUser is not null)
            {
                var user = identifier.MicrosoftTeamsUser;
                return new MicrosoftTeamsUserIdentifier(
                      AssertNotNull(user.UserId, nameof(user.UserId), nameof(MicrosoftTeamsUserIdentifierModel)),
                      AssertNotNull(user.IsAnonymous, nameof(user.IsAnonymous), nameof(MicrosoftTeamsUserIdentifierModel)),
                      Deserialize(AssertNotNull(user.Cloud, nameof(user.Cloud), nameof(MicrosoftTeamsUserIdentifierModel))),
                      rawId);
            }

            if (kind == CommunicationIdentifierModelKind.MicrosoftTeamsApp
                 && identifier.MicrosoftTeamsApp is not null)
            {
                var app = identifier.MicrosoftTeamsApp;
                return new MicrosoftTeamsAppIdentifier(
                      AssertNotNull(app.AppId, nameof(app.AppId), nameof(MicrosoftTeamsAppIdentifierModel)),
                      Deserialize(AssertNotNull(app.Cloud, nameof(app.Cloud), nameof(MicrosoftTeamsAppIdentifierModel))));
            }

            return new UnknownIdentifier(rawId);

            static void AssertMaximumOneNestedModel(CommunicationIdentifierModel identifier)
            {
                List<string> presentProperties = new();
                if (identifier.CommunicationUser is not null)
                    presentProperties.Add(nameof(identifier.CommunicationUser));
                if (identifier.PhoneNumber is not null)
                    presentProperties.Add(nameof(identifier.PhoneNumber));
                if (identifier.MicrosoftTeamsUser is not null)
                    presentProperties.Add(nameof(identifier.MicrosoftTeamsUser));
                if (identifier.MicrosoftTeamsApp is not null)
                    presentProperties.Add(nameof(identifier.MicrosoftTeamsApp));

                if (presentProperties.Count > 1)
                    throw new JsonException($"Only one of the properties in {{{string.Join(", ", presentProperties)}}} should be present.");
            }
        }

        internal static CommunicationIdentifierModelKind GetKind(CommunicationIdentifierModel identifier)
        {
            if (identifier.CommunicationUser is not null)
            {
                return CommunicationIdentifierModelKind.CommunicationUser;
            }

            if (identifier.PhoneNumber is not null)
            {
                return CommunicationIdentifierModelKind.PhoneNumber;
            }

            if (identifier.MicrosoftTeamsUser is not null)
            {
                return CommunicationIdentifierModelKind.MicrosoftTeamsUser;
            }

            if (identifier.MicrosoftTeamsApp is not null)
            {
                return CommunicationIdentifierModelKind.MicrosoftTeamsApp;
            }

            return CommunicationIdentifierModelKind.Unknown;
        }

        internal static CommunicationCloudEnvironment Deserialize(CommunicationCloudEnvironmentModel cloud)
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
                CommunicationUserIdentifier u => new CommunicationIdentifierModel
                {
                    RawId = u.Id,
                    CommunicationUser = new CommunicationUserIdentifierModel(u.Id),
                },
                PhoneNumberIdentifier p => new CommunicationIdentifierModel
                {
                    RawId = p.RawId,
                    PhoneNumber = new PhoneNumberIdentifierModel(p.PhoneNumber),
                },
                MicrosoftTeamsUserIdentifier u => new CommunicationIdentifierModel
                {
                    RawId = u.RawId,
                    MicrosoftTeamsUser = new MicrosoftTeamsUserIdentifierModel(u.UserId)
                    {
                        IsAnonymous = u.IsAnonymous,
                        Cloud = Serialize(u.Cloud),
                    }
                },
                MicrosoftTeamsAppIdentifier app => new CommunicationIdentifierModel
                {
                    RawId = app.RawId,
                    MicrosoftTeamsApp = new MicrosoftTeamsAppIdentifierModel(app.AppId)
                    {
                        Cloud = Serialize(app.Cloud),
                    }
                },
                UnknownIdentifier u => new CommunicationIdentifierModel
                {
                    RawId = u.Id
                },
                _ => throw new NotSupportedException(),
            };

        internal static CommunicationCloudEnvironmentModel Serialize(CommunicationCloudEnvironment cloud)
        {
            if (cloud == CommunicationCloudEnvironment.Public)
                return CommunicationCloudEnvironmentModel.Public;
            if (cloud == CommunicationCloudEnvironment.Gcch)
                return CommunicationCloudEnvironmentModel.Gcch;
            if (cloud == CommunicationCloudEnvironment.Dod)
                return CommunicationCloudEnvironmentModel.Dod;

            return new CommunicationCloudEnvironmentModel(cloud.ToString());
        }

        internal static T AssertNotNull<T>(T value, string name, string type) where T : class
            => value ?? throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");

        internal static T AssertNotNull<T>(T? value, string name, string type) where T : struct
        {
            if (value is null)
                throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");

            return value.Value;
        }
    }
}
