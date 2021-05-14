// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    public partial class Metric
    {
        [CodeGenMember("Name")]
        private LocalizableString LocalizedName { get; }

        /// <summary> The name of the metric. </summary>
        public string Name => LocalizedName.Value;
    }
}