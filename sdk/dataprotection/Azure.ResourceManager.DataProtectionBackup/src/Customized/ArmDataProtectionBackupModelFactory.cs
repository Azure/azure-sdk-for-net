// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmDataProtectionBackupModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.BackupInstanceProtectionStatusDetails"/>. </summary>
        /// <param name="errorDetails"> Specifies the protection status error of the resource. </param>
        /// <param name="status"> Specifies the protection status of the resource. </param>
        /// <returns> A new <see cref="Models.BackupInstanceProtectionStatusDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupInstanceProtectionStatusDetails BackupInstanceProtectionStatusDetails(ResponseError errorDetails, BackupInstanceProtectionStatus? status)
        {
            return new BackupInstanceProtectionStatusDetails
            {
                ProtectionStatusErrorDetails = Models.DataProtectionBackupUserFacingError.ToUserFacingError(errorDetails),
                Status = status
            };
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent" />. </summary>
        /// <param name="objectType"></param>
        /// <param name="restoreTargetInfo">
        /// Gets or sets the restore target information.
        /// Please note <see cref="T:Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfoBase" /> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="T:Azure.ResourceManager.DataProtectionBackup.Models.ItemLevelRestoreTargetInfo" />, <see cref="T:Azure.ResourceManager.DataProtectionBackup.Models.RestoreFilesTargetInfo" /> and <see cref="T:Azure.ResourceManager.DataProtectionBackup.Models.RestoreTargetInfo" />.
        /// </param>
        /// <param name="sourceDataStoreType"> Gets or sets the type of the source data store. </param>
        /// <param name="sourceResourceId"> Fully qualified Azure Resource Manager ID of the datasource which is being recovered. </param>
        /// <param name="identityDetails">
        /// Contains information of the Identity Details for the BI.
        /// If it is null, default will be considered as System Assigned.
        /// </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.DataProtectionBackup.Models.BackupRestoreContent" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupRestoreContent BackupRestoreContent(string objectType, RestoreTargetInfoBase restoreTargetInfo, SourceDataStoreType sourceDataStoreType, ResourceIdentifier sourceResourceId, DataProtectionIdentityDetails identityDetails)
            => BackupRestoreContent(objectType, restoreTargetInfo, sourceDataStoreType, sourceResourceId , null, identityDetails);
    }
}
