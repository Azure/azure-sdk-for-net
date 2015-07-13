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
    /// Parameters specifying how to return a ComputeType definition for a Get
    /// operation.
    /// </summary>
    public class ComputeTypeGetParameters
    {
        /// <summary>
        /// Required. A ComputeType name.
        /// </summary>
        public string ComputeTypeName { get; set; }

        /// <summary>
        /// Required. The scope for which to get a ComputeType definition.
        /// </summary>
        public string RegistrationScope { get; set; }

        /// <summary>
        /// Initializes a new instance of the ComputeTypeGetParameters class.
        /// </summary>
        public ComputeTypeGetParameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ComputeTypeGetParameters class
        /// with required arguments.
        /// </summary>
        public ComputeTypeGetParameters(string registrationScope, string computeTypeName)
            : this()
        {
            Ensure.IsNotNullOrEmpty(registrationScope, "registrationScope");
            Ensure.IsNotNullOrEmpty(computeTypeName, "computeTypeName");

            this.RegistrationScope = registrationScope;
            this.ComputeTypeName = computeTypeName;
        }

        internal ComputeTypeGetParameters(Core.Registration.Models.ComputeTypeGetParameters internalParameters) : this()
        {
            Ensure.IsNotNull(internalParameters, "internalParameters");
            Ensure.IsNotNullOrEmpty(internalParameters.RegistrationScope, "internalParameters.RegistrationScope");
            Ensure.IsNotNullOrEmpty(internalParameters.ComputeTypeName, "internalParameters.ComputeTypeName");

            this.RegistrationScope = internalParameters.RegistrationScope;
            this.ComputeTypeName = internalParameters.ComputeTypeName;
        }
    }
}
