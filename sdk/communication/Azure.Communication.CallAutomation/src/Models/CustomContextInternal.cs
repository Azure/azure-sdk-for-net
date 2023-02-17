// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("CustomContext")]
    internal partial class CustomContextInternal
    {
        public CustomContextInternal(IDictionary<string, string> sipHeaders, IDictionary<string, string> voipHeaders)
        {
            this.SipHeaders = sipHeaders;
            this.VoipHeaders = voipHeaders;
        }
    }
}
