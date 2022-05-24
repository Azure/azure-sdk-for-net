// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Response received after declining job offer.
    /// </summary>
    public class DeclineJobOfferResponse: EmptyPlaceholderObject
    {
        /// <inheritdoc />
        public DeclineJobOfferResponse(object value) : base(value)
        {
        }
    }
}
