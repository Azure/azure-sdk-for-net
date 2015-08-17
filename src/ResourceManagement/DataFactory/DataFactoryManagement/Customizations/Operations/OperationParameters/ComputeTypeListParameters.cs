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
    /// Parameters specifying how to return a list of ComputeType definitions
    /// for a List operation.Specifying both a name and scope will return a
    /// list with one ComputeType (if one exists).
    /// </summary>
    public class ComputeTypeListParameters
    {
        /// <summary>
        /// Optional. The name of the ComputeType to list.
        /// </summary>
        public string ComputeTypeName { get; set; }
        
        /// <summary>
        /// Required. The scope for which to list the ComputeType definitions.
        /// </summary>
        public string RegistrationScope { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the ComputeTypeListParameters class.
        /// </summary>
        public ComputeTypeListParameters()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the ComputeTypeListParameters class
        /// with required arguments.
        /// </summary>
        public ComputeTypeListParameters(string registrationScope)
            : this()
        {
            Ensure.IsNotNullOrEmpty(registrationScope, "registrationScope");

            this.RegistrationScope = registrationScope;
        }

        internal ComputeTypeListParameters(Core.Registration.Models.ComputeTypeListParameters internalParameters)
            : this()
        {
            Ensure.IsNotNull(internalParameters, "internalParameters");
            Ensure.IsNotNullOrEmpty(internalParameters.RegistrationScope, "internalParameters.RegistrationScope");

            this.RegistrationScope = internalParameters.RegistrationScope;
            this.ComputeTypeName = internalParameters.ComputeTypeName;
        }
    }
}
