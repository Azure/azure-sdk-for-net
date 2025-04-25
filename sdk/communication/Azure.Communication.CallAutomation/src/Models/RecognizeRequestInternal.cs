// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("RecognizeRequest")]
    internal partial class RecognizeRequestInternal
    {
        [CodeGenMember("PlayPrompts")]
        public IList<PlaySourceInternal> PlayPrompts { get; set; }
    }
}
