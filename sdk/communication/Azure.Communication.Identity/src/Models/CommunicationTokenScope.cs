// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Identity
{
    [CodeGenModel("CommunicationIdentityTokenScope")]
    public readonly partial struct CommunicationTokenScope
    {
        /// <summary> Use this for full access to Calling APIs. </summary>
        [CodeGenMember("Voip")]
        public static CommunicationTokenScope VoIP { get; } = new CommunicationTokenScope(VoIPValue);

        /// <summary> Access to Calling APIs but without the authorization to start new calls. </summary>
        [CodeGenMember("VoipJoin")]
        public static CommunicationTokenScope VoIPJoin { get; } = new CommunicationTokenScope(VoIPJoinValue);
    }
}
