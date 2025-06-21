// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Request/Response Message for Client/Server Requests
    /// </summary>
    public class ProtocolMessage
    {
        #region Public Properties

        /// <summary>
        /// Gets or Sets Request Message Type
        /// </summary>
        public int MessageType { get; set; }

        /// <summary>
        /// Gets or Sets Request Message Payload
        /// </summary>
        public byte[] Payload { get; set; }

        /// <summary>
        /// Gets or Sets Request Message Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets Session Authorization Token
        /// </summary>
        public string AuthorizationToken { get; set; }

        #endregion
    }
}
