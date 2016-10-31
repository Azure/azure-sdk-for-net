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
    /// Linked service for Amazon Redshift connector.
    /// Amazon Redshift is a fully managed, petabyte-scale data warehouse service for the Amazon Web Services cloud platform.
    /// </summary>
    [AdfTypeName("AmazonRedshift")]
    public class AmazonRedshiftLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The name of the Amazon Redshift server.
        /// </summary>
        [AdfRequired]
        public string Server { get; set; }

        /// <summary>
        /// Required. The username of the Amazon Redshift server.
        /// </summary>
        [AdfRequired]
        public string Username { get; set; }

        /// <summary>
        /// Required. The password of the Amazon Redshift server.
        /// </summary>
        [AdfRequired]
        public string Password { get; set; }

        /// <summary>
        /// Required. The database name of the Amazon Redshift server.
        /// </summary>
        [AdfRequired]
        public string Database { get; set; }

        /// <summary>
        /// Optional. The TCP port number that the Amazon Redshift server uses to listen for client connections. The default value is 5439.
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonRedshiftLinkedService" /> class.
        /// </summary>
        public AmazonRedshiftLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonRedshiftLinkedService" />
        /// class with required arguments.
        /// </summary>
        public AmazonRedshiftLinkedService(
            string server,
            string username,
            string password,
            string database)
            : this()
        {
            Ensure.IsNotNullOrEmpty(server, "server");
            Ensure.IsNotNullOrEmpty(username, "username");
            Ensure.IsNotNullOrEmpty(password, "password");
            Ensure.IsNotNullOrEmpty(database, "database");

            this.Server = server;
            this.Username = username;
            this.Password = password;
            this.Database = database;
        }
    }
}
