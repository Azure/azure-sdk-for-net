// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class DdosSettings
    {
        public global::System.Nullable<global::System.Boolean> ProtectedIP
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.DdosSettingsProtectionCoverage> ProtectionCoverage
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
