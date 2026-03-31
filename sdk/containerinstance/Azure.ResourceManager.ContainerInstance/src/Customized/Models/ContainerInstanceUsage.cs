// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerInstanceUsage
    {
        /// <summary> The name object of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerInstanceUsageName Name => _name as ContainerInstanceUsageName;
    }
}
