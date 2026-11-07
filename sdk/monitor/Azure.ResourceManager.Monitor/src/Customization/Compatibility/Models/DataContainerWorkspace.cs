// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Monitor.Models
{
    // Preserve the null-safe flattened property shipped in the GA SDK.
    public partial class DataContainerWorkspace
    {
        /// <summary> The Log Analytics workspace identifier. </summary>
        public string CustomerId => Properties?.CustomerId;
    }
}
