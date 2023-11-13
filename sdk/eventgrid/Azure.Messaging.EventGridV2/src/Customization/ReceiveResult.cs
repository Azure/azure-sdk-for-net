// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    /// <summary> Details of the Receive operation response. </summary>
    public partial class ReceiveResult
    {
        /// <summary> Initializes a new instance of ReceiveResult. </summary>
        /// <param name="value"> Array of receive responses, one per cloud event. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal ReceiveResult(IEnumerable<ReceiveDetails> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of ReceiveResult. </summary>
        /// <param name="value"> Array of receive responses, one per cloud event. </param>
        internal ReceiveResult(IReadOnlyList<ReceiveDetails> value)
        {
            Value = value.ToList();
        }

        /// <summary> Array of receive responses, one per cloud event. </summary>
        public IReadOnlyList<ReceiveDetails> Value { get; }
    }
}