// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Provisioning.Primitives
{
    /// <summary>
    /// Provisioning metadata for a single property, used to create a <see cref="Providers.ProvisioningPropertyProvider"/>.
    /// </summary>
    internal record ProvisioningPropertyInfo(
        string PropertyName,
        bool IsOutput,
        bool IsRequired,
        string[] BicepPath,
        string? DefaultValue = null,
        CSharpType? TypeOverride = null);
}
