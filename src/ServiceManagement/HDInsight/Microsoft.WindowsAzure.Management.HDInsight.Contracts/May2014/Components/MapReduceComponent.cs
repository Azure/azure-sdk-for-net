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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation;

    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class MapReduceComponent : ClusterComponent
    {
        /// <summary>
        /// Gets or sets the role on which the job tracker and the namenode will run.
        /// </summary>
        /// <value>
        /// The head node role.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required]
        public ClusterRole HeadNodeRole { get; set; }

        /// <summary>
        /// Gets or sets the role on which the tasktracker and the datanode will run.
        /// </summary>
        /// <value>
        /// The worker node role.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required]
        public ClusterRole WorkerNodeRole { get; set; }

        /// <summary>
        /// Gets or sets the default storage account used for map reduce.
        /// </summary>
        /// <value>
        /// The default storage account.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required]
        public BlobContainerCredentialBackedResource DefaultStorageAccountAndContainer { get; set; }

        /// <summary>
        /// Gets or sets the additional storage accounts.
        /// </summary>
        /// <value>
        /// The additional storage accounts.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public BlobContainerResourceSet AdditionalStorageAccounts { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList MapRedConfXmlProperties { get; set; }

        /// <summary>
        /// Gets or sets the capacity scheduler configuration.
        /// </summary>
        /// <value>
        /// The capacity scheduler configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList CapacitySchedulerConfXmlProperties { get; set; }

        public MapReduceComponent()
        {
            this.MapRedConfXmlProperties = new ConfigurationPropertyList();
            this.CapacitySchedulerConfXmlProperties = new ConfigurationPropertyList();
            this.AdditionalStorageAccounts = new BlobContainerResourceSet();
            this.DefaultStorageAccountAndContainer = new BlobContainerCredentialBackedResource();
        }
    }
}