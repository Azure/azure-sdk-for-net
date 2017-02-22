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
    /// A FTP server Linked Service.
    /// </summary>
    [AdfTypeName("FtpServer")]
    public class FtpServerLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. Host name of the FTP server.
        /// </summary>
        [AdfRequired]
        public string Host { get; set; }

        /// <summary>
        /// Required. The authentication type to be used to connect to the FTP server. Must be Basic or Anonymous. 
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Optional. The on-premises gateway name.
        /// </summary>
        public string GatewayName { get; set; }

        /// <summary>
        /// Optional. The TCP port number that the FTP server uses to listen for client connections. Default value is 21.
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Optional. Username to logon the FTP server.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. Password to logon the FTP server.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional. The encrypted credential for Basic authentication.
        /// </summary>
        public string EncryptedCredential { get; set; }

        /// <summary>
        /// Optional. If true, connect to the FTP server over SSL/TLS channel.
        /// Default value is true.
        /// It is not recommended to set this property to false.
        /// </summary>
        public bool? EnableSsl { get; set; }

        /// <summary>
        /// Optional. If true, validate the FTP server SSL certificate when connect over SSL/TLS channel.
        /// Default value is true.
        /// It is not recommended to set this property to false to skip the validation.
        /// </summary>
        public bool? EnableServerCertificateValidation { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FtpServerLinkedService"/> class.
        /// </summary>
        public FtpServerLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FtpServerLinkedService"/> class with required arguments.
        /// </summary>
        public FtpServerLinkedService(string host, string authenticationType) : this()
        {
            Ensure.IsNotNullOrEmpty(host, "host");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");
            this.Host = host;
            this.AuthenticationType = authenticationType;
        }
    }
}
