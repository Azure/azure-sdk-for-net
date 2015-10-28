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
    /// Base class of an OAuth linked service.
    /// </summary>
    public abstract class OAuthLinkedServiceBase : LinkedServiceTypeProperties
    {
        /// <summary>
        /// OAuth authorization that may be used by ADF to access
        /// resources on your behalf. Each authorization is unique and may
        /// only be used once.
        /// </summary>
        [AdfRequired]
        public string Authorization { get; set; }

        /// <summary>
        /// OAuth session ID from the OAuth authorization session.
        /// Each session ID is unique and may only be used once.
        /// </summary>
        [AdfRequired]
        public string SessionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthLinkedServiceBase"/> class.
        /// </summary>
        protected OAuthLinkedServiceBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthLinkedServiceBase"/>
        /// class with required arguments.
        /// </summary>
        protected OAuthLinkedServiceBase(string authorization, string sessionId)
            : this()
        {
            Ensure.IsNotNullOrEmpty(authorization, "authorization");
            Ensure.IsNotNullOrEmpty(sessionId, "sessionId");

            this.Authorization = authorization;
            this.SessionId = sessionId;
        }
    }
}