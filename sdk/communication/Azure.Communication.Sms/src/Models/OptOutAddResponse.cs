// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.Sms.Models
{
    /// <summary> Response for add opt out request. Validate the returned items in the response to see which recipients were successfully added to the opt outs list. </summary>
    public partial class OptOutAddResponse
    {
        /// <summary> Initializes a new instance of <see cref="OptOutAddResponse"/>. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal OptOutAddResponse(IEnumerable<OptOutAddResponseItem> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="OptOutAddResponse"/>. </summary>
        /// <param name="value"></param>
        internal OptOutAddResponse(IReadOnlyList<OptOutAddResponseItem> value)
        {
            Value = value;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<OptOutAddResponseItem> Value { get; }
    }
}
