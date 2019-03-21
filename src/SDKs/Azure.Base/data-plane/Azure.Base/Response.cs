// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Buffers;
using Azure.Base.Http;
using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Azure
{
    public readonly struct Response
    {
        readonly HttpMessage _message;

        public Response(HttpMessage message)
            => _message = message;

        public int Status => _message.Status;

        public Stream ContentStream => _message.ResponseContentStream;

        public bool TryGetHeader(string name, out HeaderValues values)
        {
            return _message.TryGetHeader(name, out values);
        }

        public void Dispose() => _message.Dispose();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => _message.ToString();
    }
}
