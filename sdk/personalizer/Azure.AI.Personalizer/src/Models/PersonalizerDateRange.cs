// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Personalizer.Models
{
    /// <summary> Initializes a new instance of DateRange. </summary>
    [CodeGenModel("DateRange")]
    public partial class PersonalizerDateRange
    {
        /// <summary> Start date for the range. </summary>
        [CodeGenMember("From")]
        public DateTimeOffset? Start { get; }
        /// <summary> End date for the range. </summary>
        [CodeGenMember("To")]
        public DateTimeOffset? End { get; }
    }
}
