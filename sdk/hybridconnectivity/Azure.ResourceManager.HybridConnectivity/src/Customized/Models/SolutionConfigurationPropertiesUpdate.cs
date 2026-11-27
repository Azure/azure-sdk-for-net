// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> Solution configuration resource. </summary>
    public partial class SolutionConfigurationPropertiesUpdate
    {
        /// <summary> Solution settings. </summary>
        public PublicCloudConnectorSolutionSettings SolutionSettings { get; set; }

        // TODO: Remove when https://github.com/Azure/azure-sdk-for-net/pull/62632 is available in the generator.
        /// <summary> Gets the additional solution properties. </summary>
        public IDictionary<string, string> SolutionAdditionalProperties
        {
            get
            {
                SolutionSettings ??= new PublicCloudConnectorSolutionSettings();
                return SolutionSettings.AdditionalProperties;
            }
        }
    }
}
