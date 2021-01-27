// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Identity
{
    [CodeGenModel("CommunicationIdentityTokenScope")]
    public readonly partial struct CommunicationTokenScope
    {
        /// <summary> voip. </summary>
        [CodeGenMember("Voip")]
        public static CommunicationTokenScope VoIP { get; } = new CommunicationTokenScope(VoIPValue);
    }
}
