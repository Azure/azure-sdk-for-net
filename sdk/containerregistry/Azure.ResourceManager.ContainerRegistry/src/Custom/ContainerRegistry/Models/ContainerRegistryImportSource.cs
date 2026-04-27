// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public partial class ContainerRegistryImportSource
    {
        /// <summary> The address of the source registry (e.g. 'mcr.microsoft.com'). </summary>
        [WirePath("registryUri")]
        [Obsolete("RegistryUri is deprecated, use RegistryAddress instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri RegistryUri { get; set; }

        /// <summary> The address of the source registry (e.g. 'mcr.microsoft.com'). </summary>
        [WirePath("registryUri")]
        public string RegistryAddress
        {
            get => RegistryUri?.AbsoluteUri;
            set => RegistryUri = value == null ? null : new Uri(value);
        }
    }
}
