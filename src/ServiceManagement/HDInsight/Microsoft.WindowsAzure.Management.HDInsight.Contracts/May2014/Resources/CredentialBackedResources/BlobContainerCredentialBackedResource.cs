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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// A blob container described by credentials.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace, IsReference = true)]
    internal class BlobContainerCredentialBackedResource : BlobContainerResource
    {
        /// <summary>
        /// Gets or sets FQDN of the storage account.
        /// </summary>
        /// <value>
        /// The FQDN of the storage account.
        /// </value>
        [DataMember(EmitDefaultValue = false)]
        [Required]
        public string AccountDnsName { get; set; }

        /// <summary>
        /// Gets or sets the name of the BLOB container.
        /// </summary>
        /// <value>
        /// The name of the BLOB container.
        /// </value>
        [DataMember(Order = 2)]
        public string BlobContainerName { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [DataMember(Order = 3, EmitDefaultValue = false)]
        [Required]
        public string Key { get; set; }
    }
}