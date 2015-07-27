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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    internal enum NodeVMSizeInternal
    {
        /// <summary>
        /// An extra small virtual machine, shared core.
        /// </summary>
        ExtraSmall = 1,

        /// <summary>
        /// A small virtual machine, 1 core.
        /// </summary>
        Small = 1,

        /// <summary>
        /// Medium virtual machine, 2 cores.
        /// </summary>
        Medium = 2,

        /// <summary>
        /// Large virtual machine, 4 cores.
        /// </summary>
        Large = 4,

        /// <summary>
        /// Extra large virtual machine, 8 cores.
        /// </summary>
        ExtraLarge = 8
    }
}