// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage;
using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;

namespace Microsoft.WCF.Azure.Tokens
{
    internal class StorageSharedKeySecurityToken : SecurityToken
    {
        public StorageSharedKeySecurityToken(StorageSharedKeyCredential storageSharedKeyCredential) : this(storageSharedKeyCredential, SecurityTokenUtils.CreateUniqueId()) { }

        public StorageSharedKeySecurityToken(StorageSharedKeyCredential storageSharedKeyCredential, string id)
        {
            StorageSharedKeyCredential = storageSharedKeyCredential;
            Id = id;
            ValidFrom = DateTime.UtcNow;
        }

        public StorageSharedKeyCredential StorageSharedKeyCredential { get; }
        public override string Id { get; }
        public override ReadOnlyCollection<SecurityKey> SecurityKeys => SecurityTokenUtils.EmptyReadOnlyCollection<SecurityKey>.Instance;
        public override DateTime ValidFrom { get; }
        public override DateTime ValidTo => SecurityTokenUtils.MaxUtcDateTime;
    }
}
