// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    [CodeGenModel("Annotations")]
    public partial class OciAnnotations
    {
        /// <summary> Date and time on which the image was built. </summary>
        [CodeGenMember("Created")]
        public DateTimeOffset? CreatedOn { get; set; }

        /// <summary> URL to find more information on the image. </summary>
        public Uri Url { get; set; }

        /// <summary> URL to get documentation on the image. </summary>
        public Uri Documentation { get; set; }

        /// <summary> URL to get source code for building the image. </summary>
        public Uri Source { get; set; }
    }
}
