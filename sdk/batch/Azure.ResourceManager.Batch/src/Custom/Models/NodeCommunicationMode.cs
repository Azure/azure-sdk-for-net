// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Batch.Models
{
    /// <summary> Determines how a pool communicates with the Batch service. </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum NodeCommunicationMode
    {
        /// <summary> The node communication mode is automatically set by the Batch service. </summary>
        Default = 0,
        /// <summary> Nodes using the Classic communication mode require inbound TCP communication on ports 29876 and 29877 from the "BatchNodeManagement.{region}" service tag and outbound TCP communication on port 443 to "Storage.region" and "BatchNodeManagement.{region}" service tags. </summary>
        Classic = 1,
        /// <summary> Nodes using the Simplified communication mode require outbound TCP communication on port 443 to the "BatchNodeManagement.{region}" service tag. No open inbound ports are required. </summary>
        Simplified = 2,
    }
}
