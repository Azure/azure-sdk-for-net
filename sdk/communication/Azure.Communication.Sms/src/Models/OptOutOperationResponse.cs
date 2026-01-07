// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.Sms.Models
{
    /// <summary> The OptOutOperationResponse wrapper for Add and Remove operations. </summary>
    internal class OptOutOperationResponse
    {
        /// <summary> Initializes a new instance of <see cref="OptOutOperationResponse"/>. </summary>
        /// <param name="value"> The operation response items. </param>
        internal OptOutOperationResponse(IEnumerable<OptOutOperationResponseItem> value)
        {
            Value = new List<OptOutOperationResponseItem>(value).AsReadOnly();
        }

        /// <summary> The operation response items. </summary>
        public IReadOnlyList<OptOutOperationResponseItem> Value { get; }
    }
}
