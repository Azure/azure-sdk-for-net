// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppConfiguration
{
    [CodeGenSuppress("ExpiresOn")]
    public partial class AppConfigurationSnapshot
    {
        private BicepValue<DateTimeOffset> _expireOn;
        private BicepValue<string> _snapshotType;

        /// <summary> Gets the expiration date of the snapshot. </summary>
        public BicepValue<DateTimeOffset> ExpireOn
        {
            get { Initialize(); return _expireOn; }
        }

        /// <summary> Gets the type of the resource. </summary>
        public BicepValue<string> SnapshotType
        {
            get { Initialize(); return _snapshotType; }
        }

        partial void DefineAdditionalProperties()
        {
            _expireOn = DefineProperty<DateTimeOffset>(nameof(ExpireOn), new string[] { "properties", "expires" }, isOutput: true);
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
