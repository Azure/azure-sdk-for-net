// Copyright(c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Azure.AI.OpenAI.Tests.Utils.Pipeline
{
    public abstract class CapturedMessage
    {
        public static readonly IReadOnlyDictionary<string, IReadOnlyList<string>> EMPTY =
            new Dictionary<string, IReadOnlyList<string>>();

        public IReadOnlyDictionary<string, IReadOnlyList<string>> Headers { get; init; } = EMPTY;
        public BinaryData? Content { get; init; }
    }

    public class CapturedResponse : CapturedMessage
    {
        public HttpStatusCode Status { get; init; } = HttpStatusCode.OK;
        public string? ReasonPhrase { get; init; } = "OK";
    }

    public class CapturedRequest : CapturedMessage
    {
        public HttpMethod Method { get; init; } = HttpMethod.Get;
        public Uri? Uri { get; init; }
    }
}
