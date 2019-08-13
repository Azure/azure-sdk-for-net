// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Http
{
    public readonly struct RequestHeaders: IEnumerable<HttpHeader>
    {
        private readonly Request _request;

        public RequestHeaders(Request request)
        {
            _request = request;
        }

        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return _request.EnumerateHeaders().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _request.EnumerateHeaders().GetEnumerator();
        }

        public void Add(HttpHeader header)
        {
            _request.AddHeader(header.Name, header.Value);
        }

        public void Add(string name, string value)
        {
            _request.AddHeader(name, value);
        }

        public bool TryGetValue(string name, [NotNullWhen(true)] out string? value)
        {
            return _request.TryGetHeader(name, out value);
        }

        public bool TryGetValues(string name, out IEnumerable<string> values)
        {
            return _request.TryGetHeaderValues(name, out values);
        }

        public bool Contains(string name)
        {
            return _request.ContainsHeader(name);
        }

        public void SetValue(string name, string value)
        {
            _request.SetHeader(name, value);
        }

        public bool Remove(string name)
        {
            return _request.RemoveHeader(name);
        }
    }
}
