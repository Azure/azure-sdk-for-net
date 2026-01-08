// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> The list of scheduled operations. </summary>
    public partial class ScheduledOperationsTypeUpdate
    {
        /// <summary> Initializes a new instance of <see cref="ScheduledOperationsTypeUpdate"/>. </summary>
        public ScheduledOperationsTypeUpdate()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ScheduledOperationsTypeUpdate"/>. </summary>
        /// <param name="dayOfWeek"> Day of week. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dayOfWeek"/> is null. </exception>
        public ScheduledOperationsTypeUpdate(OracleDatabaseDayOfWeekUpdate dayOfWeek)
        {
            Argument.AssertNotNull(dayOfWeek, nameof(dayOfWeek));

            DayOfWeek = dayOfWeek;
        }

        /// <summary> Day of week. </summary>
        public OracleDatabaseDayOfWeekUpdate DayOfWeek { get; set; }
    }
}
