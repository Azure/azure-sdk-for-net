// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Core.Http
{
    public abstract class Request : IDisposable
    {
        public virtual RequestUriBuilder UriBuilder { get; set; } = new RequestUriBuilder();

        public virtual RequestMethod Method { get; set; }

        public virtual void SetRequestLine(RequestMethod method, Uri uri)
        {
            Method = method;
            UriBuilder.Uri = uri;
        }

        public virtual HttpPipelineRequestContent? Content { get; set; }

        protected internal abstract void AddHeader(string name, string value);

        protected internal abstract bool TryGetHeader(string name, [NotNullWhen(true)] out string? value);

        protected internal abstract bool TryGetHeaderValues(string name, out IEnumerable<string> values);

        protected internal abstract bool ContainsHeader(string name);

        protected internal virtual void SetHeader(string name, string value)
        {
            RemoveHeader(name);
            AddHeader(name, value);
        }

        protected internal abstract bool RemoveHeader(string name);

        protected internal abstract IEnumerable<HttpHeader> EnumerateHeaders();

        public abstract string ClientRequestId { get; set; }

        public RequestHeaders Headers => new RequestHeaders(this);

        public abstract void Dispose();
    }
}
