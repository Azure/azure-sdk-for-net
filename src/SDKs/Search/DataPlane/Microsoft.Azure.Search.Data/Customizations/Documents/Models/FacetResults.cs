// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Contains all the results of a facet query, organized as a collection of buckets for each faceted field.
    /// </summary>
    public class FacetResults : Dictionary<string, IList<FacetResult>>
    {
    }
}
