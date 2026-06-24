// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Kusto;

namespace Azure.ResourceManager.Kusto.Models
{
    // This class is used as flattened property for KustoClusterPatch and KustoClusterData.
    // In GA, this property is named `Value` in this class, but named `LanguageExtensionsValue` in KustoClusterPatch and KustoClusterData.
    public partial class KustoLanguageExtensionList
    {
        /// <summary> The list of language extensions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<KustoLanguageExtension> Value => LanguageExtensionsValue;
    }
}
