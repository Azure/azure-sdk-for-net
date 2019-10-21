// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure
{
    internal class ResponseDebugView<T>
    {
        private readonly Response<T> _response;

        public ResponseDebugView(Response<T> response)
        {
            _response = response;
        }

        public Response GetRawResponse => _response.GetRawResponse();

        public T Value => _response.Value;
    }
}
