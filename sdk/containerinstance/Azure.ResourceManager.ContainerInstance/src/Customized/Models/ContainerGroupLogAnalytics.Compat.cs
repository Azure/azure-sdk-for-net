// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupLogAnalytics
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupLogAnalytics"/>. </summary>
        /// <param name="workspaceId"> The workspace id. </param>
        /// <param name="workspaceKey"> The workspace key. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupLogAnalytics(string workspaceId, string workspaceKey)
            : this(workspaceId, workspaceKey, default, default, default, default)
        {
        }
    }
}
