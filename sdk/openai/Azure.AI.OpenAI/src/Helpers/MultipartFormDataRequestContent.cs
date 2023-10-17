// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.OpenAI
{
    internal sealed class MultipartFormDataRequestContent : RequestContent
    {
        public string Boundary { get; }
        private MultipartFormDataContent _baseContent { get; }

        public MultipartFormDataRequestContent() : base()
        {
            Boundary = Guid.NewGuid().ToString();
            _baseContent = new MultipartFormDataContent(Boundary);
        }

        public void Add(HttpContent content) => _baseContent.Add(content);

        public void Add(HttpContent content, string name) => _baseContent.Add(content, name);

        public void Add(HttpContent content, string name, string fileName)
            => _baseContent.Add(content, name, fileName);

        public override void Dispose()
        {
            _baseContent.Dispose();
        }

        public override bool TryComputeLength(out long length)
        {
            // Open: more appropriate calculation mechanism
            using var temporaryStream = new MemoryStream();
            _baseContent.CopyToAsync(temporaryStream).Wait();
            length = temporaryStream.Length;
            return true;
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            WriteToAsync(stream, cancellation).Wait(cancellation);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
            => await _baseContent.CopyToAsync(stream).AwaitWithCancellation(cancellation);
    }
}
