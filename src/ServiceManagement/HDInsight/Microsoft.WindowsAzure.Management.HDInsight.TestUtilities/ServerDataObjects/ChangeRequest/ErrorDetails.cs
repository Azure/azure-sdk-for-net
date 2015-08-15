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
    using System.Net;
    using System.Runtime.Serialization;
    using Microsoft.HDInsight.Management.Contracts.May2013;

    /// <summary>
    /// Class to represent an error that has been returned in response to a passthrough request.
    /// </summary>
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ErrorDetails
    {
        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 1)]
        public HttpStatusCode StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 2)]
        public string ErrorId { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 3)]
        public string ErrorMessage { get; set; }
    }
}