// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class TextWeights
    {
        /// <summary> The dictionary of per-field weights to boost document scoring. The keys are field names and the values are the weights for each field. </summary>
        public IDictionary<string, double> Weights { get; }
    }
}
