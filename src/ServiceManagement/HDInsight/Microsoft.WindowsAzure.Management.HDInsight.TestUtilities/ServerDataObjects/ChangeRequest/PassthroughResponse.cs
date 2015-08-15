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
    /// Class that represents a response to a passthrough request.
    /// </summary>
    // TODO: Re-enable all of the KnownTypes that are here for job submission, once jobDetails submission is enabled
    //       All of these types need to move into this project and need to be updated to specify ordering, etc, as needed for RDFE
    //[KnownType(typeof(List<string>))]
    //[KnownType(typeof(JobDetails))]
    //[KnownType(typeof(DatabaseDetails))]
    //[KnownType(typeof(TableDetails))]
    //[KnownType(typeof(ColumnDetails))]
    [KnownType(typeof(UserChangeOperationStatusResponse))]
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class PassthroughResponse
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false, Order = 1)]
        public object Data { get; set; }

        [DataMember(EmitDefaultValue = true, IsRequired = false, Order = 2)]
        public ErrorDetails Error { get; set; }
    }
}