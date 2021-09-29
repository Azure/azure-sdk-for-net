// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class CustomEntityLookupSkill
    {
        /// <summary> Path to a JSON or CSV file containing all the target text to match against. This entity definition is read at the beginning of an indexer run. Any updates to this file during an indexer run will not take effect until subsequent runs. This configuration must be accessible over HTTPS. </summary>
        [CodeGenMember("EntitiesDefinitionUri")]
        public Uri EntitiesDefinitionUri { get; set; }

        /// <summary> The inline CustomEntity definition. </summary>
        public IList<CustomEntity> InlineEntitiesDefinition { get; }
    }
}
