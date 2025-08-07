// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for declining an offer.
    /// </summary>
    public partial class DeclineJobOfferOptions
    {
        /// <summary> Initializes a new instance of DeclineJobOfferOptions. </summary>
        internal DeclineJobOfferOptions()
        {
        }

        /// <param name="workerId"> Id of the worker. </param>
        /// <param name="offerId"> Id of the offer. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> or <paramref name="offerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="workerId"/> or <paramref name="offerId"/> is an empty string, and was expected to be non-empty. </exception>

        public DeclineJobOfferOptions(string workerId, string offerId)
        {
            Argument.AssertNotNullOrEmpty(workerId, nameof(workerId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));

            WorkerId = workerId;
            OfferId = offerId;
        }

        /// <summary>
        /// Id of the worker.
        /// </summary>
        public string WorkerId { get; }

        /// <summary>
        /// Id of the offer.
        /// </summary>
        public string OfferId { get; }

        /// <summary>
        /// If the RetryOfferAt is not provided, then this job will not be offered again to the worker who declined this job unless
        /// the worker is de-registered and re-registered.  If a RetryOfferAt time is provided, then the job will be re-matched to
        /// eligible workers at the retry time in UTC.  The worker that declined the job will also be eligible for the job at that time.
        /// </summary>
        public DateTimeOffset? RetryOfferAt { get; set; }
    }
}
