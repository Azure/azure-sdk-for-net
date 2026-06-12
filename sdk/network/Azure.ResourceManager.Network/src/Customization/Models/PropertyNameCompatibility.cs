// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayBackendHttpSettings
    {
        /// <summary> Request timeout in seconds. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.requestTimeout")]
        public int? RequestTimeoutInSeconds
        {
            get => RequestTimeout;
            set => RequestTimeout = value;
        }

        /// <summary> Enable or disable dedicated connection per backend server. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.dedicatedBackendConnection")]
        public bool? IsDedicatedBackendConnectionEnabled
        {
            get => DedicatedBackendConnection;
            set => DedicatedBackendConnection = value;
        }

        /// <summary> Verify or skip both chain and expiry validations of the certificate on the backend server. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.validateCertChainAndExpiry")]
        public bool? IsValidateCertChainAndExpiryEnabled
        {
            get => ValidateCertChainAndExpiry;
            set => ValidateCertChainAndExpiry = value;
        }

        /// <summary> When enabled, verifies if the Common Name of the certificate provided by the backend server matches the Server Name Indication (SNI) value. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.validateSNI")]
        public bool? IsValidateSniEnabled
        {
            get => ValidateSNI;
            set => ValidateSNI = value;
        }
    }
}
