// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary> Security analytics of your IoT Security solution. </summary>
    [CodeGenSuppress("IotSecuritySolutionAnalyticsModelData")]
    public partial class IotSecuritySolutionAnalyticsModelData
    {
        // Preserve the legacy public constructor for mocking.
        /// <summary> Initializes a new instance of <see cref="IotSecuritySolutionAnalyticsModelData"/>. </summary>
        public IotSecuritySolutionAnalyticsModelData()
        {
        }
    }
}
