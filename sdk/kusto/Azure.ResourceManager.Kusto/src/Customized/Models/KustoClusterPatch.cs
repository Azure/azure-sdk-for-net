// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Kusto.Models
{
    // these renaming properties are from flattened `Properties`.
    // in GA code, under this class and its `Properties` class, they are named differently.
    public partial class KustoClusterPatch
    {
        /// <summary> The cluster URI. </summary>
        public Uri Uri => ClusterUri;

        /// <summary> The list of language extensions. </summary>
        public IList<KustoLanguageExtension> LanguageExtensionsValue => Value;
    }
}
