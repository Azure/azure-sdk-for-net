// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Developer.LoadTesting
{
    public partial class RecurrenceWithCron
    {
        /// <summary> Initializes a new instance of <see cref="RecurrenceWithCron"/>. </summary>
        /// <param name="cronExpression"> The cron expression for the recurrence. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cronExpression"/> is null. </exception>
        public RecurrenceWithCron(string cronExpression) : this()
        {
            if (cronExpression is null)
            {
                throw new ArgumentNullException(nameof(cronExpression));
            }

            CronExpression = cronExpression;
        }
    }
}
