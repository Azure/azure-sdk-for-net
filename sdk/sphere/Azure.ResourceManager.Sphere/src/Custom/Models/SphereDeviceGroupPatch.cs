// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sphere.Models
{
    public partial class SphereDeviceGroupPatch
    {
        /// <summary> Operating system feed type of the device group. </summary>
        public SphereOSFeedType? OSFeedType
        {
            get => Properties is null ? default : Properties.OsFeedType;
            set
            {
                if (Properties is null)
                {
                    Properties = new DeviceGroupUpdateProperties();
                }
                Properties.OsFeedType = value;
            }
        }
    }
}
