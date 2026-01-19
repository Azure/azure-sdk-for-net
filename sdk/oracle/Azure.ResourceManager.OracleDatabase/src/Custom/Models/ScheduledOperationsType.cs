// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class ScheduledOperationsType
    {
        /// <summary> Initializes a new instance of <see cref="ScheduledOperationsType"/>. </summary>
        /// <param name="dayOfWeek"> Day of week. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dayOfWeek"/> is null. </exception>
        public ScheduledOperationsType(OracleDatabaseDayOfWeek dayOfWeek)
        {
            Argument.AssertNotNull(dayOfWeek, nameof(dayOfWeek));

            DayOfWeek = dayOfWeek;
        }
    }
}
