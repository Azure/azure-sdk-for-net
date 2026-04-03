// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Hci.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    // Backward compat: the spec changed deploymentMode from optional to required,
    // but the GA SDK (1.2.1) exposed it as Nullable<EceDeploymentMode>.
    // Suppress the generated non-nullable property and re-declare as nullable.
    [CodeGenSuppress("DeploymentMode")]
    public partial class HciClusterDeploymentSettingData
    {
        /// <summary> The deployment mode for cluster deployment. </summary>
        [WirePath("properties.deploymentMode")]
        public EceDeploymentMode? DeploymentMode
        {
            get
            {
                return Properties is null ? default : Properties.DeploymentMode;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new DeploymentSettingsProperties();
                }
                if (value.HasValue)
                {
                    Properties.DeploymentMode = value.Value;
                }
            }
        }
    }
}
