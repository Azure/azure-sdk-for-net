// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat property shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerInstanceUsage
    {
        /// <summary> The name object of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceUsageName Name
        {
            get => NameValue as ContainerInstanceUsageName;
        }
    }
}