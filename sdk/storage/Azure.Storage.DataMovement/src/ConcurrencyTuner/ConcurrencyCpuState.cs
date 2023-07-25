// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal struct ConcurrencyCpuState
    {
        public ConcurrencyTunerState State;
        public int Concurrency;
    }
}
