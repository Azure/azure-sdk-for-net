// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Base.Http
{
    public abstract class HttpPipelineRequest
    {
        public abstract void SetRequestLine(HttpVerb method, Uri uri);

        public abstract void AddHeader(HttpHeader header);

        public virtual void AddHeader(string name, string value)
            => AddHeader(new HttpHeader(name, value));

        public abstract void SetContent(HttpMessageContent content);

        public abstract HttpVerb Method { get; }
    }
}