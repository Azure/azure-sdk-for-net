// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Resources.DeploymentStacks;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Resources.DeploymentStacks.Models
{
    public partial class DeploymentExtension
    {
        /// <summary> The configuration used for deployment. The keys of this object should align with the extension config schema. </summary>
        [CodeGenMember("Config")]
        internal DeploymentExtensionConfig Config { get; set; }

        /// <summary> Gets the AdditionalProperties. </summary>
        public IDictionary<string, BinaryData> ConfigAdditionalProperties
        {
            get
            {
                if (Config is null)
                {
                    Config = new DeploymentExtensionConfig();
                }
                return Config.AdditionalProperties;
            }
        }
    }
}
