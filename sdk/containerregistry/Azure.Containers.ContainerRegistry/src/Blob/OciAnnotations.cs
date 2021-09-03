// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    [CodeGenModel("Annotations")]
    public partial class OciAnnotations
    {
        /// <summary> Date and time on which the image was built (string, date-time as defined by https://tools.ietf.org/html/rfc3339#section-5.6). </summary>
        [CodeGenMember("Created")]
        public DateTimeOffset? CreatedOn { get; set; }
    }
}
