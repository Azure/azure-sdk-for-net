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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components.YarnApplications;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation;

    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class YarnComponent : ClusterComponent
    {
        /// <summary>
        /// Gets or sets the resource manager role.
        /// </summary>
        /// <value>
        /// The resource manager role.
        /// </value>
        [DataMember]
        [Required, ValidateObject, ValidateRoleExistsInCluster]
        public ClusterRole ResourceManagerRole { get; set; }

        /// <summary>
        /// Gets or sets the node manager role.
        /// </summary>
        /// <value>
        /// The node manager role.
        /// </value>
        [DataMember]
        [Required, ValidateObject, ValidateRoleExistsInCluster]   
        public ClusterRole NodeManagerRole { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList Configuration { get; set; }

        /// <summary>
        /// Gets or sets the capacity scheduler configuration.
        /// </summary>
        /// <value>
        /// The capacity scheduler configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList CapacitySchedulerConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the set of applications that run on yarn.
        /// </summary>
        /// <value>
        /// The applications.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public IList<YarnApplication> Applications { get; set; }

        public YarnComponent()
        {
            this.Configuration = new ConfigurationPropertyList();
            this.Applications = new List<YarnApplication>();
            this.CapacitySchedulerConfiguration = new ConfigurationPropertyList();
        }
    }
  
}
