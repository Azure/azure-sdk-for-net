// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: CheckName content models had ResourceType properties
// returning custom enum types in the old SDK. The generated code has
// an internal string Type property instead.

using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class KustoClusterNameAvailabilityContent
    {
        /// <summary> The type of resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public KustoClusterType ResourceType => new KustoClusterType(Type);
    }
}
