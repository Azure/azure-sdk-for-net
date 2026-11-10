// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.LoadTesting
{
    public partial class MonthlyRecurrenceByWeekDays
    {
        /// <summary> Initializes a new instance of <see cref="MonthlyRecurrenceByWeekDays"/>. </summary>
        /// <param name="index"> The index of the week in a month at which the recurrence should repeat. </param>
        /// <param name="interval"> The interval at which the recurrence should repeat. </param>
        public MonthlyRecurrenceByWeekDays(int index, int interval) : this()
        {
            Index = index;
            Interval = interval;
        }
    }
}
