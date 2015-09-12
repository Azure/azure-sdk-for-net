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
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation;

    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class HdfsComponent : ClusterComponent
    {
        /// <summary>
        /// Gets or sets the head node role.
        /// </summary>
        /// <value>
        /// The head node role.
        /// </value>
        [DataMember]
        [Required, ValidateObject, ValidateRoleExistsInCluster]
        public ClusterRole HeadNodeRole { get; set; }

        /// <summary>
        /// Gets or sets the worker node role.
        /// </summary>
        /// <value>
        /// The worker node role.
        /// </value>
        [DataMember]
        [Required, ValidateObject, ValidateRoleExistsInCluster]
        public ClusterRole WorkerNodeRole { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required, ValidateObject, ValidateRoleExistsInCluster]
        public ConfigurationPropertyList HdfsSiteXmlProperties { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HdfsComponent"/> class.
        /// </summary>
        public HdfsComponent()
        {
            this.HdfsSiteXmlProperties = new ConfigurationPropertyList();
        }
    }
}
