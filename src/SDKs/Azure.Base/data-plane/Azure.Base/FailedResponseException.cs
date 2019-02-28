// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public class RequestFailedException : Exception
    {
        Response _response;
        string _reason;

        public RequestFailedException(Response response, string reason = null)
        {
            _response = response;
            _reason = reason;
        }

        public Response Response => _response; 
    }
}
