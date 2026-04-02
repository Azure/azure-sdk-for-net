// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

// Backward-compat constructor shims for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerInstanceContainer
    {
        /// <summary> Initializes a new instance of <see cref="ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The name of the container. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceContainer(string name)
            : this(name, (ContainerProperties)default, (IDictionary<string, System.BinaryData>)default)
        {
        }

        /// <summary> Initializes a new instance of <see cref="ContainerInstanceContainer"/>. </summary>
        /// <param name="name"> The name of the container. </param>
        /// <param name="image"> The container image. </param>
        /// <param name="resources"> The resource requirements. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceContainer(string name, string image, ContainerResourceRequirements resources)
            : this(name, (ContainerProperties)default, (IDictionary<string, System.BinaryData>)default)
        {
        }
    }
}
