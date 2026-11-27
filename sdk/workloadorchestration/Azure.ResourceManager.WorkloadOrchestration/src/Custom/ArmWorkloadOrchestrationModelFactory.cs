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
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.WorkloadOrchestration.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    [CodeGenSuppress("BulkPublishTargetDetails", typeof(ResourceIdentifier), typeof(IEnumerable<EdgeSolutionDependencyContent>), typeof(string), typeof(ResourceIdentifier), typeof(string))]
    public static partial class ArmWorkloadOrchestrationModelFactory
    {
        // Keep the shipped parameter order so that calls passing a positional null remain unambiguous.
        /// <summary> Creates a new instance of <see cref="Models.BulkPublishTargetDetails"/> for mocking. </summary>
        /// <param name="targetId"> ArmId of Target. </param>
        /// <param name="solutionInstanceName"> Name of the solution instance. </param>
        /// <param name="solutionDependencies"> Solution dependencies. </param>
        /// <param name="solutionVersionId"> ArmId of Target Solution Version. </param>
        /// <param name="solutionConfiguration"> Configuration of solution. </param>
        /// <returns> A new <see cref="Models.BulkPublishTargetDetails"/> instance for mocking. </returns>
        public static BulkPublishTargetDetails BulkPublishTargetDetails(
            ResourceIdentifier targetId = default,
            string solutionInstanceName = default,
            IEnumerable<EdgeSolutionDependencyContent> solutionDependencies = default,
            ResourceIdentifier solutionVersionId = default,
            string solutionConfiguration = default)
            => new BulkPublishTargetDetails(
                targetId,
                (solutionDependencies ?? new ChangeTrackingList<EdgeSolutionDependencyContent>()).ToList(),
                solutionInstanceName,
                solutionVersionId,
                solutionConfiguration,
                default);

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
