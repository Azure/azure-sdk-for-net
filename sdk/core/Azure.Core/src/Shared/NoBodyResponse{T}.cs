// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#if BlobSDK || QueueSDK || FileSDK
namespace Azure.Storage.Shared
#elif StorageSDK
namespace Azure.Storage.Shared.Common
#else
namespace Azure
#endif
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

        public override string ToString()
        {
            return $"Status: {GetRawResponse().Status}, Service returned no content";
        }

#pragma warning disable CA1064 // Exceptions should be public
        private class ResponseBodyNotFoundException : Exception
#pragma warning restore CA1064 // Exceptions should be public
        {
            public int Status { get; }

            public ResponseBodyNotFoundException(int status, string message)
                : base(message)
            {
                Status = status;
            }
        }
    }
}
