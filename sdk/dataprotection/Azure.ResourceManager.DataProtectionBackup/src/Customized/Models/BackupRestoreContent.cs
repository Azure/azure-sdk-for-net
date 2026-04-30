// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public abstract partial class BackupRestoreContent
    {
        /// <summary> Initializes a new instance of <see cref="BackupRestoreContent"/>. </summary>
        /// <param name="restoreTargetInfo">
        /// Gets or sets the restore target information.
        /// Please note <see cref="RestoreTargetInfoBase"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ItemLevelRestoreTargetInfo"/>, <see cref="RestoreFilesTargetInfo"/> and <see cref="Models.RestoreTargetInfo"/>.
        /// </param>
        /// <param name="sourceDataStoreType"> Gets or sets the type of the source data store. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="restoreTargetInfo"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected BackupRestoreContent(RestoreTargetInfoBase restoreTargetInfo, SourceDataStoreType sourceDataStoreType)
        {
            Argument.AssertNotNull(restoreTargetInfo, nameof(restoreTargetInfo));

            RestoreTargetInfo = restoreTargetInfo;
            SourceDataStoreType = sourceDataStoreType;
            ResourceGuardOperationRequests = new ChangeTrackingList<string>();
        }
    }
}
