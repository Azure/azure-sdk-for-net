// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// Determines how a pool communicates with the Batch service.
    /// </summary>
    public enum NodeCommunicationMode
    {
        /// <summary>
        /// The node communication mode is automatically set by the Batch service.
        /// </summary>
        Default,

        /// <summary>
        /// Nodes using the classic communication mode require inbound TCP communication on ports 29876 and 29877 from the \"BatchNodeManagement.{region}\" service tag and outbound TCP communication on port 443 to the \"Storage.region\" and \"BatchNodeManagement.{region}\" service tags.
        /// </summary>
        Classic,

        /// <summary>
        /// Nodes using the simplified communication mode require outbound TCP communication on port 443 to the \"BatchNodeManagement.{region}\" service tag. No open inbound ports are required.
        /// </summary>
        Simplified
    }
}