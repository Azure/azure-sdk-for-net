// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).
// The generated internal ctor accepts all params; this shim provides the old 2-param public ctor.
// Must pass empty dict for metadata to avoid NRE in serialization (Optional.IsCollectionDefined returns true for null).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupLogAnalytics
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupLogAnalytics"/>. </summary>
        /// <param name="workspaceId"> The workspace id. </param>
        /// <param name="workspaceKey"> The workspace key. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupLogAnalytics(string workspaceId, string workspaceKey)
            : this(workspaceId, workspaceKey, default, new ChangeTrackingDictionary<string, string>(), default, default)
        {
        }
    }
}
