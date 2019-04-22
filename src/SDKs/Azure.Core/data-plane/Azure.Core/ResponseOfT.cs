// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure
{
    public readonly struct Response<T> : IDisposable
    {
        private readonly Response _response;

        public Response(Response response, T parsed)
        {
            _response = response;
            Value = parsed;
        }

        public void Deconstruct(out T value, out Response response)
        {
            value = Value;
            response = _response;
        }

        public static implicit operator T(Response<T> response) => response.Value;

        public T Value { get; }

        public int Status => _response.Status;

        public void Dispose()
        {
            _response.Dispose();
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
