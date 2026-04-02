// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerVolumeMount
    {
        /// <summary> Initializes a new instance of <see cref="ContainerVolumeMount"/>. </summary>
        /// <param name="name"> The volume name. </param>
        /// <param name="mountPath"> The mount path. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerVolumeMount(string name, string mountPath)
            : this(name, mountPath, default, default)
        {
        }

        /// <summary> The flag indicating whether the volume mount is read-only. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsReadOnly { get => ReadOnly; set => ReadOnly = value; }
    }
}
