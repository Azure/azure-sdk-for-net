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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Networking
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation;

    /// <summary>
    /// Represents a virtual network configuration.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal class VirtualNetworkConfiguration : RestDataContract
    {
        /// <summary>
        /// Gets or sets the virtual network.
        /// </summary>
        /// <value>
        /// The virtual network.
        /// </value>
        [DataMember]
        [Required]
        public VirtualNetworkResource VirtualNetwork { get; set; }

        /// <summary>
        /// Gets or sets the virtual network site.
        /// </summary>
        /// <value>
        /// The virtual network site.
        /// </value>
        [DataMember]
        [Required]
        public string VirtualNetworkSite { get; set; }

        /// <summary>
        /// Gets or sets the address assignments.
        /// </summary>
        /// <value>
        /// The address assignments.
        /// </value>
        [DataMember, ValidateObject]
        [Required]
        public AddressAssignments AddressAssignments { get; set; }

        public VirtualNetworkConfiguration()
        {
            AddressAssignments = new AddressAssignments();
        }
    }
}
