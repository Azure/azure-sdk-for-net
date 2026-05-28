// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    [CodeGenModel("OciDescriptor")]
    public partial class OciDescriptor
    {
        /// <summary> Specifies a list of URIs from which this object may be downloaded. </summary>
        internal IList<Uri> Urls { get; }
    }
}
