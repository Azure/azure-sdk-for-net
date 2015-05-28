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
    /// Data factory linkedService properties.
    /// </summary>
    public class LinkedServiceProperties : AdfResourceProperties<LinkedServiceTypeProperties, GenericLinkedService>
    {
        /// <summary>
        /// Optional. Data factory linkedService description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional. Error in processing linkedService request.
        /// </summary>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// Optional. The name of the Hub that this linked service belongs to.
        /// </summary>
        public string HubName { get; set; }

        /// <summary>
        /// Optional. The provisioning state of the linked service.
        /// </summary>
        public string ProvisioningState { get; internal set; }

        public LinkedServiceProperties(LinkedServiceTypeProperties typeProperties)
            : base(typeProperties)
        {
        }

        public LinkedServiceProperties(GenericLinkedService typeProperties, string typeName)
            : base(typeProperties, typeName)
        {
        }

        internal LinkedServiceProperties(LinkedServiceTypeProperties typeProperties, string typeName = null)
            : base(typeProperties, typeName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LinkedServiceProperties with ProvisioningState and ErrorMessage
        /// for testing purposes.
        /// </summary>
        /// <param name="typeProperties">The type-specific properties for a LinkedService.</param>
        /// <param name="provisioningState">The provisioning state.</param>
        /// <param name="errorMessage">The error message when provisioning failed.</param>
        internal LinkedServiceProperties(
            LinkedServiceTypeProperties typeProperties,
            string provisioningState,
            string errorMessage)
            : this(typeProperties)
        {
            this.ProvisioningState = provisioningState;
            this.ErrorMessage = errorMessage;
        }
    }
}
