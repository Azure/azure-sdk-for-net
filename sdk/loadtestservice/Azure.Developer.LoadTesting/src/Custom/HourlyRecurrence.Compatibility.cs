// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.LoadTesting
{
    public partial class HourlyRecurrence
    {
        /// <summary> Initializes a new instance of <see cref="HourlyRecurrence"/>. </summary>
        /// <param name="interval"> The interval at which the recurrence should repeat. </param>
        public HourlyRecurrence(int interval) : this()
        {
            Interval = interval;
        }
    }
}
