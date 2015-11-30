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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the gateway components.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace, IsReference = true)]
    internal class GatewayComponent : ClusterComponent
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        [Required]
        [DataMember]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Rest authentication credential.
        /// </summary>
        /// <value>
        /// The authentication credential.
        /// </value>
        [DataMember]
        public UsernamePasswordCredential RestAuthCredential { get; set; }

        /// <summary>
        /// Gets or sets the rest URI.
        /// </summary>
        /// <value>
        /// The rest URI.
        /// </value>
        [DataMember]
        public string RestUri { get; set; }

        public GatewayComponent()
        {
            this.RestAuthCredential = new UsernamePasswordCredential();
        }
    }
}
