// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Test.Perf
{
    public class OperationResult
    {
        public TimeSpan Time { get; set; }
        public long Size { get; set; }
    }
}
