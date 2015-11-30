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
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;


    /// <summary>
    /// Component that describes HBase.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class HBaseComponent : ClusterComponent
    {
        /// <summary>
        /// Gets or sets the region server role.
        /// </summary>
        /// <value>
        /// The region server role.
        /// </value>
        [DataMember]
        [ValidateObject, Required, ValidateRoleExistsInCluster]
        public ClusterRole RegionServerRole { get; set; }
      
        /// <summary>
        /// Gets or sets the master server role.
        /// </summary>
        /// <value>
        /// The master server role.
        /// </value>
        [DataMember]
        [ValidateObject, Required, ValidateRoleExistsInCluster]
        public ClusterRole MasterServerRole { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList HBaseConfXmlProperties { get; set; }

        /// <summary>
        /// Gets or sets the additional libraries container.
        /// </summary>
        /// <value>
        /// The additional libraries container.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public BlobContainerCredentialBackedResource AdditionalLibraries { get; set; }

        public HBaseComponent()
        {
            this.HBaseConfXmlProperties = new ConfigurationPropertyList();
        }
    }
}
