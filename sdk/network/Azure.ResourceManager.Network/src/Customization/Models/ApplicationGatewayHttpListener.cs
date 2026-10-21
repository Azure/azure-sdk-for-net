// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayHttpListener : NetworkResourceData
    {
        // The following three references were internal in 1.15.0 and unnecessarily exposed publicly
        // during the 1.16.0 TypeSpec migration. Retained for released 1.16/1.17 API compatibility;
        // each returns a new wrapper and copies only its ID.
        /// <summary> Compatibility member. </summary>
        public WritableSubResource FrontendIPConfiguration
        {
            get => FrontendIPConfigurationId is null ? default : new WritableSubResource { Id = FrontendIPConfigurationId };
            set => FrontendIPConfigurationId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public WritableSubResource FrontendPort
        {
            get => FrontendPortId is null ? default : new WritableSubResource { Id = FrontendPortId };
            set => FrontendPortId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public WritableSubResource SslCertificate
        {
            get => SslCertificateId is null ? default : new WritableSubResource { Id = SslCertificateId };
            set => SslCertificateId = value?.Id;
        }
    }
}
