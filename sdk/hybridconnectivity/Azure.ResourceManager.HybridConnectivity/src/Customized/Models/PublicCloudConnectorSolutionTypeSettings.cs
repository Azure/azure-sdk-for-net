// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.HybridConnectivity;

namespace Azure.ResourceManager.HybridConnectivity.Models
{
    /// <summary> The properties of Solution Type. </summary>
    public partial class PublicCloudConnectorSolutionTypeSettings
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
