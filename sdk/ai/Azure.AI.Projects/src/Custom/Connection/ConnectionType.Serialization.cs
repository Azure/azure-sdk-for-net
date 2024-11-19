// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Projects
{
    internal static partial class ConnectionTypeExtensions
    {
        public static string ToSerialString(this ConnectionType value) => value switch
        {
            ConnectionType.AzureOpenAI => "AzureOpenAI",
            ConnectionType.Serverless => "Serverless",
            ConnectionType.AzureBlobStorage => "AzureBlob",
            ConnectionType.AzureAIServices => "AIServices",
            ConnectionType.AzureAISearch => "CognitiveSearch",
            ConnectionType.ApiKey => "ApiKey",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ConnectionType value.")
        };

        public static ConnectionType ToConnectionType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AzureOpenAI")) return ConnectionType.AzureOpenAI;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Serverless")) return ConnectionType.Serverless;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AzureBlob")) return ConnectionType.AzureBlobStorage;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AIServices")) return ConnectionType.AzureAIServices;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "CognitiveSearch")) return ConnectionType.AzureAISearch;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ApiKey")) return ConnectionType.ApiKey;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ConnectionType value.");
        }
    }
}
