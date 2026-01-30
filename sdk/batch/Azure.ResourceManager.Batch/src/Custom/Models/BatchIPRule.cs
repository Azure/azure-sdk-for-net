// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    public partial class BatchIPRule
    {
        /// <summary> Initializes a new instance of <see cref="BatchIPRule"/>. </summary>
        /// <param name="value"> IPv4 address, or IPv4 address range in CIDR format. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public BatchIPRule(string value) : this(BatchIPRuleAction.Allow, value)
        { }

        /// <summary> Action when client IP address is matched. </summary>
        public BatchIPRuleAction Action { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}
