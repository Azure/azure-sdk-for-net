// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.SignClient
{
    using Newtonsoft.Json;
    public partial class SignClientCertAuthConfig : EsrpServiceModelBase<SignClientCertAuthConfig>
    {
        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("AuthenticationType")]
        public string AuthenticationType { get; set; }

        [JsonProperty("ClientId")]
        public string ClientId { get; set; }

        [JsonProperty("AuthCert")]
        public Cert AuthCert { get; set; }

        [JsonProperty("RequestSigningCert")]
        public Cert RequestSigningCert { get; set; }

        public SignClientCertAuthConfig()
        {
            Version = "1.0.0";
            AuthenticationType = "AAD_CERT";
            ClientId = "";

            AuthCert = new Cert();
        }
    }

    public partial class Cert
    {
        [JsonProperty("SubjectName")]
        public string SubjectName { get; set; }

        [JsonProperty("StoreLocation")]
        public string StoreLocation { get; set; }

        [JsonProperty("StoreName")]
        public string StoreName { get; set; }

        public Cert()
        {

        }

    }
}
