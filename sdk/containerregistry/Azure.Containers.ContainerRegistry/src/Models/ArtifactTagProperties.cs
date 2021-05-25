// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Tag attributes. </summary>
    public partial class ArtifactTagProperties
    {
        /// <summary>
        /// Gets and instance of <see cref="ArtifactTagProperties"/>.
        /// </summary>
        public ArtifactTagProperties()
        {
        }

        /// <summary> Delete enabled. </summary>
        public bool? CanDelete { get; set; }
        /// <summary> Write enabled. </summary>
        public bool? CanWrite { get; set;  }
        /// <summary> List enabled. </summary>
        public bool? CanList { get; set; }
        /// <summary> Read enabled. </summary>
        public bool? CanRead { get; set; }
    }
}
