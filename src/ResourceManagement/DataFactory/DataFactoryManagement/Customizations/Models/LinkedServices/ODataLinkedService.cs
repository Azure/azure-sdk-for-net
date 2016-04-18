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
    /// Open Data Protocol (OData) linked service.
    /// </summary>
    [AdfTypeName("OData")]
    public class ODataLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. Service root URL of the OData service.
        /// </summary>
        [AdfRequired]
        public string Url { get; set; }

        /// <summary>
        /// Required. Type of authentication used to connect to the OData service. Must be one of <see cref="ODataAuthenticationType"/>. 
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Optional. User name of the OData service.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. Password of the OData service.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ODataLinkedService"/> class.
        /// </summary>
        public ODataLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ODataLinkedService"/> class with
        /// required arguments.
        /// </summary>
        public ODataLinkedService(string url, string authenticationType)
            : this()
        {
            Ensure.IsNotNullOrEmpty(url, "Uri");
            Ensure.IsNotNullOrEmpty(authenticationType, "AuthenticationType");

            this.Url = url;
            this.AuthenticationType = authenticationType;
        }
    }
}