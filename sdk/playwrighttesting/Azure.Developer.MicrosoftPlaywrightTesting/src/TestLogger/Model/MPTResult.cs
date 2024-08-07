// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

internal class RawTestStep
{
    internal string? Title { get; set; }
    internal string? Category { get; set; }
    internal string? StartTime { get; set; }
    internal int Duration { get; set; }
    internal string? Error { get; set; }
    internal List<RawTestStep> Steps { get; set; } = new List<RawTestStep>();
    internal Location? Location { get; set; }
    internal string? Snippet { get; set; }
    internal int Count { get; set; }
}

internal class Location
{
    internal int LineNumber { get; set; }
}

internal class MPTError
{
    internal string? message { get; set; }
}
internal class RawTestResult
{
    internal List<RawTestStep> Steps { get; set; } = new List<RawTestStep>();
    internal string? errors { get; set; }
    internal string? stdErr { get; set; }
    internal string? stdOut { get; set; }
}

internal class TokenDetails
{
    internal string? aid { get; set; }
    internal string? oid { get; set; }
    internal string? id { get; set; }
    internal string? userName { get; set; }
}
