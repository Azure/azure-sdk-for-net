// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for declining an offer.
    /// </summary>
    public partial class DeclineJobOfferOptions
    {
        /// <summary>
        /// If the RetryOfferAt is not provided, then this job will not be offered again to the worker who declined this job unless
        /// the worker is de-registered and re-registered.  If a RetryOfferAt time is provided, then the job will be re-matched to
        /// eligible workers at the retry time in UTC.  The worker that declined the job will also be eligible for the job at that time.
        /// </summary>
        public DateTimeOffset? RetryOfferAt { get; set; }
    }
}
