// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Azure.AI.TextAnalytics
{
    internal class OperationIdInformation
    {
        public OperationIdInformation(string jobId, IDictionary<string, int> indexMap, bool? showStats)
        {
            JobId = jobId;
            InputDocumentOrder = new Dictionary<string, int>(indexMap);
            ShowStats = showStats;
        }

        public Dictionary<string, int> InputDocumentOrder { get; set; }

        public bool? ShowStats { get; set; }

        public string JobId { get; set; }

        public static OperationIdInformation Decode(string base64OperationId)
        {
            byte[] base64EncodedBytes = Convert.FromBase64String(base64OperationId);
            string plainOperationId = Encoding.UTF8.GetString(base64EncodedBytes);

            return JsonSerializer.Deserialize<OperationIdInformation>(plainOperationId);
        }

        public static string Encode(string jobId, IDictionary<string, int> indexMap, bool? showStats)
        {
            string plainOperationId = JsonSerializer.Serialize(new OperationIdInformation(jobId, indexMap, showStats));
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainOperationId);

            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
