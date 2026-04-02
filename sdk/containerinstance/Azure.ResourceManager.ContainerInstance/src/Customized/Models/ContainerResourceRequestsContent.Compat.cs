// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerResourceRequestsContent
    {
        /// <summary> Initializes a new instance of <see cref="ContainerResourceRequestsContent"/>. </summary>
        /// <param name="memoryInGB"> The memory in GB. </param>
        /// <param name="cpu"> The CPU request. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerResourceRequestsContent(double memoryInGB, double cpu)
            : this(memoryInGB, cpu, default, default)
        {
        }
    }
}
