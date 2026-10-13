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
        public static AzureCliScript AzureCliScript(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, ArmDeploymentScriptManagedIdentity identity = null, AzureLocation location = default, IDictionary<string, string> tags = null, string containerGroupName = null, ScriptStorageConfiguration storageAccountSettings = null, ScriptCleanupOptions? cleanupPreference = null, ScriptProvisioningState? provisioningState = null, ScriptStatus status = null, BinaryData outputs = null, Uri primaryScriptUri = null, IEnumerable<Uri> supportingScriptUris = null, string scriptContent = null, string arguments = null, IEnumerable<ScriptEnvironmentVariable> environmentVariables = null, string forceUpdateTag = null, TimeSpan retentionInterval = default, TimeSpan? timeout = null, string azCliVersion = null)
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
        public static AzurePowerShellScript AzurePowerShellScript(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, ArmDeploymentScriptManagedIdentity identity, AzureLocation location, IDictionary<string, string> tags, string containerGroupName, ScriptStorageConfiguration storageAccountSettings = null, ScriptCleanupOptions? cleanupPreference = null, ScriptProvisioningState? provisioningState = null, ScriptStatus status = null, BinaryData outputs = null, Uri primaryScriptUri = null, IEnumerable<Uri> supportingScriptUris = null, string scriptContent = null, string arguments = null, IEnumerable<ScriptEnvironmentVariable> environmentVariables = null, string forceUpdateTag = null, TimeSpan retentionInterval = default, TimeSpan? timeout = null, string azPowerShellVersion = null)
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
        [Obsolete("Use Azure.ResourceManager.Resources.Deployments.Models.ArmResourcesModelFactory.ArmDeploymentPropertiesExtended instead.", false)]
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
        [Obsolete("Use Azure.ResourceManager.Resources.Deployments.Models.ArmResourcesModelFactory.ArmDeploymentPropertiesExtended instead.", false)]
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

        /// <summary> Initializes a new instance of <see cref="Models.ManagedResourceReference"/>. </summary>
        /// <param name="id"> The resourceId of a resource managed by the deployment stack. </param>
        /// <param name="status"> Current management state of the resource in the deployment stack. </param>
        /// <param name="denyStatus"> denyAssignment settings applied to the resource. </param>
        /// <returns> A new <see cref="Models.ManagedResourceReference"/> instance for mocking. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.DeploymentStacks.Models.ArmResourcesDeploymentStacksModelFactory.DeploymentStackManagedResourceReference instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedResourceReference ManagedResourceReference(string id = null, ResourceStatusMode? status = null, DenyStatusMode? denyStatus = null)
        {
            return new ManagedResourceReference(id, serializedAdditionalRawData: null, status, denyStatus);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ResourceReferenceExtended"/>. </summary>
        /// <param name="id"> The resourceId of a resource managed by the deployment stack. </param>
        /// <param name="error"> The error detail. </param>
        /// <returns> A new <see cref="Models.ResourceReferenceExtended"/> instance for mocking. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.DeploymentStacks.Models.ArmResourcesDeploymentStacksModelFactory.DeploymentStackResourceReferenceExtended instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceReferenceExtended ResourceReferenceExtended(string id = null, ResponseError error = null)
        {
            return new ResourceReferenceExtended(id, serializedAdditionalRawData: null, error);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ResourceReferenceAutoGenerated"/>. </summary>
        /// <param name="id"> The resourceId of a resource managed by the deployment stack. </param>
        /// <returns> A new <see cref="Models.ResourceReferenceAutoGenerated"/> instance for mocking. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.DeploymentStacks.Models.ArmResourcesDeploymentStacksModelFactory.DeploymentStackResourceReference instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceReferenceAutoGenerated ResourceReferenceAutoGenerated(string id = null)
        {
            return new ResourceReferenceAutoGenerated(id, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DeploymentStackTemplateDefinition"/>. </summary>
        /// <param name="template"> The template content. Use this element to pass the template syntax directly in the request rather than link to an existing template. It can be a JObject or well-formed JSON string. Use either the templateLink property or the template property, but not both. </param>
        /// <param name="templateLink"> The URI of the template. Use either the templateLink property or the template property, but not both. </param>
        /// <returns> A new <see cref="Models.DeploymentStackTemplateDefinition"/> instance for mocking. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.DeploymentStacks.Models.ArmResourcesDeploymentStacksModelFactory.DeploymentStackTemplateExportResult instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DeploymentStackTemplateDefinition DeploymentStackTemplateDefinition(BinaryData template = null, DeploymentStacksTemplateLink templateLink = null)
        {
            return new DeploymentStackTemplateDefinition(template, templateLink, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Resources.DeploymentStackData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The location of the Deployment stack. It cannot be changed after creation. It must be one of the supported Azure locations. </param>
        /// <param name="tags"> Deployment stack resource tags. </param>
        /// <param name="error"> The error detail. </param>
        /// <param name="template"> The template content. You use this element when you want to pass the template syntax directly in the request rather than link to an existing template. It can be a JObject or well-formed JSON string. Use either the templateLink property or the template property, but not both. </param>
        /// <param name="templateLink"> The URI of the template. Use either the templateLink property or the template property, but not both. </param>
        /// <param name="parameters"> Name and value pairs that define the deployment parameters for the template. Use this element when providing the parameter values directly in the request, rather than linking to an existing parameter file. Use either the parametersLink property or the parameters property, but not both. </param>
        /// <param name="parametersLink"> The URI of parameters file. Use this element to link to an existing parameters file. Use either the parametersLink property or the parameters property, but not both. </param>
        /// <param name="actionOnUnmanage"> Defines the behavior of resources that are no longer managed after the Deployment stack is updated or deleted. </param>
        /// <param name="debugSettingDetailLevel"> The debug setting of the deployment. </param>
        /// <param name="bypassStackOutOfSyncError"> Flag to bypass service errors that indicate the stack resource list is not correctly synchronized. </param>
        /// <param name="deploymentScope"> The scope at which the initial deployment should be created. If a scope is not specified, it will default to the scope of the deployment stack. Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroupId}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'). </param>
        /// <param name="description"> Deployment stack description. Max length of 4096 characters. </param>
        /// <param name="denySettings"> Defines how resources deployed by the stack are locked. </param>
        /// <param name="provisioningState"> State of the deployment stack. </param>
        /// <param name="correlationId"> The correlation id of the last Deployment stack upsert or delete operation. It is in GUID format and is used for tracing. </param>
        /// <param name="detachedResources"> An array of resources that were detached during the most recent Deployment stack update. Detached means that the resource was removed from the template, but no relevant deletion operations were specified. So, the resource still exists while no longer being associated with the stack. </param>
        /// <param name="deletedResources"> An array of resources that were deleted during the most recent Deployment stack update. Deleted means that the resource was removed from the template and relevant deletion operations were specified. </param>
        /// <param name="failedResources"> An array of resources that failed to reach goal state during the most recent update. Each resourceId is accompanied by an error message. </param>
        /// <param name="resources"> An array of resources currently managed by the deployment stack. </param>
        /// <param name="deploymentId"> The resourceId of the deployment resource created by the deployment stack. </param>
        /// <param name="outputs"> The outputs of the deployment resource created by the deployment stack. </param>
        /// <param name="duration"> The duration of the last successful Deployment stack update. </param>
        /// <returns> A new <see cref="Resources.DeploymentStackData"/> instance for mocking. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.DeploymentStacks.Models.ArmResourcesDeploymentStacksModelFactory.DeploymentStackData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DeploymentStackData DeploymentStackData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, AzureLocation? location = null, IDictionary<string, string> tags = null, ResponseError error = null, BinaryData template = null, DeploymentStacksTemplateLink templateLink = null, IDictionary<string, DeploymentParameter> parameters = null, DeploymentStacksParametersLink parametersLink = null, ActionOnUnmanage actionOnUnmanage = null, string debugSettingDetailLevel = null, bool? bypassStackOutOfSyncError = null, string deploymentScope = null, string description = null, DenySettings denySettings = null, DeploymentStackProvisioningState? provisioningState = null, string correlationId = null, IEnumerable<SubResource> detachedResources = null, IEnumerable<SubResource> deletedResources = null, IEnumerable<ResourceReferenceExtended> failedResources = null, IEnumerable<ManagedResourceReference> resources = null, string deploymentId = null, BinaryData outputs = null, TimeSpan? duration = null)
        {
            tags ??= new Dictionary<string, string>();
            parameters ??= new Dictionary<string, DeploymentParameter>();
            detachedResources ??= new List<SubResource>();
            deletedResources ??= new List<SubResource>();
            failedResources ??= new List<ResourceReferenceExtended>();
            resources ??= new List<ManagedResourceReference>();

            return new DeploymentStackData(
                id,
                name,
                resourceType,
                systemData,
                location,
                tags,
                error,
                template,
                templateLink,
                parameters,
                parametersLink,
                actionOnUnmanage,
                debugSettingDetailLevel != null ? new DeploymentStacksDebugSetting(debugSettingDetailLevel, serializedAdditionalRawData: null) : null,
                bypassStackOutOfSyncError,
                deploymentScope,
                description,
                denySettings,
                provisioningState,
                correlationId,
                detachedResources?.ToList(),
                deletedResources?.ToList(),
                failedResources?.ToList(),
                resources?.ToList(),
                deploymentId,
                outputs,
                duration,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DeploymentStackValidateResult"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> The validation result details. </param>
        /// <param name="error"> The error detail. </param>
        /// <returns> A new <see cref="Models.DeploymentStackValidateResult"/> instance for mocking. </returns>
        [Obsolete("Use Azure.ResourceManager.Resources.DeploymentStacks.Models.ArmResourcesDeploymentStacksModelFactory.DeploymentStackValidateResult instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DeploymentStackValidateResult DeploymentStackValidateResult(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, DeploymentStackValidateProperties properties = null, ResponseError error = null)
        {
            return new DeploymentStackValidateResult(
                id,
                name,
                resourceType,
                systemData,
                properties,
                error,
                serializedAdditionalRawData: null);
        }
    }
}
