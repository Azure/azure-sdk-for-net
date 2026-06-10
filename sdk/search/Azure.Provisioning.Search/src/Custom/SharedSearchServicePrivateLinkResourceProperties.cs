// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.Search
{
    public partial class SharedSearchServicePrivateLinkResourceProperties
    {
        private BicepValue<SharedSearchServicePrivateLinkResourceProvisioningState> _provisioningStateCompat;
        private BicepValue<SharedSearchServicePrivateLinkResourceStatus> _statusCompat;

        /// <summary> Gets or sets the ProvisioningState. </summary>
        public BicepValue<SharedSearchServicePrivateLinkResourceProvisioningState> ProvisioningState
        {
            get
            {
                Initialize();
                return _provisioningStateCompat ??= DefineProperty<SharedSearchServicePrivateLinkResourceProvisioningState>(nameof(ProvisioningState), new string[] { "provisioningState" });
            }
            set
            {
                Initialize();
                (_provisioningStateCompat ??= DefineProperty<SharedSearchServicePrivateLinkResourceProvisioningState>(nameof(ProvisioningState), new string[] { "provisioningState" })).Assign(value);
            }
        }

        /// <summary> Gets or sets the Status. </summary>
        public BicepValue<SharedSearchServicePrivateLinkResourceStatus> Status
        {
            get
            {
                Initialize();
                return _statusCompat ??= DefineProperty<SharedSearchServicePrivateLinkResourceStatus>(nameof(Status), new string[] { "status" });
            }
            set
            {
                Initialize();
                (_statusCompat ??= DefineProperty<SharedSearchServicePrivateLinkResourceStatus>(nameof(Status), new string[] { "status" })).Assign(value);
            }
        }
    }
}
