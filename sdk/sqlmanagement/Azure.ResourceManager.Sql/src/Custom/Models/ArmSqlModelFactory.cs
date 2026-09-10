// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql.Models
{
    public static partial class ArmSqlModelFactory
    {
        /// <summary> Backward-compatible factory for the renamed <see cref="ManagedInstanceQueryData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This function is obsolete and will be removed in a future release. Use ManagedInstanceQueryData instead.", false)]
        public static ManagedInstanceQuery ManagedInstanceQuery(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string queryText = default)
        {
            throw new NotSupportedException("This function is obsolete and will be removed in a future release. Use ManagedInstanceQueryData instead.");
        }
    }
}
