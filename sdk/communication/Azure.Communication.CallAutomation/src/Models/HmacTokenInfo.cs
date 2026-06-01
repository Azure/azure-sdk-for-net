// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Represents HMAC authentication information extracted from request headers.
    /// </summary>
    internal class HmacTokenInfo
    {
        /// <summary>
        /// The HMAC signature token from the Authorization header.
        /// </summary>
        public string? HmacSignature { get; set; }

        /// <summary>
        /// The date value from the x-ms-date header.
        /// </summary>
        public string? Date { get; set; }

        /// <summary>
        /// The content SHA256 value from the x-ms-content-sha256 header.
        /// </summary>
        public string? ContentSha256 { get; set; }

        /// <summary>
        /// The raw authorization header value.
        /// </summary>
        public string? RawAuthorizationHeader { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance contains valid HMAC authentication information.
        /// </summary>
        public bool HasValidHmacInfo => !string.IsNullOrEmpty(HmacSignature) &&
                                       !string.IsNullOrEmpty(Date) &&
                                       !string.IsNullOrEmpty(RawAuthorizationHeader);

        /// <summary>
        /// Creates authentication headers suitable for WebSocket connection.
        /// Returns a dictionary of headers that can be added to WebSocket options before connecting.
        /// This method is specifically designed for media streaming authentication.
        /// </summary>
        /// <returns>A dictionary of headers for WebSocket authentication, or null if invalid.</returns>
        public Dictionary<string, string>? ToWebSocketHeaders()
        {
            if (!HasValidHmacInfo)
                return null;

            var headers = new Dictionary<string, string>();

            headers["Authorization"] = RawAuthorizationHeader!;

            if (!string.IsNullOrEmpty(Date))
                headers["x-ms-date"] = Date!;

            if (!string.IsNullOrEmpty(ContentSha256))
                headers["x-ms-content-sha256"] = ContentSha256!;

            return headers;
        }

        /// <summary>
        /// Creates a Base64-encoded authorization token suitable for WebSocket protocols.
        /// This encodes the raw authorization header for use in WebSocket subprotocols.
        /// </summary>
        /// <returns>A Base64-encoded authorization token, or null if invalid.</returns>
        public string? ToBase64Token()
        {
            if (!HasValidHmacInfo)
                return null;

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(RawAuthorizationHeader!));
        }
    }
}
