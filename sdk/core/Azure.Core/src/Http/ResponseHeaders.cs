// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Azure.Core.Http
{
    public readonly struct ResponseHeaders : IEnumerable<HttpHeader>
    {
        private readonly Response _response;

        public ResponseHeaders(Response response)
        {
            _response = response;
        }

        public DateTimeOffset? Date =>
            TryGetValue(HttpHeader.Names.Date, out var value) ||
            TryGetValue(HttpHeader.Names.XMsDate, out value) ?
                (DateTimeOffset?)DateTimeOffset.Parse(value, CultureInfo.InvariantCulture) :
                null;

        public string? ContentType => TryGetValue(HttpHeader.Names.ContentType, out var value) ? value : null;

        public string? RequestId => TryGetValue(HttpHeader.Names.XMsRequestId, out var value) ? value : null;

        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return _response.EnumerateHeaders().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _response.EnumerateHeaders().GetEnumerator();
        }

        public bool TryGetValue(string name, [NotNullWhen(true)] out string? value)
        {
            return _response.TryGetHeader(name, out value);
        }

        public bool TryGetValues(string name, out IEnumerable<string> values)
        {
            return _response.TryGetHeaderValues(name, out values);
        }

        public bool Contains(string name)
        {
            return _response.ContainsHeader(name);
        }
    }
}
