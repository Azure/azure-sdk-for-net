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
        /// <summary> The address of the source registry (e.g. &apos;mcr.microsoft.com&apos;). </summary>
        [Obsolete("RegistryUri is deprecated, use RegistryAddress instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri RegistryUri
        {
            get
            {
                if (RegistryAddress != null && Uri.TryCreate(RegistryAddress, UriKind.Absolute, out var registryUri))
                    return registryUri;
                return null;
            }
            set
            {
                RegistryAddress = value == null ? null : value.AbsoluteUri;
            }
        }
    }
}
