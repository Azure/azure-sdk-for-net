// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Identity.Models
{
    /// <summary>
    /// Model factory that enables mocking for the Identity library.
    /// </summary>
    public static class CommunicationIdentityModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationUserIdentifierAndTokenResult"/> class.
        /// </summary>
        /// <param name="user"> The user stored in the instance. </param>
        /// <param name="accessToken"> The access token stored in the instance. </param>
        /// <returns>A new <see cref="CommunicationUserIdentifierAndTokenResult"/> instance for mocking.</returns>
        public static CommunicationUserIdentifierAndTokenResult CommunicationUserIdentifierAndTokenResult(CommunicationUserIdentifier user, AccessToken accessToken)
            => new CommunicationUserIdentifierAndTokenResult(new CommunicationIdentity(user.Id), new CommunicationIdentityAccessToken(accessToken.Token, accessToken.ExpiresOn));
    }
}
