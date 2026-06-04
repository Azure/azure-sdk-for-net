// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace Azure.Communication
{
    internal class CommunicationIdentifierSerializer
    {
        // The shared serializer is link-compiled into multiple consumer SDKs (Chat, Call Automation, ...)
        // whose generated CommunicationIdentifierModel / PhoneNumberIdentifierModel / TeamsExtensionUserIdentifierModel
        // shapes evolve at different rates. To support TeamsExtensionUserIdentifier and the optional
        // PhoneNumberIdentifierModel fields without taking a hard compile-time dependency on members that
        // only exist in the newer service models, we reach for these members via reflection and gracefully
        // no-op when they are absent.
        private const string TeamsExtensionUserKindValue = "teamsExtensionUser";

#pragma warning disable IL2070, IL2075, IL2080 // The reflection probes below intentionally tolerate the linker stripping these members; we fall back to NotSupportedException at runtime.
        private static readonly PropertyInfo? s_teamsExtensionUserProperty =
            typeof(CommunicationIdentifierModel).GetProperty("TeamsExtensionUser");
        private static readonly Type? s_teamsExtensionUserModelType = s_teamsExtensionUserProperty?.PropertyType;
        private static readonly PropertyInfo? s_teamsExtensionUserIdProperty =
            s_teamsExtensionUserModelType?.GetProperty("UserId");
        private static readonly PropertyInfo? s_teamsExtensionTenantIdProperty =
            s_teamsExtensionUserModelType?.GetProperty("TenantId");
        private static readonly PropertyInfo? s_teamsExtensionResourceIdProperty =
            s_teamsExtensionUserModelType?.GetProperty("ResourceId");
        private static readonly PropertyInfo? s_teamsExtensionCloudProperty =
            s_teamsExtensionUserModelType?.GetProperty("Cloud");
        private static readonly ConstructorInfo? s_teamsExtensionUserCtor =
            s_teamsExtensionUserModelType?.GetConstructor(new[] { typeof(string), typeof(string), typeof(string) });

        private static readonly PropertyInfo? s_phoneIsAnonymousProperty =
            typeof(PhoneNumberIdentifierModel).GetProperty("IsAnonymous");
        private static readonly PropertyInfo? s_phoneAssertedIdProperty =
            typeof(PhoneNumberIdentifierModel).GetProperty("AssertedId");
#pragma warning restore IL2070, IL2075, IL2080

        public static CommunicationIdentifier Deserialize(CommunicationIdentifierModel identifier)
        {
            string rawId = AssertNotNull(identifier.RawId, nameof(identifier.RawId), nameof(CommunicationIdentifierModel));

            object? teamsExtensionUser = s_teamsExtensionUserProperty?.GetValue(identifier);

            AssertMaximumOneNestedModel(identifier, teamsExtensionUser);

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

            if (kind == (CommunicationIdentifierModelKind)TeamsExtensionUserKindValue
                && teamsExtensionUser is not null)
            {
                return DeserializeTeamsExtensionUser(teamsExtensionUser, rawId);
            }

            return new UnknownIdentifier(rawId);

            static void AssertMaximumOneNestedModel(CommunicationIdentifierModel identifier, object? teamsExtensionUser)
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
                if (teamsExtensionUser is not null)
                    presentProperties.Add("TeamsExtensionUser");

                if (presentProperties.Count > 1)
                    throw new JsonException($"Only one of the properties in {{{string.Join(", ", presentProperties)}}} should be present.");
            }
        }

        private static TeamsExtensionUserIdentifier DeserializeTeamsExtensionUser(object teamsExtensionUserModel, string rawId)
        {
            const string modelName = "TeamsExtensionUserIdentifierModel";

            // Each member is probed independently at type-init time, so any one of them can be null
            // when the consumer SDK is generated against a contract that exposes a partially-shaped
            // TeamsExtensionUserIdentifierModel. Gate up-front so callers see a clear NotSupportedException
            // instead of a NullReferenceException leaking out of the public Deserialize entry point.
            if (s_teamsExtensionUserIdProperty is null
                || s_teamsExtensionTenantIdProperty is null
                || s_teamsExtensionResourceIdProperty is null
                || s_teamsExtensionCloudProperty is null)
            {
                throw new NotSupportedException(
                    $"{nameof(TeamsExtensionUserIdentifier)} is not supported by the current service contract. " +
                    "Upgrade the consuming SDK to a version whose generated CommunicationIdentifierModel exposes 'TeamsExtensionUser' with UserId, TenantId, ResourceId, and Cloud.");
            }

            string? userId = s_teamsExtensionUserIdProperty.GetValue(teamsExtensionUserModel) as string;
            string? tenantId = s_teamsExtensionTenantIdProperty.GetValue(teamsExtensionUserModel) as string;
            string? resourceId = s_teamsExtensionResourceIdProperty.GetValue(teamsExtensionUserModel) as string;
            var cloud = (CommunicationCloudEnvironmentModel?)s_teamsExtensionCloudProperty.GetValue(teamsExtensionUserModel);

            return new TeamsExtensionUserIdentifier(
                AssertNotNullRef(userId, nameof(TeamsExtensionUserIdentifier.UserId), modelName),
                AssertNotNullRef(tenantId, nameof(TeamsExtensionUserIdentifier.TenantId), modelName),
                AssertNotNullRef(resourceId, nameof(TeamsExtensionUserIdentifier.ResourceId), modelName),
                Deserialize(AssertNotNull(cloud, nameof(TeamsExtensionUserIdentifier.Cloud), modelName)),
                rawId);
        }

        private static T AssertNotNullRef<T>(T? value, string name, string type) where T : class
            => value ?? throw new JsonException($"Property '{name}' is required for identifier of type `{type}`.");

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

            if (s_teamsExtensionUserProperty?.GetValue(identifier) is not null)
            {
                return TeamsExtensionUserKindValue;
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
                    PhoneNumber = SerializePhoneNumber(p),
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
                TeamsExtensionUserIdentifier teamsExtensionUser => SerializeTeamsExtensionUser(teamsExtensionUser),
                UnknownIdentifier u => new CommunicationIdentifierModel
                {
                    RawId = u.Id
                },
                _ => throw new NotSupportedException(),
            };

        private static PhoneNumberIdentifierModel SerializePhoneNumber(PhoneNumberIdentifier identifier)
        {
            var model = new PhoneNumberIdentifierModel(identifier.PhoneNumber);

            // Older consumer SDKs do not expose IsAnonymous / AssertedId on PhoneNumberIdentifierModel.
            // Only populate them when the generated model carries the corresponding properties.
            // IsAnonymous defaults to false on the wire, so only emit it when true to avoid noise.
            if (identifier.IsAnonymous)
            {
                s_phoneIsAnonymousProperty?.SetValue(model, true);
            }
            if (!string.IsNullOrEmpty(identifier.AssertedId))
            {
                s_phoneAssertedIdProperty?.SetValue(model, identifier.AssertedId);
            }

            return model;
        }

        private static CommunicationIdentifierModel SerializeTeamsExtensionUser(TeamsExtensionUserIdentifier identifier)
        {
            if (s_teamsExtensionUserCtor is null
                || s_teamsExtensionUserProperty is null
                || s_teamsExtensionCloudProperty is null)
            {
                throw new NotSupportedException(
                    $"{nameof(TeamsExtensionUserIdentifier)} is not supported by the current service contract. " +
                    "Upgrade the consuming SDK to a version whose generated CommunicationIdentifierModel exposes 'TeamsExtensionUser'.");
            }

            object teamsExtensionUserModel = s_teamsExtensionUserCtor.Invoke(
                new object[] { identifier.UserId, identifier.TenantId, identifier.ResourceId });
            s_teamsExtensionCloudProperty.SetValue(teamsExtensionUserModel, Serialize(identifier.Cloud));

            var model = new CommunicationIdentifierModel { RawId = identifier.RawId };
            s_teamsExtensionUserProperty.SetValue(model, teamsExtensionUserModel);
            return model;
        }

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
