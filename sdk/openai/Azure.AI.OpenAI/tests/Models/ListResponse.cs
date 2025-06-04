// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;

namespace Azure.AI.OpenAI.Tests.Models;

public class ListResponse<T>
{
    public bool HasMore { get; init; }
    public IReadOnlyList<T>? Data { get; init; }
}
