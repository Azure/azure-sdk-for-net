// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

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

            ScheduledDay = dayOfWeek;
        }

        /// <summary> Day of week. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please use 'ScheduledDay' instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OracleDatabaseDayOfWeekUpdate DayOfWeek
        {
            get => ScheduledDay;
            set => ScheduledDay = value;
        }

        /// <summary> Day of week name. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please use 'ScheduledDayName' instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public OracleDatabaseDayOfWeekName? DayOfWeekName
        {
            get => ScheduledDayName;
            set => ScheduledDayName = value;
        }
    }
}
