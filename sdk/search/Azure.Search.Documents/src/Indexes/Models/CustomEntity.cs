// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class CustomEntity
    {
        /// <summary> An array of complex objects that can be used to specify alternative spellings or synonyms to the root entity name. </summary>
        public IList<CustomEntityAlias> Aliases { get; }
    }
}
