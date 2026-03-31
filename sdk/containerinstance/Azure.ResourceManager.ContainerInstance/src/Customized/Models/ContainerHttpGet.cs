// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerHttpGet
    {
        // backward-compat shim: old property was ContainerHttpGetScheme?, new is Scheme?
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerHttpGetScheme? Scheme
        {
            get => _scheme.HasValue ? new ContainerHttpGetScheme(_scheme.Value.ToString()) : null;
            set => _scheme = value.HasValue ? new Models.Scheme(value.Value.ToString()) : null;
        }
    }
}
