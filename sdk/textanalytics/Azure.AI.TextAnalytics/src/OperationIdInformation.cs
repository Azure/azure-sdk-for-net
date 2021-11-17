// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    internal class OperationIdInformation
    {
        public OperationIdInformation(string jobId, IDictionary<string, int> indexMap, bool? showStats = default)
        {
            JobId = jobId;
            InputDocumentOrder = new Dictionary<string, int>(indexMap);
            ShowStats = showStats;
        }

        public Dictionary<string, int> InputDocumentOrder { get; set; }

        public bool? ShowStats { get; set; }

        public string JobId { get; set; }
    }
}
