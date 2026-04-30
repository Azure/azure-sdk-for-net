// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> DayOfWeek resource properties. </summary>
    public partial class OracleDatabaseDayOfWeekUpdate
    {
        /// <summary> Initializes a new instance of <see cref="OracleDatabaseDayOfWeekUpdate"/>. </summary>
        /// <param name="name"> Name of the day of the week. </param>
        public OracleDatabaseDayOfWeekUpdate(OracleDatabaseDayOfWeekName name)
        {
            Name = name;
        }

        /// <summary> Name of the day of the week. </summary>
        public OracleDatabaseDayOfWeekName Name { get; set; }
    }
}
