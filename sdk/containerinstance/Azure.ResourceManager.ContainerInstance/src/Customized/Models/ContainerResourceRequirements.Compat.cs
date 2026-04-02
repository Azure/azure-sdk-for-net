// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerResourceRequirements
    {
        /// <summary> Initializes a new instance of <see cref="ContainerResourceRequirements"/>. </summary>
        /// <param name="requests"> The resource requests. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerResourceRequirements(ContainerResourceRequestsContent requests)
            : this(requests, default, default)
        {
        }
    }
}
