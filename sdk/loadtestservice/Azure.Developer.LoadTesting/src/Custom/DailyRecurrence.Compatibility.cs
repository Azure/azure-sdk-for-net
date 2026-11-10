// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.LoadTesting
{
    public partial class DailyRecurrence
    {
        /// <summary> Initializes a new instance of <see cref="DailyRecurrence"/>. </summary>
        /// <param name="interval"> The interval at which the recurrence should repeat. </param>
        public DailyRecurrence(int interval) : this()
        {
            Interval = interval;
        }
    }
}
