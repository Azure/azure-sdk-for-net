// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure
{
    public readonly struct Response<T>: IDisposable
    {
        private readonly Response _rawResponse;

        public Response(Response response, T parsed)
        {
            _rawResponse = response;
            Value = parsed;
        }

        public Response GetRawResponse() => _rawResponse;

        public T Value { get; }

        public static implicit operator T(Response<T> response) => response.Value;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        public void Dispose()
        {
            GetRawResponse()?.Dispose();
        }
    }
}
