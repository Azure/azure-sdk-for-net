// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    [CodeGenModel("Descriptor")]
    public partial class OciBlobDescriptor
    {
        /// <summary> Layer media type. </summary>
        public string MediaType { get; set; }
        /// <summary> Layer size. </summary>
        public long? Size { get; set; }
        /// <summary> Layer digest. </summary>
        public string Digest { get; set; }

        /// <summary> Additional information provided through arbitrary metadata. </summary>
        public OciAnnotations Annotations { get; set; }

        /// <summary> Specifies a list of URIs from which this object may be downloaded. </summary>
        internal IList<Uri> Urls { get; }
    }
}
