// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.DevOpsInfrastructure;

namespace Azure.ResourceManager.DevOpsInfrastructure.Models
{
    public partial class DevOpsPoolProperties
    {
        /// <summary> Initializes a new instance of <see cref="DevOpsPoolProperties"/>. </summary>
        /// <param name="maximumConcurrency"> Defines how many resources can there be created at any given time. </param>
        /// <param name="organizationProfile"> Defines the organization in which the pool will be used. </param>
        /// <param name="agentProfile"> Defines how the machine will be handled once it executed a job. </param>
        /// <param name="fabricProfile"> Defines the type of fabric the agent will run on. </param>
        /// <param name="devCenterProjectResourceId"> The resource id of the DevCenter Project the pool belongs to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="organizationProfile"/>, <paramref name="agentProfile"/>, <paramref name="fabricProfile"/> or <paramref name="devCenterProjectResourceId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DevOpsPoolProperties(int maximumConcurrency, DevOpsOrganizationProfile organizationProfile, DevOpsPoolAgentProfile agentProfile, DevOpsFabricProfile fabricProfile, string devCenterProjectResourceId)
            : this(maximumConcurrency, organizationProfile, agentProfile, fabricProfile)
        {
            Argument.AssertNotNull(devCenterProjectResourceId, nameof(devCenterProjectResourceId));
            DevCenterProjectResourceId = devCenterProjectResourceId;
        }
    }
}
