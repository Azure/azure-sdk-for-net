// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Repository properties. </summary>
    public partial class ContainerRepositoryProperties
    {
        /// <summary>
        /// Gets an instance of <see cref="ContainerRepositoryProperties"/>.
        /// </summary>
        public ContainerRepositoryProperties()
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
    }
}
