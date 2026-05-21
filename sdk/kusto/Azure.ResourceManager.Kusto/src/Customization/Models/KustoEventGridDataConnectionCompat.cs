// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: ManagedIdentityObjectId was Guid? in old SDK.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class KustoEventGridDataConnection
    {
        /// <summary> The object ID of the managed identity resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete. Use ManagedIdentityObjectIdValue instead.", false)]
        [WirePath("properties.managedIdentityObjectId")]
        public Guid? ManagedIdentityObjectId
        {
            get => Guid.TryParse(ManagedIdentityObjectIdValue, out var g) ? g : null;
        }
    }
}
