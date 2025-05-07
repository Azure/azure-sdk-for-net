// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Projects
{
    /// <summary> Client options for AIProjectClient. </summary>
    public partial class AIProjectClientOptions : ClientOptions
    {
        /// <summary> The size of the client cache. </summary>
        public int ClientCacheSize { get; set; }
    }
}
