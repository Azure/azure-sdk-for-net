// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayHttpListener
    {
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource FrontendIPConfiguration
        {
            get => FrontendIPConfigurationId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = FrontendIPConfigurationId };
            set => FrontendIPConfigurationId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource FrontendPort
        {
            get => FrontendPortId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = FrontendPortId };
            set => FrontendPortId = value?.Id;
        }

        public global::Azure.ResourceManager.Resources.Models.WritableSubResource SslCertificate
        {
            get => SslCertificateId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = SslCertificateId };
            set => SslCertificateId = value?.Id;
        }
    }
}
