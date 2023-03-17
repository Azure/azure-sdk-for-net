// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> List of Vaults. </summary>
    internal partial class VaultList
    {
        /// <summary> Initializes a new instance of VaultList. </summary>
        internal VaultList()
        {
            Value = new ChangeTrackingList<NetAppVault>();
        }

        /// <summary> Initializes a new instance of VaultList. </summary>
        /// <param name="value"> A list of vaults. </param>
        internal VaultList(IReadOnlyList<NetAppVault> value)
        {
            Value = value;
        }

        /// <summary> A list of vaults. </summary>
        public IReadOnlyList<NetAppVault> Value { get; }
    }
}
