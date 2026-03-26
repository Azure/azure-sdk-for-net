// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0618 // RegistryUri is [Obsolete] but referenced by RegistryAddress wrapper

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry.Models
{
    // Backward compatibility: suppress generated RegistryUri and re-expose with [Obsolete]
    // to match the 1.4.0 API contract. RegistryAddress is the main property in 1.4.0.
    // Note: [Obsolete] on RegistryUri triggers CS0618 in generated constructor/serialization,
    // which is suppressed via CS0618 in project NoWarn (generator limitation workaround).
    [CodeGenSuppress("RegistryUri")]
    public partial class ContainerRegistryImportSource
    {
        /// <summary> The address of the source registry (e.g. 'mcr.microsoft.com'). </summary>
        [Obsolete("RegistryUri is deprecated, use RegistryAddress instead")]
        [WirePath("registryUri")]
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
