// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure
{
    public readonly struct Response<T> : IDisposable
    {
        public Response(Response response, T parsed)
        {
            Raw = response;
            Value = parsed;
        }

        public Response Raw { get; }

        public T Value { get; }

        public static implicit operator T(Response<T> response) => response.Value;

        public void Dispose()
        {
            Raw.Dispose();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
