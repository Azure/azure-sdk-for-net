// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    /// <summary> Gets or sets the type of the datastore. </summary>
    public readonly partial struct StorageSettingStoreType
    {
        private const string SnapshotStoreValue = "SnapshotStore";

        /// <summary> SnapshotStore. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSettingStoreType SnapshotStore { get; } = new StorageSettingStoreType(SnapshotStoreValue);
    }
}
