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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Networking;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation;

    /// <summary>
    /// This is the main class that describes a cluster.
    /// This shares the data that is common to cluster create and get cluster calls.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    [KnownType(typeof(Cluster))]
    [KnownType(typeof(ClusterCreateParameters))]
    internal class ClusterBase : RestDataContract
    {
        /// <summary>
        /// Gets or sets Dns Name prefix of the cluster.
        /// </summary>
        /// <value>
        /// The dns name.
        /// </value>
        [DataMember]
        [Required]
        public string DnsName { get; set; }

        /// <summary>
        /// Gets or sets the version of the cluster.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public string Version { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [Required]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the HDInsight deployment ID for the cluster.
        /// </summary>
        /// <value>
        /// The deployment ID.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public string DeploymentId { get; set; }

        /// <summary>
        /// Gets or sets the roles associated with this cluster.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        [DataMember(EmitDefaultValue = false, Order = 0)]
        [Required, ValidateObject]
        public ClusterRoleCollection ClusterRoleCollection { get; set; }

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>
        /// The components.
        /// </value>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        [Required, ValidateObject]
        public ComponentSet Components { get; set; }

        /// <summary>
        /// Gets or sets the virtual network configuration.
        /// </summary>
        /// <value>
        /// The virtual network configuration.
        /// </value>
        [DataMember(EmitDefaultValue = false), ValidateObject]
        public VirtualNetworkConfiguration VirtualNetworkConfiguration { get; set; }

        public ClusterBase()
        {
            this.Components = new ComponentSet();
            ClusterRoleCollection = new ClusterRoleCollection();
        }
    }
}
