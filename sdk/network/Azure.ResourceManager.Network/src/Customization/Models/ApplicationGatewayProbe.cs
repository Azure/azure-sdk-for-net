// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Probe of the application gateway. </summary>
    public partial class ApplicationGatewayProbe
    {
        // Preserve the TypeSpec-generated property name because it maps to the same wire property as the preferred member.
        /// <inheritdoc cref="IntervalInSeconds"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IntervalInSeconds instead.")]
        public int? Interval
        {
            get => IntervalInSeconds;
            set => IntervalInSeconds = value;
        }

        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="IsProbeProxyProtocolHeaderEnabled"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsProbeProxyProtocolHeaderEnabled instead.")]
        public bool? EnableProbeProxyProtocolHeader
        {
            get => IsProbeProxyProtocolHeaderEnabled;
            set => IsProbeProxyProtocolHeaderEnabled = value;
        }

        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="TimeoutInSeconds"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use TimeoutInSeconds instead.")]
        public int? Timeout
        {
            get => TimeoutInSeconds;
            set => TimeoutInSeconds = value;
        }
    }
}
