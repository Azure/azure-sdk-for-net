// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.AI.OpenAI.Tests.Utils;

namespace Azure.AI.OpenAI.Tests.Models;

public class BatchOptions
{
    public string? InputFileId { get; set; }
    public string? Endpoint { get; set; }
    public string CompletionWindow { get; set; } = "24h";
    public IDictionary<string, string> Metadata { get; } = new Dictionary<string, string>();

    public BinaryContent ToBinaryContent()
    {
        using MemoryStream stream = new MemoryStream();
        JsonSerializer.Serialize(stream, this, JsonOptions.OpenAIJsonOptions);

        stream.Seek(0, SeekOrigin.Begin);
        var data = BinaryData.FromStream(stream);
        return BinaryContent.Create(data);
    }
}
