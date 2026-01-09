// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Sphere.Models;

namespace Azure.ResourceManager.Sphere
{
    public partial class SphereDeviceGroupData
    {
        /// <summary> Description of the device group. </summary>
        public string Description
        {
            get => Properties?.Description;
            set
            {
                EnsureProperties();
                Properties.Description = value;
            }
        }

        /// <summary> Operating system feed type of the device group. </summary>
        public SphereOSFeedType? OSFeedType
        {
            get => Properties?.OsFeedType;
            set
            {
                EnsureProperties();
                Properties.OsFeedType = value;
            }
        }

        /// <summary> Update policy of the device group. </summary>
        public SphereUpdatePolicy? UpdatePolicy
        {
            get => Properties?.UpdatePolicy;
            set
            {
                EnsureProperties();
                Properties.UpdatePolicy = value;
            }
        }

        /// <summary> Flag to define if the user allows for crash dump collection. </summary>
        public SphereAllowCrashDumpCollectionStatus? AllowCrashDumpsCollection
        {
            get => Properties?.AllowCrashDumpsCollection;
            set
            {
                EnsureProperties();
                Properties.AllowCrashDumpsCollection = value;
            }
        }

        /// <summary> Regional data boundary for the device group. </summary>
        public RegionalDataBoundary? RegionalDataBoundary
        {
            get => Properties?.RegionalDataBoundary;
            set
            {
                EnsureProperties();
                Properties.RegionalDataBoundary = value;
            }
        }

        /// <summary> Deployment status for the device group. </summary>
        public bool? HasDeployment => Properties?.HasDeployment;

        /// <summary> The status of the last operation. </summary>
        public SphereProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        private void EnsureProperties() => Properties ??= new DeviceGroupProperties();
    }
}
