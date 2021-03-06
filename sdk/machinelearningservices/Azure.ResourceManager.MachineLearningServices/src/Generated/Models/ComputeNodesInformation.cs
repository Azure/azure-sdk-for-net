// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.MachineLearningServices.Models
{
    /// <summary> Compute nodes information related to a Machine Learning compute. Might differ for every type of compute. </summary>
    public partial class ComputeNodesInformation
    {
        /// <summary> Initializes a new instance of ComputeNodesInformation. </summary>
        internal ComputeNodesInformation()
        {
        }

        /// <summary> Initializes a new instance of ComputeNodesInformation. </summary>
        /// <param name="computeType"> The type of compute. </param>
        /// <param name="nextLink"> The continuation token. </param>
        internal ComputeNodesInformation(ComputeType computeType, string nextLink)
        {
            ComputeType = computeType;
            NextLink = nextLink;
        }

        /// <summary> The type of compute. </summary>
        internal ComputeType ComputeType { get; set; }
        /// <summary> The continuation token. </summary>
        public string NextLink { get; }
    }
}
