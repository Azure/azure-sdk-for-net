// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.Sms.Models
{
    /// <summary> Response for remove opt out request. Validate the returned items in the response to see which recipients were successfully removed from the opt outs list. </summary>
    public partial class OptOutRemoveResponse
    {
        /// <summary> Initializes a new instance of <see cref="OptOutAddResponse"/>. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal OptOutRemoveResponse(IEnumerable<OptOutRemoveResponseItem> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="OptOutAddResponse"/>. </summary>
        /// <param name="value"></param>
        internal OptOutRemoveResponse(IReadOnlyList<OptOutRemoveResponseItem> value)
        {
            Value = value;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<OptOutRemoveResponseItem> Value { get; }
    }
}
