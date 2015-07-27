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
    using System;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014;

    /// <summary>
    /// Size of a VM on Windows Azure.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design",
        "CA1027:MarkEnumsWithFlags", Justification = "Doesn't make sense to do that for this type")]
    public enum NodeVMSize
    {
        /// <summary>
        /// The default VM size, it is one of the values below.
        /// </summary>
        Default = 0,
        
        /// <summary>
        /// Extra large virtual machine, 8 cores.
        /// </summary>
        ExtraLarge = 8,

        /// <summary>
        /// Large virtual machine, 4 cores.
        /// </summary>
        Large = 4,
    }

    /// <summary>
    /// An extension class to easily convert from <see cref="NodeVMSize"/> to 
    /// <see cref="NodeVMSizeInternal"/>.
    /// </summary>
    internal static class NodeVMSizeExtensions
    {
        /// <summary>
        /// Converts the user facing Node size enum to internal node size enum.
        /// </summary>
        /// <param name="nodeVmSize">Size of the node vm.</param>
        /// <returns>The corresponding <see cref="NodeVMSizeInternal"/>.</returns>
        /// <exception cref="System.InvalidProgramException">Execution should never reach here.</exception>
        public static NodeVMSizeInternal ToNodeVMSize(this NodeVMSize nodeVmSize)
        {
            switch (nodeVmSize)
            {
                case NodeVMSize.ExtraLarge:
                    return NodeVMSizeInternal.ExtraLarge;
                case NodeVMSize.Large:
                    return NodeVMSizeInternal.Large;
                case NodeVMSize.Default:
                    return NodeVMSizeInternal.ExtraLarge;
                default:
                    throw new InvalidProgramException("Execution should never reach here!");
            }
        }

        /// <summary>
        /// Extension method to covert NodeVMSize to VMSize.
        /// </summary>
        /// <param name="nodeVMSize">Size of the vm.</param>
        /// <returns>The corresponding VMSize.</returns>
        /// <exception cref="System.ArgumentException">Unknown vmSize.</exception>
        public static VmSize ToVmSize(this NodeVMSize nodeVMSize)
        {
            switch (nodeVMSize)
            {
                case NodeVMSize.Default:
                case NodeVMSize.Large:
                    return VmSize.Large;
                case NodeVMSize.ExtraLarge:
                    return VmSize.ExtraLarge;
                default:
                    throw new InvalidProgramException("Execution should never reach here!");
            }
        }

    }
}