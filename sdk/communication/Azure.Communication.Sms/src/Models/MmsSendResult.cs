// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Sms
{
    [CodeGenModel("MmsSendResponseItem")]
    public partial class MmsSendResult
    {
        [CodeGenMember("RepeatabilityResult")]
        internal MmsSendResponseItemRepeatabilityResult? RepeatabilityResult { get; }
    }
}
