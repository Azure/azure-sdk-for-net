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
using System.Collections.Generic;
using Microsoft.Azure.Management.DataFactories.Common.Models;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    public class DatasetProperties : AdfResourceProperties<DatasetTypeProperties, GenericDataset>
    {
        /// <summary>
        /// Required. The referenced data linkedService name.
        /// </summary>
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Dataset description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Columns that define the structure of the Dataset.
        /// </summary>
        public IList<DataElement> Structure { get; set; }

        /// <summary>
        /// Required. Scheduler of the Dataset.
        /// </summary>
        public Availability Availability { get; set; }

        /// <summary>
        /// Policy applied to the Dataset.
        /// </summary>
        public Policy Policy { get; set; }

        /// <summary>
        /// Optional. If set to true, the Dataset is an external data set.
        /// </summary>
        public bool? External { get; set; }

        /// <summary>
        /// The time it is created.
        /// </summary>
        public DateTime? CreateTime { get; internal set; }

        /// <summary>
        /// The provisioning state of the Dataset.
        /// </summary>
        public string ProvisioningState { get; internal set; }

        /// <summary>
        /// Error in processing Dataset request.
        /// </summary>
        public string ErrorMessage { get; internal set; }

        public DatasetProperties()
        {
        }

        public DatasetProperties(
            DatasetTypeProperties typeProperties, 
            Availability availability, 
            string linkedServiceName)
            : base(typeProperties)
        {
            this.Availability = availability;
            this.LinkedServiceName = linkedServiceName;
        }

        public DatasetProperties(
            GenericDataset typeProperties,
            Availability availability,
            string linkedServiceName,
            string typeName)
            : base(typeProperties, typeName)
        {
            this.Availability = availability;
            this.LinkedServiceName = linkedServiceName;
        }
        
        internal DatasetProperties(
            DatasetTypeProperties typeProperties,
            Availability availability,
            string linkedServiceName,
            string typeName)
            : base(typeProperties, typeName)
        {
            this.Availability = availability;
            this.LinkedServiceName = linkedServiceName;
        }

        /// <summary>
        /// Initializes a new instance of DatasetProperties with CreateTime, 
        /// ProvisioningState and ErrorMessage for testing purposes.
        /// </summary>
        /// <param name="typeProperties">The type-specific properties for a Dataset.</param>
        /// <param name="availability">Availability details for the Dataset.</param>
        /// <param name="linkedServiceName">Name of the Linked Service where the Dataset's data exists.</param>
        /// <param name="createTime">The time the Dataset was created.</param>
        /// <param name="provisioningState">The provisioning state.</param>
        /// <param name="errorMessage">The error message when provisioning failed.</param>
        internal DatasetProperties(
            DatasetTypeProperties typeProperties,
            Availability availability,
            string linkedServiceName,
            DateTime? createTime,
            bool? external,
            string provisioningState,
            string errorMessage)
            : this(typeProperties, availability, linkedServiceName)
        {
            this.CreateTime = createTime;
            this.ProvisioningState = provisioningState;
            this.ErrorMessage = errorMessage;
            this.External = external;
        }
    }
}
