// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.IoTOperations.Models
{
    public partial class BrokerAuthenticatorMethodCustom
    {
        /// <summary> Kubernetes secret containing an X.509 client certificate. This is a reference to the secret through an identifying name, not the secret itself. </summary>
        public string X509SecretRef
        {
            get => Auth is null ? default : Auth.X509SecretRef;
            set => Auth = new BrokerAuthenticatorCustomAuth(new X509ManualCertificate(value));
        }
    }
}
