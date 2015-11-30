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
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents a cluster on the server.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class Cluster : ClusterBase
    {
        /// <summary>
        /// Gets or sets the name of the fully qualified DNS name of the cluster.
        /// </summary>
        /// <value>
        /// The name of the fully qualified DNS.
        /// </value>
        [DataMember]
        public string FullyQualifiedDnsName { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        /// <value>
        /// The created time.
        /// </value>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the updated time.
        /// </summary>
        /// <value>
        /// The updated time.
        /// </value>
        [DataMember]
        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [DataMember]
        public ClusterState State { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        public ErrorDetails Error { get; set; }

        /// <summary>
        /// List of cluster capabilities to allow.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public List<string> ClusterCapabilities { get; set; }
    }
}
