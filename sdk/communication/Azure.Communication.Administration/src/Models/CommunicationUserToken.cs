// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Administration.Models
{
    [CodeGenModel("CommunicationIdentityToken")]
    public partial class CommunicationUserToken
    {
        internal CommunicationUserToken(string id, string token, DateTimeOffset expiresOn)
        {
            Id = id;
            User = new CommunicationUserIdentifier(id);
            Token = token;
            ExpiresOn = expiresOn;
        }

        /// <summary>
        /// The <see cref="CommunicationUserIdentifier" /> for which the token is being issued.
        /// </summary>
        public CommunicationUserIdentifier User { get; }
        internal string Id { get; }
    }
}
