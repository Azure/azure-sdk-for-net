// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class FieldMappingFunction
    {
        /// <summary> A dictionary of parameter name/value pairs to pass to the function. Each value must be of a primitive type. </summary>
        public IDictionary<string, object> Parameters { get; }
    }
}
