// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Azure.Core.Http;

namespace Azure
{
    public abstract class Response : IDisposable
    {
        public abstract int Status { get; }

        public abstract string ReasonPhrase { get; }

        public abstract Stream? ContentStream { get; set; }

        public abstract string ClientRequestId { get; set; }

        public virtual ResponseHeaders Headers => new ResponseHeaders(this);

        public abstract void Dispose();

        protected internal abstract bool TryGetHeader(string name, [NotNullWhen(true)] out string? value);

        protected internal abstract bool TryGetHeaderValues(string name, out IEnumerable<string> values);

        protected internal abstract bool ContainsHeader(string name);

        protected internal abstract IEnumerable<HttpHeader> EnumerateHeaders();

        public Response<T> WithValue<T>(T value)
        {
            return new ValueResponse<T>(this, value);
        }
    }
}
