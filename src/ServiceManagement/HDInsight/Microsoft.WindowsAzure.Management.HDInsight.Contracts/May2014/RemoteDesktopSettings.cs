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
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation;

    /// <summary>
    /// A class representing remote desktop settings.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace, IsReference = true)]
    internal class RemoteDesktopSettings : RestDataContract
    {
        [DataMember]
        [Required]
        public bool IsEnabled { get; set; }

        [DataMember(EmitDefaultValue = false)]
        [ValidateObject]
        public UsernamePasswordCredential AuthenticationCredential { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime RemoteAccessExpiry { get; set; }

        public RemoteDesktopSettings()
        {
            this.AuthenticationCredential = new UsernamePasswordCredential();
        }
    }
}
