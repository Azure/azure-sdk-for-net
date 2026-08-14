// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;

namespace Azure.Generator.Provisioning.Primitives
{
    /// <summary>
    /// Provides provisioning-specific metadata for a given input property.
    /// Implemented by both <see cref="Providers.ProvisioningModelProvider"/> and <see cref="Providers.ProvisioningResourceProvider"/>
    /// to supply the Bicep-related information needed by <see cref="Providers.ProvisioningPropertyProvider.Create"/>.
    /// </summary>
    internal interface IProvisioningPropertyInfo
    {
        /// <summary>
        /// Returns the provisioning metadata for the given input property,
        /// or null if the property should be skipped (e.g., discriminators).
        /// </summary>
        ProvisioningPropertyInfo? GetProvisioningPropertyInfo(InputModelProperty property);
    }
}
