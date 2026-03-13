// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    /// <summary> The ContainerRegistryImportSource. </summary>
    public partial class ContainerRegistryImportSource
    {
        /// <summary> The address of the source registry (e.g. 'mcr.microsoft.com'). </summary>
        [WirePath("registryUri")]
        public Uri RegistryUri { get; set; }

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
