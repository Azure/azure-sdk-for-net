// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the dependency of the move resource. </summary>
    public partial class MoverResourceDependency
    {
        /// <summary> Gets or sets a value indicating whether the dependency is optional. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsOptional
        {
            get => bool.TryParse(IsDependencyOptional, out bool isOptional) ? isOptional : null;
        }
    }
}
