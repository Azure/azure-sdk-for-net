// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVault : ResourceData
    {
        public string VaultName { get; }

        internal NetAppVault() { }
        internal NetAppVault(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string vaultName) : base(id, name, resourceType, systemData)
        {
            VaultName = vaultName;
            throw null;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
