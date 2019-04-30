// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
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

        protected internal abstract void AddHeader(string name, string value);

        protected internal abstract bool TryGetHeader(string name, out string value);

        protected internal abstract bool TryGetHeaderValues(string name, out IEnumerable<string> values);

        protected internal abstract bool ContainsHeader(string name);

        protected internal virtual void SetHeader(string name, string value)
        {
            RemoveHeader(name);
            AddHeader(name, value);
        }

        protected internal abstract bool RemoveHeader(string name);

        protected internal abstract IEnumerable<HttpHeader> EnumerateHeaders();

        public abstract string RequestId { get; set; }

        public RequestHeaders Headers => new RequestHeaders(this);

        public abstract void Dispose();
    }
}
