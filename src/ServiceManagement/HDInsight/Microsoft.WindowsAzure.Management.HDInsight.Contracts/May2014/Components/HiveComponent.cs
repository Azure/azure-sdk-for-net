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

    /// <summary>
    /// A component associated with Hive.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class HiveComponent : ClusterComponent
    {
        [DataMember(Order = 0, EmitDefaultValue = false)]
        [Required, ValidateObject, ValidateRoleExistsInCluster]
        public ClusterRole HeadNodeRole { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [DataMember(Order = 1, EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList HiveSiteXmlProperties { get; set; }

        /// <summary>
        /// Gets or sets the additional libraries container.
        /// </summary>
        /// <value>
        /// The additional libraries container.
        /// </value>
        [DataMember(Order = 2, EmitDefaultValue = false)]
        [ValidateObject]
        public BlobContainerCredentialBackedResource AdditionalLibraries { get; set; }

        /// <summary>
        /// Gets or sets the catalog.
        /// </summary>
        /// <value>
        /// The catalog.
        /// </value>
        [DataMember(Order = 3, EmitDefaultValue = false)]
        [Required, ValidateObject]
        public SqlAzureDatabaseResource Metastore { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HiveComponent"/> class.
        /// </summary>
        public HiveComponent()
        {
            this.HiveSiteXmlProperties = new ConfigurationPropertyList();
            this.Metastore = SqlAzureDatabaseResource.ProvisionNew;
        }

    }
   
}
