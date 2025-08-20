// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.IO;
using System.Text.Json;
using Azure.AI.OpenAI.Tests.Utils;

namespace Azure.AI.OpenAI.Tests.Models;

public class FineTuningOptions
{
    required public string TrainingFile { get; init; }
    required public string Model { get; init; }
    public int? Seed { get; set; }
    public string? Suffix { get; set; }
    public FineTuningHyperparameters? Hyperparameters { get; init; }

    public BinaryContent ToBinaryContent()
    {
        MemoryStream stream = new();
        JsonSerializer.Serialize(stream, this, JsonOptions.OpenAIJsonOptions);
        stream.Seek(0, SeekOrigin.Begin);
        return BinaryContent.Create(stream);
    }
}
