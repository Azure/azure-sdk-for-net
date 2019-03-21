// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Collections;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Azure.Base.Http
{
    public abstract partial class HttpMessage  : IDisposable
    {
        internal OptionsStore _options = new OptionsStore();

        public CancellationToken Cancellation { get; }

        public HttpMessageOptions Options => new HttpMessageOptions(this);

        protected HttpMessage(CancellationToken cancellation) => Cancellation = cancellation;

        public abstract void SetRequestLine(HttpVerb method, Uri uri);

        public abstract void AddHeader(HttpHeader header);

        public virtual void AddHeader(string name, string value)
            => AddHeader(new HttpHeader(name, value));

        public abstract void SetContent(HttpMessageContent content);

        public abstract HttpVerb Method { get; }

        // response
        public Response Response => new Response(this);

        // make many of these protected internal
        protected internal abstract int Status { get; }

        protected internal abstract bool TryGetHeader(string name, out HeaderValues values);

        protected internal abstract Stream ResponseContentStream { get; }

        public virtual void Dispose() => _options.Clear();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
