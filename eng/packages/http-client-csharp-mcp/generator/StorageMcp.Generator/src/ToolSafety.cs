// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace StorageMcp.Generator;

public sealed record ToolSafety(bool Destructive, bool Idempotent, bool ReadOnly, bool OpenWorld)
{
    public static ToolSafety FromHttpMethod(string method)
    {
        var normalized = method.ToUpperInvariant();
        if (normalized is not ("GET" or "HEAD" or "OPTIONS" or "PUT" or "DELETE" or "POST" or "PATCH"))
        {
            throw new InvalidOperationException($"Unsupported HTTP method '{method}'.");
        }

        var readOnly = normalized is "GET" or "HEAD" or "OPTIONS";
        return new(!readOnly, readOnly || normalized is "PUT" or "DELETE", readOnly, true);
    }
}
