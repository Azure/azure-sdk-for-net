// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Tests.Infrastructure
{
    internal static class ExtensionMethods
    {
        public static MockResponse WithContent(this MockResponse response, string content, string contentType = "application/json")
        {
            response.SetContent(content);
            if (!string.IsNullOrWhiteSpace(contentType))
            {
                response.AddHeader(HttpHeader.Names.ContentType, contentType);
            }

            return response;
        }

        public static MockResponse WithHeader(this MockResponse response, string name, string value)
        {
            response.AddHeader(name, value);
            return response;
        }
    }
}
