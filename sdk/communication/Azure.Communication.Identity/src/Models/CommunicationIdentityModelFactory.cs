// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Identity.Models
{
    /// <summary>
    /// Model factory that enables mocking for the Identity library.
    /// </summary>
    public static partial class CommunicationIdentityModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Azure.Communication.Identity.CommunicationUserIdentifierAndToken"/> class.
        /// </summary>
        /// <param name="user"> The user stored in the instance. </param>
        /// <param name="accessToken"> The access token stored in the instance. </param>
        /// <returns>A new <see cref="Azure.Communication.Identity.CommunicationUserIdentifierAndToken"/> instance for mocking.</returns>
        public static CommunicationUserIdentifierAndToken CommunicationUserIdentifierAndToken(CommunicationUserIdentifier user, AccessToken accessToken)
            => new CommunicationUserIdentifierAndToken(new CommunicationIdentity(user.Id), new CommunicationIdentityAccessToken(accessToken.Token, accessToken.ExpiresOn));
    }
}
