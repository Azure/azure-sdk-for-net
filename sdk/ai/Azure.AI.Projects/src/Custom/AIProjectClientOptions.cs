// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.Projects
{
    /// <summary> Client options for AIProjectClient. </summary>
    public partial class AIProjectClientOptions : ClientPipelineOptions
    {
        /// <summary> The size of the client cache. </summary>
        public int ClientCacheSize { get; set; } = 100;
    }
}
