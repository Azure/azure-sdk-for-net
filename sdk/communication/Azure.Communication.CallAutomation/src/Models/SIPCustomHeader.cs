// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Custom Context Sip header.
    /// </summary>
    public class SIPCustomHeader : CustomContextHeader
    {
        /// <summary>
        /// Create a new Sip header.
        /// </summary>
        /// <param name="key">sip header key name.</param>
        /// <param name="value">sip header value.</param>
        public SIPCustomHeader(string key, string value) : base("X-MS-Custom-"+key, value)
        {
        }
    }
}
