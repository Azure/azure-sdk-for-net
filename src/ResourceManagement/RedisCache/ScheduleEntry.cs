// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Redis.Fluent.Models
{
    using ResourceManager.Fluent.Core;
    using System;
    using System.Linq;

    /// <summary>
    /// Patch schedule entry for a Premium Redis Cache.
    /// </summary>
    public class ScheduleEntry : Wrapper<ScheduleEntryInner>
    {
        /// <summary>
        /// Initializes a new instance of the ScheduleEntry class.
        /// </summary>
        public ScheduleEntry(ScheduleEntryInner inner)
            : base(inner)
        {
        }

        /// <summary>
        /// Gets or sets day of the week when a cache can be patched. Possible
        /// values include: 'Monday', 'Tuesday', 'Wednesday', 'Thursday',
        /// 'Friday', 'Saturday', 'Sunday', 'Everyday', 'Weekend'
        /// </summary>
        public DayOfWeek DayOfWeek { get { return this.Inner.DayOfWeek; } }

        /// <summary>
        /// Gets or sets start hour after which cache patching can start.
        /// </summary>
        public int StartHourUtc { get { return this.Inner.StartHourUtc; } }

        /// <summary>
        /// Gets or sets ISO8601 timespan specifying how much time cache
        /// patching can take.
        /// </summary>
        public TimeSpan? MaintenanceWindow { get { return this.Inner.MaintenanceWindow; } }

    }
}
