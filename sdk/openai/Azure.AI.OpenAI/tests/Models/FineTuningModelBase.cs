// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.AI.OpenAI.Tests.Models;

public abstract class FineTuningModelBase
{
    required public string ID { get; init; }
    required public string Object { get; init; }
}
