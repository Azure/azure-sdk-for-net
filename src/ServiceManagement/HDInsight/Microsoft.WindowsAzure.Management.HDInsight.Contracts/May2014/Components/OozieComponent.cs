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
    /// A cluster component that describes Oozie.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class OozieComponent : ClusterComponent
    {
        /// <summary>
        /// Gets or sets the head node role.
        /// </summary>
        /// <value>
        /// The head node role.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required, ValidateObject, ValidateRoleExistsInCluster]
        public ClusterRole HeadNodeRole { get; set; }

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
        /// Gets or sets the additional shared libraries.
        /// </summary>
        /// <value>
        /// The additional shared libraries.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public BlobContainerCredentialBackedResource AdditionalSharedLibraries { get; set; }

        /// <summary>
        /// Gets or sets the additional action executor libraries.
        /// </summary>
        /// <value>
        /// The additional action executor libraries.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public BlobContainerCredentialBackedResource AdditionalActionExecutorLibraries { get; set; }

        /// <summary>
        /// Gets or sets the catalog.
        /// </summary>
        /// <value>
        /// The catalog.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required, ValidateObject]
        public SqlAzureDatabaseResource Metastore { get; set; }

        public OozieComponent()
        {
            this.Configuration = new ConfigurationPropertyList();
            this.Metastore = SqlAzureDatabaseResource.ProvisionNew;
        }
    }
   
}
