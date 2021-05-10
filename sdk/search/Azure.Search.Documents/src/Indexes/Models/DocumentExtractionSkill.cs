// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class DocumentExtractionSkill
    {
        /// <summary> A dictionary of configurations for the skill. </summary>
        public IDictionary<string, object> Configuration { get; }
    }
}
