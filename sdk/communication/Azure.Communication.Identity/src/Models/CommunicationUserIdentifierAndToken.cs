// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Communication.Identity.Models;
using Azure.Core;

namespace Azure.Communication.Identity
{
    [CodeGenModel("CommunicationIdentityAccessTokenResult")]
    public partial class CommunicationUserIdentifierAndToken
    {
        private readonly AccessToken? _accessToken;

        internal CommunicationUserIdentifierAndToken(CommunicationIdentity identity, CommunicationIdentityAccessToken accessToken)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            Identity = identity;
            InternalAccessToken = accessToken;
            User = new CommunicationUserIdentifier(identity.Id);
            _accessToken = accessToken is null ? null : new AccessToken(accessToken.Token, accessToken.ExpiresOn);
        }

        /// <summary>Deconstructs the <see cref="CommunicationUserIdentifierAndToken"/> into a user and token.</summary>
        /// <param name="user">The value of the <see cref="User"/> property.</param>
        /// <param name="accessToken">The value of the <see cref="AccessToken"/> property.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out CommunicationUserIdentifier user, out AccessToken accessToken)
        {
            user = User;
            accessToken = AccessToken;
        }

        internal CommunicationIdentity Identity { get; }

        [CodeGenMember("AccessToken")]
        internal CommunicationIdentityAccessToken InternalAccessToken { get; }

        /// <summary>A communication user.</summary>
        public CommunicationUserIdentifier User { get; }

        /// <summary>The token created for <see cref="User"/>.</summary>
        public AccessToken AccessToken => _accessToken.Value;
    }
}
