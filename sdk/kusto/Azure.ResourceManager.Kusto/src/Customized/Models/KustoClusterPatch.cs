// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    // This property is from flattend property class ClusterProperties
    // In GA, it's named ClusterUri in ClusterProperties but named Uri in this class.
    public partial class KustoClusterPatch
    {
        /// <summary> The cluster URI. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.uri")]
        public Uri Uri => ClusterUri;

        // TODO: Rename this in spec after fixed: https://github.com/Azure/azure-sdk-for-net/issues/60237
        /// <summary> The list of language extensions. </summary>
        [WirePath("properties.languageExtensions.value")]
        public IList<KustoLanguageExtension> LanguageExtensionsValue => Value;
    }
}
