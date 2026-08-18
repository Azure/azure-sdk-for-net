// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.Extensions
{
    [CodeGenType("KubernetesClusterExtensionProperties")]
    internal partial class KubernetesClusterExtensionProperties
    {
        private global::Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterExtensionScope? _installationScope;

        [CodeGenMember("Scope")]
        public global::Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterExtensionScope InstallationScope
        {
            get
            {
                Initialize();
                return _installationScope!;
            }
            set
            {
                Initialize();
                AssignOrReplace(ref _installationScope, value);
            }
        }

        partial void DefineAdditionalProperties()
        {
            _installationScope = DefineModelProperty<global::Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterExtensionScope>(nameof(InstallationScope), new string[] { "scope" });
        }
    }
}
