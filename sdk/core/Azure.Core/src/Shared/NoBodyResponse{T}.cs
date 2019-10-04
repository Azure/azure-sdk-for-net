// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    internal class NoBodyResponse<T> : Response<T>
    {
        private readonly Response _response;

        public NoBodyResponse(Response response)
        {
            _response = response;
        }

        public override T Value
        {
            get
            {
                throw new ResponseBodyNotFoundException(_response.Status, _response.ReasonPhrase);
            }
        }

        public override Response GetRawResponse() => _response;
    }
}
