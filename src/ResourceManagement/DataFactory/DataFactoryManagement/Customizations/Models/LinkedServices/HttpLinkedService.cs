//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Linked service for an HTTP endpoint.
    /// </summary>
    [AdfTypeName("Http")]
    public class HttpLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The base URL of the HTTP endpoint, e.g. http://www.microsoft.com.
        /// </summary>
        [AdfRequired]
        public string Url { get; set; }

        /// <summary>
        /// Required. The authentication type to be used to connect to the HTTP server.
        /// Must be one of <see cref="HttpAuthenticationType"/>.
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Optional. User name for Basic, Digest, or Windows authentication.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. Password for Basic, Digest, Windows, or ClientCertificate with EmbeddedCertData authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional. Base64 encoded certificate data for ClientCertificate authentication. 
        /// For on-premises copy with ClientCertificate authentication, either CertThumbprint or EmbeddedCertData/Password should be specified.
        /// 
        /// </summary>
        public string EmbeddedCertData { get; set; }

        /// <summary>
        /// Optional. Thumbprint of certificate for ClientCertificate authentication. Only valid for on-premises copy.
        /// For on-premises copy with ClientCertificate authentication, either CertThumbprint or EmbeddedCertData/Password should be specified.
        /// 
        /// </summary>
        public string CertThumbprint { get; set; }

        /// <summary>
        /// Optional. The on-premises gateway name.
        /// </summary>
        public string GatewayName { get; set; }

        /// <summary>
        /// Optional. The encrypted credential for Basic, Digest, Windows or ClientCertificate authentication, only valid for on-premises copy.
        /// For on-premises copy with non-Anonymous authentication, either Username/Password, ClientThumbprint, EmbeddedCertData/Password or EncryptedCredential should be specified.
        /// </summary>
        public string EncryptedCredential { get; set; }

        /// <summary>
        /// Optional. If true, validate the HTTP server SSL certificate when connect over SSL/TLS channel.
        /// Default value is true.
        /// It is not recommended to set this property to false to skip the validation.
        /// </summary>
        public bool? EnableServerCertificateValidation { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="HttpLinkedService"/> class.
        /// </summary>
        public HttpLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpLinkedService"/> class with required arguments.
        /// </summary>
        public HttpLinkedService(string url, string authenticationType)
            : this()
        {
            Ensure.IsNotNullOrEmpty(url, "url");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");
            this.Url = url;
            this.AuthenticationType = authenticationType;
        }
    }
}
