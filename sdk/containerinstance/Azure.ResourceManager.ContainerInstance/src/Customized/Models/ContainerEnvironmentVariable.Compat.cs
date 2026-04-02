// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerEnvironmentVariable
    {
        /// <summary> Initializes a new instance of <see cref="ContainerEnvironmentVariable"/>. </summary>
        /// <param name="name"> The variable name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerEnvironmentVariable(string name)
            : this(name, default, default, default, default)
        {
        }
    }
}
