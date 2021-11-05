// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Sms
{
    [CodeGenModel("SmsSendResponseItem")]
    public partial class SmsSendResult
    {
        [CodeGenMember("RepeatabilityResult")]
        internal SmsSendResponseItemRepeatabilityResult? RepeatabilityResult { get; }
    }
}
