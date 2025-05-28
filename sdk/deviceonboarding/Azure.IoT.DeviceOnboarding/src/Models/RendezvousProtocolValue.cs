// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Types of Rendezvous Protocol Value
    /// </summary>
    public enum RendezvousProtocolValue
    {
        /// <summary>
        /// REST
        /// </summary>
        RVProtRest = 0,
        /// <summary>
        /// HTTP
        /// </summary>
        RVProtHttp = 1,
        /// <summary>
        /// HTTPS
        /// </summary>
        RVProtHttps = 2,
        /// <summary>
        /// TCP
        /// </summary>
        RVProtTcp = 3,
        /// <summary>
        /// TLS
        /// </summary>
        RVProtTls = 4,
        /// <summary>
        /// COAP TCP
        /// </summary>
        RVProtCoapTcp = 5,
        /// <summary>
        /// COAP UDP
        /// </summary>
        RVProtCoapUdp = 6
    }
}
