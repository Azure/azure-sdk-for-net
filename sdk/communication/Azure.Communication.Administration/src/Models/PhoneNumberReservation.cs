// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Administration.Models
{
    [CodeGenModel("PhoneNumberSearch")]
    public partial class PhoneNumberReservation
    {
        /// <summary> The id of reservation. </summary>
        [CodeGenMember("SearchId")]
        public string ReservationId { get; }
    }
}
