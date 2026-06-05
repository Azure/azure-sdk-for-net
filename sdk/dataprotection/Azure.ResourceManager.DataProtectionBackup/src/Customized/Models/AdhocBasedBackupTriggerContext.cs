// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Adhoc trigger context. </summary>
    public partial class AdhocBasedBackupTriggerContext : DataProtectionBackupTriggerContext
    {
        /// <summary> Initializes a new instance of AdhocBasedBackupTriggerContext. </summary>
        /// <param name="adhocBackupRetentionTagInfo"> Retention tag information. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="adhocBackupRetentionTagInfo"/> is null. </exception>
        public AdhocBasedBackupTriggerContext(DataProtectionBackupRetentionTag adhocBackupRetentionTagInfo)
        {
            if (adhocBackupRetentionTagInfo == null)
            {
                throw new ArgumentNullException(nameof(adhocBackupRetentionTagInfo));
            }

            AdhocBackupRetention = new AdhocBasedBackupTaggingCriteria
            {
                TagInfo = adhocBackupRetentionTagInfo
            };
            ObjectType = "AdhocBasedTriggerContext";
        }
    }
}
