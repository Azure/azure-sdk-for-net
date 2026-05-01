// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation
{
    public class EvaluationSampleBase : SamplesBase
    {
        #region Snippet:Sample_GetErrorMessageOrEmpty_EvaluationSampleBase
        protected static string GetErrorMessageOrEmpty(ClientResult result)
        {
            string error = "";
            Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            string code = default;
            string message = default;
            foreach (JsonProperty prop in document.RootElement.EnumerateObject())
            {
                if (prop.NameEquals("error"u8) && prop.Value.ValueKind != JsonValueKind.Null && prop.Value is JsonElement countsElement)
                {
                    foreach (JsonProperty errorNode in countsElement.EnumerateObject())
                    {
                        if (errorNode.Value.ValueKind == JsonValueKind.String)
                        {
                            if (errorNode.NameEquals("code"u8))
                            {
                                code = errorNode.Value.GetString();
                            }
                            else if (errorNode.NameEquals("message"u8))
                            {
                                message = errorNode.Value.GetString();
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(message))
            {
                error = $"Message: {message}, Code: {code ?? "<None>"}";
            }
            return error;
        }
        #endregion
        #region Snippet:Sample_GetResultCounts_EvaluationSampleBase
        protected static string GetResultsCounts(ClientResult result)
        {
            Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            StringBuilder sbFormattedCounts = new("{\n");
            foreach (JsonProperty prop in document.RootElement.EnumerateObject())
            {
                if (prop.NameEquals("result_counts"u8) && prop.Value is JsonElement countsElement)
                {
                    foreach (JsonProperty count in countsElement.EnumerateObject())
                    {
                        if (count.Value.ValueKind == JsonValueKind.Number)
                        {
                            sbFormattedCounts.Append($"    {count.Name}: {count.Value.GetInt32()}\n");
                        }
                    }
                }
            }
            sbFormattedCounts.Append('}');
            if (sbFormattedCounts.Length == 3)
            {
                throw new InvalidOperationException("The result does not contain the \"result_counts\" field.");
            }
            return sbFormattedCounts.ToString();
        }
        #endregion
        #region Snippet:Sample_ParseClientResult_EvaluationSampleBase
        protected static Dictionary<string, string> ParseClientResult(ClientResult result, string[] expectedProperties)
        {
            Dictionary<string, string> results = [];
            Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            foreach (JsonProperty prop in document.RootElement.EnumerateObject())
            {
                foreach (string key in expectedProperties)
                {
                    if (prop.NameEquals(Encoding.UTF8.GetBytes(key)) && prop.Value.ValueKind == JsonValueKind.String)
                    {
                        results[key] = prop.Value.GetString();
                    }
                }
            }
            List<string> notFoundItems = [.. expectedProperties.Where((key) => !results.ContainsKey(key))];
            if (notFoundItems.Count > 0)
            {
                StringBuilder sbNotFound = new();
                foreach (string value in notFoundItems)
                {
                    sbNotFound.Append($"{value}, ");
                }
                if (sbNotFound.Length > 2)
                {
                    sbNotFound.Remove(sbNotFound.Length - 2, 2);
                }
                throw new InvalidOperationException($"The next keys were not found in returned result: {sbNotFound}.");
            }
            return results;
        }
        #endregion
        #region Snippet:Sample_GetResultsListAsync_EvaluationSampleBase
        protected static async Task<List<string>> GetResultsListAsync(EvaluationClient client, string evaluationId, string evaluationRunId)
        {
            List<string> resultJsons = [];
            bool hasMore = false;
            string after = default;
            do
            {
                ClientResult resultList = await client.GetEvaluationRunOutputItemsAsync(evaluationId: evaluationId, evaluationRunId: evaluationRunId, limit: null, order: "asc", after: after, outputItemStatus: default, options: new());
                Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
                using JsonDocument document = JsonDocument.ParseValue(ref reader);

                foreach (JsonProperty topProperty in document.RootElement.EnumerateObject())
                {
                    if (topProperty.NameEquals("has_more"u8))
                    {
                        hasMore = topProperty.Value.GetBoolean();
                    }
                    else if (topProperty.NameEquals("data"u8))
                    {
                        if (topProperty.Value.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement dataElement in topProperty.Value.EnumerateArray())
                            {
                                resultJsons.Add(dataElement.ToString());
                            }
                        }
                    }
                    else if (topProperty.NameEquals("last_id"u8))
                    {
                        after = topProperty.Value.GetString();
                    }
                }
            } while (hasMore);
            return resultJsons;
        }
        #endregion
        #region Snippet:Sample_GetResultsList_EvaluationSampleBase
        protected static List<string> GetResultsList(EvaluationClient client, string evaluationId, string evaluationRunId)
        {
            List<string> resultJsons = [];
            bool hasMore = false;
            string after = default;
            do
            {
                ClientResult resultList = client.GetEvaluationRunOutputItems(evaluationId: evaluationId, evaluationRunId: evaluationRunId, limit: null, order: "asc", after: after, outputItemStatus: default, options: new());
                Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
                using JsonDocument document = JsonDocument.ParseValue(ref reader);

                foreach (JsonProperty topProperty in document.RootElement.EnumerateObject())
                {
                    if (topProperty.NameEquals("has_more"u8))
                    {
                        hasMore = topProperty.Value.GetBoolean();
                    }
                    else if (topProperty.NameEquals("data"u8))
                    {
                        if (topProperty.Value.ValueKind == JsonValueKind.Array)
                        {
                            foreach (JsonElement dataElement in topProperty.Value.EnumerateArray())
                            {
                                resultJsons.Add(dataElement.ToString());
                            }
                        }
                    }
                    else if (topProperty.NameEquals("last_id"u8))
                    {
                        after = topProperty.Value.GetString();
                    }
                }
            } while (hasMore);
            return resultJsons;
        }
        #endregion

        public EvaluationSampleBase(bool isAsync) : base(isAsync)
        { }
    }
}
