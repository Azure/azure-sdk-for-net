// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies
{
    internal static class ProxyTestPayloads
    {
        // A response body in the OpenAI Responses shape carrying one tool with the given discriminator.
        public static string ResponseJson(string kind, string? property = null, string? value = null)
        {
            string extra = property is null ? string.Empty : $",\"{property}\":\"{value}\"";
            return $"{{\"id\":\"response-id\",\"object\":\"response\",\"created_at\":1760000000,"
                + $"\"model\":\"test-model\",\"output\":[],\"tools\":[{{\"type\":\"{kind}\"{extra}}}]}}";
        }

        public const string AzureToolJson = "{\"type\":\"azure_search\",\"index_name\":\"docs\"}";
        public const string BingToolJson = "{\"type\":\"bing_grounding\",\"market\":\"en-US\"}";
    }
}
