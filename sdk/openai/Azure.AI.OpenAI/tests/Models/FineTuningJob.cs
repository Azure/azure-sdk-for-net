// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Tests.Models;

public class FineTuningJob : FineTuningModelBase
{
    public DateTimeOffset CreatedAt { get; init; }
    public IReadOnlyDictionary<string, string>? Error { get; set; }
    public string? FineTunedModel { get; init; }
    public string Model { get; init; } = string.Empty;
    public string? OrganizationID { get; init; }
    public string Status { get; set; } = string.Empty;
    public IReadOnlyList<string>? ResultFiles { get; init; }
    public int? TrainedTokens { get; init; }
    public DateTimeOffset EstimatedFinish { get; init; }
}
