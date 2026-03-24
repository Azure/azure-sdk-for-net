// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // Suppress the auto-generated TriggerSourceTriggeredOn; the flattened name should be
    // SourceTriggeredOn (matching Azure SDK DateTimeOffset naming convention).
    [CodeGenSuppress("TriggerSourceTriggeredOn")]
    public partial class ContainerRegistryPipelineRunResult
    {
        /// <summary> The timestamp when the source update happened. </summary>
        [WirePath("trigger.sourceTrigger.timestamp")]
        public DateTimeOffset? SourceTriggeredOn
        {
            get
            {
                return Trigger?.SourceTriggeredOn;
            }
        }
    }
}
