// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.AI.Projects
{
    /// <summary> Client options for AIProjectClient. </summary>
    public partial class AIProjectClientOptions : ClientPipelineOptions
    {
        /// <summary> The size of the client cache. </summary>
        public int ClientCacheSize { get; set; } = 100;

        private void ValidateAutoFunctions(Dictionary<string, Delegate> delegates)
        {
            if (delegates == null || delegates.Count == 0)
            {
                throw new InvalidOperationException("The delegate dictionary must have at least one delegate.");
            }
            foreach (var kvp in delegates)
            {
                if (kvp.Value.Method.ReturnType != typeof(string))
                {
                    throw new InvalidOperationException($"The Delegates must have string as return type.");
                }
            }
        }
    }
}
