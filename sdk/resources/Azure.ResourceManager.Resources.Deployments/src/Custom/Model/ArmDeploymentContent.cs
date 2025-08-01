// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class ArmDeploymentContent
    {
        /// <summary>
        /// The Managed Identity configuration for a deployment.
        /// The supported types are: None, UserAssigned
        /// </summary>
        [WirePath("identity")]
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get; set; }
    }
}
