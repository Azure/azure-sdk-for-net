// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

internal class CIInfo
{
    internal string? Provider { get; set; }
    internal string? Repo { get; set; }
    internal string? Branch { get; set; }
    internal string? Author { get; set; }
    internal string? CommitId { get; set; }
    internal string? RevisionUrl { get; set; }
    internal string? RunId { get; set; }
    internal int? RunAttempt { get; set; }
    internal string? JobId { get; set; }
}
