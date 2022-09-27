// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

using ServiceVersion = Azure.AI.TextAnalytics.TextAnalyticsClientOptions.ServiceVersion;

namespace Azure.AI.TextAnalytics
{
    internal class OperationContinuationToken
    {
        // This represents the version of the token, not the service API version. The value itself is actually arbitrary.
        private const ServiceVersion LatestTokenVersion = ServiceVersion.V3_1;
        private static readonly string s_latestTokenVersion = TextAnalyticsClientOptions.GetVersionString(LatestTokenVersion);

        private static readonly JsonSerializerOptions s_jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // Parameterless constructor required for JSON deserialization.
        public OperationContinuationToken()
        {
            Version = s_latestTokenVersion;
        }

        public OperationContinuationToken(string jobId, IDictionary<string, int> inputDocumentOrder, bool? showStats)
            : this()
        {
            JobId = jobId;
            InputDocumentOrder = new Dictionary<string, int>(inputDocumentOrder);
            ShowStats = showStats;
        }

        public string Version { get; set; }

        public string JobId { get; set; }

        public Dictionary<string, int> InputDocumentOrder { get; set; }

        public bool? ShowStats { get; set; }

        /// <exception cref="ArgumentException">Thrown when the <see cref="Version"/> of the deserialized token is not the expected <see cref="LatestTokenVersion"/>.</exception>
        /// <exception cref="FormatException">Thrown when <paramref name="base64OperationId"/> is not a valid base-64 string.</exception>
        /// <exception cref="JsonException">Thrown when <paramref name="base64OperationId"/> cannot be deserialized from JSON.</exception>
        public static OperationContinuationToken Deserialize(string base64OperationId)
        {
            byte[] plainTextBytes = Convert.FromBase64String(base64OperationId);
            OperationContinuationToken token = JsonSerializer.Deserialize<OperationContinuationToken>(plainTextBytes, s_jsonOptions);

            if (token.Version != s_latestTokenVersion)
            {
                throw new ArgumentException($"Unsupported continuation token version. Expected: '{s_latestTokenVersion}'. Actual: '{token.Version}'.");
            }

            Argument.AssertNotNull(token.JobId, nameof(JobId));
            Argument.AssertNotNull(token.InputDocumentOrder, nameof(InputDocumentOrder));

            return token;
        }

        public static string Serialize(string jobId, IDictionary<string, int> inputDocumentOrder, bool? showStats) =>
            new OperationContinuationToken(jobId, inputDocumentOrder, showStats).Serialize();

        public string Serialize()
        {
            string plainOperationId = JsonSerializer.Serialize(this, s_jsonOptions);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainOperationId);

            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
