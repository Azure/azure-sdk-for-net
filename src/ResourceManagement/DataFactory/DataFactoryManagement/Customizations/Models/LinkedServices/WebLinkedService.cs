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

using System;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Linked Service for web page table data source.
    /// </summary>
    [AdfTypeName("Web")]
    public class WebLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. Type of authentication used to connect to the web table source. Possible values are: Anonymous and Basic.
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Required. The URL of the web service endpoint, e.g. "http://www.microsoft.com/".
        /// </summary>
        [AdfRequired]
        public string Url { get; set; }

        /// <summary>
        /// Optional. Username for Basic authentication.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. Password for Basic authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Obsolete. WebApi-based authentication has been deprecated.
        /// </summary>
        [Obsolete]
        public string ApiKey { get; set; }

        public WebLinkedService()
        {
        }

        public WebLinkedService(
            string url,
            string authenticationType)
            : this()
        {
            Ensure.IsNotNullOrEmpty(url, "url");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");

            this.Url = url;
            this.AuthenticationType = authenticationType;
        }
    }
}
