// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SynonymTokenFilter
    {
        /// <summary> A list of synonyms in following one of two formats: 1. incredible, unbelievable, fabulous =&gt; amazing - all terms on the left side of =&gt; symbol will be replaced with all terms on its right side; 2. incredible, unbelievable, fabulous, amazing - comma separated list of equivalent words. Set the expand option to change how this list is interpreted. </summary>
        public IList<string> Synonyms { get; }
    }
}
