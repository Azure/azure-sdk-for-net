// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for IpAddress. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupIPAddress : IpAddress
    {
        internal ContainerGroupIPAddress() : base(new System.Collections.Generic.List<Port>(), default) { }
    }}
