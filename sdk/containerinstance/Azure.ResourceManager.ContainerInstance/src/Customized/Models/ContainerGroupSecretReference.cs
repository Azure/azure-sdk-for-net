// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for SecretReference. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupSecretReference : SecretReference
    {
        internal ContainerGroupSecretReference() : base("default", default, default) { }
    }}
