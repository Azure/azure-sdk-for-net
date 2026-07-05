// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.WorkloadOrchestration;

namespace Azure.ResourceManager.WorkloadOrchestration.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmWorkloadOrchestrationModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.EdgeSolutionTemplateProperties"/>. </summary>
        /// <param name="description"> Description of Solution template. </param>
        /// <param name="capabilities"> List of capabilities. </param>
        /// <param name="latestVersion"> Latest solution template version. </param>
        /// <param name="state"> State of resource. </param>
        /// <param name="isExternalValidationEnabled"> Flag to enable external validation. </param>
        /// <param name="provisioningState"> Provisioning state of resource. </param>
        /// <returns> A new <see cref="Models.EdgeSolutionTemplateProperties"/> instance for mocking. </returns>
        public static EdgeSolutionTemplateProperties EdgeSolutionTemplateProperties(string description, IEnumerable<string> capabilities, string latestVersion, EdgeResourceState? state, bool? isExternalValidationEnabled, WorkloadOrchestrationProvisioningState? provisioningState)
            => EdgeSolutionTemplateProperties(null, description, capabilities, latestVersion, state, isExternalValidationEnabled, provisioningState);

        /// <summary> Initializes a new instance of <see cref="Models.EdgeConfigTemplateProperties"/>. </summary>
        /// <param name="description"> Description of config template. </param>
        /// <param name="latestVersion"> Latest config template version. </param>
        /// <param name="provisioningState"> Provisioning state of resource. </param>
        /// <returns> A new <see cref="Models.EdgeConfigTemplateProperties"/> instance for mocking. </returns>
        public static EdgeConfigTemplateProperties EdgeConfigTemplateProperties(string description, string latestVersion, WorkloadOrchestrationProvisioningState? provisioningState)
            => EdgeConfigTemplateProperties(null, description, latestVersion, provisioningState);
    }
}
