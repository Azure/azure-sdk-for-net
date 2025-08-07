// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Developer.DevCenter.Models
{
    public partial class DevCenterEnvironmentType
    {
        /// <summary>
        /// Id of a subscription or management group that the environment type will be
        /// mapped to. The environment's resources will be deployed into this subscription
        /// or management group.
        /// </summary>
        public ResourceIdentifier DeploymentTargetId { get; }
    }
}
