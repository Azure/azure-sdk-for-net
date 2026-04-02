// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor and property shims for TypeSpec migration (ApiCompat).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerSecurityContextDefinition
    {
        /// <summary> Initializes a new instance of <see cref="ContainerSecurityContextDefinition"/> for mocking. </summary>
        public ContainerSecurityContextDefinition()
        {
        }

        /// <summary> The flag to determine if the container permissions is elevated to Privileged. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsPrivileged { get => Privileged; set => Privileged = value; }

        /// <summary> The capabilities to add or drop from a container. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerSecurityContextCapabilitiesDefinition Capabilities
        {
            get => CapabilitiesValue as ContainerSecurityContextCapabilitiesDefinition;
            set => CapabilitiesValue = value;
        }
    }
}