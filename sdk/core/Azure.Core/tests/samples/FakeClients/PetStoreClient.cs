// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using Azure.Core.TestFramework;

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
        public Response SetPet(RequestContent content, RequestContext context = null)
        {
            using MemoryStream stream = new();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;

            MockResponse response = new(200);
            response.SetContent(BinaryData.FromStream(stream).ToArray());

            return response;
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class PetStoreClientOptions : ClientOptions
#pragma warning restore SA1402 // File may only contain a single type
    {
    }
}
