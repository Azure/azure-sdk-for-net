// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerInstanceGitRepoVolume
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceGitRepoVolume"/>. </summary>
        /// <param name="repository"> The repository URL. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceGitRepoVolume(string repository)
            : this(default, repository, default, default)
        {
        }
    }
}
