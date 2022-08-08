// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary> A class representing the ApiManagementGatewayHostnameConfiguration data model. </summary>
    public partial class ApiManagementGatewayHostnameConfigurationData : ResourceData
    {
#pragma warning disable CA1707
        /// <summary> Specifies if TLS 1.0 is supported. </summary>
        [CodeGenMember("Tls10Enabled")]
        public bool? IsTls1_0Enabled { get; set; }
        /// <summary> Specifies if TLS 1.1 is supported. </summary>
        [CodeGenMember("Tls11Enabled")]
        public bool? IsTls1_1Enabled { get; set; }
        /// <summary> Specifies if HTTP/2.0 is supported. </summary>
        [CodeGenMember("Http2Enabled")]
        public bool? IsHttp2_0Enabled { get; set; }
#pragma warning restore CA1707
    }
}
