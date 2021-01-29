// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Sms
{
    /// <summary> Response for a single recipient. </summary>
    [CodeGenModel("SendSmsResponseItem")]
    public partial class SmsSendResult
    {
        /// <summary> This flag will be set if the request is successfully processed. </summary>
        public bool? isSuccessful { get; set; }
    }
}
