// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> The updatable properties of the AutonomousDatabase. </summary>
    public partial class AutonomousDatabaseUpdateProperties
    {
        /// <summary> The list of scheduled operations. </summary>
        [CodeGenMember("ScheduledOperations")]
        public ScheduledOperationsType AutonomousDatabaseScheduledOperations { get; set; }

        /// <summary> The list of scheduled operations. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScheduledOperationsTypeUpdate ScheduledOperations
        {
            get
            {
                if (AutonomousDatabaseScheduledOperations == null)
                {
                    return null;
                }
                return new ScheduledOperationsTypeUpdate()
                {
                    DayOfWeekName = AutonomousDatabaseScheduledOperations.DayOfWeekName,
                    AutoStartOn = AutonomousDatabaseScheduledOperations.AutoStartOn,
                    AutoStopOn = AutonomousDatabaseScheduledOperations.AutoStopOn
                };
            }
            set
            {
                if (value == null)
                {
                    AutonomousDatabaseScheduledOperations = null;
                }
                else
                {
                    AutonomousDatabaseScheduledOperations = new ScheduledOperationsType()
                    {
                        DayOfWeekName = value.DayOfWeekName,
                        AutoStartOn = value.AutoStartOn,
                        AutoStopOn = value.AutoStopOn,
                    };
                }
            }
        }
    }
}
