// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerInstanceAzureFileVolume
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceAzureFileVolume"/>. </summary>
        /// <param name="shareName"> The share name. </param>
        /// <param name="storageAccountName"> The storage account name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceAzureFileVolume(string shareName, string storageAccountName)
            : this(shareName, default, storageAccountName, default, default, default)
        {
        }

        /// <summary> The flag indicating whether the Azure File shared mounted as a volume is read-only. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsReadOnly { get => ReadOnly; set => ReadOnly = value; }
    }
}
