// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for EncryptionProperties. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupEncryptionProperties : EncryptionProperties
    {
        internal ContainerGroupEncryptionProperties() : base("default", "default", "default") { }
    }}
