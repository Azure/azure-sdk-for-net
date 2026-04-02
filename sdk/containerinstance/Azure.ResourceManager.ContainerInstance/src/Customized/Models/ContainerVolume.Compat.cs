// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerVolume
    {
        /// <summary> Initializes a new instance of <see cref="ContainerVolume"/>. </summary>
        /// <param name="name"> The volume name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerVolume(string name)
            : this(name, default, default, default, default, default, default)
        {
        }
    }
}
