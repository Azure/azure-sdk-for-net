// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Repository properties. </summary>
    public partial class RepositoryProperties
    {
        /// <summary>
        /// Gets an instance of <see cref="RepositoryProperties"/>.
        /// </summary>
        public RepositoryProperties()
        {
        }

        /// <summary> Delete enabled. </summary>
        public bool? CanDelete { get; set; }
        /// <summary> Write enabled. </summary>
        public bool? CanWrite { get; set; }
        /// <summary> List enabled. </summary>
        public bool? CanList { get; set; }
        /// <summary> Read enabled. </summary>
        public bool? CanRead { get; set; }
        /// <summary> Gets or sets whether Teleport functionality is enabled on new images in the repository. Setting this to true can improve Container startup performance. </summary>
        public bool? TeleportEnabled { get; set; }
    }
}
