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
    /// A component that describes the dashboard.
    /// </summary>
    [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/Microsoft.HDInsight.Management.Contracts.May2014.Components")]
    internal class DashboardComponent : ClusterComponent
    {
        /// <summary>
        /// Gets or sets the authentication credential.
        /// </summary>
        /// <value>
        /// The authentication credential.
        /// </value>
        [DataMember]
        [Required, ValidateObject]
        public UsernamePasswordCredential AuthenticationCredential { get; set; }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        [DataMember]
        public string Uri { get; set; }
    }
}
