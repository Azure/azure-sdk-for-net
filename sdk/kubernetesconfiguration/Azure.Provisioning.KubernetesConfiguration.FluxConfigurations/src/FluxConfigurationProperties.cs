// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.FluxConfigurations
{
    [CodeGenType("FluxConfigurationProperties")]
    internal partial class FluxConfigurationProperties
    {
        [CodeGenMember("Scope")]
        public global::Azure.Provisioning.BicepValue<global::Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationScopeType> InstallationScope { get; set; }
    }
}
