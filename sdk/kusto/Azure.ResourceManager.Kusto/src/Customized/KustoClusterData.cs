// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Kusto.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Kusto
{
    // these renaming properties are from flattened `Properties`.
    // in GA code, under this class and its `Properties` class, they are named differently.
    /// <summary> Class representing a Kusto cluster. </summary>
    public partial class KustoClusterData : TrackedResourceData
    {
        /// <summary> The list of language extensions. </summary>
        public IList<KustoLanguageExtension> LanguageExtensionsValue => Value;
    }
}
