// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/AspNetCore/tree/master/src/Http/Headers/src

namespace Azure.Core.Http.Multipart
{
    internal enum HttpParseResult
    {
        Parsed,
        NotParsed,
        InvalidFormat,
    }
}
