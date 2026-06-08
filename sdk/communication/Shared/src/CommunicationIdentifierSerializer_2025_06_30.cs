// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication
{
    /// <summary>
    /// Thin compatibility shim retained for consumer SDKs that were generated against the
    /// 2025-06-30 service contract. All identifier handling — including
    /// <see cref="TeamsExtensionUserIdentifier"/> and the optional
    /// <c>PhoneNumberIdentifierModel</c> fields — is now provided by the unified
    /// <see cref="CommunicationIdentifierSerializer"/>. Prefer
    /// <see cref="CommunicationIdentifierSerializer"/> directly in new code; this type
    /// will be removed once all consumers migrate.
    /// </summary>
    internal static class CommunicationIdentifierSerializer_2025_06_30
    {
        public static CommunicationIdentifier Deserialize(CommunicationIdentifierModel identifier)
            => CommunicationIdentifierSerializer.Deserialize(identifier);

        public static CommunicationIdentifierModel Serialize(CommunicationIdentifier identifier)
            => CommunicationIdentifierSerializer.Serialize(identifier);
    }
}
