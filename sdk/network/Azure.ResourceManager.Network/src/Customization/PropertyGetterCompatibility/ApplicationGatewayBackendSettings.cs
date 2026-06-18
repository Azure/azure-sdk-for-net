// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayBackendSettings type. </summary>
    public partial class ApplicationGatewayBackendSettings
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> IsL4ClientIPPreservationEnabled
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Int32> TimeoutInSeconds
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
