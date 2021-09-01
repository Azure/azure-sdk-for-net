// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    [CodeGenModel("OCIManifest")]
    public partial class OciManifest
    {
        /// <summary> Additional information provided through arbitrary metadata. </summary>
        internal Annotations Annotations { get; }
    }
}
