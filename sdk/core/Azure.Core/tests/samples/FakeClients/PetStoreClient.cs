// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Core.Samples.FakeClients
{
    internal class PetStoreClient
    {
        public PetStoreClient(Uri endpoint, TokenCredential credential, PetStoreClientOptions options)
        {
        }

        // Request: "id" in the context path, like "/pets/{id}"
        // Response: {
        //      "name": "snoopy",
        //      "species": "beagle"
        // }
        public Response GetPet(string id, RequestContext context = null)
        {
            throw new NotImplementedException();
        }

        // Request: {
        //      "name": "snoopy",
        //      "species": "beagle"
        // }
        // Response: {
        //      "name": "snoopy",
        //      "species": "beagle"
        // }
        public Response SetPet(RequestContent requestBody, RequestContext context = null)
        {
            throw new NotImplementedException();
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class PetStoreClientOptions : ClientOptions
#pragma warning restore SA1402 // File may only contain a single type
    {
    }
}
