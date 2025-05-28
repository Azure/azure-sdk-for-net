// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Transport Protocol
    /// </summary>
    public enum TransportProtocol
    {
        /// <summary>
        /// Bare TCP stream
        /// </summary>
        PROT_TCP = 1,
        /// <summary>
        /// Bare TLS stream
        /// </summary>
        PROT_TLS = 2,
        /// <summary>
        /// HTTP protocol
        /// </summary>
        PROT_HTTP = 3,
        /// <summary>
        /// CoAP protocol
        /// </summary>
        PROT_COAP = 4,
        /// <summary>
        /// HTTPS protocol
        /// </summary>
        PROT_HTTPS = 5,
        /// <summary>
        /// CoAPS protocol
        /// </summary>
        PROT_COAPS = 6
    }
}
