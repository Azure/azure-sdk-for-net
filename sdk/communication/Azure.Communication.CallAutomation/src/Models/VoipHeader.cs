// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Custom Context Voip header.
    /// </summary>
    public class VoipHeader : CustomContextHeader
    {
        /// <summary>
        /// Create a new voip header.
        /// </summary>
        /// <param name="key">voip header key name.</param>
        /// <param name="value">voip header value.</param>
        public VoipHeader(string key, string value) : base(key, value)
        {
        }
    }
}
