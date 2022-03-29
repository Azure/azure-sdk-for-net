// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    public partial class MetricDefinition
    {
        [CodeGenMember("Name")]
        private LocalizableString LocalizedName { get; }

        [CodeGenMember("Dimensions")]
        private IReadOnlyList<LocalizableString> LocalizedDimensions { get; }

        /// <summary> The name of the metric. </summary>
        public string Name => LocalizedName.Value;

        /// <summary> Returns a list of dimension names. </summary>
        public IReadOnlyList<string> Dimensions => LocalizedDimensions.Select(d => d.Value).ToArray();
    }
}