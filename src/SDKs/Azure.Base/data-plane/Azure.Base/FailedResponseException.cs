// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using System;

namespace Azure
{
    public class ResponseFailedException : Exception
    {
        Response _response;
        string _reason;

        public ResponseFailedException(Response response, string reason = null)
        {
            _response = response;
            _reason = reason;
        }

        public Response Response => _response; 
    }
}
