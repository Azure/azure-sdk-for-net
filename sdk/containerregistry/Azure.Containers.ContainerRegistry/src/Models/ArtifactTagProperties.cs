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

        /// <summary> Whether or not this tag can be deleted. </summary>
        public bool? CanDelete { get; set; }
        /// <summary> Whether or not this tag can be written to. </summary>
        public bool? CanWrite { get; set;  }
        /// <summary> Whether or not to include this tag in the collection returned from <see cref="RegistryArtifact.GetAllTagProperties"/>. </summary>
        public bool? CanList { get; set; }
        /// <summary> Whether or not this tag can be read. </summary>
        public bool? CanRead { get; set; }
    }
}
