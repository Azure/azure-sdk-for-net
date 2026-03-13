// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public partial class ContainerRegistryImportSource
    {
        // The generated code does not define RegistryUri as a property (it uses it only
        // in the internal constructor). This custom property provides the public getter/setter
        // that the serialization code assigns to.
        /// <summary> The address of the source registry (e.g. 'mcr.microsoft.com'). </summary>
        [WirePath("registryUri")]
        public Uri RegistryUri { get; set; }

        // Backward compatibility: the old autorest SDK exposed RegistryAddress (string).
        // The new TypeSpec SDK uses RegistryUri (Uri) directly.
        /// <summary> The address of the source registry (e.g. 'mcr.microsoft.com'). </summary>
        [Obsolete("RegistryAddress is deprecated, use RegistryUri instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string RegistryAddress
        {
            get => RegistryUri?.AbsoluteUri;
            set => RegistryUri = value == null ? null : new Uri(value);
        }
    }
}
