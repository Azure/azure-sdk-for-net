// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using CoreWCF.IdentityModel.Tokens;
using System;
using System.Collections.ObjectModel;

namespace Microsoft.CoreWCF.Azure.Tokens
{
    internal class SasSecurityToken : SecurityToken
    {
        public SasSecurityToken(AzureSasCredential sasCredential) : this(sasCredential, SecurityTokenUtils.CreateUniqueId()) { }

        public SasSecurityToken(AzureSasCredential sasCredential, string id)
        {
            SasCredential = sasCredential;
            Id = id;
            ValidFrom = DateTime.UtcNow;
        }

        public AzureSasCredential SasCredential { get; }
        public override string Id { get; }
        public override ReadOnlyCollection<SecurityKey> SecurityKeys => SecurityTokenUtils.EmptyReadOnlyCollection<SecurityKey>.Instance;
        public override DateTime ValidFrom { get; }
        public override DateTime ValidTo => SecurityTokenUtils.MaxUtcDateTime;
    }
}
