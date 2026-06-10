// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: old SDK had LanguageExtensionsValue (IList).

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoClusterData
    {
        /// <summary> The list of language extensions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.languageExtensions.value")]
        public IList<Models.KustoLanguageExtension> LanguageExtensionsValue => LanguageExtensions?.Value;
    }
}
