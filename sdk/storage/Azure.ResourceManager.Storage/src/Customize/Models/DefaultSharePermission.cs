// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct DefaultSharePermission
    {
        /// <summary> StorageFileDataSmbShareContributor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DefaultSharePermission Contributor => StorageFileDataSmbShareContributor;

        /// <summary> StorageFileDataSmbShareElevatedContributor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DefaultSharePermission ElevatedContributor => StorageFileDataSmbShareElevatedContributor;

        /// <summary> StorageFileDataSmbShareReader. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DefaultSharePermission Reader => StorageFileDataSmbShareReader;
    }
}
