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
    /// A linked service for an SSH File Transfer Protocol (SFTP) server. 
    /// </summary>
    [AdfTypeName("Sftp")]
    public class SftpLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The SFTP server host name.
        /// </summary>
        [AdfRequired]
        public string Host { get; set; }

        /// <summary>
        /// Required. The authentication type to be used to connect to the SFTP server. Must be Basic or SshPublicKey. 
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Optional. The username used to log on to the SFTP server. It is required when EncryptedCredential is null.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. The TCP port number that the SFTP server uses to listen for client connections. Default value is 22.
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Optional. Password to logon the SFTP server for Basic authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional. The SSH private key file path for SshPublicKey authentication. Only valid for on-premises copy.
        /// For on-premises copy with SshPublicKey authentication, either PrivateKeyPath or PrivateKeyContent should be specified.
        /// SSH private key should be OpenSSH format.
        /// </summary>
        public string PrivateKeyPath { get; set; }

        /// <summary>
        /// Optional. Base64 encoded SSH private key content for SshPublicKey authentication.
        /// For on-premises copy with SshPublicKey authentication, either PrivateKeyPath or PrivateKeyContent should be specified.
        /// SSH private key should be OpenSSH format.
        /// </summary>
        public string PrivateKeyContent { get; set; }

        /// <summary>
        /// Optional. The password to decrypt the SSH private key if the SSH private key is encrypted.
        /// </summary>
        public string PassPhrase { get; set; }

        /// <summary>
        /// Optional. If true, skip the SSH host key validation. Default value is false.
        /// </summary>
        public bool? SkipHostKeyValidation { get; set; }

        /// <summary>
        /// Optional. The host key finger-print of the SFTP server.
        /// When SkipHostKeyValidation is false, HostKeyFingerprint should be specified.
        /// </summary>
        public string HostKeyFingerprint { get; set; }

        /// <summary>
        /// Optional. The encrypted credential for Basic or SshPublicKey authentication.
        /// </summary>
        public string EncryptedCredential { get; set; }

        /// <summary>
        /// Optional. The on-premises gateway name.
        /// </summary>
        public string GatewayName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SftpLinkedService" /> class.
        /// </summary>
        public SftpLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SftpLinkedService" /> class with required arguments.
        /// </summary>
        public SftpLinkedService(string host, string authenticationType, string username)
        {
            Ensure.IsNotNullOrEmpty(host, "host");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");
            if (string.IsNullOrEmpty(EncryptedCredential))
            {
                Ensure.IsNotNullOrEmpty(username, "username");
            }
            this.Host = host;
            this.AuthenticationType = authenticationType;
            this.Username = username;
        }
    }
}
