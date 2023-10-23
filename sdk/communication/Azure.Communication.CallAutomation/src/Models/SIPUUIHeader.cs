// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Custom Context User-to-User Sip header.
    /// </summary>
    public class SIPUUIHeader : CustomContextHeader
    {
        /// <summary>
        /// Create a new Sip UUI header.
        /// </summary>
        /// <param name="value">CustomContext Sip UUI value.</param>
        public SIPUUIHeader(string value) : base("User-to-User", value)
        {
        }
    }
}
