// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    /// <summary> Properties related to data used to train the model. </summary>
    [CodeGenModel("LogsProperties")]
    public partial class PersonalizerLogProperties
    {
        /// <summary> Start date for the range. </summary>
        public DateTimeOffset? StartTime { get; }
        /// <summary> End date for the range. </summary>
        public DateTimeOffset? EndTime { get; }

        /// <summary> Initializes a new instance of PersonalizerLogProperties. </summary>
        /// <param name="start"> Start date. </param>
        /// <param name="end"> End date. </param>
        internal PersonalizerLogProperties(DateTimeOffset? start, DateTimeOffset? end)
        {
            StartTime = start;
            EndTime = end;
        }

        internal PersonalizerLogPropertiesDateRange DateRange { get; }
    }
}
