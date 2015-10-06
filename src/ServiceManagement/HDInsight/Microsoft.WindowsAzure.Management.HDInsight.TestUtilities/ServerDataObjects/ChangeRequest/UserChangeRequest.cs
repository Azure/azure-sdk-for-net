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

namespace Microsoft.HDInsight.Management.Contracts
{
    using System.Runtime.Serialization;
    using Microsoft.HDInsight.Management.Contracts.May2013;

    /// <summary>
    /// Base class for Http or RDP connectivity change requests
    /// </summary>
    [DataContract(Namespace = Constants.XsdNamespace)]
    [KnownType(typeof(HttpUserChangeRequest))]
    [KnownType(typeof(RdpUserChangeRequest))]
    public abstract class UserChangeRequest
    {
        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 1)]
        public UserChangeOperationType Operation { get; set; }

        [DataMember(EmitDefaultValue = true, Order = 2)]
        public string Username { get; set; }

        [DataMember(EmitDefaultValue = true, Order = 3)]
        public string Password { get; set; }
    }
}
