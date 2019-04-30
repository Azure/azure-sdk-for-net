// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using Azure.Core.Pipeline;

namespace Azure
{
    public readonly struct ResponseHeaders: IEnumerable<HttpHeader>
    {
        private readonly Response _response;

        public ResponseHeaders(Response response)
        {
            _response = response;
        }

        public IEnumerator<HttpHeader> GetEnumerator()
        {
            return _response.EnumerateHeaders().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _response.EnumerateHeaders().GetEnumerator();
        }

        public bool TryGetValue(string name, out string value)
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
