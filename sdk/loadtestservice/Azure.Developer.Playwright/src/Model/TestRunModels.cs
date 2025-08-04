// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Developer.Playwright.Model;
internal class RunFramework
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("runnerName")]
    public string? RunnerName { get; set; }
}
internal class RunConfig
{
    [JsonPropertyName("framework")]
    public RunFramework? Framework { get; set; }

    [JsonPropertyName("sdkLanguage")]
    public string? SdkLanguage { get; set; }

    [JsonPropertyName("maxWorkers")]
    public int? MaxWorkers { get; set; }
}