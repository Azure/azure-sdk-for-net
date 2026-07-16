// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication
{
    /// <summary>
    /// The Entra Communication Token Options.
    /// </summary>
    internal static class EntraCommunicationTokenScopes
    {
        public const string TeamsExtensionScopePrefix = "https://auth.msft.communication.azure.com/";
        public const string TeamsExtensionSovereignScopePrefix = "https://auth.msft.communication.azure.us/";
        public const string CommunicationClientsScopePrefix = "https://communication.azure.com/clients/";
        public const string DefaultScopes = CommunicationClientsScopePrefix + ".default";

        internal static bool IsTeamsExtensionScope(string scope)
            => scope.StartsWith(TeamsExtensionScopePrefix, StringComparison.OrdinalIgnoreCase)
                || scope.StartsWith(TeamsExtensionSovereignScopePrefix, StringComparison.OrdinalIgnoreCase);
    }
}
