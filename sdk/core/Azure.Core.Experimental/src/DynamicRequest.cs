// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Represents an HTTP request with <see cref="DynamicJson"/> content.
    /// </summary>
    [DebuggerDisplay("Body: {Body}")]
    public class DynamicRequest : Request
    {
        private Request Request { get; }
        private HttpPipeline HttpPipeline { get; }
        private bool _disposed;

        private static readonly Encoding Utf8NoBom = new UTF8Encoding(false, true);

        /// <inheritdoc />
        public override RequestContent? Content
        {
            get => DynamicContent.Create(Body);

            set {
                MemoryStream ms = new MemoryStream();
                if (value != null)
                {
                    value.WriteTo(ms, default);
                    ms.Seek(0, SeekOrigin.Begin);
                }
                using (StreamReader sr = new StreamReader(ms, Utf8NoBom))
                {
                    Body = new DynamicJson(sr.ReadToEnd());
                }
                Request.Content = value;
            }
        }

        // TODO(matell): How does the initialization here play into the ability to send a request with an "empty" body?
        /// <summary>
        /// The JSON body of request.
        /// </summary>
        public DynamicJson Body { get; set; } = DynamicJson.Object();

        // TODO(matell): In Krzysztof's prototype we also took DiagnosticScope as a parameter, do we still need that?
        /// <summary>
        /// Creates an instance of <see cref="RequestContent"/> that wraps <see cref="DynamicJson"/> content.
        /// </summary>
        /// <param name="request">The <see cref="Request"/> to send.</param>
        /// <param name="pipeline">The HTTP pipeline for sending and receiving REST requests and responses.</param>
        public DynamicRequest(Request request, HttpPipeline pipeline)
        {
            Request = request;
            HttpPipeline = pipeline;
        }

        /// <summary>
        /// Send the request asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response dynamically typed in a <see cref="DynamicResponse"/>.</returns>
        public async Task<DynamicResponse> SendAsync(CancellationToken cancellationToken = default)
        {
            // Since we are sending the underlying request, we need to copy the Content on to it, or we'll lose the body.
            Request.Content = Content;

            Response res = await HttpPipeline.SendRequestAsync(Request, cancellationToken).ConfigureAwait(false);
            DynamicJson? dynamicContent = null;

            if (res.ContentStream != null)
            {
                JsonDocument doc = await JsonDocument.ParseAsync(res.ContentStream, new JsonDocumentOptions(), cancellationToken).ConfigureAwait(false);
                dynamicContent = new DynamicJson(doc.RootElement);
            }

            return new DynamicResponse(res, dynamicContent);
        }

        /// <summary>
        /// Send the request synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response dynamically typed in a <see cref="DynamicResponse"/>.</returns>
        public DynamicResponse Send(CancellationToken cancellationToken = default)
        {
            // Since we are sending the underlying request, we need to copy the Content on to it, or we'll lose the body.
            Request.Content = Content;

            Response res = HttpPipeline.SendRequest(Request, cancellationToken);
            DynamicJson? dynamicContent = null;

            if (res.ContentStream != null)
            {
                JsonDocument doc = JsonDocument.Parse(res.ContentStream);
                dynamicContent = new DynamicJson(doc.RootElement);
            }

            return new DynamicResponse(res, dynamicContent);
        }

        /// <inheritdoc />
        public override string ClientRequestId { get => Request.ClientRequestId; set => Request.ClientRequestId = value; }

        /// <summary>
        /// Frees resources held by the <see cref="DynamicRequest"/> object.
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Frees resources held by the <see cref="DynamicRequest"/> object.
        /// </summary>
        /// <param name="disposing">true if we should dispose, otherwise false</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                Request.Dispose();
            }
            _disposed = true;
        }

        /// <inheritdoc />
        protected override void AddHeader(string name, string value) => Request.Headers.Add(name, value);

        /// <inheritdoc />
        protected override bool ContainsHeader(string name) => Request.Headers.Contains(name);

        /// <inheritdoc />
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => Request.Headers;

        /// <inheritdoc />
        protected override bool RemoveHeader(string name) => Request.Headers.Remove(name);

        /// <inheritdoc />
        protected override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value) => Request.Headers.TryGetValue(name, out value);

        /// <inheritdoc />
        protected override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values) => Request.Headers.TryGetValues(name, out values);
    }
}
