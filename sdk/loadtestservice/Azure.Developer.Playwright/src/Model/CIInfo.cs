// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Developer.Playwright.Model;

internal class CIInfo
{
    [JsonPropertyName("providerName")]
    public string? Provider { get; set; }

    [JsonPropertyName("repo")]
    public string? Repo { get; set; }

    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [JsonPropertyName("commitId")]
    public string? CommitId { get; set; }

    [JsonPropertyName("revisionUrl")]
    public string? RevisionUrl { get; set; }

    [JsonPropertyName("runId")]
    public string? RunId { get; set; }

    [JsonPropertyName("runAttempt")]
    public int? RunAttempt { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }
}
