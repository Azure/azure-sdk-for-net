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
    using System;
    using System.Runtime.Serialization;
    using Microsoft.HDInsight.Management.Contracts.May2013;

    [DataContract(Namespace = Constants.XsdNamespace)]
    public class UserChangeOperationStatusResponse
    {
        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 1)]
        public UserChangeOperationState State { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 2)]
        public UserType UserType { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 3)]
        public UserChangeOperationType OperationType { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = true, Order = 4)]
        public DateTime RequestIssueDate { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = false, Order = 5)]
        public ErrorDetails Error { get; set; }
    }
}
