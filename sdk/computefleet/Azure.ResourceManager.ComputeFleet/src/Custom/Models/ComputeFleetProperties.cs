// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ComputeFleet.Models
{
    public partial class ComputeFleetProperties
    {
        /// <summary> The list of location profiles. </summary>
        public IList<LocationProfile> AdditionalLocationsLocationProfiles
        {
            get => AdditionalLocationsProfile is null ? default : AdditionalLocationsProfile.LocationProfiles;
            set => AdditionalLocationsProfile = new AdditionalLocationsProfile(value);
        }
    }
}
