// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.Extensions
{
    [CodeGenType("KubernetesClusterExtensionProperties")]
    internal partial class KubernetesClusterExtensionProperties
    {
        [CodeGenMember("Scope")]
        public global::Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterExtensionScope InstallationScope { get; set; }
    }
}
