// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class InputFieldMappingEntry
    {
        /// <summary> The recursive inputs used when creating a complex type. </summary>
        public IList<InputFieldMappingEntry> Inputs { get; }
    }
}
