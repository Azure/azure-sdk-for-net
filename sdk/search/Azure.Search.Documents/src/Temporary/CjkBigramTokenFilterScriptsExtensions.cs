// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Search.Documents.Indexes.Models;

internal static class CjkBigramTokenFilterScriptsExtensions
{
    public static string ToSerialString(this CjkBigramTokenFilterScripts value) => value.ToString();
    public static CjkBigramTokenFilterScripts ToCjkBigramTokenFilterScripts(this string value) => new(value);
}
