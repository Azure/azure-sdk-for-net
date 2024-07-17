// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.OpenAI.Tests.Models;

public class FineTuningJobEvent : FineTuningModelBase
{
    public DateTimeOffset CreatedAt { get; init; }
    public string? Level { get; init; }
    public string? Message { get; init; }
}
