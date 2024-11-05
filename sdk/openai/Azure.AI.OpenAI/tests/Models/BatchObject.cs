// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.AI.OpenAI.Tests.Utils;

namespace Azure.AI.OpenAI.Tests.Models;

public class BatchObject
{
    public static BatchObject From(BinaryData data)
    {
        return JsonSerializer.Deserialize<BatchObject>(data, JsonOptions.OpenAIJsonOptions)
            ?? throw new InvalidOperationException("Response was null JSON");
    }

    public string? Status { get; set; }
    public string? Id { get; set; }
    public string? OutputFileID { get; set; }
    public string? ErrorFileId { get; set; }
}
