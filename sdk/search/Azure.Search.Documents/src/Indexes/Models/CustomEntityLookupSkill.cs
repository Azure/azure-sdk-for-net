// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class CustomEntityLookupSkill
    {
        /// <summary> The inline CustomEntity definition. </summary>
        public IList<CustomEntity> InlineEntitiesDefinition { get; }
    }
}
