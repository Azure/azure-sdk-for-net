// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Experimental.Tests;
using Azure.Core.TestFramework;
using Azure.Core.Tests.ModelSerializationTests;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class SerializationSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void TrySerialize()
        {
            #region Snippet:Try_Serialize
            //TODO
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void TryDeserialize()
        {
            #region Snippet:Try_Deserialize
            //TODO
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NonTrySerialize()
        {
            #region Snippet:NonTry_Serialize
            //TODO
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void NonTryDeserialize()
        {
            #region Snippet:NonTry_Deserialize
            //TODO
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ExplicitCastSerialize()
        {
            #region Snippet:ExplicitCast_Serialize
            PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
            DogListProperty dog = new DogListProperty("myPet");
            Response response = client.CreatePet("myPet", (RequestContent)dog);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void ExplicitCastDeserialize()
        {
            #region Snippet:ExplicitCast_Deserialize
            PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
            Response response = client.GetPet("myPet");
            DogListProperty dog = (DogListProperty)response;
            Console.WriteLine(dog.IsHungry);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StjSerialize()
        {
            #region Snippet:Stj_Serialize
            //TODO
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StjDeserialize()
        {
            #region Snippet:Stj_Deserialize
            //TODO
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void StaticDeserialize()
        {
            #region Snippet:Static_Deserialize
            using Stream stream = new MemoryStream();
            SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = false, IgnoreAdditionalProperties = false };
            string serviceResponse =
                "{\"latinName\":\"Animalia\",\"weight\":2.3,\"name\":\"Rabbit\",\"isHungry\":false,\"numberOfLegs\":4}";

            Animal model = Animal.StaticDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
            #endregion
        }
    }
}
