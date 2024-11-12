// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Core.TestFramework
{
    internal interface IMockOperationInternal
    {
        List<TimeSpan> DelaysPassedToWait { get; set; }
        CancellationToken LastTokenReceivedByUpdateStatus { get; set; }
        int UpdateStatusCallCount { get; set; }
    }
}
