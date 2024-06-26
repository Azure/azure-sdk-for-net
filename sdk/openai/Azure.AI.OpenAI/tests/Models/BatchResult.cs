// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.AI.OpenAI.Tests.Utils;

namespace Azure.AI.OpenAI.Tests.Models;

public class BatchResult<T>
{
    public string? ID { get; init; }
    public string? CustomId { get; init; }
    public T? Response { get; init; }
    public JsonElement? Error { get; init; }

    public static IReadOnlyList<BatchResult<T>> From(BinaryData data)
    {
        List<BatchResult<T>> list = new();
        using var reader = new StreamReader(data.ToStream(), Encoding.UTF8, false);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            var entry = JsonSerializer.Deserialize<BatchResult<T>>(line, JsonHelpers.OpenAIJsonOptions);
            if (entry != null)
            {
                list.Add(entry);
            }
        }

        return list;
    }
}
