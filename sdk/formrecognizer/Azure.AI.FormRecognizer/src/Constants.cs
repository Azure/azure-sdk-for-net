// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;

namespace Azure.AI.FormRecognizer
{
    internal static class Constants
    {
        private const string AzurePublicCloud = "https://login.microsoftonline.com/";
        private const string AzureChina = "https://login.microsoftonline.cn/";
        private const string AzureGovernment = "https://login.microsoftonline.us/";

        public const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        public const string OperationLocationHeader = "Operation-Location";

        public static string DefaultCognitiveScope = getDefaultCognitiveScope(Environment.GetEnvironmentVariable("AZURE_AUTHORITY_HOST"));

        public const float DefaultConfidenceValue = 1.0f;
        internal static string getDefaultCognitiveScope(string authorityHost)
        {
            switch (authorityHost)
            {
                case AzurePublicCloud:
                    return "https://cognitiveservices.azure.com/.default";
                case AzureChina:
                    return "https://cognitiveservices.azure.cn/.default";
                case AzureGovernment:
                    return "https://cognitiveservices.azure.us/.default";
                default:
                    return "https://cognitiveservices.azure.com/.default";
            }
        }
    }
}
