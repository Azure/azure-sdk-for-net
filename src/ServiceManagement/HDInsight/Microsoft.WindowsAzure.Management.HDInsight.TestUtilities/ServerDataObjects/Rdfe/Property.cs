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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ServerDataObjects.Rdfe
{
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming",
        "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Property", Justification = "Needed to preserve RDFE contract.")]
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class Property
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public string Value { get; set; }
    }
}
