// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Samples.FakeClients;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class ProtocolMethodSamples
    {
        [Test]
        public void SetWithAnonymousType()
        {
            PetStoreClient client = new(new Uri("https://example.azure.com"), new MockCredential(), new PetStoreClientOptions());
            #region Snippet:AzureCoreSetWithAnonymousType
            // anonymous class is serialized by System.Text.Json using runtime reflection
            var data = new
            {
                Name = "snoopy",
                Species = "beagle"
            };
            /*
            {
                "name": "snoopy",
                "species": "beagle"
            }
            */
            client.SetPet(RequestContent.Create(data, PropertyNameHandling.ToCamelCase));
            #endregion
        }
    }
}
