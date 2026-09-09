// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.AppConfiguration
{
    public partial class AppConfigurationSnapshot
    {
        private BicepValue<string> _snapshotType;

        /// <summary> Gets the expiration date of the snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Please use ExpiresOn instead.")]
        public BicepValue<DateTimeOffset> ExpireOn
        {
            get { return ExpiresOn; }
        }

        /// <summary> Gets the type of the resource. </summary>
        public BicepValue<string> SnapshotType
        {
            get { Initialize(); return _snapshotType; }
        }

        partial void DefineAdditionalProperties()
        {
            _snapshotType = DefineProperty<string>(nameof(SnapshotType), new string[] { "type" }, isOutput: true);
        }

        /// <summary> Supported API versions retained for compatibility. </summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2024-06-01". </summary>
            public static readonly string V2024_06_01 = "2024-06-01";
            /// <summary> API version "2024-05-01". </summary>
            public static readonly string V2024_05_01 = "2024-05-01";
        }
    }
}
