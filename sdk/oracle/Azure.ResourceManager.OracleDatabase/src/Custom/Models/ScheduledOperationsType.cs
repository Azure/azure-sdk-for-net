// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

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

            ScheduledDay = dayOfWeek;
        }

        /// <summary> Day of week name. </summary>
        [System.Obsolete("This property is obsolete and will be removed in a future release. Please use 'ScheduledDayName' instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OracleDatabaseDayOfWeekName? DayOfWeekName
        {
            get => ScheduledDayName;
            set { if (value.HasValue) ScheduledDayName = value.Value; }
        }
    }
}
