// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Consumption.Models
{
    // Options bag retained for backward compatibility with v1.1.0 surface that used an options-style overload.
    [Obsolete("This options type is obsolete. Use the direct parameter overload of GetConsumptionReservationsSummaries.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ArmResourceGetConsumptionReservationsSummariesOptions
    {
        public ArmResourceGetConsumptionReservationsSummariesOptions(ReservationSummaryDataGrain grain)
        {
            Grain = grain;
        }

        public ReservationSummaryDataGrain Grain { get; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Filter { get; set; }
        public string ReservationId { get; set; }
        public string ReservationOrderId { get; set; }
    }
}
