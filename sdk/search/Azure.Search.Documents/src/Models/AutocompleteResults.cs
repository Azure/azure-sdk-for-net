// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Renames generated AutocompleteResult to AutocompleteResults for backward compatibility.
    /// </summary>
    [CodeGenType("AutocompleteResult")]
    public partial class AutocompleteResults
    {
    }
}
