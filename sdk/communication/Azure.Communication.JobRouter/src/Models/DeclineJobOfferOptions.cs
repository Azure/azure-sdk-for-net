// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for declining an offer.
    /// </summary>
    public class DeclineJobOfferOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="offerId"> The Id of the Job offer. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerId"/> is null. </exception>
        public DeclineJobOfferOptions(string workerId, string offerId)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));

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
        /// If the re-offer time is not provided, then this job will not be re-offered to the worker who declined this job unless
        /// the worker is de-registered and re-registered.  If a re-offer time is provided, then the job will be re-matched to
        /// eligible workers after the re-offer time.  The worker that declined the job will also be eligible for the job at that time.
        /// </summary>
        public DateTimeOffset? ReofferTimeUtc { get; set; }
    }
}
