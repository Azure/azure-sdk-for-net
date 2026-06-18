// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayProbe type. </summary>
    public partial class ApplicationGatewayProbe
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Int32> IntervalInSeconds
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> IsProbeProxyProtocolHeaderEnabled
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
