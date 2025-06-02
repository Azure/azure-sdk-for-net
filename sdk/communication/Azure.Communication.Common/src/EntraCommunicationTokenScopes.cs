// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication
{
    /// <summary>
    /// The Entra Communication Token Options.
    /// </summary>
    internal static class EntraCommunicationTokenScopes
    {
        public const string TeamsExtensionScopePrefix = "https://auth.msft.communication.azure.com/";
        public const string CommunicationClientsScopePrefix = "https://communication.azure.com/clients/";
        public const string DefaultScopes = CommunicationClientsScopePrefix + ".default";
    }
}
