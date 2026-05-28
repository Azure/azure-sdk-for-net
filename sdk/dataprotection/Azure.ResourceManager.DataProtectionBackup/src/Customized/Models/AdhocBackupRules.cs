// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Adhoc backup rules. </summary>
    [CodeGenSuppress("AdhocBackupRules", typeof(string), typeof(AdhocBackupTriggerSetting))]
    public partial class AdhocBackupRules
    {
        /// <summary> Initializes a new instance of AdhocBackupRules. </summary>
        /// <param name="ruleName"></param>
        /// <param name="backupTriggerRetentionTagOverride"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleName"/> or <paramref name="backupTriggerRetentionTagOverride"/> is null. </exception>
        public AdhocBackupRules(string ruleName, string backupTriggerRetentionTagOverride)
        {
            if (ruleName == null)
            {
                throw new ArgumentNullException(nameof(ruleName));
            }
            if (backupTriggerRetentionTagOverride == null)
            {
                throw new ArgumentNullException(nameof(backupTriggerRetentionTagOverride));
            }

            RuleName = ruleName;
            BackupTrigger = new AdhocBackupTriggerSetting
            {
                RetentionTagOverride = backupTriggerRetentionTagOverride
            };
        }
    }
}
