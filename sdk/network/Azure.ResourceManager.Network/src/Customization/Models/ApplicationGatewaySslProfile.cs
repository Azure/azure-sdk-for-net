// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> SSL profile of an application gateway. </summary>
    public partial class ApplicationGatewaySslProfile : NetworkResourceData
    {
         /// <summary> Verify client certificate issuer name on the application gateway. </summary>
         [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public bool? VerifyClientCertIssuerDN
        {
            get => ClientAuthConfiguration is null ? default : ClientAuthConfiguration.VerifyClientCertIssuerDN;
            set
            {
                if (ClientAuthConfiguration is null)
                    ClientAuthConfiguration = new ApplicationGatewayClientAuthConfiguration();
                ClientAuthConfiguration.VerifyClientCertIssuerDN = value;
            }
        }
    }
}
