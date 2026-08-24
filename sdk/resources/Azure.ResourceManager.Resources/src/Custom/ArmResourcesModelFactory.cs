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
        /// <summary> Initializes a new instance of <see cref="Models.AzureCliScript"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> Optional property. Managed identity to be used for this deployment script. Currently, only user-assigned MSI is supported. </param>
        /// <param name="location"> The location of the ACI and the storage account for the deployment script. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="containerGroupName"> Container settings. </param>
        /// <param name="storageAccountSettings"> Storage Account settings. </param>
        /// <param name="cleanupPreference"> The clean up preference when the script execution gets in a terminal state. Default setting is 'Always'. </param>
        /// <param name="provisioningState"> State of the script execution. This only appears in the response. </param>
        /// <param name="status"> Contains the results of script execution. </param>
        /// <param name="outputs"> List of script outputs. </param>
        /// <param name="primaryScriptUri"> Uri for the script. This is the entry point for the external script. </param>
        /// <param name="supportingScriptUris"> Supporting files for the external script. </param>
        /// <param name="scriptContent"> Script body. </param>
        /// <param name="arguments"> Command line arguments to pass to the script. Arguments are separated by spaces. ex: -Name blue* -Location 'West US 2'. </param>
        /// <param name="environmentVariables"> The environment variables to pass over to the script. </param>
        /// <param name="forceUpdateTag"> Gets or sets how the deployment script should be forced to execute even if the script resource has not changed. Can be current time stamp or a GUID. </param>
        /// <param name="retentionInterval"> Interval for which the service retains the script resource after it reaches a terminal state. Resource will be deleted when this duration expires. Duration is based on ISO 8601 pattern (for example P1D means one day). </param>
        /// <param name="timeout"> Maximum allowed script execution time specified in ISO 8601 format. Default value is P1D. </param>
        /// <param name="azCliVersion"> Azure CLI module version to be used. </param>
        /// <returns> A new <see cref="Models.AzureCliScript"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AzureCliScript AzureCliScript(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ArmDeploymentScriptManagedIdentity identity = null, AzureLocation location = default, IDictionary<string, string> tags = null, string containerGroupName = null, ScriptStorageConfiguration storageAccountSettings = null, ScriptCleanupOptions? cleanupPreference = null, ScriptProvisioningState? provisioningState = null, ScriptStatus status = null, BinaryData outputs = null, Uri primaryScriptUri = null, IEnumerable<Uri> supportingScriptUris = null, string scriptContent = null, string arguments = null, IEnumerable<ScriptEnvironmentVariable> environmentVariables = null, string forceUpdateTag = null, TimeSpan retentionInterval = default, TimeSpan? timeout = null, string azCliVersion = null)
        {
            tags ??= new Dictionary<string, string>();
            supportingScriptUris ??= new List<Uri>();
            environmentVariables ??= new List<ScriptEnvironmentVariable>();

            return AzureCliScript(
                id,
                name,
                resourceType,
                systemData,
                identity,
                location,
                tags,
                containerGroupName != null ? new ScriptContainerConfiguration() { ContainerGroupName = containerGroupName } : null,
                storageAccountSettings,
                cleanupPreference,
                provisioningState,
                status,
                outputs,
                primaryScriptUri,
                supportingScriptUris?.ToList(),
                scriptContent,
                arguments,
                environmentVariables?.ToList(),
                forceUpdateTag,
                retentionInterval,
                timeout,
                azCliVersion);
        }

        /// <summary> Initializes a new instance of <see cref="Models.AzurePowerShellScript"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> Optional property. Managed identity to be used for this deployment script. Currently, only user-assigned MSI is supported. </param>
        /// <param name="location"> The location of the ACI and the storage account for the deployment script. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="containerGroupName"> Container settings. </param>
        /// <param name="storageAccountSettings"> Storage Account settings. </param>
        /// <param name="cleanupPreference"> The clean up preference when the script execution gets in a terminal state. Default setting is 'Always'. </param>
        /// <param name="provisioningState"> State of the script execution. This only appears in the response. </param>
        /// <param name="status"> Contains the results of script execution. </param>
        /// <param name="outputs"> List of script outputs. </param>
        /// <param name="primaryScriptUri"> Uri for the script. This is the entry point for the external script. </param>
        /// <param name="supportingScriptUris"> Supporting files for the external script. </param>
        /// <param name="scriptContent"> Script body. </param>
        /// <param name="arguments"> Command line arguments to pass to the script. Arguments are separated by spaces. ex: -Name blue* -Location 'West US 2'. </param>
        /// <param name="environmentVariables"> The environment variables to pass over to the script. </param>
        /// <param name="forceUpdateTag"> Gets or sets how the deployment script should be forced to execute even if the script resource has not changed. Can be current time stamp or a GUID. </param>
        /// <param name="retentionInterval"> Interval for which the service retains the script resource after it reaches a terminal state. Resource will be deleted when this duration expires. Duration is based on ISO 8601 pattern (for example P1D means one day). </param>
        /// <param name="timeout"> Maximum allowed script execution time specified in ISO 8601 format. Default value is P1D. </param>
        /// <param name="azPowerShellVersion"> Azure PowerShell module version to be used. </param>
        /// <returns> A new <see cref="Models.AzurePowerShellScript"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AzurePowerShellScript AzurePowerShellScript(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ArmDeploymentScriptManagedIdentity identity, AzureLocation location, IDictionary<string, string> tags, string containerGroupName, ScriptStorageConfiguration storageAccountSettings = null, ScriptCleanupOptions? cleanupPreference = null, ScriptProvisioningState? provisioningState = null, ScriptStatus status = null, BinaryData outputs = null, Uri primaryScriptUri = null, IEnumerable<Uri> supportingScriptUris = null, string scriptContent = null, string arguments = null, IEnumerable<ScriptEnvironmentVariable> environmentVariables = null, string forceUpdateTag = null, TimeSpan retentionInterval = default, TimeSpan? timeout = null, string azPowerShellVersion = null)
        {
            return AzurePowerShellScript(
                id,
                name,
                resourceType,
                systemData,
                identity,
                location,
                tags,
                containerGroupName != null ? new ScriptContainerConfiguration() { ContainerGroupName = containerGroupName } : null,
                storageAccountSettings,
                cleanupPreference,
                provisioningState,
                status,
                outputs,
                primaryScriptUri,
                supportingScriptUris,
                scriptContent,
                arguments,
                environmentVariables,
                forceUpdateTag,
                retentionInterval,
                timeout,
                azPowerShellVersion);
        }

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
