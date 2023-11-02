// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("CustomCallingContext")]
    internal partial class CustomCallingContextInternal
    {
        public CustomCallingContextInternal(IDictionary<string, string> sipHeaders, IDictionary<string, string> voipHeaders)
        {
            SipHeaders = sipHeaders;
            VoipHeaders = voipHeaders;
        }
    }
}
