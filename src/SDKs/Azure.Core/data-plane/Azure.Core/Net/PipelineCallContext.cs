// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Azure.Core.Http
{
    public abstract class HttpMessage  : IDisposable
    {
        internal OptionsStore _options = new OptionsStore();

        public CancellationToken Cancellation { get; }

        public PipelineMessageOptions Options => new PipelineMessageOptions(this);

        protected HttpMessage(CancellationToken cancellation)
        {
            Cancellation = cancellation;
        }

        // TODO (pri 1): what happens if this is called after AddHeader? Especially for SocketTransport
        public abstract void SetRequestLine(PipelineMethod method, Uri uri);

        public abstract void AddHeader(HttpHeader header);

        public virtual void AddHeader(string name, string value)
            => AddHeader(new HttpHeader(name, value));

        public abstract void SetContent(PipelineContent content);

        public abstract PipelineMethod Method { get; }

        // response
        public Response Response => new Response(this);

        // make many of these protected internal
        protected internal abstract int Status { get; }

        protected internal abstract bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value);

        protected internal abstract Stream ResponseContentStream { get; }

        public virtual void Dispose() => _options.Clear();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
