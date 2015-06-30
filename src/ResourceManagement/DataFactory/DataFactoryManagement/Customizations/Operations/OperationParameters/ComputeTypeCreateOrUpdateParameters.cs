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
    /// Parameters specifying the ComputeType definition for a create or update
    /// operation.
    /// </summary>
    public class ComputeTypeCreateOrUpdateParameters
    {
        /// <summary>
        /// Required. The definition of a ComputeType to be created or updated.
        /// </summary>
        public ComputeType ComputeType { get; set; }

        /// <summary>
        /// Initializes a new instance of the
        /// ComputeTypeCreateOrUpdateParameters class.
        /// </summary>
        public ComputeTypeCreateOrUpdateParameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ComputeTypeCreateOrUpdateParameters class with required
        /// arguments.
        /// </summary>
        public ComputeTypeCreateOrUpdateParameters(ComputeType computeType)
            : this()
        {
            Ensure.IsNotNull(computeType, "computeType");
            this.ComputeType = computeType;
        }
    }
}
