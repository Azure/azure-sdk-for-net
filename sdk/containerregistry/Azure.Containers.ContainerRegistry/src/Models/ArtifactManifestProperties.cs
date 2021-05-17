// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Manifest attributes details. </summary>
    public partial class ArtifactManifestProperties
    {
        /// <summary> Delete enabled. </summary>
        public bool? CanDelete { get; set; }
        /// <summary> Write enabled. </summary>
        public bool? CanWrite { get; set;  }
        /// <summary> List enabled. </summary>
        public bool? CanList { get; set;  }
        /// <summary> Read enabled. </summary>
        public bool? CanRead { get; set; }
        /// <summary> Quarantine state. </summary>
        internal string QuarantineState { get; }
        /// <summary> Quarantine details. </summary>
        internal string QuarantineDetails { get; }
    }
}
