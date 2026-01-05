// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable enable
namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Represents HMAC authentication information extracted from request headers.
    /// </summary>
    public class HmacTokenInfo
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
    }
}
