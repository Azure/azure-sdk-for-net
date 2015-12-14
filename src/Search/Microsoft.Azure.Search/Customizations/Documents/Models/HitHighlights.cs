// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains all the hit highlights for a document, organized as a collection of text fragments for each
    /// applicable field.
    /// </summary>
    public class HitHighlights : Dictionary<string, IList<string>>
    {
    }
}
