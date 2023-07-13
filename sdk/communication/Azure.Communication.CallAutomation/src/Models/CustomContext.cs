// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// CustomContext details.
    /// </summary>
    public class CustomContext
    {
        /// <summary> Dictionary of VOIP headers. </summary>
        public IDictionary<string, string> VoipHeaders { get; }

        /// <summary> Dictionary of SIP headers. </summary>
        public IDictionary<string, string> SipHeaders { get; }

        /// <summary>
        /// Creates a new CustomContext.
        /// </summary>
        internal CustomContext(IDictionary<string, string> sipHeaders, IDictionary<string, string> voipHeaders)
        {
            SipHeaders = sipHeaders;
            VoipHeaders = voipHeaders;
        }

        /// <summary>
        /// Add a custom context sip or voip header.
        /// </summary>
        /// <param name="header">custom context sip UUI, custom header or voip header.</param>
        public void Add(CustomContextHeader header)
        {
            if (header is SIPUUIHeader sipUUIHeader)
            {
                if (SipHeaders == null)
                {
                    throw new InvalidOperationException("Cannot add sip header, SipHeaders is null.");
                }
                SipHeaders.Add(sipUUIHeader.Key, sipUUIHeader.Value);
            }
            else if (header is SIPCustomHeader sipCustomHeader)
            {
                if (SipHeaders == null)
                {
                    throw new InvalidOperationException("Cannot add sip header, SipHeaders is null.");
                }
                SipHeaders.Add(sipCustomHeader.Key, sipCustomHeader.Value);
            }
            else if (header is VoipHeader voipHeader)
            {
                if (VoipHeaders == null)
                {
                    throw new InvalidOperationException("Cannot add voip header, VoipHeaders is null");
                }
                VoipHeaders.Add(voipHeader.Key, voipHeader.Value);
            }
            else
            {
                throw new InvalidOperationException("Unknown custom context header type.");
            }
        }
    }
}
