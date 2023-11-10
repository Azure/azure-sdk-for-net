// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// CustomCallingContext details.
    /// </summary>
    public class CustomCallingContext
    {
        /// <summary> Dictionary of VOIP headers. </summary>
        public IDictionary<string, string> VoipHeaders { get; }

        /// <summary> Dictionary of SIP headers. </summary>
        public IDictionary<string, string> SipHeaders { get; }

        /// <summary>
        /// Creates a new CustomCallingContext.
        /// </summary>
        internal CustomCallingContext(IDictionary<string, string> sipHeaders, IDictionary<string, string> voipHeaders)
        {
            SipHeaders = sipHeaders;
            VoipHeaders = voipHeaders;
        }

        /// <summary>
        /// Add a custom calling context sip UUI header. The Key always remains 'User-To-User'
        /// </summary>
        /// <param name="value">custom calling context sip UUI header's value.</param>
        public void AddSipUui(string value)
        {
            if (SipHeaders == null)
            {
                throw new InvalidOperationException("Cannot add sip UUI header, SipHeaders is null.");
            }
            SipHeaders.Add("User-To-User", value);
        }

        /// <summary>
        /// Add a custom calling context sip X header. The provided key is appended to such as 'X-MS-Custom-{key}'
        /// </summary>
        /// <param name="key">custom calling context sip X header's key.</param>
        /// <param name="value">custom calling context sip X header's value.</param>
        public void AddSipX(string key, string value)
        {
            if (SipHeaders == null)
            {
                throw new InvalidOperationException("Cannot add sip X header, SipHeaders is null.");
            }
            SipHeaders.Add("X-MS-Custom-" + key, value);
        }

        /// <summary>
        /// Add a custom calling context voip header.
        /// </summary>
        /// <param name="key">custom calling context voip header's key.</param>
        /// <param name="value">custom calling context voip header's value.</param>
        public void AddVoip(string key, string value)
        {
            if (VoipHeaders == null)
            {
                throw new InvalidOperationException("Cannot add voip header, VoipHeaders is null.");
            }
            VoipHeaders.Add(key, value);
        }
    }
}
