// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Azure.Storage.Test.Shared
{
    internal class FaultyHttpContent : HttpContent
    {
        private readonly HttpContent _innerContent;
        private readonly Stream _faultyStream;

        public FaultyHttpContent(HttpContent httpContent, FaultyStream faultyStream)
        {
            _innerContent = httpContent;
            foreach (System.Collections.Generic.KeyValuePair<string, System.Collections.Generic.IEnumerable<string>> item in _innerContent.Headers)
            {
                Headers.Add(item.Key, item.Value);
            }

            _faultyStream = faultyStream;
        }

        protected override Task<Stream> CreateContentReadStreamAsync() => Task.FromResult(_faultyStream);

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context) => _faultyStream.CopyToAsync(stream);

        protected override bool TryComputeLength(out long length)
        {
            length = _faultyStream.Length;
            return true;
        }
    }
}
