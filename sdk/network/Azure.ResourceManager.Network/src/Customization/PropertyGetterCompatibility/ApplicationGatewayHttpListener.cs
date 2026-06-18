// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewayHttpListener type. </summary>
    public partial class ApplicationGatewayHttpListener
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource FrontendIPConfiguration
        {
            get => FrontendIPConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = FrontendIPConfigurationId };
            set => FrontendIPConfigurationId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource FrontendPort
        {
            get => FrontendPortId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = FrontendPortId };
            set => FrontendPortId = value?.Id;
        }

        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource SslCertificate
        {
            get => SslCertificateId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SslCertificateId };
            set => SslCertificateId = value?.Id;
        }
    }
}
