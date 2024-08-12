// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> The configuration for container-enabled pools. </summary>
    public partial class BatchVmContainerConfiguration
    {
        /// <summary> The container technology to be used. </summary>
        public BatchVmContainerType ContainerType { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchVmContainerConfiguration"/> class.
        /// </summary>
        public BatchVmContainerConfiguration()
        {
            ContainerType = BatchVmContainerType.DockerCompatible;
        }
    }
}
