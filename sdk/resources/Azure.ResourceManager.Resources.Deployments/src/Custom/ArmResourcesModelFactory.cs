// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Resources.Deployments.Models
{
    [CodeGenType("ArmResourcesDeploymentsModelFactory")]
    [CodeGenSuppress("ArmDeploymentExtensionConfigItem", typeof(BinaryData), typeof(KeyVaultParameterReference), typeof(ExtensionConfigPropertyType?))]
    [CodeGenSuppress("WhatIfChange", typeof(string), typeof(string), typeof(string), typeof(string), typeof(BinaryData), typeof(ArmDeploymentExtensionDefinition), typeof(WhatIfChangeType), typeof(string), typeof(BinaryData), typeof(BinaryData), typeof(IEnumerable<WhatIfPropertyChange>))]
    public static partial class ArmResourcesModelFactory
    {
        // API version 2026-06-01 removed the type property, but this signature shipped in SDK 1.0.0.
        // Preserve its parameter order and defaults for existing positional and optional-argument callers.
        /// <summary> Represents the value for an extension config property. </summary>
        /// <param name="extensionConfigPropertyType"> The value type of the extension config property. </param>
        /// <param name="value"> The value of the extension config property. </param>
        /// <param name="keyVaultReference"> The Azure Key Vault reference used to retrieve the secret value of the extension config property. </param>
        /// <returns> A new <see cref="Models.ArmDeploymentExtensionConfigItem"/> instance for mocking. </returns>
        public static ArmDeploymentExtensionConfigItem ArmDeploymentExtensionConfigItem(ExtensionConfigPropertyType? extensionConfigPropertyType = default, BinaryData value = default, KeyVaultParameterReference keyVaultReference = default)
        {
            return new ArmDeploymentExtensionConfigItem(value, keyVaultReference, extensionConfigPropertyType, default);
        }

        // Append the new parameter so existing calls that omit optional arguments keep compiling.
        /// <summary> Information about a single resource change predicted by What-If operation. </summary>
        /// <param name="resourceId"> The fully-qualified ARM resource ID for this change. </param>
        /// <param name="deploymentId"> The resource id of the Deployment responsible for this change. </param>
        /// <param name="symbolicName"> The symbolic name of the resource responsible for this change. </param>
        /// <param name="identifiers"> A subset of properties that uniquely identify a Bicep extensible resource because it lacks a resource id like an Azure resource has. </param>
        /// <param name="extension"> The extension the resource was deployed with. </param>
        /// <param name="changeType"> Type of change that will be made to the resource when the deployment is executed. </param>
        /// <param name="unsupportedReason"> The explanation about why the resource is unsupported by What-If. </param>
        /// <param name="before"> The snapshot of the resource before the deployment is executed. </param>
        /// <param name="after"> The predicted snapshot of the resource after the deployment is executed. </param>
        /// <param name="delta"> The predicted changes to resource properties. </param>
        /// <param name="resourceType"> The resource type of the resource. </param>
        /// <returns> A new <see cref="Models.WhatIfChange"/> instance for mocking. </returns>
        public static WhatIfChange WhatIfChange(string resourceId = default, string deploymentId = default, string symbolicName = default, BinaryData identifiers = default, ArmDeploymentExtensionDefinition extension = default, WhatIfChangeType changeType = default, string unsupportedReason = default, BinaryData before = default, BinaryData after = default, IEnumerable<WhatIfPropertyChange> delta = default, string resourceType = default)
        {
            return new WhatIfChange(
                resourceId,
                deploymentId,
                symbolicName,
                resourceType,
                identifiers,
                extension,
                changeType,
                unsupportedReason,
                before,
                after,
                delta?.ToList() ?? new List<WhatIfPropertyChange>(),
                default);
        }

        // Route historical signatures through current factories to initialize newly added collections.
        /// <summary> Creates an <see cref="Models.ArmResourceReference"/> instance for mocking. </summary>
        /// <param name="id"> The fully qualified Azure resource ID. </param>
        /// <param name="extension"> The extension the resource was deployed with. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="identifiers"> The extensible resource identifiers. </param>
        /// <param name="apiVersion"> The API version the resource was deployed with. </param>
        /// <returns> A new <see cref="Models.ArmResourceReference"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmResourceReference ArmResourceReference(ResourceIdentifier id, ArmDeploymentExtensionDefinition extension, string resourceType, BinaryData identifiers, string apiVersion)
        {
            return ArmResourceReference(id, extension, resourceType, identifiers, apiVersion, symbolicNamePath: Array.Empty<string>());
        }

        /// <summary> Creates a <see cref="Models.TargetResource"/> instance for mocking. </summary>
        /// <param name="id"> The Azure resource ID of the resource. </param>
        /// <param name="resourceName"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="extension"> The extension the resource was deployed with. </param>
        /// <param name="identifiers"> The extensible resource identifiers. </param>
        /// <param name="apiVersion"> The API version the resource was deployed with. </param>
        /// <param name="symbolicName"> The symbolic name of the resource as defined in the deployment template. </param>
        /// <returns> A new <see cref="Models.TargetResource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TargetResource TargetResource(string id, string resourceName, ResourceType? resourceType, ArmDeploymentExtensionDefinition extension, BinaryData identifiers, string apiVersion, string symbolicName)
        {
            return TargetResource(id, resourceName, resourceType, extension, identifiers, apiVersion, symbolicName, symbolicNamePath: Array.Empty<string>());
        }

        /// <summary> Creates an <see cref="Models.ArmDeploymentWhatIfProperties"/> instance for mocking. </summary>
        /// <param name="template"> The template content. </param>
        /// <param name="templateLink"> The link to the template. </param>
        /// <param name="deploymentParameters"> The deployment parameters. </param>
        /// <param name="externalInputs"> The external input values. </param>
        /// <param name="externalInputDefinitions"> The external input definitions. </param>
        /// <param name="parametersLink"> The link to the deployment parameters. </param>
        /// <param name="extensionConfigs"> The deployment extension configurations. </param>
        /// <param name="mode"> The deployment mode. </param>
        /// <param name="debugSettingDetailLevel"> The deployment debug setting. </param>
        /// <param name="errorDeployment"> The deployment on error behavior. </param>
        /// <param name="expressionEvaluationScope"> The scope for evaluating template expressions. </param>
        /// <param name="validationLevel"> The validation level of the deployment. </param>
        /// <param name="whatIfResultFormat"> The format of the What-If results. </param>
        /// <returns> A new <see cref="Models.ArmDeploymentWhatIfProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmDeploymentWhatIfProperties ArmDeploymentWhatIfProperties(BinaryData template, ArmDeploymentTemplateLink templateLink, IDictionary<string, ArmDeploymentParameterValue> deploymentParameters, IDictionary<string, ArmDeploymentExternalInput> externalInputs, IDictionary<string, ArmDeploymentExternalInputDefinition> externalInputDefinitions, ArmDeploymentParametersLink parametersLink, IDictionary<string, IDictionary<string, ArmDeploymentExtensionConfigItem>> extensionConfigs, ArmDeploymentMode mode, string debugSettingDetailLevel, ErrorDeployment errorDeployment, ExpressionEvaluationScope? expressionEvaluationScope, ValidationLevel? validationLevel, WhatIfResultFormat? whatIfResultFormat)
        {
            return ArmDeploymentWhatIfProperties(
                template,
                templateLink,
                deploymentParameters,
                externalInputs,
                externalInputDefinitions,
                parametersLink,
                extensionConfigs,
                mode,
                debugSettingDetailLevel,
                errorDeployment,
                expressionEvaluationScope,
                validationLevel,
                whatIfResultFormat,
                resourcePredictions: Array.Empty<DeploymentResourceWhatIfPrediction>());
        }
    }
}
