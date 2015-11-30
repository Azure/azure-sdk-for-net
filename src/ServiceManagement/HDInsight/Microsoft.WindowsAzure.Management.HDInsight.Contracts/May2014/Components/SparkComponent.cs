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

    /// <summary>
    /// Component represents Spark
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class SparkComponent : ClusterComponent
    {
        /// <summary>
        /// Gets or sets the master role.
        /// </summary>
        /// <value>
        /// The master role.
        /// </value>
        [DataMember]
        [ValidateObject, Required, ValidateRoleExistsInCluster]
        public ClusterRole MasterRole { get; set; }

        /// <summary>
        /// Gets or sets the worker role.
        /// </summary>
        /// <value>
        /// The worker role.
        /// </value>
        [DataMember]
        [ValidateObject, Required, ValidateRoleExistsInCluster]
        public ClusterRole WorkerRole { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public ConfigurationPropertyList SparkConfiguration { get; set; }

        public SparkComponent()
        {
            SparkConfiguration = new ConfigurationPropertyList();
        }
    }
}
