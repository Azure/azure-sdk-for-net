// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.Pipeline;

namespace Azure
{
    public abstract class Request : IDisposable
    {
        public virtual HttpPipelineUriBuilder UriBuilder { get; set; } = new HttpPipelineUriBuilder();

        public virtual HttpPipelineMethod Method { get; set; }

        public virtual void SetRequestLine(HttpPipelineMethod method, Uri uri)
        {
            Method = method;
            UriBuilder.Uri = uri;
        }

        public virtual HttpPipelineRequestContent Content { get; set; }

        public abstract void AddHeader(HttpHeader header);

        public virtual void AddHeader(string name, string value)
            => AddHeader(new HttpHeader(name, value));

        public abstract bool TryGetHeader(string name, out string value);

        public abstract bool TryGetHeaderValues(string name, out IEnumerable<string> values);

        public abstract bool ContainsHeader(string name);

        public abstract void SetHeader(string name, string value);

        public abstract bool RemoveHeader(string name);

        public abstract IEnumerable<HttpHeader> Headers { get; }

        public abstract string RequestId { get; set; }

        public abstract void Dispose();
    }
}
