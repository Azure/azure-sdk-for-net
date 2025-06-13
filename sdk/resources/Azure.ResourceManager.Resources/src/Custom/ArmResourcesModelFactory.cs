// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmResourcesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ArmDeploymentPropertiesExtended"/>. </summary>
        /// <param name="provisioningState"> Denotes the state of provisioning. </param>
        /// <param name="correlationId"> The correlation ID of the deployment. </param>
        /// <param name="timestamp"> The timestamp of the template deployment. </param>
        /// <param name="duration"> The duration of the template deployment. </param>
        /// <param name="outputs"> Key/value pairs that represent deployment output. </param>
        /// <param name="providers"> The list of resource providers needed for the deployment. </param>
        /// <param name="dependencies"> The list of deployment dependencies. </param>
        /// <param name="templateLink"> The URI referencing the template. </param>
        /// <param name="parameters"> Deployment parameters. </param>
        /// <param name="parametersLink"> The URI referencing the parameters. </param>
        /// <param name="mode"> The deployment mode. Possible values are Incremental and Complete. </param>
        /// <param name="debugSettingDetailLevel"> The debug setting of the deployment. </param>
        /// <param name="errorDeployment"> The deployment on error behavior. </param>
        /// <param name="templateHash"> The hash produced for the template. </param>
        /// <param name="outputResources"> Array of provisioned resources. </param>
        /// <param name="validatedResources"> Array of validated resources. </param>
        /// <param name="error"> The deployment error. </param>
        /// <param name="diagnostics"> Contains diagnostic information collected during validation process. </param>
        /// <param name="validationLevel"> The validation level of the deployment. </param>
        /// <returns> A new <see cref="Models.ArmDeploymentPropertiesExtended"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmDeploymentPropertiesExtended ArmDeploymentPropertiesExtended(ResourcesProvisioningState? provisioningState, string correlationId, DateTimeOffset? timestamp, TimeSpan? duration, BinaryData outputs, IEnumerable<ResourceProviderData> providers, IEnumerable<ArmDependency> dependencies, ArmDeploymentTemplateLink templateLink, BinaryData parameters, ArmDeploymentParametersLink parametersLink, ArmDeploymentMode? mode = default, string debugSettingDetailLevel = null, ErrorDeploymentExtended errorDeployment = null, string templateHash = null, IEnumerable<SubResource> outputResources = null, IEnumerable<SubResource> validatedResources = null, ResponseError error = null, IEnumerable<DeploymentDiagnosticsDefinition> diagnostics = null, ValidationLevel? validationLevel = default)
        {
            return ArmDeploymentPropertiesExtended(
                provisioningState: provisioningState,
                correlationId: correlationId,
                timestamp: timestamp,
                duration: duration,
                outputs: outputs,
                providers: providers,
                dependencies: dependencies,
                templateLink: templateLink,
                parameters: parameters,
                parametersLink: parametersLink,
                mode: mode,
                debugSettingDetailLevel: debugSettingDetailLevel,
                errorDeployment: errorDeployment,
                templateHash: templateHash,
                outputResourceDetails: outputResources != null ? outputResources.Select(r => ArmResourceReference(id: r.Id)) : null,
                validatedResourceDetails: validatedResources != null ? validatedResources.Select(r => ArmResourceReference(id: r.Id)) : null,
                error: error,
                diagnostics: diagnostics,
                validationLevel: validationLevel
                );
        }

        /// <summary> Initializes a new instance of <see cref="Models.ArmDeploymentPropertiesExtended" />. </summary>
        /// <param name="provisioningState"> Denotes the state of provisioning. </param>
        /// <param name="correlationId"> The correlation ID of the deployment. </param>
        /// <param name="timestamp"> The timestamp of the template deployment. </param>
        /// <param name="duration"> The duration of the template deployment. </param>
        /// <param name="outputs"> Key/value pairs that represent deployment output. </param>
        /// <param name="providers"> The list of resource providers needed for the deployment. </param>
        /// <param name="dependencies"> The list of deployment dependencies. </param>
        /// <param name="templateLink"> The URI referencing the template. </param>
        /// <param name="parameters"> Deployment parameters. </param>
        /// <param name="parametersLink"> The URI referencing the parameters. </param>
        /// <param name="mode"> The deployment mode. Possible values are Incremental and Complete. </param>
        /// <param name="debugSettingDetailLevel"> The debug setting of the deployment. </param>
        /// <param name="errorDeployment"> The deployment on error behavior. </param>
        /// <param name="templateHash"> The hash produced for the template. </param>
        /// <param name="outputResources"> Array of provisioned resources. </param>
        /// <param name="validatedResources"> Array of validated resources. </param>
        /// <param name="error"> The deployment error. </param>
        /// <returns> A new <see cref="Models.ArmDeploymentPropertiesExtended" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmDeploymentPropertiesExtended ArmDeploymentPropertiesExtended(ResourcesProvisioningState? provisioningState, string correlationId, DateTimeOffset? timestamp, TimeSpan? duration, BinaryData outputs, IEnumerable<ResourceProviderData> providers, IEnumerable<ArmDependency> dependencies, ArmDeploymentTemplateLink templateLink, BinaryData parameters, ArmDeploymentParametersLink parametersLink, ArmDeploymentMode? mode, string debugSettingDetailLevel, ErrorDeploymentExtended errorDeployment, string templateHash, IEnumerable<SubResource> outputResources, IEnumerable<SubResource> validatedResources, ResponseError error)
        {
            return ArmDeploymentPropertiesExtended(
                provisioningState: provisioningState,
                correlationId: correlationId,
                timestamp: timestamp,
                duration: duration,
                outputs: outputs,
                providers: providers,
                dependencies: dependencies,
                templateLink: templateLink,
                parameters: parameters,
                parametersLink: parametersLink,
                mode: mode,
                debugSettingDetailLevel: debugSettingDetailLevel,
                errorDeployment: errorDeployment,
                templateHash: templateHash,
                outputResources: outputResources,
                validatedResources: validatedResources,
                error: error,
                diagnostics: default,
                validationLevel: default);
        }
    }
}
