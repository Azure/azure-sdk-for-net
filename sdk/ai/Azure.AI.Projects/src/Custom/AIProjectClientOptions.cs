// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects
{
    /// <summary> Client options for AIProjectClient. </summary>
    public partial class AIProjectClientOptions : ClientPipelineOptions
    {
        /// <summary> The size of the client cache. </summary>
        internal int ClientCacheSize { get; set; } = 100;

        private string _userAgentApplicationId;
        /// <summary>
        /// An optional application ID to use as part of the request User-Agent header.
        /// </summary>
        public string UserAgentApplicationId
        {
            get => _userAgentApplicationId;
            set
            {
                AssertNotFrozen();
                _userAgentApplicationId = value;
            }
        }
    }
}
