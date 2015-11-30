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

using System.Collections.Generic;
using System.Linq;
using CoreRegistrationModel = Microsoft.Azure.Management.DataFactories.Core.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories.Registration.Models
{
    /// <summary>
    /// The List ActivityType operation response.
    /// </summary>
    public class ActivityTypeListResponse : AzureOperationResponse
    {
        /// <summary>
        /// Optional. All the ActivityType definitions for a particular
        /// RegistrationScope.
        /// </summary>
        public IList<ActivityType> ActivityTypes { get; set; }

        /// <summary>
        /// Required. The link (url) to the next page of results.
        /// </summary>
        public string NextLink { get; set; }

        /// <summary>
        /// Initializes a new instance of the ActivityTypeListResponse
        /// class.
        /// </summary>
        public ActivityTypeListResponse()
        {
            this.ActivityTypes = new List<ActivityType>();
        }

        /// <summary>
        /// Initializes a new instance of the ActivityTypeListResponse
        /// class with required arguments.
        /// </summary>
        public ActivityTypeListResponse(string nextLink)
            : this()
        {
            Ensure.IsNotNull(nextLink, "nextLink");
            this.NextLink = nextLink;
        }

        internal ActivityTypeListResponse(
            CoreRegistrationModel.ActivityTypeListResponse internalResponse,
            DataFactoryManagementClient client)
        {
            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.NextLink = internalResponse.NextLink;
            this.ActivityTypes = internalResponse.ActivityTypes.Select(
                    internalActivityType => ((ActivityTypeOperations)client.ActivityTypes).Converter.ToWrapperType(internalActivityType))
                    .ToList();
        }
    }
}
