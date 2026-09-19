// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.Identity
{
    // Reduced to internal: wire model, not part of the public contract. Belongs in a spec-repo client.tsp via @access(Access.internal).
    [CodeGenSuppress("CommunicationIdentityAccessToken", typeof(string), typeof(DateTimeOffset))]
    [CodeGenSuppress("CommunicationIdentityAccessToken", typeof(string), typeof(DateTimeOffset), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("CommunicationIdentityAccessToken")]
    internal partial class CommunicationIdentityAccessToken
    {
        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityAccessToken"/>. </summary>
        /// <param name="token"> The access token issued for the identity. </param>
        /// <param name="expiresOn"> The expiry time of the token. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        internal CommunicationIdentityAccessToken(string token, DateTimeOffset expiresOn)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            Token = token;
            ExpiresOn = expiresOn;
        }

        /// <summary> Initializes a new instance of <see cref="CommunicationIdentityAccessToken"/>. </summary>
        /// <param name="token"> The access token issued for the identity. </param>
        /// <param name="expiresOn"> The expiry time of the token. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        internal CommunicationIdentityAccessToken(string token, DateTimeOffset expiresOn, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            Token = token;
            ExpiresOn = expiresOn;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }
    }
}
