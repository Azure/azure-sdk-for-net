// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ComputeFleet.Models
{
    public partial class ComputeFleetVmProfile
    {
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier CapacityReservationGroupId
        {
            get => CapacityReservation is null ? default : CapacityReservation.CapacityReservationGroupId;
            set
            {
                if (CapacityReservation is null)
                    CapacityReservation = new CapacityReservationProfile();
                CapacityReservation.CapacityReservationGroupId = value;
            }
        }
    }
}
