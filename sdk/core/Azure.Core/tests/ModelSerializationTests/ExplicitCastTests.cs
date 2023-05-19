// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.ModelSerializationTests
{
    public class ExplicitCastTests
    {
        [Test]
        public void CastFromResponse()
        {
            string serviceResponse = "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse));
            stream.Position = 0;
            Response response = new MockResponse(200);
            response.ContentStream = stream;
            DogListProperty dog = (DogListProperty)response;

            Assert.AreEqual("Doggo", dog.Name);
            Assert.AreEqual(false, dog.IsHungry);
            Assert.AreEqual(1.1, dog.Weight);
            Assert.AreEqual(new List<string> { "kibble", "egg", "peanut butter" }, dog.FoodConsumed);
            Assert.AreEqual("Animalia", dog.LatinName);

            var additionalProperties = typeof(Animal).GetProperty("RawData", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(dog) as Dictionary<string, BinaryData>;
            Assert.IsNotNull(additionalProperties);
            Assert.IsTrue(additionalProperties.ContainsKey("numberOfLegs"));
            Assert.AreEqual("4", additionalProperties["numberOfLegs"].ToString());

#if NETFRAMEWORK
            string requestContent = "{\"latinName\":\"Animalia\",\"name\":\"Doggo\",\"isHungry\":false,\"weight\":1.1000000000000001,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";
#else
            string requestContent = "{\"latinName\":\"Animalia\",\"name\":\"Doggo\",\"isHungry\":false,\"weight\":1.1,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";
#endif

            RequestContent content = (RequestContent)dog;
            var requestStream = new MemoryStream();
            content.WriteTo(requestStream, default);
            requestStream.Position = 0;
            string contentString = new StreamReader(requestStream).ReadToEnd();
            Assert.AreEqual(requestContent, contentString);
        }

        [Test]
        public void CastToRequestContent()
        {
#if NETFRAMEWORK
            string requestContent = "{\"latinName\":\"Animalia\",\"name\":\"Doggo\",\"isHungry\":false,\"weight\":1.1000000000000001,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]}";
#else
            string requestContent = "{\"latinName\":\"Animalia\",\"name\":\"Doggo\",\"isHungry\":false,\"weight\":1.1,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"]}";
#endif
            var dog = new DogListProperty
            {
                Name = "Doggo",
                IsHungry = false,
                Weight = 1.1,
                FoodConsumed = { "kibble", "egg", "peanut butter" },
            };
            RequestContent content = (RequestContent)dog;
            var stream = new MemoryStream();
            content.WriteTo(stream, default);
            stream.Position = 0;
            string contentString = new StreamReader(stream).ReadToEnd();
            Assert.AreEqual(requestContent, contentString);
        }
    }
}
