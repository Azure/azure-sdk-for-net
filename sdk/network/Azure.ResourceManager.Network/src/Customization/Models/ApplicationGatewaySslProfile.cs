// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewaySslProfile
    {
        // This was already a handwritten flattened facade in 1.15, not a generated leaf.
        // Restore its null-safe forwarding and lazy parent creation so assignments reach
        // clientAuthConfiguration.verifyClientCertIssuerDN instead of independent storage.
        // Hide the convenience facade without deprecating its still-supported wire field.
        /// <summary> Enables verification of the client certificate issuer distinguished name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? VerifyClientCertIssuerDN
        {
            get => ClientAuthConfiguration is null ? default : ClientAuthConfiguration.VerifyClientCertIssuerDN;
            set
            {
                if (ClientAuthConfiguration is null)
                {
                    ClientAuthConfiguration = new ApplicationGatewayClientAuthConfiguration();
                }
                ClientAuthConfiguration.VerifyClientCertIssuerDN = value;
            }
        }
    }
}
