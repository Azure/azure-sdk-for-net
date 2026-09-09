// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.KubernetesConfiguration.Extensions
{
    [CodeGenType("KubernetesClusterExtension")]
    public partial class KubernetesClusterExtension
    {
        /// <summary> Gets or sets the resource that contains this extension. </summary>
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

        /// <summary> Gets or sets the installation scope of the extension. </summary>
        [CodeGenMember("Scope")]
        public KubernetesClusterExtensionScope InstallationScope
        {
            get => Properties is null ? default! : Properties.Scope;
            set
            {
                if (Properties is null)
                {
                    Properties = new KubernetesClusterExtensionProperties();
                }
                Properties.Scope = value;
            }
        }
    }
}
