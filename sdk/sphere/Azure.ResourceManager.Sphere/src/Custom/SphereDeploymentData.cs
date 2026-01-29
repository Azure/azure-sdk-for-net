// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Sphere.Models;

namespace Azure.ResourceManager.Sphere
{
    public partial class SphereDeploymentData
    {
        /// <summary> Deployment ID. </summary>
        public string DeploymentId
        {
            get => Properties?.DeploymentId;
            set
            {
                EnsureProperties();
                Properties.DeploymentId = value;
            }
        }

        /// <summary> A list of images in the deployment. </summary>
        public IList<SphereImageData> DeployedImages => Properties?.DeployedImages;

        /// <summary> Deployment date and time (UTC). </summary>
        public DateTimeOffset? DeploymentDateUtc => Properties?.DeploymentDateUtc;

        /// <summary> The status of the last operation. </summary>
        public SphereProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        private void EnsureProperties() => Properties ??= new DeploymentProperties();
    }
}
