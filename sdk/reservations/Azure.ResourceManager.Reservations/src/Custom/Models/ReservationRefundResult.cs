// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Reservations.Models
{
    /// <summary> The response of refund request containing refund information of reservation. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ReservationRefundResult
    {
        /// <summary> Initializes a new instance of ReservationRefundResult. </summary>
        internal ReservationRefundResult()
        {
        }

        /// <summary> Initializes a new instance of ReservationRefundResult. </summary>
        /// <param name="id"> Fully qualified identifier of the reservation being returned. </param>
        /// <param name="properties"> The refund properties of reservation. </param>
        internal ReservationRefundResult(string id, ReservationRefundResponseProperties properties)
        {
            Id = id;
            Properties = properties;
        }

        /// <summary> Fully qualified identifier of the reservation being returned. </summary>
        public string Id { get; }
        /// <summary> The refund properties of reservation. </summary>
        public ReservationRefundResponseProperties Properties { get; }
    }
}
