// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.Sms.Models
{
    /// <summary> Response for an opt out request. Validate the returned items in the response to see which recipients were successfully added or removed from the opt outs list. </summary>
    public partial class OptOutChangeResponse
    {
        /// <summary> Initializes a new instance of <see cref="OptOutChangeResponse"/>. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal OptOutChangeResponse(IEnumerable<OptOutChangeResponseItem> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="OptOutChangeResponse"/>. </summary>
        /// <param name="value"></param>
        internal OptOutChangeResponse(IReadOnlyList<OptOutChangeResponseItem> value)
        {
            Value = value;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<OptOutChangeResponseItem> Value { get; }
    }
}
