// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects;

public partial class DataGenerationJob
{
    internal FoundryOpenAIError Error { get; }

    /// <summary> The timestamp when the job was created, represented in Unix time (seconds since January 1, 1970). </summary>
    [CodeGenMember("CreatedOn")]
    public DateTimeOffset CreatedAt { get; }

    /// <summary> The timestamp when the job was finished, represented in Unix time (seconds since January 1, 1970). </summary>
    [CodeGenMember("FinishedOn")]
    public DateTimeOffset? FinishedAt { get; }
}
