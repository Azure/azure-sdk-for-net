// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Resources.Deployments.Models
{
    [CodeGenType("ArmResourcesDeploymentsModelFactory")]
    [CodeGenSuppress("ArmDeploymentExtensionConfigItem", typeof(BinaryData), typeof(KeyVaultParameterReference), typeof(ExtensionConfigPropertyType?))]
    [CodeGenSuppress("WhatIfChange", typeof(string), typeof(string), typeof(string), typeof(string), typeof(BinaryData), typeof(ArmDeploymentExtensionDefinition), typeof(WhatIfChangeType), typeof(string), typeof(BinaryData), typeof(BinaryData), typeof(IEnumerable<WhatIfPropertyChange>))]
    public static partial class ArmResourcesModelFactory
    {
        // Preserve the GA parameter order and optional arguments after restoring the removed property.
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
    }
}
