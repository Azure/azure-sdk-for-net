// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Developer.Playwright.Model;

internal class CIInfo
{
    [JsonInclude]
    internal string? providerName { get; set; }
    [JsonInclude]
    internal string? branch { get; set; }
    [JsonInclude]
    internal string? author { get; set; }
    [JsonInclude]
    internal string? commitId { get; set; }
    [JsonInclude]
    internal string? revisionUrl { get; set; }
}
