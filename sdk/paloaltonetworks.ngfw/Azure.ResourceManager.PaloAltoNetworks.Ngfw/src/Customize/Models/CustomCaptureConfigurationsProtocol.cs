// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models
{
    public readonly partial struct CustomCaptureConfigurationsProtocol
    {
        /// <summary> Transmission Control Protocol. </summary>
        [CodeGenMember("TCP")]
        public static CustomCaptureConfigurationsProtocol Tcp { get; } = new CustomCaptureConfigurationsProtocol("TCP");

        /// <summary> User Datagram Protocol. </summary>
        [CodeGenMember("UDP")]
        public static CustomCaptureConfigurationsProtocol Udp { get; } = new CustomCaptureConfigurationsProtocol("UDP");
    }
}
