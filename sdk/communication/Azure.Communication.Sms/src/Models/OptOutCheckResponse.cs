// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.Sms.Models
{
    /// <summary> The OptOutCheckResponse wrapper for Check operations. </summary>
    internal class OptOutCheckResponse
    {
        /// <summary> Initializes a new instance of <see cref="OptOutCheckResponse"/>. </summary>
        /// <param name="value"> The check response items. </param>
        internal OptOutCheckResponse(IEnumerable<OptOutCheckResponseItem> value)
        {
            Value = new List<OptOutCheckResponseItem>(value).AsReadOnly();
        }

        /// <summary> The check response items. </summary>
        public IReadOnlyList<OptOutCheckResponseItem> Value { get; }
    }
}
