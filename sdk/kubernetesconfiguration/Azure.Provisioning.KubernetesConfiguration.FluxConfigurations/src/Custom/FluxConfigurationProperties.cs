// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.FluxConfigurations
{
    [CodeGenType("FluxConfigurationProperties")]
    internal partial class FluxConfigurationProperties
    {
        private global::Azure.Provisioning.BicepValue<global::Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationScopeType> _installationScope;

        [CodeGenMember("Scope")]
        public global::Azure.Provisioning.BicepValue<global::Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationScopeType> InstallationScope
        {
            get
            {
                Initialize();
                return _installationScope;
            }
            set
            {
                Initialize();
                _installationScope.Assign(value);
            }
        }

        partial void DefineAdditionalProperties()
        {
            _installationScope = DefineProperty<global::Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationScopeType>(nameof(InstallationScope), new string[] { "scope" });
        }
    }
}
