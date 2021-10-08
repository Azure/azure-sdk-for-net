// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    internal static class Constants
    {
        public static readonly StringIndexType DefaultStringIndexType = StringIndexType.Utf16CodeUnit;
        public static string CognitiveServicesEndpointSuffix => Environment.GetEnvironmentVariable("TEXT_ANALYTICS_DEFAULT_SCOPE") ?? ".cognitiveservices.azure.com";
        public const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        public static string getDefaultCognitiveScope()
        {
            string cognitiveServicesEndpointSuffix = CognitiveServicesEndpointSuffix;
            cognitiveServicesEndpointSuffix = cognitiveServicesEndpointSuffix.Substring(1);
            string defaultCognitiveScope = $"https://{cognitiveServicesEndpointSuffix}/.default";
            return defaultCognitiveScope;
        }
    }
}
