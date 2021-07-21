// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class EntityRecognitionSkill
    {
        /// <summary> A list of entity categories that should be extracted. </summary>
        public IList<EntityCategory> Categories { get; }
    }
}
