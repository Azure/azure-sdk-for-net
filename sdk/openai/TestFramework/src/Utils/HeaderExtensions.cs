// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Utils;

public static class HeaderExtensions
{
    public static string? GetFirstOrDefault(this PipelineResponseHeaders headers, string name)
    {
        if (headers?.TryGetValues(name, out IEnumerable<string>? values) == true)
        {
            return values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }

        return null;
    }

    public static string? GetFirstOrDefault(this PipelineRequestHeaders headers, string name)
    {
        if (headers?.TryGetValues(name, out IEnumerable<string>? values) == true)
        {
            return values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }

        return null;
    }
}
