// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for LogAnalytics. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContainerGroupLogAnalytics : LogAnalytics
    {
        internal ContainerGroupLogAnalytics() : base("default", "default") { }
    }}
