// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql.Models
{
    public static partial class ArmSqlModelFactory
    {
        /// <summary> Backward-compatible factory for the renamed <see cref="ManagedInstanceQueryData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Type or member is obsolete
        public static ManagedInstanceQuery ManagedInstanceQuery(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string queryText = default)
            => new ManagedInstanceQuery(id, name, resourceType, systemData, queryText, null);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
