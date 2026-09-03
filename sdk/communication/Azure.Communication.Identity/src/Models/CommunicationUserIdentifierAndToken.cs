// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.Identity
{
    [CodeGenType("CommunicationIdentityAccessTokenResult")]
    [CodeGenSuppress("CommunicationUserIdentifierAndToken", typeof(CommunicationIdentity))]
    public partial class CommunicationUserIdentifierAndToken
    {
        internal CommunicationUserIdentifierAndToken(CommunicationIdentity identity, CommunicationIdentityAccessToken accessToken)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));

            Identity = identity;
            InternalAccessToken = accessToken;
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

        // User and AccessToken are computed rather than assigned in the constructor. The generated
        // deserializer builds this type through the generator's own constructor, which only knows
        // about Identity and InternalAccessToken, so anything assigned in a hand-written constructor
        // would stay null on every deserialized instance.
        private AccessToken? AccessTokenCore
            => InternalAccessToken is null ? null : new AccessToken(InternalAccessToken.Token, InternalAccessToken.ExpiresOn);

        /// <summary>A communication user.</summary>
        public CommunicationUserIdentifier User => new CommunicationUserIdentifier(Identity.Id);

        /// <summary>The token created for <see cref="User"/>.</summary>
        public AccessToken AccessToken => AccessTokenCore.Value;
    }
}
