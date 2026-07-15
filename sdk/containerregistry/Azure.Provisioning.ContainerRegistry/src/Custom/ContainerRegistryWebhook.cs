// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;

namespace Azure.Provisioning.ContainerRegistry
{
    public partial class ContainerRegistryWebhook
    {
        private BicepValue<Uri> _serviceUri;
        private BicepDictionary<string> _customHeaders;

        /// <summary> Gets or sets the service URI for the webhook to post notifications. </summary>
        public BicepValue<Uri> ServiceUri
        {
            get { Initialize(); return _serviceUri; }
            set { Initialize(); _serviceUri.Assign(value); }
        }

        /// <summary> Gets or sets custom headers added to webhook notifications. </summary>
        public BicepDictionary<string> CustomHeaders
        {
            get { Initialize(); return _customHeaders; }
            set { Initialize(); _customHeaders.Assign(value); }
        }

        partial void DefineAdditionalProperties()
        {
            // The create body contains properties absent from the resource model. Remove this workaround
            // when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
            _serviceUri = DefineProperty<Uri>(nameof(ServiceUri), new string[] { "properties", "serviceUri" }, isRequired: true);
            _customHeaders = DefineDictionaryProperty<string>(nameof(CustomHeaders), new string[] { "properties", "customHeaders" });
        }

        /// <summary></summary>
        public static partial class ResourceVersions
        {
            /// <summary> API version "2017-10-01". </summary>
            public static readonly string V2017_10_01 = "2017-10-01";
            /// <summary> API version "2019-05-01". </summary>
            public static readonly string V2019_05_01 = "2019-05-01";
            /// <summary> API version "2021-09-01". </summary>
            public static readonly string V2021_09_01 = "2021-09-01";
            /// <summary> API version "2022-12-01". </summary>
            public static readonly string V2022_12_01 = "2022-12-01";
            /// <summary> API version "2023-07-01". </summary>
            public static readonly string V2023_07_01 = "2023-07-01";
            /// <summary> API version "2025-04-01". </summary>
            public static readonly string V2025_04_01 = "2025-04-01";
        }
    }
}
