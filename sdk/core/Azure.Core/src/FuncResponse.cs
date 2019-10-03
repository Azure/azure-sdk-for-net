// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    internal class FuncResponse<T> : Response<T>
    {
        private readonly Response _response;
        private readonly Func<T> _func;

        public FuncResponse(Response response, Func<T> func)
        {
            _response = response;
            _func = func;
        }

        public override T Value { get { return _func(); } }

        public override Response GetRawResponse() => _response;
    }
}
