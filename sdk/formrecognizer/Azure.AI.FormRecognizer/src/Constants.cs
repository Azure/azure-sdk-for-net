// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer
{
    internal static class Constants
    {
        private const string AzurePublicCloud = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        private const string AzureChina = "3d0a72e2-8b06-4528-98df-1391c6f12c11";
        private const string AzureGovernment = "63296244-ce2c-46d8-bc36-3e558792fbee";
        private static TestEnvironment _testEnvironment;
        public const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        public const string OperationLocationHeader = "Operation-Location";

        public static string DefaultCognitiveScope = getDefaultCognitiveScope();

        public const float DefaultConfidenceValue = 1.0f;
        internal static string getDefaultCognitiveScope()
        {
            switch (_testEnvironment.TenantId)
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
