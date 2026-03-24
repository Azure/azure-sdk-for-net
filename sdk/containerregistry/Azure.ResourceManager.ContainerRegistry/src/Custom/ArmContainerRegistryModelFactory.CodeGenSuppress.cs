// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Suppress the generated ModelFactory method that takes internal WebhookProperties
    // as a parameter (causes CS0051: inconsistent accessibility).
    [CodeGenSuppress("ContainerRegistryWebhookData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(WebhookProperties))]
    // Suppress the generated ContainerRegistryPipelineRunResult factory method whose parameter
    // name is triggerSourceTriggeredOn; the custom replacement uses sourceTriggeredOn.
    [CodeGenSuppress("ContainerRegistryPipelineRunResult", typeof(string), typeof(IEnumerable<string>), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(ContainerRegistryImportPipelineSourceProperties), typeof(ContainerRegistryExportPipelineTargetProperties), typeof(string), typeof(DateTimeOffset?), typeof(string))]
    public static partial class ArmContainerRegistryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryPipelineRunResult"/>. </summary>
        /// <param name="status"> The current status of the pipeline run. </param>
        /// <param name="importedArtifacts"> The artifacts imported in the pipeline run. </param>
        /// <param name="progressPercentage"> The percentage complete of the copy operation. </param>
        /// <param name="startOn"> The time the pipeline run started. </param>
        /// <param name="finishOn"> The time the pipeline run finished. </param>
        /// <param name="source"> The source of the pipeline run. </param>
        /// <param name="target"> The target of the pipeline run. </param>
        /// <param name="catalogDigest"> The digest of the tar used to transfer the artifacts. </param>
        /// <param name="sourceTriggeredOn"> The timestamp when the source update happened. </param>
        /// <param name="pipelineRunErrorMessage"> The detailed error message for the pipeline run in the case of failure. </param>
        /// <returns> A new <see cref="ContainerRegistryPipelineRunResult"/> instance for mocking. </returns>
        public static ContainerRegistryPipelineRunResult ContainerRegistryPipelineRunResult(string status = default, IEnumerable<string> importedArtifacts = default, string progressPercentage = default, DateTimeOffset? startOn = default, DateTimeOffset? finishOn = default, ContainerRegistryImportPipelineSourceProperties source = default, ContainerRegistryExportPipelineTargetProperties target = default, string catalogDigest = default, DateTimeOffset? sourceTriggeredOn = default, string pipelineRunErrorMessage = default)
        {
            importedArtifacts ??= new ChangeTrackingList<string>();

            return new ContainerRegistryPipelineRunResult(
                status,
                importedArtifacts.ToList(),
                progressPercentage is null ? default : new ProgressProperties(progressPercentage, null),
                startOn,
                finishOn,
                source,
                target,
                catalogDigest,
                sourceTriggeredOn is null ? default : new PipelineTriggerDescriptor(new PipelineSourceTriggerDescriptor(sourceTriggeredOn, null), null),
                pipelineRunErrorMessage,
                additionalBinaryDataProperties: null);
        }
    }
}
