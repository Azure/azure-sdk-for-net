// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Azure.Communication
{
    internal class CommunicationIdentifierSerializer
    {
        private const string OrgIdPrefix = "8:orgid:";
        private const string TeamsVisitorPrefix = "8:teamsvisitor:";

        public static CommunicationIdentifier Deserialize(CommunicationIdentifierModel identifier)
        {
            var id = identifier.Id;
            var kind = identifier.Kind;
            return kind switch
            {
                IdentifierKinds.CommunicationUser
                    => new CommunicationUserIdentifier(AssertNotNull(id, nameof(identifier.Id), kind)),
                IdentifierKinds.CallingApplication
                    => new CallingApplicationIdentifier(AssertNotNull(id, nameof(identifier.Id), kind)),
                IdentifierKinds.PhoneNumber
                    => new PhoneNumberIdentifier(AssertNotNull(identifier.PhoneNumber, nameof(identifier.PhoneNumber), kind)),
                IdentifierKinds.MicrosoftTeamsUser
                    => new MicrosoftTeamsUserIdentifier(
                        GetTeamsUserId(AssertNotNull(identifier.MicrosoftTeamsUserId, nameof(identifier.MicrosoftTeamsUserId), kind)),
                        AssertNotNull(identifier.IsAnonymous, nameof(identifier.IsAnonymous), kind)),
                IdentifierKinds.Unknown
                    => new UnknownIdentifier(AssertNotNull(id, nameof(identifier.Id), kind)),
                _
                    => new UnknownIdentifier(AssertNotNull(id, nameof(identifier.Id), kind)),
            };

            static string GetTeamsUserId(string fullId)
            {
                if (fullId.StartsWith(OrgIdPrefix, StringComparison.InvariantCulture))
                    return fullId.Substring(OrgIdPrefix.Length);
                if (fullId.StartsWith(TeamsVisitorPrefix, StringComparison.InvariantCulture))
                    return fullId.Substring(TeamsVisitorPrefix.Length);
                throw new JsonException("Invalid MicrosoftTeams user identifier string");
            }
        }

        public static CommunicationIdentifierModel Serialize(CommunicationIdentifier identifier)
            => identifier switch
            {
                CommunicationUserIdentifier u => new CommunicationIdentifierModel(IdentifierKinds.CommunicationUser) { Id = u.Id },
                CallingApplicationIdentifier a => new CommunicationIdentifierModel(IdentifierKinds.CallingApplication) { Id = a.Id },
                PhoneNumberIdentifier p => new CommunicationIdentifierModel(IdentifierKinds.PhoneNumber) { PhoneNumber = p.Value },
                MicrosoftTeamsUserIdentifier u => new CommunicationIdentifierModel(IdentifierKinds.MicrosoftTeamsUser) { MicrosoftTeamsUserId = GetFullTeamsUserId(u.UserId, u.IsAnonymous) },
                UnknownIdentifier u => new CommunicationIdentifierModel(IdentifierKinds.Unknown) { Id = u.Id },
                _ => throw new NotSupportedException(),
            };

        private static string GetFullTeamsUserId(string userId, bool isAnonymous)
            => isAnonymous ? TeamsVisitorPrefix + userId : OrgIdPrefix + userId;

        private class IdentifierKinds
        {
            public const string CommunicationUser = "CommunicationUser";
            public const string PhoneNumber = "PhoneNumber";
            public const string CallingApplication = "CallingApplication";
            public const string MicrosoftTeamsUser = "MicrosoftTeamsUser";
            public const string Unknown = "Unknown";
        }

        public static T AssertNotNull<T>([AllowNull, NotNull] T value, string name, string kind) where T : class?
        {
            if (value is null)
                throw new JsonException($"Property '{name}' is required for identifier of kind `{kind}`.");

            return value;
        }

        public static T AssertNotNull<T>(T? value, string name, string kind) where T : struct
        {
            if (value is null)
                throw new JsonException($"Property '{name}' is required for identifier of kind `{kind}`.");

            return value.Value;
        }
    }
}
