//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    /// <summary>
    /// The possible node sizes for a virtual machine 
    /// </summary>
    public enum NodeVMSize
    {
        /// <summary>
        /// An extra small virtual machine, shared core
        /// </summary>
        ExtraSmall = 1,

        /// <summary>
        /// A small virtual machine, 1 core
        /// </summary>
        Small = 1,

        /// <summary>
        /// Medium virtual machine, 2 cores
        /// </summary>
        Medium = 2,

        /// <summary>
        /// Large virtual machine, 4 cores
        /// </summary>
        Large = 4,

        /// <summary>
        /// Extra large virtual machine, 8 cores
        /// </summary>
        ExtraLarge = 8,
    }
}
