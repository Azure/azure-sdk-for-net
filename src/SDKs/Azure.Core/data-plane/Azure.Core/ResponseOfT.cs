// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure
{
    public struct Response<T> : IDisposable
    {
        Response _response;
        Func<Response, T> _contentParser;
        T _value;

        public Response(Response response)
        {
            _response = response;
            _contentParser = null;
            _value = default;
        }

        public Response(Response response, Func<Response, T> parser)
        {
            _response = response;
            _contentParser = parser;
            _value = default;
        }

        public Response(Response response, T parsed)
        {
            _response = response;
            _contentParser = null;
            _value = parsed;
        }

        public void Deconstruct(out T value, out Response response)
        {
            value = Value;
            response = _response;
        }

        public static implicit operator T(Response<T> response)
            => response.Value;


        public T Value
        {
            get {
                if (_contentParser != null) {
                    _value = _contentParser(_response);
                    _contentParser = null;
                }
                return _value;
            }
        }

        public int Status => _response.Status;

        public void Dispose()
        {
            _response.Dispose();
            _contentParser = default;
        }

        public bool TryGetHeader(string name, out string values)
        {
            return _response.TryGetHeader(name, out values);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
