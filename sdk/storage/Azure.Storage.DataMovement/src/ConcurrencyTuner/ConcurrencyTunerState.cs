// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal enum ConcurrencyTunerState
    {
        /// <summary>
        /// Default.
        /// </summary>
        ConcurrencyReasonNone = default,

        /// <summary>
        /// tuner disabled used as the final (non-finished) state for null tuner
        /// </summary>
	    ConcurrencyReasonTunerDisabled = 1,

        /// <summary>
        /// initial starting point
        /// </summary>
	    ConcurrencyReasonInitial = 2,

        /// <summary>
        /// seeking optimum
        /// </summary>
        ConcurrencyReasonSeeking = 3,

        /// <summary>
        /// backing off
        /// </summary>
        ConcurrencyReasonBackoff = 4,

        /// <summary>
        /// hit max concurrency limit
        /// </summary>
        ConcurrencyReasonHitMax = 5,

        /// <summary>
        /// at optimum, but may be limited by CPU
        /// </summary>
        ConcurrencyReasonHighCpu = 6,

        /// <summary>
        /// at optimum
        /// </summary>
        ConcurrencyReasonAtOptimum = 7,

        /// <summary>
        /// tuning already finished (or never started)
        /// </summary>
        ConcurrencyReasonFinished = 8
    }
}
