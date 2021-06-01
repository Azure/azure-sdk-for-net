// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#nullable disable

namespace Azure.Core
{
    /// <summary>
    /// A Response that can be constructed in memory without being tied to a
    /// live request.
    /// </summary>
    internal class MemoryResponse : Response
    {
        private const int NoStatusCode = 0;
        private const string XmsClientRequestIdName = "x-ms-client-request-id";

        /// <summary>
        /// The Response <see cref="Status"/>.
        /// </summary>
        private int _status = NoStatusCode;

        /// <summary>
        /// The Response <see cref="ReasonPhrase"/>.
        /// </summary>
        private string _reasonPhrase;

        /// <summary>
        /// The <see cref="Response.Headers"/>.
        /// </summary>
        private readonly IDictionary<string, List<string>> _headers =
            new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        /// <inheritdoc />
        public override int Status => _status;

        /// <inheritdoc />
        public override string ReasonPhrase => _reasonPhrase;

        /// <inheritdoc />
        public override Stream ContentStream { get; set; }

        /// <inheritdoc />
        public override string ClientRequestId
        {
            get => TryGetHeader(XmsClientRequestIdName, out string id) ? id : null;
            set => SetHeader(XmsClientRequestIdName, value);
        }

        /// <summary>
        /// Set the Response <see cref="Status"/>.
        /// </summary>
        /// <param name="status">The Response status.</param>
        public void SetStatus(int status) => _status = status;

        /// <summary>
        /// Set the Response <see cref="ReasonPhrase"/>.
        /// </summary>
        /// <param name="reasonPhrase">The Response ReasonPhrase.</param>
        public void SetReasonPhrase(string reasonPhrase) => _reasonPhrase = reasonPhrase;

        /// <summary>
        /// Set the Response <see cref="ContentStream"/>.
        /// </summary>
        /// <param name="content">The response content.</param>
        public void SetContent(byte[] content) => ContentStream = new MemoryStream(content);

        /// <summary>
        /// Set the Response <see cref="ContentStream"/>.
        /// </summary>
        /// <param name="content">The response content.</param>
        public void SetContent(string content) => SetContent(Encoding.UTF8.GetBytes(content));

        /// <summary>
        /// Dispose the Response.
        /// </summary>
        public override void Dispose() => ContentStream?.Dispose();

        /// <summary>
        /// Set the value of a response header (and overwrite any existing
        /// values).
        /// </summary>
        /// <param name="name">The name of the response header.</param>
        /// <param name="value">The response header value.</param>
        public void SetHeader(string name, string value) =>
            SetHeader(name, new List<string> { value });

        /// <summary>
        /// Set the values of a response header (and overwrite any existing
        /// values).
        /// </summary>
        /// <param name="name">The name of the response header.</param>
        /// <param name="values">The response header values.</param>
        public void SetHeader(string name, IEnumerable<string> values) =>
            _headers[name] = values.ToList();

        /// <summary>
        /// Add a response header value.
        /// </summary>
        /// <param name="name">The name of the response header.</param>
        /// <param name="value">The response header value.</param>
        public void AddHeader(string name, string value)
        {
            if (!_headers.TryGetValue(name, out List<string> values))
            {
                _headers[name] = values = new List<string>();
            }
            values.Add(value);
        }

        /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool ContainsHeader(string name) =>
            _headers.ContainsKey(name);

        /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override IEnumerable<HttpHeader> EnumerateHeaders() =>
            _headers.Select(header => new HttpHeader(header.Key, JoinHeaderValues(header.Value)));

        /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool TryGetHeader(string name, out string value)
        {
            if (_headers.TryGetValue(name, out List<string> headers))
            {
                value = JoinHeaderValues(headers);
                return true;
            }
            value = null;
            return false;
        }

        /// <inheritdoc />
#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
        {
            bool found = _headers.TryGetValue(name, out List<string> headers);
            values = headers;
            return found;
        }

        /// <summary>
        /// Join multiple header values together with a comma.
        /// </summary>
        /// <param name="values">The header values.</param>
        /// <returns>A single joined value.</returns>
        private static string JoinHeaderValues(IEnumerable<string> values) =>
            string.Join(",", values);
    }
}
