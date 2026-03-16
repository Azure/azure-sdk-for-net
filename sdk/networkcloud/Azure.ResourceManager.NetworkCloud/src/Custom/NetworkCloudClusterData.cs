// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudClusterData
    {
        /// <summary> The mode of operation for runtime protection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RuntimeProtectionEnforcementLevel? RuntimeProtectionEnforcementLevel
        {
            get => RuntimeProtectionConfiguration?.EnforcementLevel;
            set
            {
                if (RuntimeProtectionConfiguration == null)
                    RuntimeProtectionConfiguration = new RuntimeProtectionConfiguration();
                RuntimeProtectionConfiguration.EnforcementLevel = value;
            }
        }
    }
}
