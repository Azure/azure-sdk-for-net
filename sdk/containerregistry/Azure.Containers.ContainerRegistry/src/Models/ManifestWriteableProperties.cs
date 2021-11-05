// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry
{
    internal partial class ManifestWriteableProperties
    {
        /// <summary> Quarantine state. </summary>
        internal string QuarantineState { get; set; }
        /// <summary> Quarantine details. </summary>
        internal string QuarantineDetails { get; set; }
    }
}
