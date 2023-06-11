// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> Scaling plan schedule. </summary>
    public partial class ScalingSchedule
    {
        /// <summary> Starting time for ramp up period. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `RampUpStartTime` instead.", false)]
        public DateTimeOffset? RampUpStartOn
        {
            get => new DateTimeOffset(0, 0, 0, RampUpStartTime.Hour, RampUpStartTime.Minute, 0, new TimeSpan());
            set
            {
                RampUpStartTime.Hour = value.Value.Hour;
                RampUpStartTime.Minute = value.Value.Minute;
            }
        }
        /// <summary> Starting time for peak period. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `PeakStartTime` instead.", false)]
        public DateTimeOffset? PeakStartOn
        {
            get => new DateTimeOffset(0, 0, 0, PeakStartTime.Hour, PeakStartTime.Minute, 0, new TimeSpan());
            set
            {
                PeakStartTime.Hour = value.Value.Hour;
                PeakStartTime.Minute = value.Value.Minute;
            }
        }
        /// <summary> Starting time for ramp down period. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `RampDownStartTime` instead.", false)]
        public DateTimeOffset? RampDownStartOn
        {
            get => new DateTimeOffset(0, 0, 0, RampDownStartTime.Hour, RampDownStartTime.Minute, 0, new TimeSpan());
            set
            {
                RampDownStartTime.Hour = value.Value.Hour;
                RampDownStartTime.Minute = value.Value.Minute;
            }
        }
        /// <summary> Starting time for off-peak period. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `OffPeakStartTime` instead.", false)]
        public DateTimeOffset? OffPeakStartOn
        {
            get => new DateTimeOffset(0, 0, 0, OffPeakStartTime.Hour, OffPeakStartTime.Minute, 0, new TimeSpan());
            set
            {
                OffPeakStartTime.Hour = value.Value.Hour;
                OffPeakStartTime.Minute = value.Value.Minute;
            }
        }
    }
}
