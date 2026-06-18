// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec constructor/property list follows the latest wire schema, but the GA SDK exposed a different constructor or property signature; CodeGenSuppress lets this partial provide the GA shape explicitly.
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
