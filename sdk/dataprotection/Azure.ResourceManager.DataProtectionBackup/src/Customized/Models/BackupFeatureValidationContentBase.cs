// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary>
    /// Base class for Backup Feature support
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="BackupFeatureValidationContent"/>.
    /// </summary>
    public abstract partial class BackupFeatureValidationContentBase
    {
        /// <summary> Initializes a new instance of <see cref="BackupFeatureValidationContentBase"/> for deserialization. </summary>
        protected BackupFeatureValidationContentBase()  // This constructor is protected for backward compatibility.
        {
        }
    }
}
