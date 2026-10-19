// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayOnDemandProbe
    {
        // Bind the service field to the original .NET boolean-property name.
        /// <summary> Whether to send Proxy Protocol header along with the Health Probe over TCP or TLS protocol. Default value is false. </summary>
        [CodeGenMember("EnableProbeProxyProtocolHeader")]
        [WirePath("enableProbeProxyProtocolHeader")]
        public bool? IsProbeProxyProtocolHeaderEnabled { get; set; }

        // Preserve the TypeSpec name shipped in 1.17.0 without independent serialized storage.
        /// <inheritdoc cref="IsProbeProxyProtocolHeaderEnabled"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsProbeProxyProtocolHeaderEnabled instead.")]
        public bool? EnableProbeProxyProtocolHeader
        {
            get => IsProbeProxyProtocolHeaderEnabled;
            set => IsProbeProxyProtocolHeaderEnabled = value;
        }
    }
}
