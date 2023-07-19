// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Properties of an artifact's manifest. </summary>
    public partial class ArtifactManifestProperties
    {
        /// <summary>
        /// Gets an instance of <see cref="ArtifactManifestProperties"/>.
        /// </summary>
        public ArtifactManifestProperties()
        {
        }

        /// <summary> Whether or not this tag can be deleted. </summary>
        public bool? CanDelete { get; set; }
        /// <summary> Whether or not this tag can be written to. </summary>
        public bool? CanWrite { get; set;  }
        /// <summary> Whether or not to include this artifact in the collection returned from <see cref="ContainerRepository.GetAllManifestProperties"/>. </summary>
        public bool? CanList { get; set;  }
        /// <summary> Whether or not this tag can be read. </summary>
        public bool? CanRead { get; set; }
        /// <summary> Image size. </summary>
        [CodeGenMember("Size")]
        public long? SizeInBytes { get; }
        /// <summary> Quarantine state. </summary>
        internal string QuarantineState { get; }
        /// <summary> Quarantine details. </summary>
        internal string QuarantineDetails { get; }
    }
}
