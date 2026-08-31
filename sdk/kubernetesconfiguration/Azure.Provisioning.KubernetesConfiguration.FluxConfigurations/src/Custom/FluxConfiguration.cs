// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.FluxConfigurations
{
    [CodeGenType("FluxConfiguration")]
    public partial class FluxConfiguration
    {
        /// <summary> Gets or sets the resource that contains this configuration. </summary>
        public ProvisionableResource Scope
        {
            get
            {
                Initialize();
                return _scope.Value!;
            }
            set
            {
                Initialize();
                _scope.Value = value;
            }
        }

        /// <summary> Gets or sets the scope at which the configuration will be installed. </summary>
        [CodeGenMember("Scope")]
        public BicepValue<FluxConfigurationScopeType> InstallationScope
        {
            get => Properties is null ? default! : Properties.InstallationScope;
            set
            {
                if (Properties is null)
                {
                    Properties = new FluxConfigurationProperties();
                }
                Properties.InstallationScope = value;
            }
        }
    }
}
