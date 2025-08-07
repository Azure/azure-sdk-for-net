// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Developer.Playwright.Model;
internal class RunFramework
{  [JsonInclude]
    internal string? Name { get; set; }
    [JsonInclude]
    internal string? Version { get; set; }
    [JsonInclude]
    internal string? RunnerName { get; set; }
}
internal class RunConfig
{   [JsonInclude]
    internal RunFramework? Framework { get; set; }
    [JsonInclude]
    internal string? SdkLanguage { get; set; }
    [JsonInclude]
    internal string? RunnerName { get; set; }
}