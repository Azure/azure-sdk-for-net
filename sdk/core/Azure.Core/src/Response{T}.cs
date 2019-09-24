// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure
{
    public class Response<T>
    {
        private readonly Response _rawResponse;

        public Response(Response response, T parsed)
        {
            _rawResponse = response;
            Value = parsed;
        }

        public virtual Response GetRawResponse() => _rawResponse;

        public virtual T Value { get; }

        public static implicit operator T(Response<T> response) => response.Value;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
