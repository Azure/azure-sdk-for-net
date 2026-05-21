// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: old SDK had LanguageExtensionsValue and Uri properties.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class KustoClusterPatch
    {
        /// <summary> The list of language extensions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.languageExtensions.value")]
        public IList<KustoLanguageExtension> LanguageExtensionsValue => LanguageExtensions?.Value;

        /// <summary> The cluster URI. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.uri")]
        public Uri Uri => ClusterUri;
    }
}
