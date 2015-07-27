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

namespace Microsoft.Azure.Management.DataFactories.Registration.Models
{
    /// <summary>
    /// Parameters specifying how to return a list of ActivityType definitions
    /// for a List operation.
    /// </summary>
    public class ActivityTypeListParameters
    {
        /// <summary>
        /// Optional. The name of the ActivityType to list.
        /// </summary>
        public string ActivityTypeName { get; set; }
        
        /// <summary>
        /// Optional. The scope for which to list the ActivityType definitions.
        /// </summary>
        public string RegistrationScope { get; set; }

        /// <summary>
        /// Optional. If true, gets the properties of any base types each
        /// ActivityType inherits from.
        /// </summary>
        public bool Resolved { get; set; }

        /// <summary>
        /// Initializes a new instance of the ActivityTypeListParameters class.
        /// </summary>
        public ActivityTypeListParameters()
        {
        }

        internal ActivityTypeListParameters(Core.Registration.Models.ActivityTypeListParameters internalParameters)
            : this()
        {
            Ensure.IsNotNull(internalParameters, "internalParameters");

            this.RegistrationScope = internalParameters.RegistrationScope;
            this.ActivityTypeName = internalParameters.ActivityTypeName;
            this.Resolved = internalParameters.Resolved;
        }
    }
}
