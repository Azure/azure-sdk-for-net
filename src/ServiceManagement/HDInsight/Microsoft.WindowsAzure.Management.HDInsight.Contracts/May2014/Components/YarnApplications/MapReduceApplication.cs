// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.YarnApplications
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation;

    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class MapReduceApplication : YarnApplication
    {
        /// <summary>
        /// Gets or sets the default storage container.
        /// </summary>
        /// <value>
        /// The default storage container.
        /// </value>
        [DataMember]
        [Required, ValidateObject]
        public BlobContainerCredentialBackedResource DefaultStorageAccountAndContainer { get; set; }

        /// <summary>
        /// Gets or sets the additional storage containers.
        /// </summary>
        /// <value>
        /// The additional storage containers.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public BlobContainerResourceSet AdditionalStorageContainers { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList MapRedSiteXmlProperties { get; set; }

        /// <summary>
        /// Gets or sets the capacity scheduler configuration.
        /// </summary>
        /// <value>
        /// The capacity scheduler configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList CapacitySchedulerConfiguration { get; set; }
 
        public MapReduceApplication()
        {
            this.MapRedSiteXmlProperties = new ConfigurationPropertyList();
            this.CapacitySchedulerConfiguration = new ConfigurationPropertyList();
            this.AdditionalStorageContainers = new BlobContainerResourceSet();
        }
    }
}
