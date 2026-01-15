// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.EdgeOrder.Models
{
    // Manually add to maintain its backward compatibility
    public partial class EdgeOrderItemDetails
    {
        /// <summary> Parent RP details - this returns only the first or default parent RP from the entire list. </summary>
        internal ResourceProviderDetails FirstOrDefaultManagement { get; }
        /// <summary> Resource provider namespace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FirstOrDefaultManagementResourceProviderNamespace
        {
            get => FirstOrDefaultManagement?.ResourceProviderNamespace;
        }
    }
}
