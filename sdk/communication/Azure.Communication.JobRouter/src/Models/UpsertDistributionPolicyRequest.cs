// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter.Models
{
    internal partial class UpsertDistributionPolicyRequest
    {
        /// <summary> The expiry time of any offers created under this policy will be governed by the offer time to live. </summary>
        public TimeSpan OfferTTL { get; set; }
    }
}
