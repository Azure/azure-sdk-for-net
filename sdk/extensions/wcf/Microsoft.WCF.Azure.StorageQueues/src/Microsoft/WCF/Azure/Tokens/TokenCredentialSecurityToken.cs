// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;

namespace Microsoft.WCF.Azure.Tokens
{
    internal class TokenCredentialSecurityToken : SecurityToken
    {
        public TokenCredentialSecurityToken(TokenCredential tokenCredential) : this(tokenCredential, SecurityTokenUtils.CreateUniqueId()) { }

        public TokenCredentialSecurityToken(TokenCredential tokenCredential, string id)
        {
            TokenCredential = tokenCredential;
            Id = id;
            ValidFrom = DateTime.UtcNow;
        }

        public TokenCredential TokenCredential { get; }
        public override string Id { get; }
        public override ReadOnlyCollection<SecurityKey> SecurityKeys => SecurityTokenUtils.EmptyReadOnlyCollection<SecurityKey>.Instance;
        public override DateTime ValidFrom { get; }
        public override DateTime ValidTo => SecurityTokenUtils.MaxUtcDateTime;
    }
}
