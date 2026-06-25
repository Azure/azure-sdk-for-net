// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Kusto.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Kusto
{
    // This property is from flattend property class ClusterProperties
    // In GA, it's named ClusterUri in ClusterProperties but named Uri in this class.
    public partial class KustoClusterData : TrackedResourceData
    {
        // TODO: Rename this in spec after fixed: https://github.com/Azure/azure-sdk-for-net/issues/60237
        /// <summary> The list of language extensions. </summary>
        public IList<KustoLanguageExtension> LanguageExtensionsValue => Value;
    }
}
