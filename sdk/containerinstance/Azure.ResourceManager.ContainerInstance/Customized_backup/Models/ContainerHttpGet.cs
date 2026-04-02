// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerHttpGet
    {
        /// <summary> The scheme. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerHttpGetScheme? Scheme
        {
            get => _scheme.HasValue ? (ContainerHttpGetScheme)_scheme.Value : null;
            set => _scheme = value.HasValue ? (Scheme)value.Value : null;
        }
    }
}
