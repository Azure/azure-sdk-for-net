// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    internal static class Constants
    {
        public static readonly StringIndexType DefaultStringIndexType = StringIndexType.Utf16CodeUnit;
        public static readonly Legacy.StringIndexType DefaultLegacyStringIndexType = Legacy.StringIndexType.Utf16CodeUnit;
        public const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";
    }
}
