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
    /// Linked Service for Salesforce connector.
    /// Salesforce is a cloud-based customer relationship management (CRM) system.
    /// </summary>
    [AdfTypeName("Salesforce")]
    public class SalesforceLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The username of the Salesforce source.
        /// </summary>
        [AdfRequired]
        public string Username { get; set; }

        /// <summary>
        /// Required. The password of the Salesforce source.
        /// </summary>
        [AdfRequired]
        public string Password { get; set; }

        /// <summary>
        /// Required. The security token is required to remotely access the Salesforce source.
        /// Reference: https://developer.salesforce.com/docs/atlas.en-us.api.meta/api/sforce_api_concepts_security.htm
        /// </summary>
        [AdfRequired]
        public string SecurityToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceLinkedService" /> class.
        /// </summary>
        public SalesforceLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceLinkedService" />
        /// class with required arguments.
        /// </summary>
        public SalesforceLinkedService(
            string username,
            string password,
            string securityToken)
            : this()
        {
            Ensure.IsNotNullOrEmpty(username, "username");
            Ensure.IsNotNullOrEmpty(password, "password");
            Ensure.IsNotNullOrEmpty(securityToken, "securityToken");

            this.Username = username;
            this.Password = password;
            this.SecurityToken = securityToken;
        }
    }
}
