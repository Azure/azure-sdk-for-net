// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;

namespace Azure.Provisioning.ApplicationInsights
{
    public partial class ApplicationInsightsComponent
    {
        private SystemData _systemData;

        /// <summary> Gets the system metadata associated with this resource. </summary>
        public SystemData SystemData
        {
            get { Initialize(); return _systemData; }
        }

        partial void DefineAdditionalProperties()
        {
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }

        /// <summary> Supported API versions retained for compatibility. </summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2015-05-01". </summary>
            public static readonly string V2015_05_01 = "2015-05-01";
            /// <summary> API version "2014-08-01". </summary>
            public static readonly string V2014_08_01 = "2014-08-01";
            /// <summary> API version "2014-04-01". </summary>
            public static readonly string V2014_04_01 = "2014-04-01";
        }
    }
}
