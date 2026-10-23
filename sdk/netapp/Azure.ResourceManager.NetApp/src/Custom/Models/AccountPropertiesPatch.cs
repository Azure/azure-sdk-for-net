// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetApp.Models
{
    internal partial class AccountPropertiesPatch
    {
        /// <summary> Active Directories configured for the account. </summary>
        public IList<NetAppAccountActiveDirectory> ActiveDirectories { get; } = new ChangeTrackingList<NetAppAccountActiveDirectory>();

        /// <summary> Encryption settings of the account. </summary>
        [CodeGenMember("Encryption")]
        public NetAppAccountEncryption Encryption { get; set; }
    }
}
