// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Consumption.Models
{
    /// <summary>
    /// Obsolete options bag retained for backward compatibility with the v1.1.0 surface that used an
    /// options-style overload of <c>GetConsumptionReservationsSummaries</c>. Use the direct-parameter
    /// overload of <c>GetConsumptionReservationSummaries</c> on the appropriate scope instead.
    /// </summary>
    [Obsolete("This options type is obsolete. Use the direct parameter overload of GetConsumptionReservationsSummaries.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ArmResourceGetConsumptionReservationsSummariesOptions
    {
        /// <summary> Initializes a new instance of the <see cref="ArmResourceGetConsumptionReservationsSummariesOptions"/> class. </summary>
        /// <param name="grain"> Reservation summary data grain (daily/monthly). </param>
        public ArmResourceGetConsumptionReservationsSummariesOptions(ReservationSummaryDataGrain grain)
        {
            Grain = grain;
        }

        /// <summary> Reservation summary data grain. </summary>
        public ReservationSummaryDataGrain Grain { get; }

        /// <summary> Optional start date filter (ISO 8601). </summary>
        public string StartDate { get; set; }

        /// <summary> Optional end date filter (ISO 8601). </summary>
        public string EndDate { get; set; }

        /// <summary> Optional OData filter expression. </summary>
        public string Filter { get; set; }

        /// <summary> Optional reservation identifier filter. </summary>
        public string ReservationId { get; set; }

        /// <summary> Optional reservation-order identifier filter. </summary>
        public string ReservationOrderId { get; set; }
    }
}
