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
    using System.Runtime.Serialization;

    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal enum VmSize 
    {
        /// <summary>
        /// An extra small virtual machine, shared core.
        /// </summary>
        [EnumMember]
        ExtraSmall = 0,

        /// <summary>
        /// A small virtual machine, 1 core.
        /// </summary>
        [EnumMember]
        Small = 1,

        /// <summary>
        /// Medium virtual machine, 2 cores.
        /// </summary>
        [EnumMember]
        Medium = 2,

        /// <summary>
        /// Large virtual machine, 4 cores.
        /// </summary>
        [EnumMember]
        Large = 4,

        /// <summary>
        /// Extra large virtual machine, 8 cores.
        /// </summary>
        [EnumMember]
        ExtraLarge = 8,

        /// <summary>
        /// A5 Virtual Machine, 2 Cores and 14GB of RAM.
        /// </summary>
        [EnumMember]
        A5 = 9,

        /// <summary>
        /// A6 Virtual Machine, 4 cores and 28GB of RAM.
        /// </summary>
        [EnumMember]
        A6 = 10,

        /// <summary>
        /// A7 Virtual Machine, 8 cores and 56GB of RAM.
        /// </summary>
        [EnumMember]
        A7 = 11,

        /// <summary>
        /// A8 Virutal Machine, 8 cores and 56GB of RAM.
        /// </summary>
        [EnumMember]
        A8 = 12,

        /// <summary>
        /// A9 Virtual Machine, 16 cores and 112GB of RAM.
        /// </summary>
        [EnumMember]
        A9 = 13,
    }
}