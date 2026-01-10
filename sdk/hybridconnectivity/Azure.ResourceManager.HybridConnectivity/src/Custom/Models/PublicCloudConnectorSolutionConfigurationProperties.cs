// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.HybridConnectivity;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> Solution configuration resource. </summary>
    public partial class PublicCloudConnectorSolutionConfigurationProperties
    {
        /// <summary> Solution settings. </summary>
        public PublicCloudConnectorSolutionSettings SolutionSettings { get; set; }
    }
}
