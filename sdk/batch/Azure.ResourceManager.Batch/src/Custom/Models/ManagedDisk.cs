// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> The managed disk parameters. </summary>
    public partial class ManagedDisk
    {
        /// <summary> Specifies the EncryptionType of the managed disk. Use SecurityProfile.SecurityEncryptionType instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BatchSecurityEncryptionType? SecurityEncryptionType
        {
            get => SecurityProfile?.SecurityEncryptionType;
            set
            {
                if (SecurityProfile is null)
                    SecurityProfile = new VmDiskSecurityProfile();
                SecurityProfile.SecurityEncryptionType = value;
            }
        }
    }
}
