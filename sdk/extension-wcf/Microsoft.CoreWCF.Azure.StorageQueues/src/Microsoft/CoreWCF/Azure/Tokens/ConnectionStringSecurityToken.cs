// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF.IdentityModel.Tokens;
using System;
using System.Collections.ObjectModel;

namespace Microsoft.CoreWCF.Azure.Tokens
{
    internal class ConnectionStringSecurityToken : SecurityToken
    {
        public ConnectionStringSecurityToken(string connectionString) : this(connectionString, SecurityTokenUtils.CreateUniqueId()) { }

        public ConnectionStringSecurityToken(string connectionString, string id)
        {
            ConnectionString = connectionString;
            Id = id;
            ValidFrom = DateTime.UtcNow;
        }

        public string ConnectionString { get; }
        public override string Id { get; }
        public override ReadOnlyCollection<SecurityKey> SecurityKeys => SecurityTokenUtils.EmptyReadOnlyCollection<SecurityKey>.Instance;
        public override DateTime ValidFrom { get; }
        public override DateTime ValidTo => SecurityTokenUtils.MaxUtcDateTime;
    }
}
