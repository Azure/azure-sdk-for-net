// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.ServiceModel.Rest.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Adapter class to enable setting Request.Content to RequestBody values.
    /// </summary>
    public sealed class RequestBodyContent : RequestContent
    {
        private readonly RequestBody _body;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBodyContent"/> class.
        /// </summary>
        /// <param name="body"></param>
        public RequestBodyContent(RequestBody body)
        {
            _body = body;
        }

        /// <inheritdoc/>
        public override void Dispose() => _body.Dispose();

        /// <inheritdoc/>
        public override bool TryComputeLength(out long length) => _body.TryComputeLength(out length);

        /// <inheritdoc/>
        public override void WriteTo(Stream stream, CancellationToken cancellation) => _body.WriteTo(stream, cancellation);

        /// <inheritdoc/>
        public override Task WriteToAsync(Stream stream, CancellationToken cancellation) => _body.WriteToAsync(stream, cancellation);
    }
}
