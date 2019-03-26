// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Base.Http
{
    public abstract class HttpPipelineRequest : IDisposable
    {
        public virtual Uri Uri { get; set; }

        public virtual HttpVerb Method { get; set; }

        public virtual void SetRequestLine(HttpVerb method, Uri uri)
        {
            Method = method;
            Uri = uri;
        }

        public virtual HttpPipelineRequestContent Content { get; set; }

        public abstract void AddHeader(HttpHeader header);

        public virtual void AddHeader(string name, string value)
            => AddHeader(new HttpHeader(name, value));

        public abstract bool TryGetHeader(string name, out string value);

        public abstract IEnumerable<HttpHeader> Headers { get; }

        public abstract string CorrelationId { get; }

        public abstract void Dispose();
    }
}