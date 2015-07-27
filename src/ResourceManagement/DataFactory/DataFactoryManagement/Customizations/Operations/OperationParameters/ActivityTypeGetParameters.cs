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
    /// Parameters specifying how to return an ActivityType definition for a
    /// Get operation.
    /// </summary>
    public class ActivityTypeGetParameters
    {
        /// <summary>
        /// Required. An ActivityType name.
        /// </summary>
        public string ActivityTypeName { get; set; }

        /// <summary>
        /// Required. The scope for which to get an ActivityType definition.
        /// </summary>
        public string RegistrationScope { get; set; }

        /// <summary>
        /// Optional. If true, gets the properties of any base types an
        /// ActivityType inherits from.
        /// </summary>
        public bool Resolved { get; set; }

        /// <summary>
        /// Initializes a new instance of the ActivityTypeGetParameters class.
        /// </summary>
        public ActivityTypeGetParameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ActivityTypeGetParameters class
        /// with required arguments.
        /// </summary>
        public ActivityTypeGetParameters(string registrationScope, string activityTypeName)
            : this()
        {
            Ensure.IsNotNullOrEmpty(registrationScope, "registrationScope");
            Ensure.IsNotNullOrEmpty(activityTypeName, "activityTypeName");

            this.RegistrationScope = registrationScope;
            this.ActivityTypeName = activityTypeName;
        }

        internal ActivityTypeGetParameters(Core.Registration.Models.ActivityTypeGetParameters internalParameters)
            : this()
        {
            Ensure.IsNotNull(internalParameters, "internalParameters");
            Ensure.IsNotNullOrEmpty(internalParameters.RegistrationScope, "internalParameters.RegistrationScope");
            Ensure.IsNotNullOrEmpty(internalParameters.ActivityTypeName, "internalParameters.ActivityTypeName");

            this.RegistrationScope = internalParameters.RegistrationScope;
            this.ActivityTypeName = internalParameters.ActivityTypeName;
            this.Resolved = internalParameters.Resolved;
        }
    }
}
