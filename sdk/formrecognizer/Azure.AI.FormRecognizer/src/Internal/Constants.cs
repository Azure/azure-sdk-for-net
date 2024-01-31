// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.FormRecognizer.DocumentAnalysis;

namespace Azure.AI.FormRecognizer
{
    internal static class Constants
    {
        public const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        public const string OperationLocationHeader = "Operation-Location";

        public const float DefaultConfidenceValue = 1.0f;

        public static readonly StringIndexType DefaultStringIndexType = StringIndexType.Utf16CodeUnit;
    }
}
