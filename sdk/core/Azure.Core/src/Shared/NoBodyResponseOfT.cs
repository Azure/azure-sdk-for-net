// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
#pragma warning disable SA1649 // File name should match first type name
    internal class NoBodyResponse<T> : Response<T>
#pragma warning restore SA1649 // File name should match first type name
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
