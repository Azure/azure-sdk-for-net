// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Request body to get the configuration for the region. </summary>
    public partial class RegionConfigurationContent
    {
        /// <summary> Type of the device. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataBoxSkuName? TransportAvailabilityRequestSkuName
        {
            get => TransportAvailabilityRequest is null ? default : TransportAvailabilityRequest.SkuName;
            set
            {
                if (TransportAvailabilityRequest is null)
                    TransportAvailabilityRequest = new TransportAvailabilityContent();
                TransportAvailabilityRequest.SkuName = value;
            }
        }
    }
}
