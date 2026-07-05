// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore GA status enum type over the generated private-link status type.
    [CodeGenSuppress("Status")]
    public partial class MachineLearningPrivateLinkServiceConnectionState
    {
        /// <summary> Connection status of the service consumer with the service provider. </summary>
        [WirePath("status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPrivateEndpointServiceConnectionStatus? Status { get; set; }
    }
}
